using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Autofac.log4net;
using System.Text;
using System.Threading.Tasks;
using VuelingCrudDB.Domain.Entities;
using VuelingCrudDB.Infrastructure.Repositories.Contracts;

namespace VuelingCrudDB.Infrastructure.Repositories.Implementations
{
    public class EFCFStudentRepository : IStudentRepository<Student>
    {
        public Student Add(Student entity)
        {
            using(var context = new StudentContext())
            {
                var studentInserted = context.Students.Add(entity);
				context.SaveChanges();
				return studentInserted;
            }
        }

        public bool Delete(Student entity)
        {
            using(var context = new StudentContext())
            {
				var studentToDelete = context.Students.Find(entity.Id);
				context.Students.Remove(studentToDelete);
				context.SaveChanges();

				return true;
            }
        }

        public IEnumerable<Student> GetAll()
        {
           using(var context = new StudentContext())
            {
				var students = context.Students.ToList();
				return students;
            }
        }

        public Student Update(Student entity)
        {
            using(var context = new StudentContext())
            {
				var studentToUpdate = context.Students.Find(entity.Id);
				studentToUpdate.Name = entity.Name;
				studentToUpdate.Surname = entity.Surname;

				context.SaveChanges();
				return studentToUpdate;
            }
        }

	}
}
