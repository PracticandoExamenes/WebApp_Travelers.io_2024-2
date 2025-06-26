namespace si732pc2u20221f613.API.Subscriptions.domain.model.Commands;

public record CreatePlanCommand(string Name,
                                int MaxUsers,
                                int IsDefault,
                                int MonetizationStrategyId);