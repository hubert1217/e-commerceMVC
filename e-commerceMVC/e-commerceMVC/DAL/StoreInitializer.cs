using e_commerceMVC.Migrations;
using e_commerceMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace e_commerceMVC.DAL
{
    public class StoreInitializer : MigrateDatabaseToLatestVersion<StoreContext, Configuration>
    {//DropCreateDatabaseAlways<StoreContext>//

        
        
        
        
        //protected override void Seed(StoreContext context)
        //{
        //    SeedStoreData(context);

        //    base.Seed(context);
        //}

        public static void SeedStoreData(StoreContext context)
        {
            var kategories = new List<Kategory>
            {
                new Kategory() {KategoryId=1, Name = "Laptopy", IconFileName="1.png"},
                new Kategory() {KategoryId=2, Name = "Monitory", IconFileName="1.png"},
                new Kategory() {KategoryId=3, Name = "Klawiatury", IconFileName="1.png"},
                new Kategory() {KategoryId=4, Name = "Myszki", IconFileName="1.png"},
            };

            kategories.ForEach(g => context.Kategories.AddOrUpdate(g));
            context.SaveChanges();


            var products = new List<Product>
            {
                new Product() {ProductId = 1,KategoryId = 1, ProductName = "Dell Lattitude", DateAdded= new DateTime(2010,09,8), ProductFileName="1.png",Description="Intel celeron 2.4, 2GB RAm",Price=99,IsBestseller=true},
                new Product() {ProductId = 2,KategoryId = 2, ProductName = "LG 3D", DateAdded= new DateTime(2010,08,08), ProductFileName="1.png",Description="Monitor z funkcją 3D",Price=108,IsBestseller=false},
                new Product() {ProductId = 3,KategoryId = 3, ProductName = "Razer DeathStalker", DateAdded= new DateTime(2011,09,8), ProductFileName="1.png",Description="Klawiatura mechaniczna",Price=300,IsBestseller=true},
                new Product() {ProductId = 4,KategoryId = 4, ProductName = "StellSeries", DateAdded= new DateTime(2012,09,8), ProductFileName="1.png",Description="Myszka dla graczy",Price=20,IsBestseller=false},
                new Product() {ProductId = 5,KategoryId = 1, ProductName = "Toshiba AA120", DateAdded= new DateTime(2010,09,8), ProductFileName="1.png",Description="Intel celeron 3.0, 4GB RAm",Price=4000,IsBestseller=false},
                new Product() {ProductId = 6,KategoryId = 2, ProductName = "Dell 37", DateAdded= new DateTime(2010,09,8), ProductFileName="1.png",Description="Zwykły monitor",Price=1200,IsBestseller=false}
            };

            products.ForEach(a => context.Products.AddOrUpdate(a));
            context.SaveChanges();


        }

        public static void InitializeIdentityForEF(StoreContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            //var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name = "admin@admin.pl";
            const string password = "Admin1234";
            const string roleName = "Admin";


            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, UserData = new UserData() };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            //var user = userManager.FindByName(name);
            //if (user == null)
            //{
            //    user = new ApplicationUser { UserName = name, Email = name };
            //    var result = userManager.Create(user, password);
            //    result = userManager.SetLockoutEnabled(user.Id, false);
            //}

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }

    }
}