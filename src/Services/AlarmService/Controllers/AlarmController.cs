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
    readonly DateTimeService _dateTimeService;

    public AlarmController(IPublishEndpoint publishEndpoint, ILogger<AlarmController> logger, DateTimeService dateTimeService)
    {
        _publishEndpoint = publishEndpoint;
        _logger = logger;
        _dateTimeService = dateTimeService;   
    }

    [HttpPost]
    public async Task<ActionResult> Post(AlarmTriggeredEvent context)
    {
        _logger.LogInformation("An alarm triggered event has just occured!");


        await _publishEndpoint.Publish<AlarmTriggeredEvent>(new()
        {
            AlarmId = context.AlarmId,
            AlarmEventDateTime = _dateTimeService.Now,
            HomeOwnerId = context.HomeOwnerId,
            Address = context.Address,
        });

        _logger.LogInformation("Alarm Triggered on {Now} and has been sent to rabbitmq", _dateTimeService.Now);

        return Ok();

    }

}
