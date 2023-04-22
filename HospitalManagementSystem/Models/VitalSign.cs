using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models;

public class VitalSign
{
    [Key]
    public Guid VitalSignId { get; set; }
    public Guid PatientId { get; set; }
    public Guid NurseId { get; set; }
    [DataType(DataType.Date)]
    public DateTime IssueDate { get; set; }
    [Required]
    [MaxLength(10)]
    public string Temp { get; set; }
    [Required]
    [MaxLength(10)]
    public string Weight { get; set; }
    [Required]
    [MaxLength(10)]
    public string Heart { get; set; }
    [Required]
    [MaxLength(10)]
    public string BloodPres { get; set; }
    [MaxLength(100)]
    [DataType(DataType.MultilineText)]
    public string Noted { get; set; }
}
