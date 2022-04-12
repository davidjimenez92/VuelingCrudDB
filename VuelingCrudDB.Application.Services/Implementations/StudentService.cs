
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
        private readonly ILog _logger;
        private readonly IAbstactStudentRepositoryFactory _abstactStudentRepositoryFactory;

        public StudentService(ILog logger, IAbstactStudentRepositoryFactory abstactStudentRepositoryFactory)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
            _abstactStudentRepositoryFactory = abstactStudentRepositoryFactory ?? throw new NullReferenceException(nameof(abstactStudentRepositoryFactory));
        }

        public Student Add(Student entity, EnumTypes type)
        {
            _logger.Info(entity);

            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            IStudentRepository<Student> studentRepository = _abstactStudentRepositoryFactory.Create(type);
            entity.Guid = Guid.NewGuid();
            _logger.Info($"Student to insert: {entity}");
            return studentRepository.Add(entity);
        }

        public bool Delete(Student entity, EnumTypes type)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            IStudentRepository<Student> studentRepository = _abstactStudentRepositoryFactory.Create(type);
            return studentRepository.Delete(entity);
        }

        public IEnumerable<Student> GetAll(EnumTypes type)
        {
            IStudentRepository<Student> studentRepository = _abstactStudentRepositoryFactory.Create(type);

            return studentRepository.GetAll();
        }

        public Student Update(Student entity, EnumTypes type)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            IStudentRepository<Student> studentRepository = _abstactStudentRepositoryFactory.Create(type);
            return studentRepository.Update(entity);
        }
    }
}
