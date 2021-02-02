using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;
namespace MondayOnlineShopWeb.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            List<Product> allProducts = BusinessManager.GetAllProducts();
            ViewData["allProducts"] = allProducts;
            return View();
        }
        public ActionResult Inventory()
        {
            List<Product> allProducts = BusinessManager.GetAllProducts();
            ViewData["allProducts"] = allProducts;
            return View();
        }
        public ActionResult Details(int id)
        {
            Product theProduct = BusinessManager.GetProduct(id);

            string usrrole = Session["userroll"].ToString();

            ViewBag.urole = usrrole;

            return View(theProduct);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(int id, string title, string description,
                                   double unitprice,int quantity, string imageurl,string farmer)
        {
            Product newProduct = new Product
            {
                ID = id,
                Title = title,
                Description = description,
                UnitPrice = unitprice,
                Quantity = quantity,
                ImageUrl = imageurl,
                Farmer=farmer
            };

            bool status= BusinessManager.Insert(newProduct);
            if (status)
            {
               return this.RedirectToAction("index", "products");
            }
            return View();
        }
        public ActionResult Update(int id)
        {
            Product theProduct = BusinessManager.GetProduct(id);
            return View(theProduct);
        }

        [HttpPost]
        public ActionResult Update(int id, string title, string description,
                                   double unitprice, int quantity, string imageurl, string farmer)
        {
            Product newProduct = new Product
            {
                ID = id,
                Title = title,
                Description = description,
                UnitPrice = unitprice,
                Quantity = quantity,
                ImageUrl = imageurl,
                Farmer = farmer
            };

            bool status = BusinessManager.Update(newProduct);
            if (status)
            {
                //product updated successfully
                return this.RedirectToAction("ownproducts", "farmer");

            }
            return View();
        }

        //To remove existing product
        public ActionResult Delete(int id)
        {
            bool status = BusinessManager.Delete(id);
            if (status)
            {
                //product deleted successfully
                return this.RedirectToAction("ownproducts", "farmer");

            }
            return View();
        }
    }
}