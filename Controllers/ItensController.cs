using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ItensController : ControllerBase
{
    private readonly AuctionContext _context;

    public ItensController(AuctionContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetItens()
    {
        return await _context.Itens.Include(i => i.Lances).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Item>> CreateItem(Item item)
    {
        _context.Itens.Add(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
        var item = await _context.Itens.Include(i => i.Lances).FirstOrDefaultAsync(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        return item;
    }
}
