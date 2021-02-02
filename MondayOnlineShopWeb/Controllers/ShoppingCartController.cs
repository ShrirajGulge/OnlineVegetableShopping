using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;
namespace MondayOnlineShopWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            Cart existingCart = this.HttpContext.Session["shoppingcart"] as Cart;
            return View(existingCart);
        }

        public ActionResult AddToCart(int id)
        {
            Product theProduct = BusinessManager.GetProduct(id);
            return View(theProduct);
        }

        [HttpPost]
        public ActionResult AddToCart(int id, string title, int quantity)
        {
            Cart existingCart = this.HttpContext.Session["shoppingcart"] as Cart;
            Item newItem = new Item { ProductID = id, Quantity = quantity };
            existingCart.items.Add(newItem);

            return RedirectToAction("index", "products");
        }

        public ActionResult PlaceOrder()
        {
            string message = " ";
            Cart existingCart = this.HttpContext.Session["shoppingcart"] as Cart;
            foreach (Item theItem in existingCart.items)
            {
                int id = theItem.ProductID;
                int quantity = theItem.Quantity;
                
                 message =message+ BusinessManager.UpdateQuantity(id,quantity);
            }
            ViewData["msg"] = message;

            existingCart.items.Clear();
            return View();
        }
    }
}