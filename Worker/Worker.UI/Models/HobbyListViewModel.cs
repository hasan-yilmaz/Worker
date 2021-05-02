using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Worker.UI.Models
{
    public class HobbyListViewModel
    {
        public int HobbyId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}