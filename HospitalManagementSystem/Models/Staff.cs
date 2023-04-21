using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models;

public class Staff
{
	[Key]
	public Guid StaffId { get; set; }
	[ForeignKey("Position")]
	public Guid PositionId { get; set; }
	[Required]
	[MaxLength(50)]
	[Display(Name ="Staff Name")]
	public string StaffName { get; set; }
	[Required]
	[MaxLength(10)]
	public string Gender { get; set; }
	[MaxLength(50)]
	[Phone]
	public string PhoneNumber { get; set; }
	[MaxLength(500)]
	[DataType(DataType.MultilineText)]
	public string Address { get; set; }
	[MaxLength(50)]
	[EmailAddress]
	public string Email { get; set; }

	public Position Position { get; set; }
}

