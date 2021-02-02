using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;
namespace MondayOnlineShopWeb.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Customer theCustomer =BusinessManager1.login(username, password);

            Session["username"] = theCustomer.Name;
            Session["userroll"] = theCustomer.Role;



            // TempData["mydata"] = theCustomer;

            if (theCustomer.Password == password)
            {
                if (theCustomer.Role == "farmer")
                {
                    return this.RedirectToAction("index", "farmer");
                }
                if (theCustomer.Role == "customer")
                {
                    return this.RedirectToAction("index", "products");
                }
            }
            else
            {
                return this.RedirectToAction("login", "accounts");
            }

           

            return View();

        }


        [ActionName("Register")]
        public ActionResult Register_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Register")]
        public ActionResult Register_Post(int id, string name, string gender,
                                   int age, string location, string phonenumber,string role,string email,string password)
        {
           
            Customer newCustomer = new Customer
            {
                Id = id,
                Name = name,
                Gender= gender,
                Age = age,
                Location = location,
                PhoneNumber = phonenumber,
                Role=role,
                Email=email,
                Password=password
            };



            bool status = BusinessManager1.Insert(newCustomer);
            if (status)
            {

                return RedirectToAction("login", "accounts");
            }

            return View();
        }
        public ActionResult Logout()
        {
            Cart theExistingCart = this.Session["shoppingcart"] as Cart;
            theExistingCart.items.Clear();
            return RedirectToAction("index", "home");
        }
    }
}