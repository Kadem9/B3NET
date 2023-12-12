using Microsoft.AspNetCore.Mvc;
using BookStoreAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class AchatController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AchatController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Achat>> CreateAchat(Achat achat)
    {
        _context.Achats.Add(achat);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetAchat", new { id = achat.Id }, achat);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Achat>>> GetAchats()
    {
        return await _context.Achats.ToListAsync();
    }


}
