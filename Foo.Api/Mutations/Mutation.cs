using Common.Domain;
using Foo.Infrastructure.Repositories.Interfaces;
using MassTransit;

namespace Foo.Api.Mutations
{
    public class Mutation
    {
        private readonly IBus _bus;

        public Mutation(IBus bus)
        {
            _bus = bus;
        }


        public async Task<bool> CreateFoo(Domain.Entities.Foo foo)
        {
            await _bus.Publish(new FooCreatedIntegrationEvent { FooName = foo.Name });

            return true;
        }
    }
}
