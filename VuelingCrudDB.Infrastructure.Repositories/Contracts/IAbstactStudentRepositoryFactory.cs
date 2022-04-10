using VuelingCrudDB.CrossCutting.ProjectSettings;
using VuelingCrudDB.Domain.Entities;

namespace VuelingCrudDB.Infrastructure.Repositories.Contracts
{
    public interface IAbstactStudentRepositoryFactory
    {
        IStudentRepository<Student> Create(EnumTypes type);
    }
}
