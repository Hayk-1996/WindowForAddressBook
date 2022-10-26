using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowForAddressBook
{
     class ConnectionDB
    {
        public string GetConnection()
        {
            string con = @"Data Source=DESKTOP-FE8TQN1\SQLEXPRESS;Initial Catalog=AddressDB;Integrated Security=True";
            //string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Csharp\repos\WindowForAddressBook\WindowForAddressBook\Database1.mdf;Integrated Security=True";
            return con;
        }
    }
}
