using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingCrudDB.Domain.Entities;
using VuelingCrudDB.Infrastructure.Repositories.Contracts;

namespace VuelingCrudDB.Infrastructure.Repositories.Implementations
{
    public class StoredProceduresStudentRepository : IStudentRepository<Student>
    {
        //private readonly ILog _log;
        private readonly string connectionString = ConfigurationManager.AppSettings["connectionString"];

        public StoredProceduresStudentRepository()
        {
            //_log = log;
        }
                  
        public Student Add(Student entity)
        {
            //_log.Info(entity);
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(QueriesResources.AddProcedure, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@stdGuid", entity.Guid);
                    command.Parameters.AddWithValue("@stdName", entity.Name);
                    command.Parameters.AddWithValue("stdSurname", entity.Surname);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return entity;
                }
                catch (InvalidOperationException ex)
                {
                    //_log.Error(ex);
                    throw;
                }
                catch (SqlException ex)
                {
                    //_log.Error(ex);
                    throw;
                }
                catch (InvalidCastException ex)
                {
                    //_log.Error(ex);
                    throw;
                }
                catch (IOException ex)
                {
                    //_log.Error(ex);
                    throw;
                }

            }
        }

        public bool Delete(Student entity)
        {
            //_log.Info(entity);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var command = new SqlCommand(QueriesResources.DeleteProcedure, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@stdId", entity.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (InvalidOperationException ex)
                {
                    //_log.Error(ex);
                    throw;
                }
                catch (SqlException ex)
                {
                    //_log.Error(ex);
                    throw;
                }
                catch (InvalidCastException ex)
                {
                    //_log.Error(ex);
                    throw;
                }
                catch (IOException ex)
                {
                    //_log.Error(ex);
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
                    using (SqlCommand command = new SqlCommand(QueriesResources.GetAllProcedure, connection))
                    {
                        connection.Open();

                        command.CommandType = CommandType.StoredProcedure;
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
                    //_log.Error(ex);
                    throw;
                }
                catch (SqlException ex)
                {
                    //_log.Error(ex);
                    throw;
                }
                catch (InvalidCastException ex)
                {
                    //_log.Error(ex);
                    throw;
                }
                catch (IOException ex)
                {
                    //_log.Error(ex);
                    throw;
                }
            }
        }

        public Student Update(Student entity)
        {
            //_log.Info(entity);

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(QueriesResources.UpdateProcedure, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@stdId", entity.Id);
                    command.Parameters.AddWithValue("@stdName", entity.Name);
                    command.Parameters.AddWithValue("@stdSurname", entity.Surname);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return entity;
                }
                catch (InvalidOperationException ex)
                {
                    //_log.Error(ex);
                    throw;
                }
                catch (SqlException ex)
                {
                    //_log.Error(ex);
                    throw;
                }
                catch (InvalidCastException ex)
                {                    
                    //_log.Error(ex);
                    throw;
                }
                catch (IOException ex)
                {                    
                    //_log.Error(ex);
                    throw;
                }

            }
        }
    }
}
