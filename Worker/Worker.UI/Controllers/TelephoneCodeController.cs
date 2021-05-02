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
    public class TelephoneCodeController : Controller
    {
        DBWorkerEntities db;
        TelephoneCodeOperation telephoneCodeOperation;

        public TelephoneCodeController()
        {
            db = new DBWorkerEntities();
            telephoneCodeOperation = new TelephoneCodeOperation(db);
        }


        public ActionResult Index()
        {
            List<TelephoneCodeListViewModel> telephoneCodeListViewModelList = new List<TelephoneCodeListViewModel>();

            List<TelephoneCode> telephoneCodeList = telephoneCodeOperation.GetAllTelephoneCode();
            foreach (TelephoneCode tel in telephoneCodeList)
            {
                telephoneCodeListViewModelList.Add(new TelephoneCodeListViewModel()
                {
                    TelephoneCodeId = tel.TelephoneCodeId,
                    TelCode=tel.TelCode,
                    IsActive=tel.IsActive
                });
            }
            return View(telephoneCodeListViewModelList);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            TelephoneCodeCRUDModel telephoneCodeCRUDModel = new TelephoneCodeCRUDModel();

            List<TelephoneCode> telephoneCodeList = telephoneCodeOperation.GetAllTelephoneCode();
            telephoneCodeCRUDModel.TelList = new SelectList(telephoneCodeList, "TelephoneCodeId", "TelCode");

            return View();
        }

        [HttpPost]
        public ActionResult Insert(TelephoneCodeCRUDModel model)
        {
            TelephoneCode telephoneCode = new TelephoneCode()
            {
                TelephoneCodeId = model.TelephoneCodeId,
                TelCode = model.TelCode,
                IsActive = true
            };
            telephoneCodeOperation.Insert(telephoneCode);

            return RedirectToAction("Index", "TelephoneCode");
        }

    }
}