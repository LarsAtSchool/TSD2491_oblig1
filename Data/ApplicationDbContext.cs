using Microsoft.EntityFrameworkCore;
using TSD2491_oblig1_031688.Models;

namespace TSD2491_oblig1_031688.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Device> Devices { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Loan> Loans { get; set; }
}
