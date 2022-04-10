﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VuelingCrudDB.CrossCutting.ProjectSettings;

namespace VuelingCrudDB.Distributed.WebServices.Contracts
{
    [ServiceContract]
    public interface IDelete<T>
    {
        [OperationContract]
        bool Delete(T entity, EnumTypes type);
    }
}