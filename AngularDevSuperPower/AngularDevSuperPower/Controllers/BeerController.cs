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
                model.Beers = db.Beer.ToList();
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
