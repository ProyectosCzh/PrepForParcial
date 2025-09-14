using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductivityTrackerAPI.Models;

[Table("distractions")]
public class Distraction
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(64)]
    public string User { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime Date { get; set; }

    [Required, StringLength(500)]
    public string Description { get; set; } = null!;

    public int DurationMinutes { get; set; }

    [Required, StringLength(64)]
    public string Category { get; set; } = null!;
}