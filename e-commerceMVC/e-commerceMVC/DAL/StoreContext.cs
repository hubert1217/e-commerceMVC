using e_commerceMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace e_commerceMVC.DAL
{
    public class StoreContext:DbContext
    {

        public StoreContext() : base("StoreContext") 
        { 
            
        }


        static StoreContext()
        {
            Database.SetInitializer<StoreContext>(new StoreInitializer());
        }



        public DbSet<Product> Products { get; set; }

        public DbSet<Kategory> Kategories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}