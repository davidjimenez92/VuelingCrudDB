using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingCrudDB.Infrastructure.Repositories.Contracts
{
    public interface IDelete<T>
    {
        bool Delete(T entity);
    }
}
