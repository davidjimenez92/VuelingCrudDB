using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using VuelingCrudDB.Domain.Entities;
using Autofac.Extras.Moq;
using VuelingCrudDB.Application.Services.Contracts;
using VuelingCrudDB.CrossCutting.ProjectSettings;

namespace VuelingCrudDB.Application.Services.Implementations.Unit.Tests
{
    [TestClass()]
    public class StudentServiceUnitTests
    {
        private static Student studentToSave;
        private static Student studentToUpdate;
        private static Student studentToDelete;
        private static IEnumerable<Student> students;

        [TestInitialize]
        public void SetUp()
        {
            studentToSave = new Student()
            {
                Id = 1,
                Name = "David",
                Surname = "Jimenez"
            };

            studentToUpdate = new Student()
            {
                Id = 1,
                Name = "D",
                Surname = "J"
            };

            studentToDelete = studentToUpdate;

            students = new List<Student>();
        }

        [TestMethod()]
        public void AddUnitTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange - configure the mock 


                //Setup
                mock.Mock<IStudentService<Student>>().
                    Setup(studentService => studentService.Add(studentToSave, EnumTypes.SqlQueries)).
                    Returns(studentToSave);

                //we create a mocked repository with setup conditions
                var mockedStudentService =
                    mock.Create<IStudentService<Student>>();

                //Act
                var expectedStudent = mockedStudentService.Add(studentToSave, EnumTypes.SqlQueries);

                // Assert
                //verify that GetAll is called one time
                mock.Mock<IStudentService<Student>>().
                    Verify(service => service.Add(studentToSave, EnumTypes.SqlQueries));

                Assert.IsTrue(studentToSave.Equals(expectedStudent));
            }
        }

        [TestMethod()]
        public void DeleteUnitTest()
        {
            using (var mock = AutoMock.GetLoose())
            {

                //Setup
                mock.Mock<IStudentService<Student>>().
                    Setup(studentService => studentService.Delete(studentToDelete, EnumTypes.SqlQueries)).
                    Returns(true);

                //we create a mocked repository with setup conditions
                var mockedStudentService =
                    mock.Create<IStudentService<Student>>();

                //Act
                var expectedResult = mockedStudentService.Delete(studentToDelete, EnumTypes.SqlQueries);

                // Assert
                //verify that GetAll is called one time
                mock.Mock<IStudentService<Student>>().
                    Verify(service => service.Delete(studentToDelete, EnumTypes.SqlQueries));

                Assert.IsTrue(expectedResult);
            }
        }

        [TestMethod()]
        public void GetAllUnitTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange - configure the mock 


                //Setup
                mock.Mock<IStudentService<Student>>().
                    Setup(studentService => studentService.GetAll(EnumTypes.SqlQueries)).
                    Returns(students);

                //we create a mocked repository with setup conditions
                var mockedStudentService =
                    mock.Create<IStudentService<Student>>();

                //Act
                var expectedStudents = mockedStudentService.GetAll(EnumTypes.SqlQueries);

                // Assert
                //verify that GetAll is called one time
                mock.Mock<IStudentService<Student>>().
                    Verify(service => service.GetAll(EnumTypes.SqlQueries));

                Assert.IsTrue(expectedStudents.Count() == 0);
            }
        }

        [TestMethod()]
        public void UpdateUnitTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange - configure the mock 


                //Setup
                mock.Mock<IStudentService<Student>>().
                    Setup(studentRepository => studentRepository.Update(studentToUpdate, EnumTypes.SqlQueries)).
                    Returns(studentToUpdate);

                //we create a mocked repository with setup conditions
                var mockedStudentService =
                    mock.Create<IStudentService<Student>>();

                //Act
                var expectedStudent = mockedStudentService.Update(studentToUpdate, EnumTypes.SqlQueries);

                // Assert
                //verify that GetAll is called one time
                mock.Mock<IStudentService<Student>>().
                    Verify(service => service.Update(studentToUpdate, EnumTypes.SqlQueries));

                Assert.IsTrue(studentToUpdate.Equals(expectedStudent));
            }
        }
    }
}