using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductivityTrackerAPI.Data;
using ProductivityTrackerAPI.Models;

namespace ProductivityTrackerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GoalsController : ControllerBase
{
    private readonly AppDbContext _context;

    public GoalsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/goals
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Goal>>> GetGoals()
    {
        return await _context.Goals.ToListAsync();
    }

    // GET: api/goals/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Goal>> GetGoal(int id)
    {
        var goal = await _context.Goals.FindAsync(id);
        if (goal == null) return NotFound();

        return goal;
    }

    // POST: api/goals
    [HttpPost]
    public async Task<ActionResult<Goal>> PostGoal(Goal goal)
    {
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGoal), new { id = goal.Id }, goal);
    }

    // PUT: api/goals/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGoal(int id, Goal goal)
    {
        if (id != goal.Id) return BadRequest();

        _context.Entry(goal).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Goals.Any(e => e.Id == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    // DELETE: api/goals/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGoal(int id)
    {
        var goal = await _context.Goals.FindAsync(id);
        if (goal == null) return NotFound();

        _context.Goals.Remove(goal);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}