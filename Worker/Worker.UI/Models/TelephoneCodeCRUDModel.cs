using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Worker.UI.Models
{
    public class TelephoneCodeCRUDModel
    {
        public int TelephoneCodeId { get; set; }
        public SelectList TelList { get; set; }

        public string TelCode { get; set; }
    }
}