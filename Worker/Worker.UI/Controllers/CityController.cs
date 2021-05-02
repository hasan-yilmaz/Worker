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
    public class CityController : Controller
    {
        DBWorkerEntities db;
        CityOperation cityOperation;

        public CityController()
        {
            db = new DBWorkerEntities();
            cityOperation = new CityOperation(db);
        }

        public ActionResult Index()
        {
            List<CityListViewModel> cityListViewModelList = new List<CityListViewModel>();

            List<City> cityList = cityOperation.GetAllCity();

            foreach (City city in cityList)
            {
                cityListViewModelList.Add(new CityListViewModel()
                {
                    CityId = city.CityId,
                    CityName = city.CityName,
                    IsActive = city.IsActive
                });
            }
            return View(cityListViewModelList);
        }
    }
}