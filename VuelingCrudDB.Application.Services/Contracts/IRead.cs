using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingCrudDB.CrossCutting.ProjectSettings;

namespace VuelingCrudDB.Application.Services.Contracts
{
    public interface IRead<T>
    {
        IEnumerable<T> GetAll(EnumTypes type);
    }
}
