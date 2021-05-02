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
    public class DrivingController : Controller
    {
        DBWorkerEntities db;
        DrivingLienseOperation drivingLienseOperation;

        public DrivingController()
        {
            db = new DBWorkerEntities();
            drivingLienseOperation = new DrivingLienseOperation(db);
        }

        public ActionResult Index()
        {
            List<DrivingListViewModel> drivingListViewModelList = new List<DrivingListViewModel>();

            List<DrivingLiense> drivingList = drivingLienseOperation.GetAllDrivingLiense();

            foreach (DrivingLiense driving in drivingList)
            {
                drivingListViewModelList.Add(new DrivingListViewModel()
                {
                    DrivingId = driving.DrivingId,
                    DrivingGroup = driving.DrivingGroup,
                    IsActive = driving.IsActive
                }); 
            }
            return View(drivingListViewModelList);
        }
    }
}