using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VuelingCrudDB.CrossCutting.ProjectSettings;
using VuelingCrudDB.Domain.Entities;
using VuelingCrudDB.Infrastructure.Repositories.Contracts;

namespace VuelingCrudDB.Infrastructure.Repositories.Implementations
{
    public class StudentRepositoryFactory : IAbstactStudentRepositoryFactory
    {
        public IStudentRepository<Student> Create(EnumTypes type)
        {
            var configurationFilePath = ConfigurationManager.AppSettings["configurationFilePath"];
            var assemby = Assembly.GetExecutingAssembly();
            XElement root = XElement.Load(configurationFilePath);
            IEnumerable<XElement> fileTypes = 
                from element in root.Elements("Type")
                where element.Attribute("Id").Value == type.ToString()
                select element;

            var fileType = fileTypes.First().Element("class").Value;
            var factoryType = assemby.GetType(fileType);
            return Activator.CreateInstance(factoryType) as IStudentRepository<Student>;
       }
    }
}
