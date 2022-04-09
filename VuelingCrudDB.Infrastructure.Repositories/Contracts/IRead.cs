using System.Collections.Generic;

namespace VuelingCrudDB.Infrastructure.Repositories.Contracts
{
    public interface IRead<T>
    {
        IEnumerable<T> GetAll();
    }
}
