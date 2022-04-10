using Autofac;
using Autofac.Integration.Wcf;
using System;
using VuelingCrudDB.Distributed.WebServices.Configuration;

namespace VuelingCrudDB.Distributed.WebServices
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            IContainer container = AutofacConfig.Configure();
            AutofacHostFactory.Container = container;
        }
    }
}