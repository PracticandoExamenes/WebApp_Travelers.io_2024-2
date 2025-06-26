using si732pc2u20221f613.API.Subscriptions.domain.model.aggregates;
using si732pc2u20221f613.API.Subscriptions.domain.model.Commands;

namespace si732pc2u20221f613.API.Subscriptions.domain.Services;

public interface IPlanCommandService
{
    Task<Plan?> Handle(CreatePlanCommand command);
}