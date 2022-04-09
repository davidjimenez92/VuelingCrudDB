
namespace VuelingCrudDB.Application.Services.Contracts
{
    public interface IStudentService<Student>: IAdd<Student>, IDelete<Student>, IUpdate<Student>, IRead<Student>
    {
    }
}
