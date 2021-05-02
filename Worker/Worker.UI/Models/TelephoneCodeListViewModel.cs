using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Worker.UI.Models
{
    public class TelephoneCodeListViewModel
    {
        public int TelephoneCodeId { get; set; }

        public string TelCode { get; set; }

        public bool IsActive { get; set; }
    }
}