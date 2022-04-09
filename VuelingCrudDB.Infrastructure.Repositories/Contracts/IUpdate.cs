
namespace VuelingCrudDB.Infrastructure.Repositories.Contracts
{
    public interface IUpdate<T>
    {
        T Update(T entity);
    }
}
