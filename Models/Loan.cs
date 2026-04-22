using System;
using System.ComponentModel.DataAnnotations;
namespace TSD2491_oblig1_031688.Models;

public class Loan
{
    public int Id { get; set; }

    [DataType(DataType.Date)]
    public DateTime LoanDate { get; set; }

    // Foreign keys
    public int DeviceId { get; set; }
    public Device? Device { get; set; }

    public int StudentId { get; set; }
    public Student? Student { get; set; }
}
