using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using VuelingCrudDB.CrossCutting.ProjectSettings;
using VuelingCrudDB.CrossCutting.Resources;
using VuelingCrudDB.Domain.Entities;
using VuelingCrudDB.Infrastructure.Repositories.Contracts;

namespace VuelingCrudDB.Infrastructure.Repositories.Implementations
{
    public class SQLQueriesStudentRepository : IStudentRepository<Student>
    {
        private readonly VuelingCrudDBConfig config = ConfigurationManager.GetSection(nameof(VuelingCrudDBConfig)) as VuelingCrudDBConfig;


        public Student Add(Student entity)
        {
            using (var connection = new SqlConnection(config.ConnectionString))
            {

                SqlCommand command = new SqlCommand(QueryResources.AddQuery, connection);
                command.Parameters.AddWithValue("@studentGuid", entity.Guid);
                command.Parameters.AddWithValue("@studentName", entity.Name);
                command.Parameters.AddWithValue("@studentSurname", entity.Surname);

                connection.Open();
                command.ExecuteNonQuery();
            }

            return GetStudentByGuid(entity.Guid);

        }

        public bool Delete(Student entity)
        {

            using (SqlConnection connection = new SqlConnection(config.ConnectionString))
            {

                var command = new SqlCommand(QueryResources.DeleteQuery, connection);
                command.Parameters.AddWithValue("@Id", entity.Id);

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
                using (SqlCommand command = new SqlCommand(QueryResources.GetAllQuery, connection))
                {
                    connection.Open();
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
            using (SqlConnection connection = new SqlConnection(config.ConnectionString))
            {

                SqlCommand command = new SqlCommand(QueryResources.UpdateQuery, connection);
                command.Parameters.AddWithValue("@Id", entity.Id);
                command.Parameters.AddWithValue("@Name", entity.Name);
                command.Parameters.AddWithValue("@Surname", entity.Surname);

                connection.Open();
                command.ExecuteNonQuery();

                return GetStudentByGuid(entity.Guid);

            }
        }

        private Student GetStudentByGuid(Guid guid)
        {
            using (SqlConnection connection = new SqlConnection(config.ConnectionString))
            {
                SqlCommand command = new SqlCommand(QueryResources.GetByGuidQuery, connection);
                command.Parameters.AddWithValue("@stdGuid", guid);

                connection.Open();
                var reader = command.ExecuteReader();

                reader.Read();

                return new Student()
                {
                    Id = reader.GetInt32(0),
                    Guid = reader.GetGuid(1),
                    Name = reader.GetString(2),
                    Surname = reader.GetString(3),
                };      
            }
        }
    }
}
