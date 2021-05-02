using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Worker.BIZ;
using Worker.DATA;
using Worker.UI.Models;

namespace Worker.UI.Controllers
{
    public class BloodController : Controller
    {
        DBWorkerEntities db;
        BloodOperation bloodOperation;

        public BloodController()
        {
            db = new DBWorkerEntities();
            bloodOperation = new BloodOperation(db);
        }

        public ActionResult Index()
        {
            List<BloodListViewModel> bloodListViewModelList = new List<BloodListViewModel>();

            List<Blood> bloodList = bloodOperation.GetAllBlood();

            foreach (Blood blood in bloodList)
            {
                bloodListViewModelList.Add(new BloodListViewModel()
                {
                    BloodId = blood.BloodId,
                    BloodName = blood.BloodGroup,
                    IsActive = blood.IsActive
                });
            }

            return View(bloodListViewModelList);
        }


   
    }
}