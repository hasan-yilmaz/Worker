using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.DATA;

namespace Worker.BIZ
{
    public class DrivingLienseOperation
    {
        DBWorkerEntities db;

        public DrivingLienseOperation(DBWorkerEntities _db)
        {
            db = _db;
        }

        public void Insert(DrivingLiense drivingLiense)
        {
            db.DrivingLiense.Add(drivingLiense);
            db.SaveChanges();
        }

        public List<DrivingLiense> GetAllDrivingLiense()
        {
            List<DrivingLiense> drivingList = db.DrivingLiense.Where(s => s.IsActive).ToList();
            return drivingList;
        }

        public DrivingLiense GetById(int id)
        {
            DrivingLiense drivingLiense = db.DrivingLiense.Where(s => s.DrivingId == id).SingleOrDefault();
            return drivingLiense;
        }

        public void Update(DrivingLiense drivingLiense)
        {
            db.Entry(drivingLiense).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
