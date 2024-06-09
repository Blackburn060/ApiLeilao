using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class LancesController : ControllerBase
{
    private readonly AuctionContext _context;

    public LancesController(AuctionContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Bid>> PlaceBid(Bid lance)
    {
        var item = await _context.Itens.Include(i => i.Lances).FirstOrDefaultAsync(i => i.Id == lance.ItemId);
        if (item == null)
        {
            return NotFound("Item não encontrado");
        }

        var highestBid = item.Lances.OrderByDescending(b => b.Quantia).FirstOrDefault();
        if (highestBid != null && lance.Quantia <= highestBid.Quantia)
        {
            return BadRequest("A quantia do lance deve ser maior que o lance atual mais alto");
        }

        _context.Lances.Add(lance);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBid), new { id = lance.Id }, lance);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Bid>> GetBid(int id)
    {
        var lance = await _context.Lances.FirstOrDefaultAsync(b => b.Id == id);
        if (lance == null)
        {
            return NotFound();
        }
        return lance;
    }
}
