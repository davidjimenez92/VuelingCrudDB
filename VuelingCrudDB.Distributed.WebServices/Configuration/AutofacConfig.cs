using Autofac;
using Autofac.log4net;
using VuelingCrudDB.Application.Services.AutofacModules;
using VuelingCrudDB.Application.Services.Contracts;
using VuelingCrudDB.Application.Services.Implementations;
using VuelingCrudDB.Distributed.WebServices.Contracts;
using VuelingCrudDB.Domain.Entities;

namespace VuelingCrudDB.Distributed.WebServices.Configuration
{
    public class AutofacConfig
    {
        protected AutofacConfig()
        {
        }

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<Log4NetModule>();
            builder.RegisterModule(new ServicesModule());
            builder.RegisterType<StudentService>().
                As<IStudentService<Student>>().InstancePerDependency();
            builder.RegisterType<StudentWebService>()
                .As<IStudentWebService>().InstancePerDependency();
          
            return builder.Build();
        }
    }
}