using Autofac;
using Autofac.log4net;
using VuelingCrudDB.Infrastructure.Repositories.Contracts;
using VuelingCrudDB.Infrastructure.Repositories.Implementations;

namespace VuelingCrudDB.Application.Services.AutofacModules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepositoryFactory>().
                As<IAbstactStudentRepositoryFactory>();

            builder.RegisterModule<Log4NetModule>();
            base.Load(builder);
        }
    }
}
