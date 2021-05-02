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


        [HttpGet]
        public ActionResult Insert(int id = 0)
        {
            BloodCRUDModel bloodCRUDModel = new BloodCRUDModel();

            List<Blood> bloodList = bloodOperation.GetAllBlood();
            bloodCRUDModel.BloodList = new SelectList(bloodList, "BloodId", "BloodGroup");

            return View();
        }

        [HttpPost]
        public ActionResult Insert(BloodCRUDModel model)
        {
            Blood blood = new Blood()
            {
                BloodId = model.BloodId,
                BloodGroup = model.BloodGroup,
                IsActive = true
            };
            bloodOperation.Insert(blood);

            return RedirectToAction("Index", "Blood");
        }

        [HttpGet]
        public ActionResult Update(int id = 0)
        {
            Blood blood = bloodOperation.GetById(id);

            BloodCRUDModel bloodCRUDModel = new BloodCRUDModel();

            if (blood != null)
            {
                List<Blood> bloodList = bloodOperation.GetAllBlood();
                bloodCRUDModel.BloodList = new SelectList(bloodList, "BloodId", "BloodGroup");

                bloodCRUDModel.BloodId = blood.BloodId;
                bloodCRUDModel.BloodGroup = blood.BloodGroup;
            }
            else
            {
                return RedirectToAction("Index", "Blood");
            }
            return View(bloodCRUDModel);
        }

        [HttpPost]
        public ActionResult Update(BloodCRUDModel model)
        {
            Blood blood = bloodOperation.GetById(model.BloodId);

            if (blood != null)
            {
                blood.BloodId = model.BloodId;
                blood.BloodGroup = model.BloodGroup;

                bloodOperation.Update(blood);
            }

            return RedirectToAction("Index","Blood");
        }
    }
}