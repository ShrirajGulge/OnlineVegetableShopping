using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using BOL;
namespace DAL
{
    public static class DBManager
    {
        public static readonly string connString = string.Empty;
        static DBManager()
        {
            connString= ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        }
        public static Product GetByID(int id)
        {
            Product theproduct = new Product();
           
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from products WHERE Id="+id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {                  
                    theproduct.ID = int.Parse(row["Id"].ToString());
                    theproduct.Title = row["Title"].ToString();
                    theproduct.Description = row["Description"].ToString();
                    theproduct.UnitPrice = double.Parse(row["UnitPrice"].ToString());
                    theproduct.Quantity = int.Parse(row["Quantity"].ToString());
                    theproduct.ImageUrl = row["ImageUrl"].ToString();
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }        
            // implementation 
            return theproduct;
        }
        public static List<Product> GetAllProducts()
        {
            List<Product> allProducts = new List<Product>();
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from products";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach( DataRow row in rows)
                {
                    Product theproduct = new Product();
                    theproduct.ID = int.Parse(row["Id"].ToString());
                    theproduct.Title = row["Title"].ToString() ;
                    theproduct.Description =row["Description"].ToString();
                    theproduct.UnitPrice= double.Parse(row["UnitPrice"].ToString());
                    theproduct.Quantity  = int.Parse(row["Quantity"].ToString());
                    allProducts.Add(theproduct);
                }
            }
            catch(MySqlException e)
            {
                string message = e.Message;
            }
            return allProducts;
        }
        public static bool Insert( Product newProduct)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))   //DI via Constructor
                {
                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "INSERT INTO products (Id,Title ,Description, UnitPrice, Quantity, ImageUrl,Farmer) " +
                                                "VALUES (@Id, @Title, @Description, @UnitPrice, @Quantity,@ImageUrl,@Farmer)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@Id", newProduct.ID));
                    cmd.Parameters.Add(new MySqlParameter("@Title", newProduct.Title));
                    cmd.Parameters.Add(new MySqlParameter("@Description", newProduct.Description));
                    cmd.Parameters.Add(new MySqlParameter("@UnitPrice", newProduct.UnitPrice));
                    cmd.Parameters.Add(new MySqlParameter("@Quantity", newProduct.Quantity));
                    cmd.Parameters.Add(new MySqlParameter("@ImageUrl", newProduct.ImageUrl));
                    cmd.Parameters.Add(new MySqlParameter("@Farmer", newProduct.Farmer));

                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;
        }
        public static bool Update(Product newProduct)
        {
            bool status = false;
            try
            {
                /*
                 *
                 *bool status = false;
              IDbConnection conn = new MySqlConnection();
             conn.ConnectionString = connString;
              IDbCommand cmd = new MySqlCommand();
             cmd.CommandText = "Select * from products";
             c md.Connection = conn;
             MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
             DataSet ds = new DataSet();
               
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = ds.Tables[0].Columns["Id"];
                ds.Tables[0].PrimaryKey = keyColumns;
                //exception='These columns don't currently have unique values.'

                DataRow datarow = ds.Tables[0].Rows.Find(existingProduct.ID);
                datarow["Title"] = existingProduct.Title;
                datarow["Description"] = existingProduct.Description;
                datarow["UnitPrice"] = existingProduct.UnitPrice;
                datarow["Quantity"] = existingProduct.Quantity;
                datarow["ImageUrl"] = existingProduct.ImageUrl;
                //datarow["Farmer"] = existingProduct.Farmer;

                da.Update(ds);
                status = true;
                */
               
                using (MySqlConnection con = new MySqlConnection(connString))   
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "UPDATE products SET Title=@Title,Description=@Description,UnitPrice=@UnitPrice,Quantity=@Quantity,ImageUrl=@ImageUrl WHERE Id=@Id";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@Id", newProduct.ID));
                    cmd.Parameters.Add(new MySqlParameter("@Title", newProduct.Title));
                    cmd.Parameters.Add(new MySqlParameter("@Description", newProduct.Description));
                    cmd.Parameters.Add(new MySqlParameter("@UnitPrice", newProduct.UnitPrice));
                    cmd.Parameters.Add(new MySqlParameter("@Quantity", newProduct.Quantity));
                    cmd.Parameters.Add(new MySqlParameter("@ImageUrl", newProduct.ImageUrl));
                    //cmd.Parameters.Add(new MySqlParameter("@Farmer", newProduct.Farmer));

                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }



            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                string msg = e.Message;
            }
            return status;
        }
        public static bool Delete(int id)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))   
                {
                    if (con.State == ConnectionState.Closed)        
                    con.Open();
                    string query = "DELETE from products  WHERE Id=@Id";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@Id", id));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;
        }
        public static Product GetByFarmer(string farmer)
        {
            Product theproduct = new Product();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from products WHERE Farmer=" +"'"+ farmer+"'";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    theproduct.ID = int.Parse(row["Id"].ToString());
                    theproduct.Title = row["Title"].ToString();
                    theproduct.Description = row["Description"].ToString();
                    theproduct.UnitPrice = double.Parse(row["UnitPrice"].ToString());
                    theproduct.Quantity = int.Parse(row["Quantity"].ToString());
                    theproduct.ImageUrl = row["ImageUrl"].ToString();
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            // implementation 
            return theproduct;
        }
        public static List<Product> GetProductsbyFarmer(string farmer)
        {
            List<Product> allProducts = new List<Product>();
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from products WHERE Farmer=" +"'"+farmer+"'";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    Product theproduct = new Product();
                    theproduct.ID = int.Parse(row["Id"].ToString());
                    theproduct.Title = row["Title"].ToString();
                    theproduct.Description = row["Description"].ToString();
                    theproduct.UnitPrice = double.Parse(row["UnitPrice"].ToString());
                    theproduct.Quantity = int.Parse(row["Quantity"].ToString());
                    allProducts.Add(theproduct);
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            return allProducts;
        }

        public static string UpdateQuantity(int id, int quantity)
        {
            string message = " ";
            bool flag = true;
            try
            {
                IDbConnection conn = new MySqlConnection();
                conn.ConnectionString = connString;
                string query = "Select * from products WHERE Id=" + id;
                IDbCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
                DataSet ds = new DataSet();

                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    
                    int DBQuantity = int.Parse(row["Quantity"].ToString());
                    if (DBQuantity < quantity)
                    { message = "Quantity is not available";
                        flag = false;
                    }
                        
                    
                    
                    
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                string msg = e.Message;
            }



            if (flag)
            {
                try
                {
                    using (MySqlConnection con = new MySqlConnection(connString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        string query = "UPDATE products SET Quantity=@Quantity WHERE Id=@Id";
                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.Add(new MySqlParameter("@Id", id));
                        cmd.Parameters.Add(new MySqlParameter("@Quantity", quantity));


                        cmd.ExecuteNonQuery();
                        con.Close();
                        message = "updated";
                    }



                }
                catch (MySql.Data.MySqlClient.MySqlException e)
                {
                    string msg = e.Message;
                }
            }

            return message;
        }

    }
}
