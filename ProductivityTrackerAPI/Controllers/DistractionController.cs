using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductivityTrackerAPI.Data;
using ProductivityTrackerAPI.Models;

namespace ProductivityTrackerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DistractionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public DistractionsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/distractions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Distraction>>> GetDistractions()
    {
        return await _context.Distractions.ToListAsync();
    }

    // GET: api/distractions/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Distraction>> GetDistraction(int id)
    {
        var distraction = await _context.Distractions.FindAsync(id);
        if (distraction == null) return NotFound();

        return distraction;
    }

    // POST: api/distractions
    [HttpPost]
    public async Task<ActionResult<Distraction>> PostDistraction(Distraction distraction)
    {
        _context.Distractions.Add(distraction);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDistraction), new { id = distraction.Id }, distraction);
    }

    // PUT: api/distractions/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDistraction(int id, Distraction distraction)
    {
        if (id != distraction.Id) return BadRequest();

        _context.Entry(distraction).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Distractions.Any(e => e.Id == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    // DELETE: api/distractions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDistraction(int id)
    {
        var distraction = await _context.Distractions.FindAsync(id);
        if (distraction == null) return NotFound();

        _context.Distractions.Remove(distraction);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
