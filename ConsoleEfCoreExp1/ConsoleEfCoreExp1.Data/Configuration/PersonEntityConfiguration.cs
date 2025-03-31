using Microsoft.EntityFrameworkCore;

namespace ConsoleEfCoreExp1.Data;

public class PersonEntityConfiguration : IEntityTypeConfiguration<PersonEntity>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PersonEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(e => e.Version).IsRowVersion();

        builder.HasOne(o => o.Address)
            .WithOne(o => o.Person);

        // .HasForeignKey<AddressEntity>(fk => fk.Person);

        builder.ToTable("Person");
    }
}