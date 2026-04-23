using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSD2491_oblig1_031688.Data;
using TSD2491_oblig1_031688.Models;

namespace TSD2491_oblig1_031688.Controllers
{
    public class LoansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Loans.Include(l => l.Device).Include(l => l.Student);
            return View(await applicationDbContext.ToListAsync());
        }


        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(
                _context.Devices
                    .Where(d => d.IsAvailable == true)
                    .Select(d => new 
                    {
                        d.Id,
                        Display = d.Name + " (" + d.DeviceType + ")"
                    }),
                "Id",
                "Display"
            );

            ViewData["StudentId"] = new SelectList(
                _context.Students
                    .Where(s => s.HasActiveLoan == false)
                    .Select(s => new 
                    {
                        s.Id,
                        Display = s.FirstName + " " + s.LastName
                    }),
                "Id",
                "Display"
            );

            return View();
        }

        // POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LoanDate,DeviceId,StudentId")] Loan loan)
        {
            // Hent device og student
            var device = await _context.Devices.FindAsync(loan.DeviceId);
            var student = await _context.Students.FindAsync(loan.StudentId);

            // --- FORRETNINGSREGLER (4d) ---

            // Regel 1: Enheten må være tilgjengelig
            if (device == null || device.IsAvailable == false)
            {
                ModelState.AddModelError("DeviceId", "Denne enheten er ikke tilgjengelig for utlån.");
            }

            // Regel 2: Studenten kan ikke ha aktivt lån
            if (student == null || student.HasActiveLoan == true)
            {
                ModelState.AddModelError("StudentId", "Denne studenten har allerede et aktivt lån.");
            }

            // Hvis noen regler feiler → vis feilmelding og stopp
            if (!ModelState.IsValid)
            {
                // Fyll dropdowns på nytt
                ViewData["DeviceId"] = new SelectList(
                    _context.Devices
                        .Where(d => d.IsAvailable == true)
                        .Select(d => new
                        {
                            d.Id,
                            Display = d.Name + " (" + d.DeviceType + ")"
                        }),
                    "Id",
                    "Display",
                    loan.DeviceId
                );

                ViewData["StudentId"] = new SelectList(
                    _context.Students
                        .Where(s => s.HasActiveLoan == false)
                        .Select(s => new
                        {
                            s.Id,
                            Display = s.FirstName + " " + s.LastName
                        }),
                    "Id",
                    "Display",
                    loan.StudentId
                );

                return View(loan);
            }

            // --- HVIS ALT ER OK → OPPRETT LÅN (4c) ---

            _context.Add(loan);

            device.IsAvailable = false;
            student.HasActiveLoan = true;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loans
                .Include(l => l.Device)
                .Include(l => l.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loan == null)
            {
                return NotFound();
            }

            return View(loan);
        }


        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loan = await _context.Loans.FindAsync(id);

            if (loan != null)
            {
                // Hent device og student
                var device = await _context.Devices.FindAsync(loan.DeviceId);
                var student = await _context.Students.FindAsync(loan.StudentId);

                // Sett status tilbake
                if (device != null)
                    device.IsAvailable = true;

                if (student != null)
                    student.HasActiveLoan = false;

                // Fjern lånet
                _context.Loans.Remove(loan);

                // Lagre alt
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }



        private bool LoanExists(int id)
        {
            return _context.Loans.Any(e => e.Id == id);
        }

    }
}
