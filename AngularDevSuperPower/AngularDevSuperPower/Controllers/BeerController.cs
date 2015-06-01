using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularDevSuperPower.EF;
using AngularDevSuperPower.Models;

namespace AngularDevSuperPower.Controllers
{
    public class BeerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexVM()
        {
            var model = new BeerIndexVM();
            using (var db = new AngularDemoContext())
            {
                //model.Beers = db.Beer.ToList();
				model.Beers = new List<Beer>() { 
					new Beer(){Id=1, Name="Эль", Colour="светлое", HasTried=true},
					new Beer(){Id=2, Name="Имбирное", Colour="темное", HasTried=false},
					new Beer(){Id=4, Name="Медовуха", Colour="красное", HasTried=true},
				};
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete (int id )
        {
            using (var db = new AngularDemoContext())
            {
                var existing = db.Beer.FirstOrDefault(x => x.Id == id);
                if (existing != null)
                {
                    db.Beer.Remove(existing);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Beer");
        }

        public ActionResult Edit (BeerEditVM model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AngularDemoContext())
                {
                    var beer = new Beer()
                    {
                        Name = model.Name,
                        Colour = model.Colour,
                        HasTried = model.HasTried
                    };

                    db.Beer.Add(beer);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Beer");
                }
            }
            throw new HttpException(400, "error");
        }
    }
}
