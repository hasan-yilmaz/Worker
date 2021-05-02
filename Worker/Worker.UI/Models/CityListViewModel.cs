using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Worker.UI.Models
{
    public class CityListViewModel
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public bool IsActive { get; set; }
    }
}