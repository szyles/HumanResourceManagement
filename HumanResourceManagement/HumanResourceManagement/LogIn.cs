using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace HumanResourceManagement
{
    class LogIn
    {

        ///Connection to Databases
        readonly MySqlConnection cs;
        MySqlCommand cmd;
        MySqlDataReader dr;



        public LogIn()
        { 
            string connStr = "server=serwer2016433.home.pl;user=32493616_golem;database = 32493616_golem;port=3306;password= #golemki123"; 
            // string connStr = "server=localhost;user=root;database=mysql;port=3308;password=password"; BAZA lokalna
            cs = new MySqlConnection(connStr);
        }


        public void Start()
            {

            char cLoginOption;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------------SYSTEM LOGIN----------------");
                Console.WriteLine("Press 1 if you want to LOG IN.....");
                Console.WriteLine("Press 2 if you want REGISTER.....");
            cLoginOption = Char.Parse(Console.ReadLine());

            switch (cLoginOption)
            {
                case '1':
                    Console.Clear();
                    Log();
                    break;
                case '2':
                    Console.Clear();
                    Reg();
                    break;
                default:
                    break;
            }
              
   
        }

        public void Log()
        {
            string sLogLogin;
            string sLogPassword;

            Console.Write("Login:");
            sLogLogin = Console.ReadLine();

   
            Console.Write("Password:");
            sLogPassword = Console.ReadLine();

            cmd = new MySqlCommand();
            cs.Open();
            cmd.Connection = cs;
            cmd.CommandText = "SELECT * FROM Persons WHERE Login ='" + sLogLogin + "' AND Password = '" + sLogPassword + "'";
            dr = cmd.ExecuteReader(); 
            if (dr.Read())
            {
                Console.WriteLine("Login sucess");
            }
            else
            {
                Console.WriteLine("Bad login and password");
            }

            cs.Close();

        }
        public void Reg()
        {
            string sRegLogin;
            string sRegPassword;
            
            Console.WriteLine("-----------REJSTRACJA----------");

            Console.Write("Login:");
            sRegLogin = Console.ReadLine();
            
            Console.Write("Password:");
            sRegPassword = Console.ReadLine();

            cmd = new MySqlCommand();
            cs.Open();
            cmd.Connection = cs;
            cmd.CommandText = "INSERT INTO Persons( Login ,Password) VALUES('" + sRegLogin + "'  ,  '" + sRegPassword + "' )";
            dr = cmd.ExecuteReader();


            dr.Read();

           /* if (dr.Read())
            {
                Console.WriteLine("Sucessfull registration");
            }
            else
            {
                Console.WriteLine("Bad");
            }

            */
               
            





        }



    }
}
