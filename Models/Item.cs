public class Item
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal LanceInicial { get; set; }
    public DateTime FimLeilao { get; set; }
    public List<Bid> Lances { get; set; } = new List<Bid>();

    public int VendedorId { get; set; }
    public Seller? Vendedor { get; set; }
}
