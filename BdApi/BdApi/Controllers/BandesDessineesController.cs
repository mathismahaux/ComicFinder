using BdApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BdApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BandesDessineesController : ControllerBase
{
    private readonly BandesDessineesContext _context;

    public BandesDessineesController(BandesDessineesContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BandesDessinees>>> GetBandesDessinees()
    {
        return await _context.BandesDessinees.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BandesDessinees>> GetBandesDessinees(int id)
    {
        var bd = await _context.BandesDessinees.FindAsync(id);

        if (bd == null)
        {
            return NotFound();
        }

        return bd;
    }

    [HttpPost]
    public async Task<ActionResult<BandesDessinees>> PostBandesDessinees(BandesDessinees bandesDessinees)
    {
        _context.BandesDessinees.Add(bandesDessinees);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBandesDessinees), new { id = bandesDessinees.Id }, bandesDessinees);
    }
}