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

        [HttpGet]
        public ActionResult Insert()
        {
            DrivingCRUDModel drivingCRUDModel = new DrivingCRUDModel();

            List<DrivingLiense> drivingLienseList = drivingLienseOperation.GetAllDrivingLiense();
            drivingCRUDModel.DrivingList = new SelectList(drivingLienseList, "DrivingId", "DrivingGroup");

            return View(drivingCRUDModel);
        }

        [HttpPost]
        public ActionResult Insert(DrivingCRUDModel model)
        {
            DrivingLiense drivingLiense = new DrivingLiense()
            {
                DrivingId = model.DrivingId,
                DrivingGroup = model.DrivingGroup,
                IsActive = true
            };
            drivingLienseOperation.Insert(drivingLiense);

            return RedirectToAction("Index", "Driving");
        }

        [HttpGet]
        public ActionResult Update(int id = 0)
        {
            DrivingCRUDModel drivingCRUDModel = new DrivingCRUDModel();
            DrivingLiense drivingLiense = drivingLienseOperation.GetById(id);
            if(drivingLiense != null)
            {
                drivingCRUDModel.DrivingId = drivingLiense.DrivingId;
                drivingCRUDModel.DrivingGroup = drivingLiense.DrivingGroup;

                List<DrivingLiense> drivingList = drivingLienseOperation.GetAllDrivingLiense();
                drivingCRUDModel.DrivingList = new SelectList(drivingList, "DrivingId", "DrivingGroup");
            }
            else
            {
                return RedirectToAction("Index", "Driving");
            }
            return View(drivingCRUDModel);

        }

        [HttpPost]
        public ActionResult Update(DrivingCRUDModel model)
        {
            DrivingLiense drivingLiense = drivingLienseOperation.GetById(model.DrivingId);
            if(drivingLiense != null)
            {
                drivingLiense.DrivingId = model.DrivingId;
                drivingLiense.DrivingGroup = model.DrivingGroup;

                drivingLienseOperation.Update(drivingLiense);
                
            }

            return RedirectToAction("Index", "Driving");
        }


    }
}