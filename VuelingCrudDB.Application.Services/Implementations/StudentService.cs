
using log4net;
using System;
using System.Collections.Generic;
using VuelingCrudDB.Application.Services.Contracts;
using VuelingCrudDB.CrossCutting.ProjectSettings;
using VuelingCrudDB.Domain.Entities;
using VuelingCrudDB.Infrastructure.Repositories.Contracts;

namespace VuelingCrudDB.Application.Services.Implementations
{
    public class StudentService : IStudentService<Student>
    {
        //private readonly ILog _logger;
        private readonly IAbstactStudentRepositoryFactory _abstactStudentRepositoryFactory;

        public StudentService(IAbstactStudentRepositoryFactory abstactStudentRepositoryFactory)
        {
            //_logger = logger;
            _abstactStudentRepositoryFactory = abstactStudentRepositoryFactory;
        }

        public Student Add(Student entity, EnumTypes type)
        {
           // _logger.Info(entity);
            try
            {
                IStudentRepository<Student> studentRepository = _abstactStudentRepositoryFactory.Create(type);
                entity.Guid = Guid.NewGuid();
                return studentRepository.Add(entity);
            }
            catch (InvalidOperationException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
            catch (InvalidCastException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
            catch (System.IO.IOException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
        }

        public bool Delete(Student entity, EnumTypes type)
        {
            try
            {
                IStudentRepository<Student> studentRepository = _abstactStudentRepositoryFactory.Create(type);
                return studentRepository.Delete(entity);
            }
            catch (InvalidOperationException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
            catch (InvalidCastException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
            catch (System.IO.IOException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
        }

        public IEnumerable<Student> GetAll(EnumTypes type)
        {
            try
            {
                IStudentRepository<Student> studentRepository = _abstactStudentRepositoryFactory.Create(type);
                return studentRepository.GetAll();
            }
            catch (InvalidOperationException ex)
            {
                //_logger.Error(ex.Message);
                throw;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
            catch (InvalidCastException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
            catch (System.IO.IOException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
        }

        public Student Update(Student entity, EnumTypes type)
        {
            try
            {
                IStudentRepository<Student> studentRepository = _abstactStudentRepositoryFactory.Create(type);
                return studentRepository.Update(entity);
            }
            catch (InvalidOperationException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
            catch (InvalidCastException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
            catch (System.IO.IOException ex)
            {
               // _logger.Error(ex.Message);
                throw;
            }
        }
    }
}
