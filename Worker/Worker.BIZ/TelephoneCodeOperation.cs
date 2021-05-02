using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.DATA;

namespace Worker.BIZ
{
    public class TelephoneCodeOperation
    {
        DBWorkerEntities db;

        public TelephoneCodeOperation(DBWorkerEntities _db)
        {
            db = _db;
        }

        public void Insert(TelephoneCode telephoneCode)
        {
            db.TelephoneCode.Add(telephoneCode);
            db.SaveChanges();
        }

        public List<TelephoneCode> GetAllTelephoneCode()
        {
            List<TelephoneCode> telephoneCodeList = db.TelephoneCode.Where(s => s.IsActive).ToList();
            return telephoneCodeList;
        }

        public TelephoneCode GetById(int id)
        {
            TelephoneCode telephoneCode = db.TelephoneCode.Where(s => s.TelephoneCodeId == id).SingleOrDefault();
            return telephoneCode;
        }

        public void Update(TelephoneCode telephoneCode)
        {
            db.Entry(telephoneCode).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

    }
}
