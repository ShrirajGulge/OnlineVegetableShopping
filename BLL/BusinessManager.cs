using BOL;
using System.Collections.Generic;
using DAL;
namespace BLL
{
    public static class BusinessManager
    {

        public static Product GetProduct(int id)
        {
            /* return   new Product { ID = id, Title = "Gerbera", Description = "Wedding Flower", 
                                              UnitPrice = 6, Quantity = 5000 
                                              ,ImageUrl="/images/Transflower.jpg"};*/
           return  DBManager.GetByID(id);
        }
        public static List<Product> GetAllProducts()
        {
            List<Product> allProducts = new List<Product>();

            allProducts = DBManager.GetAllProducts();
            
            // fiter data 
            // sort data and send Analytical data back to  Controller action method
            // according to business logic modify data  and store back to data base

            return allProducts;

            /* allProducts.Add(new Product { ID = 1, Title = "Gerbera", Description = "Wedding Flower", UnitPrice = 6, Quantity = 5000 });
             allProducts.Add(new Product { ID = 2, Title = "Rose", Description = "Valentine Flower", UnitPrice = 15, Quantity = 7000 });
             allProducts.Add(new Product { ID = 3, Title = "Lotus", Description = "Worship Flower", UnitPrice = 26, Quantity = 0 });
             allProducts.Add(new Product { ID = 4, Title = "Carnation", Description = "Pink carnations signify a mother's love, red is for admiration and white for good luck", UnitPrice = 16, Quantity = 27000 });
             allProducts.Add(new Product { ID = 5, Title = "Lily", Description = "Lilies are among the most popular flowers in the U.S.", UnitPrice = 6, Quantity = 1000 });
             allProducts.Add(new Product { ID = 6, Title = "Jasmine", Description = "Jasmine is a genus of shrubs and vines in the olive family", UnitPrice = 26, Quantity = 0 });
             allProducts.Add(new Product { ID = 7, Title = "Daisy", Description = "Give a gift of these cheerful flowers as a symbol of your loyalty and pure intentions.", UnitPrice = 36, Quantity = 159 });
             allProducts.Add(new Product { ID = 8, Title = "Aster", Description = "Asters are the September birth flower and the the 20th wedding anniversary flower.", UnitPrice = 16, Quantity = 67 });
             allProducts.Add(new Product { ID = 9, Title = "Daffodil", Description = "Wedding Flower", UnitPrice = 6, Quantity = 5000 });
             allProducts.Add(new Product { ID = 10, Title = "Dahlia", Description = "Dahlias are a popular and glamorous summer flower.", UnitPrice = 7, Quantity = 0 });
             allProducts.Add(new Product { ID = 11, Title = "Hydrangea", Description = "Hydrangea is the fourth wedding anniversary flower", UnitPrice = 12, Quantity = 0 });
             allProducts.Add(new Product { ID = 12, Title = "Orchid", Description = "Orchids are exotic and beautiful, making a perfect bouquet for anyone in your life.", UnitPrice = 10, Quantity = 700 });
             allProducts.Add(new Product { ID = 13, Title = "Statice", Description = "Surprise them with this fresh, fabulous array of Statice flowers", UnitPrice = 16, Quantity = 1500 });
             allProducts.Add(new Product { ID = 14, Title = "Sunflower", Description = "Sunflowers express your pure love.", UnitPrice = 8, Quantity = 2300 });
             allProducts.Add(new Product { ID = 15, Title = "Tulip", Description = "Tulips are the quintessential spring flower and available from January to June.", UnitPrice = 17, Quantity = 10000 });
           

            return allProducts;*/

        }
        public static bool Insert(Product newProduct)
        {
            return DBManager.Insert(newProduct);
        }
        public static bool Update(Product newProduct)
        {
            return DBManager.Update(newProduct);
        }
        public static bool Delete(int id)
        {
            return DBManager.Delete(id);
        }


        //Analytical functionalities
        public static List<string> GetTopTenCustomers()
        {
            List<string> customers = new List<string>();
            customers.Add("Microsoft");
            customers.Add("IBM");
            customers.Add("Oracle");
            customers.Add("Google");
            customers.Add("Facebook");
            customers.Add("Infosys");
            customers.Add("Tcs");
            customers.Add("IET");
            customers.Add("IACSD");
            customers.Add("KnowIT");
            return customers;
        }

        public static List<Customer> GetTopCustomers()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer { Id = 1, Name = "Manoj", Age = 32, Location = "Nagpur", PhoneNumber = "9881735806", Email = "manoj.tambade@transflower.in" });
            customers.Add(new Customer { Id = 2, Name = "Manisha", Age = 24, Location = "Delhi", PhoneNumber = "9881735861", Email = "manisha.jadhav@transflower.in" });
            customers.Add(new Customer { Id = 3, Name = "Ravi", Age = 32, Location = "Mumbai", PhoneNumber = "9881735441", Email = "ravi.pant@transflower.in" });
            customers.Add(new Customer { Id = 4, Name = "Rajiv", Age = 25, Location = "Mumbai", PhoneNumber = "9881735856", Email = "rajiv.gore@transflower.in" });
            customers.Add(new Customer { Id = 5, Name = "Gokul", Age = 32, Location = "Kanpur", PhoneNumber = "9881735236", Email = "gokul.varma@transflower.in" });
            customers.Add(new Customer { Id = 6, Name = "sheetal", Age = 22, Location = "Nashik", PhoneNumber = "9881735765", Email = "sheetal.kulkarni@transflower.in" });
            customers.Add(new Customer { Id = 7, Name = "Amarn", Age = 32, Location = "Delhi", PhoneNumber = "9881733761", Email = "amar.sharma@transflower.in" });
            customers.Add(new Customer { Id = 8, Name = "Sarang", Age = 24, Location = "Pune", PhoneNumber = "9881735871", Email = "sarang.Agarwal@transflower.in" });

            return customers;
        }
        public static List<string> GetTopTenOrders()
        {
            List<string> orders = new List<string>();
            orders.Add("Azure Programming");
            orders.Add("DotNet 5 Application Development");
            orders.Add("Spring Boot api for Microservices");
            orders.Add("MongoDB Programming");
            orders.Add("React JS Single Page Applications");
            orders.Add("Angular SPA with WebAPI");
            orders.Add("WPF Programming");
            orders.Add("Dev Ops  Training");
            orders.Add("SQL Programming");
            orders.Add("C++ Systems Programming");
            return orders;
        }
        public static List<Product> GetProductsbyFarmer(string farmer)
        {
            List<Product> allProducts = new List<Product>();

            allProducts = DBManager.GetProductsbyFarmer( farmer);
            return allProducts;
        }

        public static string UpdateQuantity(int id,int quantity)
        {
            return DBManager.UpdateQuantity(id,quantity);
        }







    }
}
