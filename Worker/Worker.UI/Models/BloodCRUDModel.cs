using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Worker.UI.Models
{
    public class BloodCRUDModel
    {
        public int BloodId { get; set; }
        public SelectList BloodList { get; set; }

        public string BloodGroup { get; set; }
    }
}