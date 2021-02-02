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
    public static class DBManager1
    {
        public static readonly string connString1 = string.Empty;
        static DBManager1()
        {
            connString1 = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        }

        public static bool Insert(Customer newCustomer)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString1))   //DI via Constructor
                {
                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "INSERT INTO customers (Id,Name ,Gender, Age, Location, Phonenumber,Role,Email,Password) " +
                                                "VALUES (@Id, @Name, @Gender, @Age, @Location,@Phonenumber,@Role,@Email,@Password)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@Id", newCustomer.Id));
                    cmd.Parameters.Add(new MySqlParameter("@Name", newCustomer.Name));
                    cmd.Parameters.Add(new MySqlParameter("@Gender", newCustomer.Gender));
                    cmd.Parameters.Add(new MySqlParameter("@Age", newCustomer.Age));
                    cmd.Parameters.Add(new MySqlParameter("@Location", newCustomer.Location));
                    cmd.Parameters.Add(new MySqlParameter("@Phonenumber", newCustomer.PhoneNumber));
                    cmd.Parameters.Add(new MySqlParameter("@Role", newCustomer.Role));
                    cmd.Parameters.Add(new MySqlParameter("@Email", newCustomer.Email));
                    cmd.Parameters.Add(new MySqlParameter("@Password", newCustomer.Password));


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

        public static Customer login(string username, string password)
        {

           
                Customer theCustomer = new Customer();

                IDbConnection conn = new MySqlConnection();
                conn.ConnectionString = connString1;
                string query = "Select * from customers WHERE Email="+"'"+username+"'";

            //		message	"Unknown column 'shriraj22' in 'where clause'"	string


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
                    //Id,Name ,Gender, Age, Location, Phonenumber,Role,Email,Password
                    theCustomer.Id = int.Parse(row["Id"].ToString());
                    theCustomer.Name = row["Name"].ToString();
                    theCustomer.Gender = row["Gender"].ToString();
                    theCustomer.Age = int.Parse(row["Age"].ToString());
                    theCustomer.Location = row["Location"].ToString();
                    theCustomer.PhoneNumber = row["Phonenumber"].ToString();
                    theCustomer.Email = row["Email"].ToString();
                    theCustomer.Role = row["Role"].ToString();
                    theCustomer.Password = row["Password"].ToString();
                  }
                }
                catch (MySqlException e)
                {
                    string message = e.Message;
                }
                // implementation 
                return theCustomer;
           
        }

    }
}
