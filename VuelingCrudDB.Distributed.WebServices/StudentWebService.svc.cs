using log4net;
using System;
using System.Collections.Generic;
using VuelingCrudDB.Application.Services.Contracts;
using VuelingCrudDB.CrossCutting.ProjectSettings;
using VuelingCrudDB.Distributed.WebServices.Contracts;
using VuelingCrudDB.Domain.Entities;

namespace VuelingCrudDB.Distributed.WebServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class StudentWebService : IStudentWebService
    {
        private readonly ILog _logger;
        private readonly IStudentService<Student> _studentService;

        public StudentWebService(ILog logger, IStudentService<Student> studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        public Student Add(Student entity, EnumTypes type)
        {
            try
            {
                return _studentService.Add(entity, type);
            }
            catch (InvalidOperationException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            catch (InvalidCastException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            catch (System.IO.IOException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        public bool Delete(Student entity, EnumTypes type)
        {
            try
            {
                return _studentService.Delete(entity, type);
            }
            catch (InvalidOperationException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            catch (InvalidCastException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            catch (System.IO.IOException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        public IEnumerable<Student> GetAll(EnumTypes type)
        {
            try
            {
                return _studentService.GetAll(type);
            }
            catch (InvalidOperationException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            catch (InvalidCastException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            catch (System.IO.IOException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }

        public Student Update(Student entity, EnumTypes type)
        {
            try
            {
                return _studentService.Update(entity, type);
            }
            catch (InvalidOperationException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            catch (InvalidCastException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
            catch (System.IO.IOException ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }
    }
}
