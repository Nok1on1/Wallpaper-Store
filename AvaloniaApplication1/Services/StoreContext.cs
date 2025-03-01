using System;
using System.IO;
using System.Text.Json;
using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.Services;

public class StoreContext : DbContext
{
    public DbSet<Wallpapers> Wallpapers { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Restock> Restocks { get; set; }
    public DbSet<Sell> Sells { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppSettings? appSettings = JsonSerializer
                .Deserialize<AppSettings>(File.ReadAllText("appsettings.json"));

        optionsBuilder.UseNpgsql(appSettings.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasKey(c => new { c.CName });

        modelBuilder.Entity<Seller>().HasKey(s => new { s.SName });

        modelBuilder.Entity<Wallpapers>().HasKey(w => new { w.WId,  w.WProdDate, w.WCompany });

        //Restock Primary key
        modelBuilder.Entity<Restock>()
            .HasKey(r => new { r.WId, r.WProdDate, r.WCompany, r.RestockDate, r.SName });

        // Foreign Key
        // Restock to Wallpaper
        modelBuilder.Entity<Restock>()
            .HasOne(r => r.Wallpapers)
            .WithMany(w => w.Restocks)
            .HasForeignKey(r => new { r.WId, r.WProdDate, r.WCompany })
            .OnDelete(DeleteBehavior.Cascade);

        // Foreign Key
        // Restock to Seller
        modelBuilder.Entity<Restock>()
            .HasOne(r => r.Seller)
            .WithMany(s => s.Restocks)
            .HasForeignKey(r => r.SName)
            .OnDelete(DeleteBehavior.Cascade);

        // Sell Primary key
        modelBuilder.Entity<Sell>()
            .HasKey(s => new { s.WId, s.WProdDate, s.WCompany, s.PurchaseDate, s.CName });

        // Foreign Key
        // Sell to Wallpaper
        modelBuilder.Entity<Sell>()
            .HasOne(s => s.Wallpapers)
            .WithMany(w => w.Sells)
            .HasForeignKey(s => new { s.WId, s.WProdDate, s.WCompany })
            .OnDelete(DeleteBehavior.Cascade);

        // Foreign Key
        // Sell to Client
        modelBuilder.Entity<Sell>()
            .HasOne(s => s.Client)
            .WithMany(c => c.Sells)
            .HasForeignKey(s => s.CName)
            .OnDelete(DeleteBehavior.Cascade);
    }
}