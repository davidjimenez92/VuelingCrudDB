using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelingCrudDB.Infrastructure.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingCrudDB.Infrastructure.RepositoriesIntegrationTests.Implementations;
using VuelingCrudDB.Infrastructure.RepositoriesIntegrationTests.AutofacModule;
using VuelingCrudDB.Infrastructure.Repositories.Contracts;
using VuelingCrudDB.Domain.Entities;

namespace VuelingCrudDB.Infrastructure.Repositories.Implementations.Unit.Tests
{
    [TestClass()]
    public class SQLQueriesStudentRepositoryUnitTests: IoCSuportedTest<RepositoryModuleTest>
    {

        private IStudentRepository<Student> _studentRepository = null;
        private Student studentToSave;


        [TestInitialize]
        public void SetUp()
        {
            _studentRepository = Resolve<IStudentRepository<Student>>();
            studentToSave = new Student()
            {
                Id = 1,
                Guid = Guid.NewGuid(),
                Name = "David",
                Surname = "Jimenez"
            };
        }

        [TestMethod()]
        public void AddUnitTest()
        {
            Assert.IsTrue(_studentRepository.Add(studentToSave) != null);
        }

        [TestMethod()]
        public void DeleteUnitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllUnitTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateUnitTest()
        {
            Assert.Fail();
        }
    }
}