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
           
            LogIn Login = new LogIn();
            Login.Start();
            

            HumanResources Staff = new HumanResources();
            Staff.StartMenu();
        }
    }
}