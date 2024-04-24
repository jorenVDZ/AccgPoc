namespace Foo.Infrastructure.Repositories.Interfaces
{
    public interface IFooRepository
    {
        IEnumerable<Domain.Entities.Foo> GetFoos();
    }
}
