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


    }
}