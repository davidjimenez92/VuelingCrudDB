using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuelingCrudDB.Application.Services.Contracts
{
    public interface IStudentService<Student>: IAdd<Student>, IDelete<Student>, IUpdate<Student>, IRead<Student>
    {
    }
}
