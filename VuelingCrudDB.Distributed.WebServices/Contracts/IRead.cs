using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VuelingCrudDB.CrossCutting.ProjectSettings;
using VuelingCrudDB.CrossCutting.Resources;

namespace VuelingCrudDB.Distributed.WebServices.Contracts
{
    [ServiceContract]
    [ValidationBehavior]
    public interface IRead<T>
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        IEnumerable<T> GetAll([NotNullValidator(MessageTemplate = "El tipo no puede ser nulo")]EnumTypes type);
    }
}
