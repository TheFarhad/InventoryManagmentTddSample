namespace IM.Infrastructure.Context;

using Microsoft.EntityFrameworkCore;
using Domain.Inventory;

public class IMContext : DbContext
{
    public DbSet<Inventory> Inventories => Set<Inventory>();

    public IMContext(DbContextOptions<IMContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
