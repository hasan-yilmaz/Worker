using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Worker.UI.Models
{
    public class PersonListViewModel
    {
        public int WorkerId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Blood { get; set; }

        public string Driving { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string Hobby { get; set; }

        public string TelephoneCode { get; set; }

        public bool IsActive { get; set; }
    }
}