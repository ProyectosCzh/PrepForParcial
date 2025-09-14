using Microsoft.EntityFrameworkCore;
using ProductivityTrackerAPI.Models;

namespace ProductivityTrackerAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TaskItem> Tasks { get; set; } = null!;
    public DbSet<TimeBlock> TimeBlocks { get; set; } = null!;
    public DbSet<Goal> Goals { get; set; } = null!;
    public DbSet<Distraction> Distractions { get; set; } = null!;
}