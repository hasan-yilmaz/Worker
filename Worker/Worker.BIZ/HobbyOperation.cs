using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.DATA;

namespace Worker.BIZ
{
    public class HobbyOperation
    {
        DBWorkerEntities db;

        public HobbyOperation(DBWorkerEntities _db)
        {
            db = _db;
        }

        public void Insert(Hobby hobby)
        {
            db.Hobby.Add(hobby);
            db.SaveChanges();
        }

        public List<Hobby> GetAllHobby()
        {
            List<Hobby> hobbyList = db.Hobby.Where(s => s.IsActive).ToList();
            return hobbyList;
        }

        public Hobby GetById(int id)
        {
            Hobby hobby = db.Hobby.Where(s => s.HobbyId == id).SingleOrDefault();
            return hobby;
        }

        public void Update(Hobby hobby)
        {
            db.Entry(hobby).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
