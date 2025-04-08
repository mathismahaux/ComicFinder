using Microsoft.EntityFrameworkCore;

namespace BdApi.Data;

public class BandesDessineesContext : DbContext
{
    public DbSet<BandesDessinees> BandesDessinees { get; set; }

    public BandesDessineesContext(DbContextOptions<BandesDessineesContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BandesDessinees>().ToTable("bandes_dessinees");
 
        modelBuilder.Entity<BandesDessinees>()
            .Property(b => b.Serie)
            .HasColumnName("serie");
        
        modelBuilder.Entity<BandesDessinees>()
            .Property(b => b.Titre)
            .HasColumnName("title");

        modelBuilder.Entity<BandesDessinees>()
            .Property(b => b.NumeroAlbum)
            .HasColumnName("numero");
        
        modelBuilder.Entity<BandesDessinees>()
            .Property(b => b.Editeur)
            .HasColumnName("editeur");
    }
}

public class BandesDessinees
{
    public int Id { get; set; }
    public string Serie { get; set; }
    public string Titre { get; set; }
    public int NumeroAlbum { get; set; }
    public string Editeur { get; set; }
}

