using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple.API.Domain;

namespace Simple.API.Data.Configuration;

public class ClientConfiguration: IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(e => e.Id);

        builder.Property(e => e.Name).HasMaxLength(100);

        builder.Property(e => e.Email).HasMaxLength(100);

        builder.Property(e => e.DateBecameCustomer).HasDefaultValueSql("GetDate()");
    }
}