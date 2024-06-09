using Microsoft.EntityFrameworkCore;

public class AuctionContext : DbContext
{
    public AuctionContext(DbContextOptions<AuctionContext> options) : base(options) { }

    public DbSet<Item> Itens { get; set; }
    public DbSet<Bid> Lances { get; set; }
    public DbSet<Seller> Vendedores { get; set; }
    public DbSet<Buyer> Compradores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .HasMany(i => i.Lances)
            .WithOne(b => b.Item)
            .HasForeignKey(b => b.ItemId);

        modelBuilder.Entity<Item>()
            .HasOne(i => i.Vendedor)
            .WithMany(s => s.Itens)
            .HasForeignKey(i => i.VendedorId);

        modelBuilder.Entity<Buyer>()
            .HasMany(b => b.Lances)
            .WithOne(b => b.Comprador)
            .HasForeignKey(b => b.CompradorId);
    }
}
