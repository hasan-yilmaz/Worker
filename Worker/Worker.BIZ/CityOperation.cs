using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.DATA;

namespace Worker.BIZ
{
    public class CityOperation
    {
        DBWorkerEntities db;

        public CityOperation(DBWorkerEntities _db)
        {
            db = _db;
        }

        public void Insert(City city)
        {
            db.City.Add(city);
            db.SaveChanges();
        }

        public List<City> GetAllCity()
        {
            List<City> cityList = db.City.Where(s => s.IsActive).ToList();
            return cityList;
        }

        public City GetById(int id)
        {
            City city = db.City.Where(s => s.CityId == id).SingleOrDefault();
            return city;
        }

        public void Update(City city)
        {
            db.Entry(city).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
