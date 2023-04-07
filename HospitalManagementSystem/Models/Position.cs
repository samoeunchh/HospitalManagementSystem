using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models;

public class Position
{
    [Key]
    public Guid PositionId { get; set; }
    [Required]
    [MaxLength(50)]
    public string PositionName { get; set; }
    [MaxLength(100)]
    public string Description { get; set; }
}
