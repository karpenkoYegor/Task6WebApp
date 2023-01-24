using Microsoft.EntityFrameworkCore;
using Task6WebApp.Data.Entities;

namespace Task6WebApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Message> Messages => Set<Message>();
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>()
            .HasOne(m => m.User)
            .WithMany(u => u.Messages)
            .HasForeignKey(m => m.ToUser);
        base.OnModelCreating(modelBuilder);
    }
}