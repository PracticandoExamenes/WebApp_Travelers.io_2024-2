using si732pc2u20221f613.API.Subscriptions.Interfaces.REST.Resources;
using si732pc2u20221f613.API.Subscriptions.domain.model.Commands;

namespace si732pc2u20221f613.API.Subscriptions.Interfaces.REST.Transforms;

public static class PlanCommandAssembler
{
    public static CreatePlanCommand ToCommand(PlanResource resource)
    {
        return new CreatePlanCommand(
            resource.Name,
            resource.MaxUsers,
            resource.IsDefault,
            resource.MonetizationStrategyId
        );
    }
}