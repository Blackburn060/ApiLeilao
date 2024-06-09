using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class VendedoresController : ControllerBase
{
    private readonly AuctionContext _context;

    public VendedoresController(AuctionContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Seller>>> GetVendedores()
    {
        return await _context.Vendedores.Include(s => s.Itens).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Seller>> GetVendedor(int id)
    {
        var vendedor = await _context.Vendedores.Include(s => s.Itens).FirstOrDefaultAsync(s => s.Id == id);
        if (vendedor == null)
        {
            return NotFound();
        }
        return vendedor;
    }

    [HttpPost]
    public async Task<ActionResult<Seller>> CreateVendedor(Seller vendedor)
    {
        _context.Vendedores.Add(vendedor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetVendedor), new { id = vendedor.Id }, vendedor);
    }
}
