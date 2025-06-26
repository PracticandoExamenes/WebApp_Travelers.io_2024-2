using Microsoft.EntityFrameworkCore;
using si732pc2u20221f613.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si732pc2u20221f613.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using si732pc2u20221f613.API.Subscriptions.domain.model.aggregates;
using si732pc2u20221f613.API.Subscriptions.domain.Repositories;

namespace si732pc2u20221f613.API.Subscriptions.infrastructure.Persistence.EFC.Repositories;

public class PlanRepository(AppDbContext context): BaseRepository<Plan>(context), IPlanRepository
{
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await context.Set<Plan>()
            .AnyAsync(p => p.Name == name);
    }

    public async Task<bool> HasDefaultPlanAsync()
    {
        return await context.Set<Plan>()
            .AnyAsync(p => p.IsDefault == 1);
    }
}