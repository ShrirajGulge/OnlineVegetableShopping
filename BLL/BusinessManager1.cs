using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public static class BusinessManager1
    {

        public static bool Insert(Customer newCustomer)
        {
            return DBManager1.Insert(newCustomer);
        }

        public static Customer login(string username,string password)
        {
            return DBManager1.login(username, password);

        }
    }
}
