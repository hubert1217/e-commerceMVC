using e_commerceMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_commerceMVC.Controllers
{
    public class StoreController : Controller
    {

        StoreContext db = new StoreContext();
        
        
        //
        // GET: /Store/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {

            var product = db.Products.Find(id);


            return View(product);
        }

        public ActionResult List(string kategoryname)
        {
            var kategory = db.Kategories.Include("Products").Where(g => g.Name.ToUpper() == kategoryname.ToUpper()).Single();
            var products = kategory.Products.ToList();

            return View(products);
        }

        [ChildActionOnly]
        public ActionResult KategoriesMenu() 
        {

            var kategories = db.Kategories.ToList();


            return PartialView("_KategoriesMenu",kategories);
        }



        public ActionResult ProductSuggestions(string term) 
        {
            var products = this.db.Products.Where(a => !a.IsHidden && a.ProductName.ToLower().Contains(term.ToLower()))
                .Take(5).Select(a => new { label = a.ProductName });

            return Json(products, JsonRequestBehavior.AllowGet);
        }



	}
}