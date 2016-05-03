﻿using e_commerceMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerceMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Bestsellers { get; set; }
        public IEnumerable<Product> NewArrivals { get; set; }
        public IEnumerable<Kategory> Kategories { get; set; }
    }
}