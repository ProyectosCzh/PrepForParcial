using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductivityTrackerAPI.Models;

[Table("goals")]
public class Goal
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
    public DateTime TargetDate { get; set; }

    [Required, StringLength(64)]
    public string Progress { get; set; } = null!;

    public bool Completed { get; set; }
}