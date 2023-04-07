using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models;

public class Patient
{
    [Key]
    public Guid PatientId { get; set; }
    [Required]
    [MaxLength(50)]
    public string PatientName { get; set; }
    [Required]
    [MaxLength(50)]
    public string Gender { get; set; }
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }
    [MaxLength(20)]
    [Phone]
    public string PhoneNumber { get; set; }
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; }
    [MaxLength(100)]
    [DataType(DataType.MultilineText)]
    public string Address { get; set; }
}
