using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularDevSuperPower.Models
{
    public class BeerEditVM
    {
        public int? Id { get; set;  }
        public string Name { get; set; }
        public string Colour { get; set; }
        public bool HasTried { get; set; }
    }
}