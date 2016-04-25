using Mvc.dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult CreateProduct()
        {
            return View(db.Products.ToList());
        }

        [HttpPost]
        public ActionResult CreateProduct(string name, int category)
        {
            Products add = new Products()
            {
                Name = name,
                CategoryId = category
            };
            db.Products.Add(add);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int? Id)
        {
            Products product = db.Products.Find(Id);
            return View(product);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int Id)
        {
            Products product = db.Products.Find(Id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("EditProduct")]
        public ActionResult EditProduct(int Id)
        {
            Products product = db.Products.Find(Id);
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct([Bind(Include = "Id,Name,CategoryId")] Products product)
        {
            var entry = db.Entry(product);
            entry.State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}