using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectLibrary
{
    public static class Connections
    {
        public static SqlConnection GetConnection()
        {
            string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ProjectDBGR2;Integrated Security=True";
            //string strCon = @"Server=tcp:st211111953sr.database.windows.net,1433;Initial Catalog=st211111953db;Persist Security Info=False;User ID=st211111953;Password=Kayphonik@53;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return new SqlConnection(strCon);
        }
    }
}
