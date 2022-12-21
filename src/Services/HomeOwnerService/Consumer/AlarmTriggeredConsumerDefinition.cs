using MassTransit;

namespace HomeOwnerService.Consumer;
public class AlarmTriggeredConsumerDefinition : ConsumerDefinition<AlarmTriggeredConsumer>
{
    public AlarmTriggeredConsumerDefinition()
    {
        EndpointName = "Alarm-Triggered";
        ConcurrentMessageLimit = 1000;
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
        IConsumerConfigurator<AlarmTriggeredConsumer> consumerConfigurator)
    {

        endpointConfigurator.UseMessageRetry(r => r.Intervals(100, 200, 500, 800, 1000));

        endpointConfigurator.UseInMemoryOutbox();
    }
}