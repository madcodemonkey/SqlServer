using Microsoft.EntityFrameworkCore;

namespace ConsoleEfCoreExp1.Data;

public class AddressEntityConfiguration : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AddressEntity> builder)
    {
        builder.HasKey(x => x.Id);


        builder.ToTable("Addresses");
    }
}