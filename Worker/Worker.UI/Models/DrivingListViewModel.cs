using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Worker.UI.Models
{
    public class DrivingListViewModel
    {
        public int DrivingId { get; set; }

        public string DrivingGroup { get; set; }

        public bool IsActive { get; set; }
    }
}