using si732pc2u20221f613.API.Shared.Domain.Repositories;
using si732pc2u20221f613.API.Subscriptions.domain.model.aggregates;
using si732pc2u20221f613.API.Subscriptions.domain.model.Commands;
using si732pc2u20221f613.API.Subscriptions.domain.Repositories;
using si732pc2u20221f613.API.Subscriptions.domain.Services;

namespace si732pc2u20221f613.API.Subscriptions.Application.Internal.CommandServices;

public class PlanCommandService(IPlanRepository planRepository,
    IUnitOfWork unitOfWork): IPlanCommandService
{
    public async Task<Plan?> Handle(CreatePlanCommand command)
    {
        if (await planRepository.ExistsByNameAsync(command.Name))
            throw new InvalidOperationException("A plan with this name already exists.");
        
        if (command.IsDefault == 1 && await planRepository.HasDefaultPlanAsync())
            throw new InvalidOperationException("There is already a default plan.");
        
        var plan = new Plan(
            command.Name,
            command.MaxUsers,
            command.IsDefault,
            command.MonetizationStrategyId
        );
        
        await planRepository.AddAsync(plan);
        await unitOfWork.CompleteAsync();

        return plan;
    }
}