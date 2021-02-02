using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace MondayOnlineShopWeb.Controllers
{
    public class FarmerController : Controller
    {
        // GET: Farmer
        public ActionResult Index()
        {
            string usrname = Session["username"].ToString();
            // Customer data1 = TempData["mydata"] as Customer;

            ViewBag.user = usrname;
            return View();
        }

        public ActionResult OwnProducts()
        {
            string farmer = Session["username"].ToString();
            List<Product> allProducts = BusinessManager.GetProductsbyFarmer(farmer);
            ViewData["allProducts"] = allProducts;
            return View();
        }

       





    }
}