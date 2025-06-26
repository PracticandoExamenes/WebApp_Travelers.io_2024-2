using Microsoft.AspNetCore.Mvc;
using si732pc2u20221f613.API.Subscriptions.domain.Services;
using si732pc2u20221f613.API.Subscriptions.Interfaces.REST.Resources;
using si732pc2u20221f613.API.Subscriptions.Interfaces.REST.Transforms;

namespace si732pc2u20221f613.API.Subscriptions.Interfaces.REST;

[ApiController]
[Route("api/v1/plans")]
public class PlansController : ControllerBase
{
    private readonly IPlanCommandService _commandService;

    public PlansController(IPlanCommandService commandService)
    {
        _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PlanResource resource)
    {
        var command = PlanCommandAssembler.ToCommand(resource);
        var result = await _commandService.Handle(command);
    
        var response = PlanResourceFromEntityAssembler.ToResourceFromEntity(result);
    
        return Ok(response);
    }
}