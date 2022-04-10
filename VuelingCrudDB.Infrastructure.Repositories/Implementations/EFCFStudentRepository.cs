using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
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
				SaveInContext(context);
				return studentInserted;
            }
        }

        public bool Delete(Student entity)
        {
            using(var context = new StudentContext())
            {
				var studentToDelete = context.Students.Find(entity.Id);
				context.Students.Remove(studentToDelete);
				SaveInContext(context);

				return context.Students.Find(entity.Id) == null;
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

				SaveInContext(context);
				return studentToUpdate;
            }
        }

		public void SaveInContext(StudentContext vContext)
		{
			try
			{
				vContext.SaveChanges();
			}
			catch (DbUpdateException due)
			{
				throw;
			}
			catch (DbEntityValidationException deve)
			{
				throw;
			}
			catch (NotSupportedException nse)
			{
				throw;
			}
			catch (ObjectDisposedException ode)
			{
				throw;
			}
			catch (InvalidOperationException ioe)
			{
				throw;
			}

		}
	}
}
