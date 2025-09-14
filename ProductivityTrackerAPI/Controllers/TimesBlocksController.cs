using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductivityTrackerAPI.Data;
using ProductivityTrackerAPI.Models;

namespace ProductivityTrackerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeBlocksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TimeBlocksController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/timeblocks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TimeBlock>>> GetTimeBlocks()
    {
        return await _context.TimeBlocks.ToListAsync();
    }

    // GET: api/timeblocks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TimeBlock>> GetTimeBlock(int id)
    {
        var timeBlock = await _context.TimeBlocks.FindAsync(id);
        if (timeBlock == null) return NotFound();

        return timeBlock;
    }

    // POST: api/timeblocks
    [HttpPost]
    public async Task<ActionResult<TimeBlock>> PostTimeBlock(TimeBlock timeBlock)
    {
        _context.TimeBlocks.Add(timeBlock);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTimeBlock), new { id = timeBlock.Id }, timeBlock);
    }

    // PUT: api/timeblocks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTimeBlock(int id, TimeBlock timeBlock)
    {
        if (id != timeBlock.Id) return BadRequest();

        _context.Entry(timeBlock).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TimeBlocks.Any(e => e.Id == id)) return NotFound();
            else throw;
        }

        return NoContent();
    }

    // DELETE: api/timeblocks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTimeBlock(int id)
    {
        var timeBlock = await _context.TimeBlocks.FindAsync(id);
        if (timeBlock == null) return NotFound();

        _context.TimeBlocks.Remove(timeBlock);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
