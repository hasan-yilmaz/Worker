using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.DATA;

namespace Worker.BIZ
{
    public class PersonOperation
    {
        DBWorkerEntities db;

        public PersonOperation(DBWorkerEntities _db)
        {
            db = _db;
        }

        public void Insert(Person person)
        {
            db.Person.Add(person);
            db.SaveChanges();
        }

        public List<Person> GetAllPerson()
        {
            List<Person> personList = db.Person.Where(s => s.IsActive).ToList();
            return personList;
        }

        public Person GetById(int id)
        {
            Person person = db.Person.Where(s => s.WorkerId == id).SingleOrDefault();
            return person;
        }

        public void Update(Person person)
        {
            db.Entry(person).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
