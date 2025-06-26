using si732pc2u20221f613.API.Subscriptions.domain.model.aggregates;
using si732pc2u20221f613.API.Subscriptions.Interfaces.REST.Resources;

namespace si732pc2u20221f613.API.Subscriptions.Interfaces.REST.Transforms;

public static class PlanResourceFromEntityAssembler
{
    public static PlanResource ToResourceFromEntity(Plan entity)
    {
        return new PlanResource(
            entity.Id,
            entity.Name,
            entity.MaxUsers,
            entity.IsDefault,
            entity.MonetizationStrategyId);
    }
}