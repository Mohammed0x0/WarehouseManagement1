using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Base
    {

        public static string connectString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;



        //public string connectString;
        //protected Base()
        //{
        //    connectString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        //}
        //public SqlConnection GetConnection()
        //{
        //    var Conection = new SqlConnection(connectString);
        //    return Conection;
        //}
        //public void OpenConnectio(SqlConnection connection)
        //{
        //    connection.Open();

        //}

    }
}
