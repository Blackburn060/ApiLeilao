using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CompradoresController : ControllerBase
{
    private readonly AuctionContext _context;

    public CompradoresController(AuctionContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Buyer>>> GetCompradores()
    {
        return await _context.Compradores.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Buyer>> GetComprador(int id)
    {
        var comprador = await _context.Compradores.FirstOrDefaultAsync(b => b.Id == id);
        if (comprador == null)
        {
            return NotFound();
        }
        return comprador;
    }

    [HttpPost]
    public async Task<ActionResult<Buyer>> CreateComprador(Buyer comprador)
    {
        _context.Compradores.Add(comprador);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetComprador), new { id = comprador.Id }, comprador);
    }
}
