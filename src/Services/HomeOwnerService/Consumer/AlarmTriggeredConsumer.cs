using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Contracts;

namespace HomeOwnerService.Consumer;
public class AlarmTriggeredConsumer : IConsumer<AlarmTriggeredEvent>
{
    readonly ILogger<AlarmTriggeredConsumer> _logger;

    public AlarmTriggeredConsumer(ILogger<AlarmTriggeredConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<AlarmTriggeredEvent> context)
    {
        _logger.LogInformation("Alarm triggered notification has been received");


        await context.Publish<HomeOwnerNotificationEvent>(new
        {
            context.Message.HomeOwnerId,
            context.Message.Address,
            context.Message.AlarmEventDateTime

        });

        _logger.LogInformation("Home owner has been notified");
    }

}