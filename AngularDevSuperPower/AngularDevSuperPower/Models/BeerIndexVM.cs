using AngularDevSuperPower.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularDevSuperPower.Models
{
    public class BeerIndexVM
    {
        public IEnumerable<Beer> Beers { get; set; }

        public BeerIndexVM()
        {
            Beers = new List<Beer>();
        }
    }
}