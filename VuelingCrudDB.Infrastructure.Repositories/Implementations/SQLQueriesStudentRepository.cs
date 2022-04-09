using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingCrudDB.Domain.Entities;
using VuelingCrudDB.Infrastructure.Repositories.Contracts;

namespace VuelingCrudDB.Infrastructure.Repositories.Implementations
{
    public class SQLQueriesStudentRepository : IStudentRepository<Student>
    {
        private readonly ILog _log;
        private readonly string connectionString = ConfigurationManager.AppSettings["connectionString"];

        public SQLQueriesStudentRepository(ILog logger)
        {
            _log = logger;
        }
        public Student Add(Student entity)
        {
            _log.Info(entity);
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(QueriesResources.AddQuery, connection);
                    command.Parameters.AddWithValue("@studentGuid", entity.Guid);
                    command.Parameters.AddWithValue("@studentName", entity.Name);
                    command.Parameters.AddWithValue("@studentSurname", entity.Surname);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return entity;
                }
                catch (InvalidOperationException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
                catch (SqlException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
                catch (InvalidCastException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
                catch (IOException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }

            }
        }

        public bool Delete(Student entity)
        {
            _log.Info(entity);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var command = new SqlCommand(QueriesResources.DeleteQuery, connection);
                    command.Parameters.AddWithValue("@Id", entity.Id);

                    command.ExecuteNonQuery();
                    return true;
                }
                catch (InvalidOperationException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
                catch (SqlException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
                catch (InvalidCastException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
                catch (IOException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }

            }
        }

        public IEnumerable<Student> GetAll()
        {
            var result = new List<Student>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(QueriesResources.GetAllQuery, connection))
                    {
                        var reader = command.ExecuteReader();
                        int ordId = reader.GetOrdinal("Id");
                        int ordGuid = reader.GetOrdinal("Guid");
                        int ordName = reader.GetOrdinal("Name");
                        int ordSurname = reader.GetOrdinal("Surname");

                        while (reader.Read())
                        {
                            var student = new Student()
                            {
                                Id = reader.GetInt32(ordId),
                                Guid = reader.GetGuid(ordGuid),
                                Name = reader.GetString(ordName),
                                Surname = reader.GetString(ordSurname)
                            };
                            result.Add(student);
                        }

                        return result;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
                catch (SqlException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
                catch (InvalidCastException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
                catch (IOException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
            }
        }

        public Student Update(Student entity)
        {
            _log.Info(entity);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(QueriesResources.UpdateQuery, connection);
                    command.Parameters.AddWithValue("@Id", entity.Id);
                    command.Parameters.AddWithValue("@Name", entity.Name);
                    command.Parameters.AddWithValue("@Surname", entity.Surname);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return entity;
                }
                catch (InvalidOperationException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
                catch (SqlException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
                catch (InvalidCastException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
                catch (IOException ex)
                {
                    _log.Error(ex.Message);
                    throw;
                }
            }
        }
    }
}
