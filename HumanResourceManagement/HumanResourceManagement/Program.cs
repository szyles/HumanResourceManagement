using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace HumanResourceManagement
{
    class Program
    {
        static void Main(string[] args)


        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "Server=127.0.0.1;Port=3308;Database=mydb;Uid=root;Pwd=password";


            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                Console.WriteLine("Successfull");
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Cannot open");
                

            }


            HumanResources Staff = new HumanResources();
            Staff.StartMenu();
        }
    }
}