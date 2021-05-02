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
    }
}