﻿using System;
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

        [HttpGet]
        public ActionResult Insert(int id = 0)
        {
            CityCRUDModel cityCRUDModel = new CityCRUDModel();

            List<City> cityList = cityOperation.GetAllCity();
            cityCRUDModel.CityList = new SelectList(cityList, "CityId", "CityName");

            return View(cityCRUDModel);
        }

        [HttpPost]
        public ActionResult Insert(CityCRUDModel model)
        {
            City city = new City()
            {
                CityId = model.CityId,
                CityName =model.CityName,
                IsActive = true
            };
            cityOperation.Insert(city);

            return RedirectToAction("Index", "City");
        }
    }
}