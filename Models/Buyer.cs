public class Buyer
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Bid> Lances { get; set; } = new List<Bid>();
}
