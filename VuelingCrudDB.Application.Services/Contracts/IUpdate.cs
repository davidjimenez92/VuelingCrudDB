using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingCrudDB.Application.Services.Contracts
{
    public interface IUpdate<T>
    {
        T Update(T entity);
    }
}
