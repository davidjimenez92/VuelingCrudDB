using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingCrudDB.CrossCutting.ProjectSettings;

namespace VuelingCrudDB.Infrastructure.Repositories.Contracts
{
    public interface IAbstactStudentRepository
    {
        IStudentRepository<IStudent> Create(EnumTypes type);
    }
}
