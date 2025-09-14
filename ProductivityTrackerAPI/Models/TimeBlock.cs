using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductivityTrackerAPI.Models;

[Table("time_blocks")]
public class TimeBlock
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(64)]
    public string User { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    [Required, StringLength(64)]
    public string ActivityType { get; set; } = null!;

    [Required, StringLength(64)]
    public string FocusLevel { get; set; } = null!;
}