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

        public Student Add(string name, string surname, EnumTypes type)
        {
            _logger.Info($"Name: {name}");
            _logger.Info($"Surname: {surname}");
            _logger.Info($"Type: {type}");
            try
            {
                var student = new Student()
                {
                    Name = name,
                    Surname = surname,
                };
                
                var result = _studentService.Add(student, type);
                _logger.Info($"Inserted: {result}");

                return result;
            }
            catch (InvalidOperationException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
            catch (InvalidCastException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
            catch (System.IO.IOException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
        }

        public bool Delete(int id, EnumTypes type)
        {
            _logger.Info($"Id: {id}");
            _logger.Info($"type: {type}");

            try
            {
                var student = new Student()
                {
                    Id = id,
                };

                var result = _studentService.Delete(student, type);
                _logger.Info($"Deleted: {result}");

                return result;
            }
            catch (InvalidOperationException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
            catch (InvalidCastException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
            catch (System.IO.IOException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
        }

        public IEnumerable<Student> GetAll(EnumTypes type)
        {
            _logger.Info($"Type: {type}");

            try
            {
                return _studentService.GetAll(type);
            }
            catch (InvalidOperationException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
            catch (InvalidCastException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
            catch (System.IO.IOException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
        }

        public Student Update(string name, string surname, EnumTypes type)
        {
            _logger.Info($"Name: {name}");
            _logger.Info($"Surname: {surname}");
            _logger.Info($"Type: {type}");

            try
            {
                var student = new Student()
                {
                    Name = name,
                    Surname = surname,
                };

                var result = _studentService.Update(student, type);
                _logger.Info($"Updated: {result}");

                return result;
            }
            catch (InvalidOperationException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
            catch (InvalidCastException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
            catch (System.IO.IOException ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                throw;
            }
        }
    }
}
