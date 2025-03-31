using Microsoft.EntityFrameworkCore;

namespace ConsoleEfCoreExp1.Data;

public class AcmeDbContext : DbContext
{
    /// <summary>Constructor</summary>
    public AcmeDbContext(DbContextOptions<AcmeDbContext> options) : base(options)
    {

    }

    public virtual DbSet<PersonEntity> People { get; set; } = default!;
    public virtual DbSet<AddressEntity> Addresses { get; set; } = default!;

    /// <summary>
    /// Used to configure various tables and relationships in the database.
    /// </summary> 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Warning!  Avoid using modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly); since there are two different contexts in this project!
        modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AddressEntityConfiguration());
    }
}
