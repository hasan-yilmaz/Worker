using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Worker.UI.Models
{
    public class PersonCRUDModel
    {
        public int WorkerId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int CityId { get; set; }
        public SelectList CityList { get; set; }

        public string Address { get; set; }

        public int BloodId { get; set; }
        public SelectList BloodList { get; set; }

        public int DrivingId { get; set; }
        public SelectList DrivingList { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public int HobbyId { get; set; }
        public SelectList HobbyList { get; set; }

        public int TelephoneCodeId { get; set; }
        public SelectList TelList { get; set; }
    }
}