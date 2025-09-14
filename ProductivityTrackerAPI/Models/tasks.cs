using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductivityTrackerAPI.Models;

[Table("tasks")] // nombre exacto de la tabla
public class TaskItem
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(64)]
    public string User { get; set; } = null!;

    [Required, StringLength(128)]
    public string Title { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DueDate { get; set; }

    public int Priority { get; set; }

    [Required]
    public string Status { get; set; } = "pending"; 
}