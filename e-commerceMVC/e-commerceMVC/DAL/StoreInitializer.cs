using e_commerceMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace e_commerceMVC.DAL
{
    public class StoreInitializer : DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            SeedStoreData(context);

            base.Seed(context);
        }

        private void SeedStoreData(StoreContext context)
        {
            var kategories = new List<Kategory>
            {
                new Kategory() {KategoryId=1, Name = "Laptopy", IconFileName="1.png"},
                new Kategory() {KategoryId=2, Name = "Monitory", IconFileName="2.png"},
                new Kategory() {KategoryId=3, Name = "Klawiatury", IconFileName="3.png"},
                new Kategory() {KategoryId=4, Name = "Myszki", IconFileName="4.png"},
            };

            kategories.ForEach(g => context.Kategories.Add(g));
            context.SaveChanges();


            var products = new List<Product>
            {
                new Product() {ProductId = 1,KategoryId = 1, ProductName = "Dell Lattitude", DateAdded= new DateTime(2010,09,8), CovertFileName="1.png",Description="Intel celeron 2.4, 2GB RAm",Price=99,IsBestseller=true}
            };

            products.ForEach(a => context.Products.Add(a));
            context.SaveChanges();
        }
    }
}