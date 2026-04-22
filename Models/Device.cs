using System.ComponentModel.DataAnnotations;
namespace TSD2491_oblig1_031688.Models;

public class Device
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    public string? DeviceType { get; set; }
    public string? ModelName { get; set; }
    public string? Specifications { get; set; }

    public bool IsAvailable { get; set; } = true;

    // Navigation property (optional)
    //public Loan Loan { get; set; }
}
