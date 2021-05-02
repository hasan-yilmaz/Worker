using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Worker.UI.Models
{
    public class BloodListViewModel
    {
        public int BloodId { get; set; }

        public string BloodName { get; set; }

        public bool IsActive { get; set; }
    }
}