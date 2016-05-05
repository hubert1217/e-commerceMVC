using e_commerceMVC.DAL;
using e_commerceMVC.Models;
using e_commerceMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_commerceMVC.Controllers
{
    public class HomeController : Controller
    {
        //

        private StoreContext db = new StoreContext();


        // GET: /Home/
        public ActionResult Index()
        {
            var kategories = db.Kategories.ToList();

            var newArrivals = db.Products.Where(a => !a.IsHidden).OrderByDescending(a => a.DateAdded).Take(3).ToList(); //Listowanie na stronie głównej 3 dodanych nowych produktów

            var bestsellers = db.Products.Where(a => !a.IsHidden && a.IsBestseller).OrderBy(g => Guid.NewGuid()).Take(3).ToList(); // Listowanie na stronie głównej 3 losowych produków które sa bestselerami 

            
            var vm = new HomeViewModel()
            {
                Bestsellers=bestsellers,
                Kategories = kategories,
                NewArrivals= newArrivals
            };
            
            
            
            return View(vm);
        }


        public ActionResult StaticContent(string viewname)
        {
            return View(viewname);
        }

	}
}