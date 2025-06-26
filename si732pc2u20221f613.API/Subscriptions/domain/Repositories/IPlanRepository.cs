using si732pc2u20221f613.API.Shared.Domain.Repositories;
using si732pc2u20221f613.API.Subscriptions.domain.model.aggregates;

namespace si732pc2u20221f613.API.Subscriptions.domain.Repositories;

public interface IPlanRepository: IBaseRepository<Plan>
{
    Task<bool> ExistsByNameAsync(string name);
    Task<bool> HasDefaultPlanAsync();
}