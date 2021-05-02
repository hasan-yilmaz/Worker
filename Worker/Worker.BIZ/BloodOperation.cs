using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.DATA;

namespace Worker.BIZ
{
    public class BloodOperation
    {
        DBWorkerEntities db;

        public BloodOperation(DBWorkerEntities _db)
        {
            db = _db;
        }

        public void Insert(Blood blood)
        {
            db.Blood.Add(blood);
            db.SaveChanges();
        }

        public List<Blood> GetAllBlood()
        {
            List<Blood> bloodList = db.Blood.Where(s => s.IsActive).ToList();
            return bloodList;
        }

        public Blood GetById(int id)
        {
            Blood blood = db.Blood.Where(s => s.BloodId == id).SingleOrDefault();
            return blood;
        }

        public void Update(Blood blood)
        {
            db.Entry(blood).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
