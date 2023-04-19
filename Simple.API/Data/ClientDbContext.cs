using Microsoft.EntityFrameworkCore;
using Simple.API.Domain;

namespace Simple.API.Data;

public class ClientDbContext: DbContext
{
    public ClientDbContext(DbContextOptions options): base(options)
    {
    }
    
    public virtual DbSet<Client> Client { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ClientDbContext).Assembly);
        base.OnModelCreating(builder);
    }
}