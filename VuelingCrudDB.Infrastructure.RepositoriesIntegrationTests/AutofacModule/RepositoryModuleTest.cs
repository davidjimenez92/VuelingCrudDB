using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingCrudDB.Domain.Entities;
using VuelingCrudDB.Infrastructure.Repositories.Contracts;
using VuelingCrudDB.Infrastructure.Repositories.Implementations;

namespace VuelingCrudDB.Infrastructure.RepositoriesIntegrationTests.AutofacModule
{
    public class RepositoryModuleTest: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SQLQueriesStudentRepository>()
                .As<IStudentRepository<Student>>();

            base.Load(builder);
        }
    }
}
