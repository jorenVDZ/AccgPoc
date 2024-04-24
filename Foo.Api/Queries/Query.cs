using Foo.Infrastructure.Repositories.Interfaces;

namespace Foo.Api.Queries
{
    public class Query
    {
        [UseSorting]
        public IEnumerable<Domain.Entities.Foo> GetFoos([Service] IFooRepository fooRepository) => fooRepository.GetFoos();
    }
}
