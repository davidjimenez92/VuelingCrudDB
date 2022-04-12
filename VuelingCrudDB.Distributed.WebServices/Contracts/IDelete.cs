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
    public interface IDelete
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        bool Delete([NotNullValidator(MessageTemplate = "El id no puede ser nulo")] int id,
            [NotNullValidator(MessageTemplate = "El tipo no puede ser nulo")] EnumTypes type);
    }
}
