using Microsoft.VisualStudio.TestTools.UnitTesting;
using VuelingCrudDB.Domain.Entities;
using Autofac.Extras.Moq;
using System.Collections.Generic;
using System.Linq;
using VuelingCrudDB.Infrastructure.Repositories.Contracts;

namespace VuelingCrudDB.Infrastructure.Repositories.Implementations.Unit.Tests
{
    [TestClass()]
    public class SQLQueriesStudentRepositoryUnitTests
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
                mock.Mock<IStudentRepository<Student>>().
                    Setup(studentRepository => studentRepository.Add(studentToSave)).
                    Returns(studentToSave);

                //we create a mocked repository with setup conditions
                var mockedStudentRepository =
                    mock.Create<IStudentRepository<Student>>();

                //Act
                var expectedStudent = mockedStudentRepository.Add(studentToSave);

                // Assert
                //verify that GetAll is called one time
                mock.Mock<IStudentRepository<Student>>().
                    Verify(repository => repository.Add(studentToSave));

                Assert.IsTrue(studentToSave.Equals(expectedStudent));
            }
        }

        [TestMethod()]
        public void DeleteUnitTest()
        {
            using (var mock = AutoMock.GetLoose())
            {

                //Setup
                mock.Mock<IStudentRepository<Student>>().
                    Setup(studentRepository => studentRepository.Delete(studentToDelete)).
                    Returns(true);

                //we create a mocked repository with setup conditions
                var mockedStudentRepository =
                    mock.Create<IStudentRepository<Student>>();

                //Act
                var expectedResult = mockedStudentRepository.Delete(studentToDelete);

                // Assert
                //verify that GetAll is called one time
                mock.Mock<IStudentRepository<Student>>().
                    Verify(repository => repository.Delete(studentToDelete));

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
                mock.Mock<IStudentRepository<Student>>().
                    Setup(studentRepository => studentRepository.GetAll()).
                    Returns(students);

                //we create a mocked repository with setup conditions
                var mockedStudentRepository =
                    mock.Create<IStudentRepository<Student>>();

                //Act
                var expectedStudents = mockedStudentRepository.GetAll();

                // Assert
                //verify that GetAll is called one time
                mock.Mock<IStudentRepository<Student>>().
                    Verify(repository => repository.GetAll());

                Assert.IsTrue(expectedStudents.Any());
            }
        }

        [TestMethod()]
        public void UpdateUnitTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange - configure the mock 


                //Setup
                mock.Mock<IStudentRepository<Student>>().
                    Setup(studentRepository => studentRepository.Update(studentToUpdate)).
                    Returns(studentToUpdate);

                //we create a mocked repository with setup conditions
                var mockedStudentRepository =
                    mock.Create<IStudentRepository<Student>>();

                //Act
                var expectedStudent = mockedStudentRepository.Update(studentToUpdate);

                // Assert
                //verify that GetAll is called one time
                mock.Mock<IStudentRepository<Student>>().
                    Verify(repository => repository.Update(studentToUpdate));

                Assert.IsTrue(studentToUpdate.Equals(expectedStudent));
            }
        }
    }
}