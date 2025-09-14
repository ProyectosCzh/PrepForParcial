using Microsoft.EntityFrameworkCore;
using ProductivityTrackerAPI.Models;

namespace ProductivityTrackerAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TaskItem> Tasks { get; set; }
    // Cuando otro integrante cree su entidad, se agrega aquí su DbSet
}