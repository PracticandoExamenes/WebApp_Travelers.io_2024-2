using si732pc2u20221f613.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si732pc2u20221f613.API.Subscriptions.domain.model.aggregates;

namespace si732pc2u20221f613.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Plan> Plans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.UseSnakeCaseNamingConvention();

        // Si quieres configurar propiedades adicionales, puedes hacerlo aquí también:
        // builder.Entity<Plan>().Property(p => p.Name).HasMaxLength(120).IsRequired();
    }
}