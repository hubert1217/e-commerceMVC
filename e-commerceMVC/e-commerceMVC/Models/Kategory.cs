using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerceMVC.Models
{
    public class Kategory
    {
        public int KategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconFileName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}