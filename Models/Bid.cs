public class Bid
{
    public int Id { get; set; }
    public decimal Quantia { get; set; }
    public DateTime Hora { get; set; }
    public int ItemId { get; set; }
    public Item? Item { get; set; }
    public int CompradorId { get; set; }
    public Buyer? Comprador { get; set; }
}
