using e_commerceMVC.DAL;
using e_commerceMVC.Models;
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
            //Kategory nowa = new Kategory{ Name="Laptopy",Description="Opis kategorii",IconFileName="1.png" };
            //db.Kategories.Add(nowa);
            //db.SaveChanges();

            var kategoryList = db.Kategories.ToList();

            return View();
        }

        public ActionResult StaticContent(string viewname)
        {
            return View(viewname);
        }

	}
}