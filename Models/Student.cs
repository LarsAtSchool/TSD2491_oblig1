using System.ComponentModel.DataAnnotations;
namespace TSD2491_oblig1_031688.Models;

public class Student
{
    public int Id { get; set; }

    [Required]
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? StudentNumber { get; set; }

    public bool HasActiveLoan { get; set; } = false;

    // Navigation property (optional)
    //public Loan Loan { get; set; }
}
