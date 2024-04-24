using Foo.Infrastructure.Repositories.Interfaces;

namespace Foo.Infrastructure.Repositories
{
    public class MockFooRepository : IFooRepository
    {
        public IEnumerable<Domain.Entities.Foo> GetFoos()
        {
            return new List<Domain.Entities.Foo>
            {
                new Domain.Entities.Foo { Name = "Foo 1" },
                new Domain.Entities.Foo { Name = "Foo 2" },
                new Domain.Entities.Foo { Name = "Foo 3" },
                new Domain.Entities.Foo { Name = "Foo 4" },
                new Domain.Entities.Foo { Name = "Foo 5" },
                new Domain.Entities.Foo { Name = "Foo 6" },
                new Domain.Entities.Foo { Name = "Foo 7" }
            };
        }
    }
}
