using System.Runtime.Serialization;
using System.ServiceModel;
using VuelingCrudDB.Domain.Entities;

namespace VuelingCrudDB.Distributed.WebServices.Contracts

{

    [ServiceContract]
    public interface IStudentWebService : IAdd<Student>, IDelete<Student>, IRead<Student>, IUpdate<Student>
    {

    
    }
}
