using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Worker.UI.Models
{
    public class DrivingCRUDModel
    {
        public int DrivingId { get; set; }
        public SelectList DrivingList { get; set; }

        public string DrivingGroup { get; set; }
    }
}