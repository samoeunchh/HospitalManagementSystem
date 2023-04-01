using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models;

public class Room
{
    [Key]
    public Guid RoomId { get; set; }
    [Required]
    [MaxLength(10)]
    public string RoomNumber { get; set; }
}
