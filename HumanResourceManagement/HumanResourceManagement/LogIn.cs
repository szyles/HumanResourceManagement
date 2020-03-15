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

            char loginOption;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("----------------SYSTEM LOGIN----------------");
                Console.WriteLine("Press L if you want to LOG IN.....");
                Console.WriteLine("Press R if you want REGISTER.....");
            loginOption = Char.Parse(Console.ReadLine());
            if (loginOption == 'L' )
            {
                Console.Clear();
                Log();
            }
            else if(loginOption == 'R')
            {
                Console.Clear();
                Reg();
            }
            else
            {
                Console.WriteLine("Try one more");

            }
              
   
        }

        public void Log()
        {
            string Log_login;
            string Log_password;

            Console.Write("Login:");
            Log_login = Console.ReadLine();

   
            Console.Write("Password:");
            Log_password = Console.ReadLine();

            cmd = new MySqlCommand();
            cs.Open();
            cmd.Connection = cs;
            cmd.CommandText = "SELECT * FROM Persons WHERE Login ='" + Log_login + "' AND Password = '" + Log_password + "'";
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
            string Reg_login;
            string Reg_password;
            
            Console.WriteLine("-----------REJSTRACJA----------");

            Console.Write("Login:");
            Reg_login = Console.ReadLine();
            
            Console.Write("Password:");
            Reg_password = Console.ReadLine();

            cmd = new MySqlCommand();
            cs.Open();
            cmd.Connection = cs;
            cmd.CommandText = "INSERT INTO Persons( Login ,Password) VALUES('" + Reg_login + "'  ,  '" + Reg_password + "' )";
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
