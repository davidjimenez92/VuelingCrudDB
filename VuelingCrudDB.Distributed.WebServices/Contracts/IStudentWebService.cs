using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using System.Runtime.Serialization;
using System.ServiceModel;
using VuelingCrudDB.Domain.Entities;

namespace VuelingCrudDB.Distributed.WebServices.Contracts

{
    [ValidationBehavior]
    [ServiceContract]
    public interface IStudentWebService : IAdd<Student>, IDelete, IRead<Student>, IUpdate<Student>
    {

    
    }
}
