using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerceMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int KategoryId { get; set; }
        public string ProductName { get; set; }
        public DateTime DateAdded { get; set; }
        public string ProductFileName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsBestseller { get; set; }
        public bool IsHidden { get; set; }

        public virtual Kategory Kategory { get; set; }
    }
}