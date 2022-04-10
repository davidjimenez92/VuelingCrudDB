using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingCrudDB.CrossCutting.ProjectSettings;

namespace VuelingCrudDB.Application.Services.Contracts
{
    public interface IDelete<T>
    {
        bool Delete(T entity, EnumTypes type);
    }
}
