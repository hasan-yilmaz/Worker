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
    public class HomeController : Controller
    {
        DBWorkerEntities db;
        BloodOperation bloodOperation;
        CityOperation cityOperation;
        DrivingLienseOperation drivingLienseOperation;
        HobbyOperation hobbyOperation;
        PersonOperation personOperation;
        TelephoneCodeOperation telephoneCodeOperation;


        public HomeController()
        {
            db = new DBWorkerEntities();
            bloodOperation = new BloodOperation(db);
            cityOperation = new CityOperation(db);
            drivingLienseOperation = new DrivingLienseOperation(db);
            hobbyOperation = new HobbyOperation(db);
            telephoneCodeOperation = new TelephoneCodeOperation(db);
            personOperation = new PersonOperation(db);
        }

        public ActionResult Index()
        {
            List<PersonListViewModel> personListViewModelList = new List<PersonListViewModel>();

            List<Person> personList = personOperation.GetAllPerson();

            foreach (Person person in personList)
            {
                personListViewModelList.Add(new PersonListViewModel()
                {
                    WorkerId=person.WorkerId,
                    Name = person.Name,
                    Surname = person.Surname,
                    City=person.City.CityName,
                    Address=person.Address,
                    Blood=person.Blood.BloodGroup,
                    Driving=person.DrivingLiense.DrivingGroup,
                    Email=person.Email,
                    TelephoneCode=person.TelephoneCode.TelCode,
                    Telephone=person.Telephone,
                    Hobby=person.Hobby.HobbyName,
                    IsActive=person.IsActive
                });
            }
            return View(personListViewModelList);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            PersonCRUDModel personCRUDModel = new PersonCRUDModel();

            List<Blood> bloodList = bloodOperation.GetAllBlood();
            personCRUDModel.BloodList = new SelectList(bloodList, "BloodId", "BloodGroup");

            List<City> cityList = cityOperation.GetAllCity();
            personCRUDModel.CityList = new SelectList(cityList, "CityId", "CityName");

            List<DrivingLiense> drivingList = drivingLienseOperation.GetAllDrivingLiense();
            personCRUDModel.DrivingList = new SelectList(drivingList, "DrivingId", "DrivingGroup");

            List<TelephoneCode> telephoneList = telephoneCodeOperation.GetAllTelephoneCode();
            personCRUDModel.TelList = new SelectList(telephoneList, "TelephoneCodeId", "TelCode");

            List<Hobby> hobbyList = hobbyOperation.GetAllHobby();
            personCRUDModel.HobbyList = new SelectList(hobbyList, "HobbyId", "HobbyName");

            return View(personCRUDModel);
        }

        [HttpPost]
        public ActionResult Insert(PersonCRUDModel model)
        {
            Person person = new Person()
            {
                Name = model.Name,
                Surname = model.Surname,
                CityId = model.CityId,
                Address = model.Address,
                BloodId = model.BloodId,
                DrivingId = model.DrivingId,
                Email = model.Email,
                TelephoneCodeId = model.TelephoneCodeId,
                Telephone = model.Telephone,
                HobbyId = model.HobbyId,
                IsActive = true
            };
            personOperation.Insert(person);

            return RedirectToAction("Index","Home");
        }
        

    }
}