using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models;

public class CheckUpViewModel
{
    [Key]
    public Guid CheckUpId { get; set; }
    public string Doctor { get; set; }
    public Guid PatientId { get; set; }
    [DataType(DataType.Date)]
    public DateTime IssueDate { get; set; }
    [MaxLength(100)]
    [DataType(DataType.MultilineText)]
    public string Noted { get; set; }
}
