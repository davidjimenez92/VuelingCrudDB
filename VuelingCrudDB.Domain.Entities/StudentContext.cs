using System.Configuration;
using System.Data.Entity;

namespace VuelingCrudDB.Domain.Entities
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; } 

        public StudentContext() : base(ConfigurationManager.AppSettings["connectionString"])
        {

        }
    }
}
