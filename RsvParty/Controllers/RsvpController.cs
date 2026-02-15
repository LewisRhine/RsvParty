using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RsvParty.Data;
using RsvParty.Models;

namespace RsvParty.Controllers;

[ApiController]
[Route("[controller]")]
public class RsvpController(RsvpContext context) : ControllerBase
{
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Rsvp>>> GetAll()
    // {
    //     return await context.Rsvps.ToListAsync();
    // }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Rsvp>> Get(Guid id)
    {
        var post = await context.Rsvps.FindAsync(id);
        return post == null ? NotFound() : post;
    }
    
    [HttpGet("attendingcount")]
    public async Task<ActionResult<Dictionary<string,int>>> GetAttendingCount()
    {
        var total = await context.Rsvps.Where(r => r.NumberInParty > 0).SumAsync(r => (int?)r.NumberInParty) ?? 0;
        return Ok(new Dictionary<string,int> { ["Number of Attendees"] = total });
    }

    [HttpPost]
    public async Task<ActionResult<Rsvp>> Create(RsvpBody rsvp)
    {
        var newRsvp = new Rsvp
        {
            Name = rsvp.Name,
            NumberInParty = rsvp.NumberInParty,
            MoveGuess = rsvp.MoveGuess,
            Email = rsvp.Email,
            GetReminder = rsvp.GetReminder,
            GetUpdates = rsvp.GetUpdates
        };
        context.Rsvps.Add(newRsvp);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = newRsvp.Id }, rsvp);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, Rsvp rsvp)
    {
        if (id != rsvp.Id) return BadRequest();
        context.Entry(rsvp).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var rsvp = await context.Rsvps.FindAsync(id);
        if (rsvp == null) return NotFound();
        context.Rsvps.Remove(rsvp);
        await context.SaveChangesAsync();
        return NoContent();
    }
}