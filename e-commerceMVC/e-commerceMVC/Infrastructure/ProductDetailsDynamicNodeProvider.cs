using e_commerceMVC.DAL;
using e_commerceMVC.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerceMVC.Infrastructure
{
    public class ProductDetailsDynamicNodeProvider:DynamicNodeProviderBase
    {
        private StoreContext db = new StoreContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();

            foreach (Product a in db.Products) 
            {
                DynamicNode n = new DynamicNode();
                n.Title = a.ProductName;
                n.Key = "Product_" + a.ProductId;
                n.ParentKey = "Kategory_" + a.KategoryId;
                n.RouteValues.Add("id", a.ProductId);
                returnValue.Add(n);
            }

            return returnValue;
        }

    }
}