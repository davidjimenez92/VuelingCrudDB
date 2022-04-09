using Autofac;
using Autofac.log4net;
using VuelingCrudDB.Distributed.WebServices.Contracts;

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
            builder.RegisterType<StudentWebService>()
                .As<IStudentWebService>().InstancePerDependency();
          
            return builder.Build();
        }
    }
}