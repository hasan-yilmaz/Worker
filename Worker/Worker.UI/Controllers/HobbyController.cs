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
    public class HobbyController : Controller
    {
        DBWorkerEntities db;
        HobbyOperation hobbyOperation;

        public HobbyController()
        {
            db = new DBWorkerEntities();
            hobbyOperation = new HobbyOperation(db);
        }

        public ActionResult Index()
        {
            List<HobbyListViewModel> hobbyListViewModelList = new List<HobbyListViewModel>();

            List<Hobby> hobbyList = hobbyOperation.GetAllHobby();

            foreach (Hobby hobby in hobbyList)
            {
                hobbyListViewModelList.Add(new HobbyListViewModel()
                {
                    HobbyId = hobby.HobbyId,
                    Name = hobby.HobbyName,
                    IsActive = hobby.IsActive
                });
            }
            return View(hobbyListViewModelList);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            HobbyCRUDModel hobbyCRUDModel = new HobbyCRUDModel();

            List<Hobby> hobbyList = hobbyOperation.GetAllHobby();
            hobbyCRUDModel.HobbyList = new SelectList(hobbyList, "HobbyId", "HobbyName");

            return View(hobbyCRUDModel);
        }

        [HttpPost]
        public ActionResult Insert(HobbyCRUDModel model)
        {
            Hobby hobby = new Hobby()
            {
                HobbyId = model.HobbyId,
                HobbyName = model.HobbyName,
                IsActive = true
            };
            hobbyOperation.Insert(hobby);

            return RedirectToAction("Index","Hobby");
        }

        [HttpGet]
        public ActionResult Update(int id = 0)
        {
            HobbyCRUDModel hobbyCRUDModel = new HobbyCRUDModel();
            Hobby hobby = hobbyOperation.GetById(id);

            if (hobby != null)
            {
                List<Hobby> hobbyList = hobbyOperation.GetAllHobby();
                hobbyCRUDModel.HobbyList = new SelectList(hobbyList, "HobbyId", "HobbyName");

                hobbyCRUDModel.HobbyId = hobby.HobbyId;
                hobbyCRUDModel.HobbyName = hobby.HobbyName;
            }
            else
            {
                return RedirectToAction("Index", "Hobby");
            }

            return View(hobbyCRUDModel);
        }

        [HttpPost]
        public ActionResult Update(HobbyCRUDModel model)
        {
            Hobby hobby = hobbyOperation.GetById(model.HobbyId);

            if (hobby != null)
            {
                hobby.HobbyId = model.HobbyId;
                hobby.HobbyName = model.HobbyName;

                hobbyOperation.Update(hobby);
            }


            return RedirectToAction("Index","Hobby");
        }
    }
}