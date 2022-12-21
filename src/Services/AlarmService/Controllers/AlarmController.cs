using MassTransit;
using Contracts;
using AlarmService.Common;
using Microsoft.AspNetCore.Mvc;

namespace IMessageServiceApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AlarmController : ControllerBase
{
    readonly IPublishEndpoint _publishEndpoint;
    readonly ILogger<AlarmController> _logger;
    readonly IDateTime _dateTime;

    public AlarmController(IPublishEndpoint publishEndpoint, ILogger<AlarmController> logger, IDateTime dateTime)
    {
        _publishEndpoint = publishEndpoint;
        _logger = logger;
        _dateTime = dateTime;   
    }

    [HttpPost]
    public async Task<ActionResult> Post(AlarmTriggeredEvent context)
    {
        _logger.LogInformation("An alarm triggered event has just occured!");


        await _publishEndpoint.Publish<AlarmTriggeredEvent>(new()
        {
            AlarmId = context.AlarmId,
            AlarmEventDateTime = _dateTime.Now,
            HomeOwnerId = context.HomeOwnerId,
            Address = context.Address,
        });

        _logger.LogInformation("Alarm Triggered on {Now} and has been sent to rabbitmq", _dateTime.Now);

        return Ok();

    }

}
