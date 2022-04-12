using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VuelingCrudDB.CrossCutting.ProjectSettings;

namespace VuelingCrudDB.Distributed.WebServices.Contracts
{
    [ServiceContract]
    [ValidationBehavior]

    public interface IAdd<T>
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        T Add([NotNullValidator(MessageTemplate = "El nombre no puede ser nulo")] string name,
            [NotNullValidator(MessageTemplate = "El apellido no puede ser nulo")]string surname, 
            [NotNullValidator(MessageTemplate = "El tipo no puede ser nulo")] EnumTypes type);
    }
}
