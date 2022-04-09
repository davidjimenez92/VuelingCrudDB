using System;

namespace VuelingCrudDB.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }


        public override string ToString()
        {
            return $"{Id}, {Guid}, {Name}, {Surname}";
        }

        public override bool Equals(object obj)
        {
            bool equals = false;
            if (obj != null && GetType() == obj.GetType())
            {
                Student student = (Student)obj;
                if ((this.Id == student.Id) && (this.Name == student.Name) && (this.Surname == student.Surname))
                {
                    equals = true;
                }
            }

            return equals;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            hash = Id.GetHashCode() ^ Name.GetHashCode()
                                    ^ Surname.GetHashCode();

            return hash;
        }
    }
}
