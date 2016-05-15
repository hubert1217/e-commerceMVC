using e_commerceMVC.DAL;
using e_commerceMVC.Infrastructure;
using e_commerceMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace e_commerceMVC.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        private ShoppingCartManager shoppingCartManager;
        private ISessionManager sessionManager { get; set; }
        private StoreContext db = new StoreContext();


        public CartController() 
        {
            this.sessionManager = new SessionManager();
            this.shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.db);
            
        }


        public ActionResult Index()
        {
            var cartItems = shoppingCartManager.GetCart();
            var cartTotalPrice = shoppingCartManager.GetCartTotalPrice();

            CartViewModel cartVM = new CartViewModel() { CartItems = cartItems, TotalPrice = cartTotalPrice };
            return View(cartVM);
        }


        public ActionResult AddToCart(int id) 
        {
            shoppingCartManager.AddToCart(id);

            return RedirectToAction("Index");
        }

        public int GetCartItemsCount() 
        {
            return shoppingCartManager.GetCartItemsCount();
        }

        public ActionResult RemoveFromCart(int productID) 
        {
            int itemCount = shoppingCartManager.RemoveFromCart(productID);
            int cartItemsCount = shoppingCartManager.GetCartItemsCount();
            decimal cartTotal = shoppingCartManager.GetCartTotalPrice();

            var result = new CartRemoveViewModel {
            
            RemoveItemId=productID,
            RemovedItemCount = itemCount,
            CartTotal = cartTotal,
            CartItemsCount=cartItemsCount
            };

            return Json(result);
        }
	}

}