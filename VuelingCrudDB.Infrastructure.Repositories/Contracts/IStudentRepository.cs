using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingCrudDB.Domain.Entities;

namespace VuelingCrudDB.Infrastructure.Repositories.Contracts
{
    public interface IStudentRepository<Student>: IAdd<Student>, IRead<Student>, IUpdate<Student>, IDelete<Student>
    {
    }
}
