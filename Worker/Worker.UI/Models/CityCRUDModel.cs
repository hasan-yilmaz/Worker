using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Worker.UI.Models
{
    public class CityCRUDModel
    {
        public int CityId { get; set; }
        public SelectList CityList { get; set; }

        public string CityName { get; set; }
    }
}