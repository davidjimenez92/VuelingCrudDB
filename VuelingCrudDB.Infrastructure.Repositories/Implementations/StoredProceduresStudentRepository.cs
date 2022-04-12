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
using VuelingCrudDB.CrossCutting.ProjectSettings;
using VuelingCrudDB.CrossCutting.Resources;
using VuelingCrudDB.Domain.Entities;
using VuelingCrudDB.Infrastructure.Repositories.Contracts;

namespace VuelingCrudDB.Infrastructure.Repositories.Implementations
{
    public class StoredProceduresStudentRepository : IStudentRepository<Student>
    {
        private readonly VuelingCrudDBConfig config = ConfigurationManager.GetSection(nameof(VuelingCrudDBConfig)) as VuelingCrudDBConfig;


        public Student Add(Student entity)
        {
            using (var connection = new SqlConnection(config.ConnectionString))
            {

                SqlCommand command = new SqlCommand(QueryResources.AddProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@stdGuid", entity.Guid);
                command.Parameters.AddWithValue("@stdName", entity.Name);
                command.Parameters.AddWithValue("stdSurname", entity.Surname);

                connection.Open();
                command.ExecuteNonQuery();
                return GetByGuid(entity.Guid);
            }
        }

        public bool Delete(Student entity)
        {
            using (SqlConnection connection = new SqlConnection(config.ConnectionString))
            {

                var command = new SqlCommand(QueryResources.DeleteProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@stdId", entity.Id);

                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public IEnumerable<Student> GetAll()
        {
            var result = new List<Student>();
            using (SqlConnection connection = new SqlConnection(config.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(QueryResources.GetAllProcedure, connection))
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
        }

        public Student Update(Student entity)
        {

            using (var connection = new SqlConnection(config.ConnectionString))
            {

                SqlCommand command = new SqlCommand(QueryResources.UpdateProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@stdId", entity.Id);
                command.Parameters.AddWithValue("@stdName", entity.Name);
                command.Parameters.AddWithValue("@stdSurname", entity.Surname);

                connection.Open();
                command.ExecuteNonQuery();
                return GetByGuid(entity.Guid);
            }
        }

        private Student GetByGuid(Guid guid)
        {
            using (var connection = new SqlConnection(config.ConnectionString))
            {
                SqlCommand command = new SqlCommand(QueryResources.GetByGuidProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@stdGuid", guid);
                connection.Open();
                var reader = command.ExecuteReader(); 
                reader.Read();

                return new Student()
                {
                    Id = reader.GetInt32(0),
                    Guid = reader.GetGuid(1),
                    Name = reader.GetString(2),
                    Surname = reader.GetString(3)
                };
            }
        }
    }
}
