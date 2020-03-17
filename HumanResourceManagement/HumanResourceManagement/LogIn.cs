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

        public LogIn(){ 
            string connStr = "server=serwer2016433.home.pl;user=32493616_golem;database = 32493616_golem;port=3306;password= #golemki123"; 
            // string connStr = "server=localhost;user=root;database=mysql;port=3308;password=password"; BAZA lokalna
            cs = new MySqlConnection(connStr);
        }

        char cLoginOption;

        public void Start(){
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("----------------SYSTEM LOGIN----------------");
            Console.WriteLine("     1. Login");
            Console.WriteLine("     2. Registration");
            Console.WriteLine("     0. Exit");
            cLoginOption = Console.ReadKey(true).KeyChar;
            Console.Clear();

            switch (cLoginOption)
            {
                case '0':
                    Console.WriteLine("Goodbye!");
                    break;
                case '1':
                    Log();
                    LogInEnd();
                    break;
                case '2':
                    Reg();
                    LogInEnd();
                    break;
                default:
                    Console.WriteLine("No action selected!");
                    System.Environment.Exit(1);
                    break;
            }
            if (cLoginOption == '0')
            {
                Console.WriteLine();
                Console.WriteLine("Press ENTER to end");
                Console.ReadLine();
                System.Environment.Exit(1);
            }
            Console.Clear();
        }

        public void Log()
        {
            string sLogLogin;
            string sLogPassword;
            bool bLoggedCorrectly;

            do
            {
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
                    Console.WriteLine("Login sucessful");
                    bLoggedCorrectly = true;
                }
                else
                {
                    Console.WriteLine("Wrong login or password! Please try again.");
                    bLoggedCorrectly = false;
                }

                cs.Close();

            } while (bLoggedCorrectly != true);
        }

        public void Reg()
        {
            string sRegLogin;
            string sRegPassword;
            
            Console.WriteLine("-----------REGISTRATION----------");
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

            /*if (dr.Read())
            {
                Console.WriteLine("Sucessfull registration");
            }
            else
            {
                Console.WriteLine("Bad");
            }
            dr.Close();*/
        }

        public void LogInEnd()
        {
            Console.WriteLine();
            if (cLoginOption != '0')
            {
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
            }
        }
    }
}
