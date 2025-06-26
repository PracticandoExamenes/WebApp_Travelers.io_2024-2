namespace si732pc2u20221f613.API.Subscriptions.Interfaces.REST.Resources;

public record PlanResource(int Id, string Name, 
                        int MaxUsers, 
                        int IsDefault, 
                        int MonetizationStrategyId);