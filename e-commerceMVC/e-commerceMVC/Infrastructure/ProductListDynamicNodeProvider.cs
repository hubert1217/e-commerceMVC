using e_commerceMVC.DAL;
using e_commerceMVC.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerceMVC.Infrastructure
{
    public class ProductListDynamicNodeProvider:DynamicNodeProviderBase
    {
        private StoreContext db = new StoreContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node) 
        {
            var returnValue = new List<DynamicNode>();

            foreach (Kategory a in db.Kategories) 
            {
                DynamicNode n = new DynamicNode();
                n.Title = a.Name;
                n.Key = "Kategory_" + a.KategoryId;
                n.RouteValues.Add("kategoryname", a.Name);
                returnValue.Add(n);
                
            }

            return returnValue;
        }
    }
}