using Common.Domain;
using Marten;
using MassTransit;

namespace Bar.Api.Consumers
{
    public class BarConsumer : IConsumer<FooCreatedIntegrationEvent>
    {
        readonly ILogger<BarConsumer> _logger;
        readonly IDocumentSession _session;

        public BarConsumer(ILogger<BarConsumer> logger, IDocumentSession session)
        {
            _logger = logger;
            _session = session;
        }

        public Task Consume(ConsumeContext<FooCreatedIntegrationEvent> context)
        {
            _logger.LogInformation("Received Name: {Name}", context.Message.FooName);

            _session.Store(new Bar.Domain.Bar
            {
                FooName = context.Message.FooName
            });

            _session.SaveChangesAsync();

            return Task.CompletedTask;
        }
    }
}
