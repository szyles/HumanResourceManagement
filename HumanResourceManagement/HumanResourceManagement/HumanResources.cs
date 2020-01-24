using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace HumanResourceManagement
{
    class HumanResources
    {
        List<Person> employeeList;

        public List<Person> EmployeeList
        {
            get
            {
                if (employeeList == null)
                {
                    employeeList = new List<Person>();
                }
                return employeeList;
            }
        }

        public HumanResources()
        {
            Address newAddress0001 = new Address("Fioletowa", 69, "70-781", "Szczecin");
            Address newAddress0002 = new Address("Okrezna", 46, "74-320", "Barlinek");
            Address newAddress0003 = new Address("ks.Boguslawa X", 43, "70-441", "Szczecin");
            ContractOfEmployment newContractOfEmployment = new ContractOfEmployment("15-01-2020", "UoP", 36);
            EmployeeList.Add(new Person("Pawel", "Cybulski", "0002", newAddress0001, "30-09-1998", newContractOfEmployment)
                );
            EmployeeList.Add(new Person("Kamil", "Blaz", "0001", newAddress0002, "09-07-1998", newContractOfEmployment)
                );
            EmployeeList.Add(new Person("Szymon", "Lesisz", "0003", newAddress0003, "20-09-1999", newContractOfEmployment)
                );
        }
        char cOption;
        public void StartMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press ENTER to get access to MAIN MENU");
            Console.ReadLine();


            do
            {
                Console.Clear();
                Console.WriteLine("Selecton action:");
                Console.WriteLine("   1. Hire an employee ");
                Console.WriteLine("   2. Search employees by category ");
                Console.WriteLine("   3. View Employees ");
                Console.WriteLine("   4. Change Address ");
                Console.WriteLine("   5. Change Personal Data ");
                Console.WriteLine("   6. Change Contract of Employment ");
                Console.WriteLine("   7. Delete Employee ");
                Console.WriteLine("   0. Exit ");
                Console.WriteLine("----------");
                Console.WriteLine("version 0.1");
                Console.WriteLine("(c) 2020 Kamil Blaz, Pawel Cybulski, Szymon Lesisz   All Rights Reserved");
                cOption = Console.ReadKey(true).KeyChar;
                Console.Clear();

                switch (cOption)
                {
                    case '0':
                        Console.WriteLine("Goodbye!");
                        break;
                    case '1':
                        Hire_an_Employee();
                        end();
                        break;
                    case '2':
                        Search_Employees_by_category();
                        break;
                    case '3':
                        ShowEmployees();
                        end();
                        break;
                    case '4':
                        Change_Address();
                        end();
                        break;
                    case '5':
                        Change_Personal_Data();
                        end();
                        break;
                    case '6':
                        Change_Contract_of_Employment();
                        end();
                        break;
                    case '7':
                        Delete_Employee();
                        end();
                        break;
                    default:
                        Console.WriteLine("No action selected!");
                        end();
                        break;
                }
                if (cOption == '0')
                {
                    Console.WriteLine();
                    Console.WriteLine("Press ENTER to end");
                    Console.ReadLine();
                }
            } while (cOption != '0');
        }

        public void Hire_an_Employee()
        {
            string sContractTime_F, sHouseNumber_F;
            string sName_F, sSurname_F, sRegNumber_F, sDateOfBirth_F, sDateOfConclusion_F, sContractType_F, sStreet_F, sPostalAddress_F, sCity_F;
            int iContractTime_F, iHouseNumber_F;
            Console.WriteLine("--- Personal Data ---");
            Console.Write("   Name: ");
            sName_F = Console.ReadLine();
            while (true)
            {
                if (!Regex.IsMatch(sName_F, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("***  Name cannot contain characters other than letters! **");
                    Console.Write("   Name: ");
                    sName_F = Console.ReadLine();
                }
                else
                    break;
            }
            Console.Write("   Surname: ");
            sSurname_F = Console.ReadLine();
            while (true)
            {
                if (!Regex.IsMatch(sSurname_F, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("*** Surname cannot contain characters other than letters! ***");
                    Console.Write("   Nazwisko: ");
                    sSurname_F = Console.ReadLine();
                }
                else
                    break;
            }
            Console.Write("   Registration Number: ");
            sRegNumber_F = Console.ReadLine();
            while (true)
            {
                if (!Regex.IsMatch(sRegNumber_F, @"^[0-9]{4,}$"))
                {
                    Console.WriteLine("*** The Registration Number have to consist of 4 or more number!  ***");
                    Console.Write("   Registration Number: ");
                    sRegNumber_F = Console.ReadLine();
                }
                else
                    break;
            }
            Console.WriteLine("  Date Of Birth:");
            while (true)
            {
                DateTime ActualDateTime = DateTime.Today;
                int iNowDay = int.Parse(ActualDateTime.Day.ToString());
                int iNowMonth = int.Parse(ActualDateTime.Month.ToString());
                int iNowYear = int.Parse(ActualDateTime.Year.ToString());
                int iDay, iMonth, iYear;
                string sDayAdd0 = "", sMonthAdd0 = "";
                Console.Write("   Day (DD): ");
                string sDay = Console.ReadLine();
                while (true)
                {
                    if (!Regex.IsMatch(sDay, @"^[0-9]{1,2}$"))
                    {
                        Console.WriteLine("*** Day have to consist of 1 or 2 number! ***");
                        Console.Write("   Day (DD): ");
                        sDay = Console.ReadLine();
                    }
                    else if (Regex.IsMatch(sDay, @"^[0-9]{1}$"))
                    {
                        sDayAdd0 = "0";
                        iDay = int.Parse(sDay);
                        break;
                    }
                    else
                    {
                        iDay = int.Parse(sDay);
                        break;
                    }
                }
                Console.Write("   Month (MM): ");
                string sMonth = Console.ReadLine();
                while (true)
                {
                    if (!Regex.IsMatch(sMonth, @"^[0-9]{1,2}$"))
                    {
                        Console.WriteLine("*** Month have to consist of 1 or 2 number!  ***");
                        Console.Write("   Month (MM): ");
                        sMonth = Console.ReadLine();
                    }
                    else if (Regex.IsMatch(sMonth, @"^[0-9]{1}$"))
                    {
                        sMonthAdd0 = "0";
                        iMonth = int.Parse(sMonth);
                        break;
                    }
                    else
                    {
                        iMonth = int.Parse(sMonth);
                        break;
                    }
                }
                Console.Write("   Year (YYYY): ");
                string sYear = Console.ReadLine();
                while (true)
                {
                    if (!Regex.IsMatch(sYear, @"^[0-9]{4}$"))
                    {
                        Console.WriteLine("*** Year have to consist of 4 or more number! ***");
                        Console.Write("   Year (YYYY): ");
                        sYear = Console.ReadLine();
                    }
                    else
                    {
                        iYear = int.Parse(sYear);
                        break;
                    }
                }

                if (iYear > iNowYear)
                {
                    Console.WriteLine("*** Incorrect Year! ***");
                }
                else if ((iYear == iNowYear) && (iMonth > iNowMonth))
                {
                    Console.WriteLine("*** Incorrect Month! ***");
                }
                else if ((iYear < iNowYear) && (iMonth > 12))
                {
                    Console.WriteLine("*** Incorrect Month! ***");
                }
                else if ((iYear == iNowYear) && (iMonth == iNowMonth) && (iDay > iNowDay))
                {
                    Console.WriteLine("*** Incorrect Day! ***");
                }
                else if ((iYear < iNowYear) && (iMonth < 13) && (iDay > 31))
                {
                    Console.WriteLine("*** Incorrect Day! ***");
                }
                else if ((iYear < iNowYear) && ((iMonth == 2) || (iMonth == 4) || (iMonth == 6) || (iMonth == 9) || (iMonth == 11)) && (iDay > 30))
                {
                    Console.WriteLine("*** Incorrect Day! ***");
                }
                else if ((iYear < iNowYear) && ((iYear % 4 == 0) && (iYear % 100 != 0) || (iYear % 400 == 0)) && (iMonth == 2) && (iDay > 29))
                {
                    Console.WriteLine("*** Incorrect Day! ***");
                }
                else if ((iYear < iNowYear) && !(((iYear % 4 == 0) && (iYear % 100 != 0) || (iYear % 400 == 0))) && (iMonth == 2) && (iDay > 28))
                {
                    Console.WriteLine("*** Incorrect Day! ***");
                }
                else
                {
                    sDateOfBirth_F = sDayAdd0 + iDay.ToString() + "-" + sMonthAdd0 + iMonth.ToString() + "-" + iYear.ToString();
                    Console.WriteLine("Date Of Brith: {0}", sDateOfBirth_F);
                    break;
                }
            }

            Console.WriteLine("--- Address ---");
            Console.Write("   Street: ");
            sStreet_F = Console.ReadLine();
            while (true)
            {
                if (!Regex.IsMatch(sStreet_F, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("*** The Street must not contain other signs than letters! ***");
                    Console.Write("   Street: ");
                    sStreet_F = Console.ReadLine();
                }
                else
                    break;
            }
            Console.Write("   House Number : ");
            sHouseNumber_F = Console.ReadLine(); // Znaki specjalne
            while (true)
            {
                if (!Regex.IsMatch(sHouseNumber_F, @"^[0-9]+$"))
                {
                    Console.WriteLine("*** The House Number cannot contain characters other than numbers! ***");
                    Console.Write("   House Number: ");
                    sHouseNumber_F = Console.ReadLine();
                    iHouseNumber_F = Convert.ToInt32(sHouseNumber_F);
                }
                else
                {
                    iHouseNumber_F = Convert.ToInt32(sHouseNumber_F);
                    break;
                }
            }
            Console.Write("   Postal Address (XX-XXX): ");
            sPostalAddress_F = Console.ReadLine();
            while (true)
            {
                if (!Regex.IsMatch(sPostalAddress_F, @"^[0-9]{2}\-[0-9]{3}$"))
                {
                    Console.WriteLine("*** Postal Address have to contain " + "-" + " and cannot contain characters other than numbers!***");
                    Console.Write("   Postal Address: ");
                    sPostalAddress_F = Console.ReadLine();
                }
                else
                    break;
            }
            Console.Write("   City: ");
            sCity_F = Console.ReadLine();
            while (true)
            {
                if (!Regex.IsMatch(sCity_F, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("*** City cannot contain other signs than numbers ***");
                    Console.Write("   City: ");
                    sCity_F = Console.ReadLine();
                }
                else
                    break;
            }

            Console.WriteLine("--- Contract---");
            Console.WriteLine("  Date Of Conclusion : ");
            while (true)
            {
                int iDay, iMonth, iYear;
                string sDayAdd0 = "", sMonthAdd0 = "", sDayAdd0_1 = "", sMonthAdd0_1 = "";
                DateTime ActualDateTime = DateTime.Today;
                int iNowDay = int.Parse(ActualDateTime.Day.ToString());
                int iNowMonth = int.Parse(ActualDateTime.Month.ToString());
                int iNowYear = int.Parse(ActualDateTime.Year.ToString());
                if (Regex.IsMatch(ActualDateTime.Day.ToString(), @"^[0-9]{1}$"))
                {
                    sDayAdd0_1 = "0";
                }
                if (Regex.IsMatch(ActualDateTime.Month.ToString(), @"^[0-9]{1}$"))
                {
                    sMonthAdd0_1 = "0";
                }
                Console.WriteLine("Today's date : {0}{1}-{2}{3}-{4}", sDayAdd0_1, iNowDay, sMonthAdd0_1, iNowMonth, iNowYear);

                Console.Write("   Day (DD): ");
                string sDay = Console.ReadLine();
                while (true)
                {
                    if (!Regex.IsMatch(sDay, @"^[0-9]{1,2}$"))
                    {
                        Console.WriteLine("*** Day have to consist  1 or 2 number! ***");
                        Console.Write("   Day (DD): ");
                        sDay = Console.ReadLine();
                    }
                    else if (Regex.IsMatch(sDay, @"^[0-9]{1}$"))
                    {
                        sDayAdd0 = "0";
                        iDay = int.Parse(sDay);
                        break;
                    }
                    else
                    {
                        iDay = int.Parse(sDay);
                        break;
                    }
                }
                Console.Write("   Month (MM): ");
                string sMonth = Console.ReadLine();
                while (true)
                {
                    if (!Regex.IsMatch(sMonth, @"^[0-9]{1,2}$"))
                    {
                        Console.WriteLine("*** Month have to consist of 1 or 2 number!  ***");
                        Console.Write("   Month (MM): ");
                        sMonth = Console.ReadLine();
                    }
                    else if (Regex.IsMatch(sMonth, @"^[0-9]{1}$"))
                    {
                        sMonthAdd0 = "0";
                        iMonth = int.Parse(sMonth);
                        break;
                    }
                    else
                    {
                        iMonth = int.Parse(sMonth);
                        break;
                    }
                }
                Console.Write("   Year (YYYY): ");
                string sYear = Console.ReadLine();
                while (true)
                {
                    if (!Regex.IsMatch(sYear, @"^[0-9]{4}$"))
                    {
                        Console.WriteLine("*** Year have to consist of 4 or more number! ***");
                        Console.Write("   Year (YYYY): ");
                        sYear = Console.ReadLine();
                    }
                    else
                    {
                        iYear = int.Parse(sYear);
                        break;
                    }
                }

                if ((iMonth > 12))
                {
                    Console.WriteLine("*** Incorrect Month! ***");
                }
                else if ((iDay > 31))
                {
                    Console.WriteLine("*** Incorrect Day! ***");
                }
                else if (((iMonth == 2) || (iMonth == 4) || (iMonth == 6) || (iMonth == 9) || (iMonth == 11)) && (iDay > 30))
                {
                    Console.WriteLine("*** Incorrect Day! ***");
                }
                else if (((iYear % 4 == 0) && (iYear % 100 != 0) || (iYear % 400 == 0)) && (iMonth == 2) && (iDay > 29))
                {
                    Console.WriteLine("*** Incorrect Day! ***");
                }
                else if (!(((iYear % 4 == 0) && (iYear % 100 != 0) || (iYear % 400 == 0))) && (iMonth == 2) && (iDay > 28))
                {
                    Console.WriteLine("*** Incorrect Day! ***");
                }
                else
                {
                    sDateOfConclusion_F = sDayAdd0 + iDay.ToString() + "-" + sMonthAdd0 + iMonth.ToString() + "-" + iYear.ToString();
                    Console.WriteLine("Date of conclusion: {0}", sDateOfConclusion_F);
                    break;
                }
            }
            Console.Write("   Typ Umowy: ");
            sContractType_F = Console.ReadLine();
            while (true)
            {
                if (!Regex.IsMatch(sContractType_F, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("*** Contract type may not contain characters other than letters! ***");
                    Console.Write("   Contract type: ");
                    sContractType_F = Console.ReadLine();
                }
                else
                    break;
            }
            Console.Write("   Contract time: ");
            sContractTime_F = Console.ReadLine();
            while (true)
            {
                if (!Regex.IsMatch(sContractTime_F, @"^[0-9]+$"))
                {
                    Console.WriteLine("*** The Contract Time may not contain characters other than Numbers! ***");
                    Console.Write("   Contract Time: ");
                    sContractTime_F = Console.ReadLine();
                    iContractTime_F = Convert.ToInt32(sContractTime_F);
                }
                else
                {
                    iContractTime_F = Convert.ToInt32(sContractTime_F);
                    break;
                }
            }

            Address newAddress = new Address(sStreet_F, iHouseNumber_F, sPostalAddress_F, sCity_F);
            ContractOfEmployment newContractOfEmployment = new ContractOfEmployment(sDateOfConclusion_F, sContractType_F, iContractTime_F);

            EmployeeList.Add(new Person(sName_F, sSurname_F, sRegNumber_F, newAddress, sDateOfBirth_F, newContractOfEmployment));
        }

        public void Search_Employees_by_category()
        {
            Address newAddress = new Address("", 0, "", "");
            ContractOfEmployment newContractOfEmployment = new ContractOfEmployment("", "", 0);
            Person SearchedPerson = new Person("", "", "", newAddress, "", newContractOfEmployment);

            char cOption;
            do
            {
                Console.Clear();
                Console.WriteLine("Search by:");
                Console.WriteLine("   1. Surname ");
                Console.WriteLine("   2. Name ");
                Console.WriteLine("   3. Registration Number ");
                Console.WriteLine("   4. City ");
                Console.WriteLine("   5. Contract of employment ");
                Console.WriteLine("   6. Date of birth ");
                Console.WriteLine("   0. End searching ");
                cOption = Console.ReadKey(true).KeyChar;
                Console.Clear();

                switch (cOption)
                {
                    case '0':
                        break;
                    case '1':
                        string sParameter;
                        Console.Write("Please enter the person's name: ");
                        sParameter = Console.ReadLine();
                        while (true)
                        {
                            if (!Regex.IsMatch(sParameter, @"^[a-zA-Z]+$"))
                            {
                                Console.WriteLine("*** The name cannot contain any characters other than letters! ***");
                                Console.Write("   Surname: ");
                                sParameter = Console.ReadLine();
                            }
                            else
                                break;
                        }
                        SearchedPerson = EmployeeList.Find(tag => tag.sSurname == sParameter);

                        if (SearchedPerson != null)
                        {
                            Console.WriteLine(SearchedPerson.Date());
                        }
                        else
                        {
                            Console.WriteLine("There is no such person on the list");
                        }
                        end();
                        break;
                    case '2':
                        Console.Write("Please enter the person's name:");
                        sParameter = Console.ReadLine();
                        while (true)
                        {
                            if (!Regex.IsMatch(sParameter, @"^[a-zA-Z]+$"))
                            {
                                Console.WriteLine("*** The name cannot contain any characters other than letters! ***");
                                Console.Write("   Name: ");
                                sParameter = Console.ReadLine();
                            }
                            else
                                break;
                        }
                        SearchedPerson = EmployeeList.Find(tag => tag.sName == sParameter);

                        if (SearchedPerson != null)
                        {
                            Console.WriteLine(SearchedPerson.Date());
                        }
                        else
                        {
                            Console.WriteLine("There is no such person on the list");
                        }
                        end();
                        break;
                    case '3':
                        Console.Write("Please enter the person's Registration Number: ");
                        sParameter = Console.ReadLine();
                        while (true)
                        {
                            if (!Regex.IsMatch(sParameter, @"^[0-9]{4,}$"))
                            {
                                Console.WriteLine("*** The Registration Number must consist of 4 or more digits! ***");
                                Console.Write("   Registration Number: ");
                                sParameter = Console.ReadLine();
                            }
                            else
                                break;
                        }
                        SearchedPerson = EmployeeList.Find(tag => tag.sRegNumber == sParameter);

                        if (SearchedPerson != null)
                        {
                            Console.WriteLine(SearchedPerson.Date());
                        }
                        else
                        {
                            Console.WriteLine("There is no such person on the list");
                        }
                        end();
                        break;
                    case '4':
                        Console.Write("Please enter the city in which the person lives ");
                        sParameter = Console.ReadLine();
                        while (true)
                        {
                            if (!Regex.IsMatch(sParameter, @"^[a-zA-Z]+$"))
                            {
                                Console.WriteLine("*** The city cannot contain any characters other than letters! ***");
                                Console.Write("   City: ");
                                sParameter = Console.ReadLine();
                            }
                            else
                                break;
                        }
                        SearchedPerson = EmployeeList.Find(tag => tag.Address.sCity == sParameter);

                        if (SearchedPerson != null)
                        {
                            Console.WriteLine(SearchedPerson.Date());
                        }
                        else
                        {
                            Console.WriteLine("There is no such person on the list");
                        }
                        end();
                        break;
                    case '5':
                        Console.Write("Please enter the Contract Type of the person: ");
                        sParameter = Console.ReadLine();
                        while (true)
                        {
                            if (!Regex.IsMatch(sParameter, @"^[a-zA-Z]+$"))
                            {
                                Console.WriteLine("*** Contract type may not contain characters other than letters! ***");
                                Console.Write("   Contract type: ");
                                sParameter = Console.ReadLine();
                            }
                            else
                                break;
                        }
                        SearchedPerson = EmployeeList.Find(tag => tag.ContractOfEmployment.sContractType == sParameter);

                        if (SearchedPerson != null)
                        {
                            Console.WriteLine(SearchedPerson.Date());
                        }
                        else
                        {
                            Console.WriteLine("There is no such person on the list");
                        }
                        end();
                        break;
                    case '6':
                        Console.WriteLine("  Date of birth:");
                        while (true)
                        {
                            DateTime ActualDateTime = DateTime.Today;
                            int iNowDay = int.Parse(ActualDateTime.Day.ToString());
                            int iNowMonth = int.Parse(ActualDateTime.Month.ToString());
                            int iNowYear = int.Parse(ActualDateTime.Year.ToString());
                            int iDay, iMonth, iYear;
                            string sDayAdd0 = "", sMonthAdd0 = "";
                            Console.Write("   Day (DD): ");
                            string sDay = Console.ReadLine();
                            while (true)
                            {
                                if (!Regex.IsMatch(sDay, @"^[0-9]{1,2}$"))
                                {
                                    Console.WriteLine("*** Day have to consist of 1 or 2 number! ***");
                                    Console.Write("   Day (DD): ");
                                    sDay = Console.ReadLine();
                                }
                                else if (Regex.IsMatch(sDay, @"^[0-9]{1}$"))
                                {
                                    sDayAdd0 = "0";
                                    iDay = int.Parse(sDay);
                                    break;
                                }
                                else
                                {
                                    iDay = int.Parse(sDay);
                                    break;
                                }
                            }
                            Console.Write("   Month (MM): ");
                            string sMonth = Console.ReadLine();
                            while (true)
                            {
                                if (!Regex.IsMatch(sMonth, @"^[0-9]{1,2}$"))
                                {
                                    Console.WriteLine("*** Month have to consist of 1 or 2 number!  ***");
                                    Console.Write("   Month (MM): ");
                                    sMonth = Console.ReadLine();
                                }
                                else if (Regex.IsMatch(sMonth, @"^[0-9]{1}$"))
                                {
                                    sMonthAdd0 = "0";
                                    iMonth = int.Parse(sMonth);
                                    break;
                                }
                                else
                                {
                                    iMonth = int.Parse(sMonth);
                                    break;
                                }
                            }
                            Console.Write("   Year (YYYY): ");
                            string sYear = Console.ReadLine();
                            while (true)
                            {
                                if (!Regex.IsMatch(sYear, @"^[0-9]{4}$"))
                                {
                                    Console.WriteLine("*** Year have to consist of 4 or more number! ***");
                                    Console.Write("   Year (YYYY): ");
                                    sYear = Console.ReadLine();
                                }
                                else
                                {
                                    iYear = int.Parse(sYear);
                                    break;
                                }
                            }

                            if (iYear > iNowYear)
                            {
                                Console.WriteLine("*** Incorrect Year! ***");
                            }
                            else if ((iYear == iNowYear) && (iMonth > iNowMonth))
                            {
                                Console.WriteLine("*** Incorrect Month! ***");
                            }
                            else if ((iYear < iNowYear) && (iMonth > 12))
                            {
                                Console.WriteLine("*** Incorrect Month! ***");
                            }
                            else if ((iYear == iNowYear) && (iMonth == iNowMonth) && (iDay > iNowDay))
                            {
                                Console.WriteLine("*** Incorrect Day! ***");
                            }
                            else if ((iYear < iNowYear) && (iMonth < 13) && (iDay > 31))
                            {
                                Console.WriteLine("*** Incorrect Day! ***");
                            }
                            else if ((iYear < iNowYear) && ((iMonth == 2) || (iMonth == 4) || (iMonth == 6) || (iMonth == 9) || (iMonth == 11)) && (iDay > 30))
                            {
                                Console.WriteLine("*** Incorrect Day! ***");
                            }
                            else if ((iYear < iNowYear) && ((iYear % 4 == 0) && (iYear % 100 != 0) || (iYear % 400 == 0)) && (iMonth == 2) && (iDay > 29))
                            {
                                Console.WriteLine("*** Incorrect Day! ***");
                            }
                            else if ((iYear < iNowYear) && !(((iYear % 4 == 0) && (iYear % 100 != 0) || (iYear % 400 == 0))) && (iMonth == 2) && (iDay > 28))
                            {
                                Console.WriteLine("*** Incorrect Day! ***");
                            }
                            else
                            {
                                sParameter = sDayAdd0 + iDay.ToString() + "-" + sMonthAdd0 + iMonth.ToString() + "-" + iYear.ToString();
                                Console.WriteLine("Date of birth: {0}", sParameter);
                                break;
                            }
                        }
                        SearchedPerson = EmployeeList.Find(nazw => nazw.sDateOfBrith == sParameter);

                        if (SearchedPerson != null)
                        {
                            Console.WriteLine(SearchedPerson.Date());
                        }
                        else
                        {
                            Console.WriteLine("There is no such person on the list");
                        }
                        end();
                        break;
                    default:
                        Console.WriteLine("Nie wybrano żadnej akcji! ");
                        break;
                }
            } while (cOption != '0');

        }


        public void ShowEmployees()
        {
            Console.WriteLine("--- Employes List ---");
            foreach (Person O in EmployeeList)
            {
                Console.WriteLine(O.ToString());
            }
        }

        public void Change_Address()
        {
            string sParameter;
            Console.Write("Enter the registration number of the person whose address you want to edit: ");
            sParameter = Console.ReadLine();
            while (true)
            {
                if (!Regex.IsMatch(sParameter, @"^[0-9]{4,}$"))
                {
                    Console.WriteLine("*** The Registration Number have to consist of 4 or more number!  ***");
                    Console.WriteLine("Enter the registration number of the employee you want to edit:");
                    sParameter = Console.ReadLine();
                }
                else
                    break;
            }
            Person SearchedPerson = EmployeeList.Find(number => number.sRegNumber == sParameter);

            if (SearchedPerson != null)
            {
                Console.WriteLine(" Person details for editing the home address {0}", SearchedPerson);
                Console.Write("   Street: ");
                string sNewStreet = Console.ReadLine();
                while (true)
                {
                    if (!Regex.IsMatch(sNewStreet, @"^[a-zA-Z]+$"))
                    {
                        Console.WriteLine("*** The street may not contain other signs than letters! ***");
                        Console.Write("   Street: ");
                        sNewStreet = Console.ReadLine();
                    }
                    else
                        break;
                }
                Console.Write("   House Number: ");
                string sNewHouseNumber = Console.ReadLine();
                int iNewNumber;
                while (true)
                {
                    if (!Regex.IsMatch(sNewHouseNumber, @"^[0-9]+$"))
                    {
                        Console.WriteLine("*** The House Number cannot contain characters other than Numbers! ***");
                        Console.Write("   House Number: ");
                        sNewHouseNumber = Console.ReadLine();
                        iNewNumber = Convert.ToInt32(sNewHouseNumber);
                    }
                    else
                    {
                        iNewNumber = int.Parse(sNewHouseNumber);
                        break;
                    }
                }
                Console.Write("   Postal Address: ");
                string sNewPostalAddress = Console.ReadLine();
                while (true)
                {
                    if (!Regex.IsMatch(sNewPostalAddress, @"^[0-9]{2}\-[0-9]{3}$"))
                    {
                        Console.WriteLine("*** Postal Code must contain " + "-" + " and cannot contain characters other than Numbers! ***");
                        Console.Write("   Postal Address: ");
                        sNewPostalAddress = Console.ReadLine();
                    }
                    else
                        break;
                }
                Console.Write("   City: ");
                string sNewCity = Console.ReadLine();
                while (true)
                {
                    if (!Regex.IsMatch(sNewCity, @"^[a-zA-Z]+$"))
                    {
                        Console.WriteLine("*** The city cannot contain any characters other than letters! ***");
                        Console.Write("   City: ");
                        sNewCity = Console.ReadLine();
                    }
                    else
                        break;
                }
                string sNewName = SearchedPerson.sName;
                string sNewSurname = SearchedPerson.sSurname;
                string sNewRegNumber = SearchedPerson.sRegNumber;
                string sNewDateOfBirth = SearchedPerson.sDateOfBrith;

                string sNewDateOfConclusion = SearchedPerson.ContractOfEmployment.sDateOfConclusion;
                string sNewContractType = SearchedPerson.ContractOfEmployment.sContractType;
                int iNewContractTime = SearchedPerson.ContractOfEmployment.iContractTime;

                ContractOfEmployment newContractOfEmployment = new ContractOfEmployment(sNewDateOfConclusion, sNewContractType, iNewContractTime);

                Address NewAddress = new Address(sNewStreet, iNewNumber, sNewPostalAddress, sNewCity);
                EmployeeList.Remove(SearchedPerson);
                EmployeeList.Add(new Person(sNewName, sNewSurname, sNewRegNumber, NewAddress, sNewDateOfBirth, newContractOfEmployment));
            }
        }

        public void Change_Personal_Data()
        {
            string sParameter;
            string sNewName, sNewSurname, sNewDateOfBirth;
            Console.Write("Enter the registration number of the person whose personal data you want to change: ");
            sParameter = Console.ReadLine();

            Person SearchedPerson = EmployeeList.Find(number => number.sRegNumber == sParameter);

            if (SearchedPerson != null)
            {
                Console.WriteLine("Person data to change personal data {0}", SearchedPerson);
                Console.Write("   Name: ");
                sNewName = Console.ReadLine();
                while (true)
                {
                    if (!Regex.IsMatch(sNewName, @"^[a-zA-Z]+$"))
                    {
                        Console.WriteLine("*** The name cannot contain any characters other than letters! ***");
                        Console.Write("   Name: ");
                        sNewName = Console.ReadLine();
                    }
                    else
                        break;
                }
                Console.Write("   Surname: ");
                sNewSurname = Console.ReadLine();
                while (true)
                {
                    if (!Regex.IsMatch(sNewSurname, @"^[a-zA-Z]+$"))
                    {
                        Console.WriteLine("*** The name cannot contain any characters other than letters! ***");
                        Console.Write("   Surname: ");
                        sNewSurname = Console.ReadLine();
                    }
                    else
                        break;
                }
                Console.WriteLine("  Date of Birth:");
                while (true)
                {
                    DateTime ActualDateTime = DateTime.Today;
                    int iNowDay = int.Parse(ActualDateTime.Day.ToString());
                    int iNowMonth = int.Parse(ActualDateTime.Month.ToString());
                    int iNowYear = int.Parse(ActualDateTime.Year.ToString());
                    int iDay, iMonth, iYear;
                    string sDayAdd0 = "", sMonthAdd0 = "";
                    Console.Write("   Day (DD): ");
                    string sDay = Console.ReadLine();
                    while (true)
                    {
                        if (!Regex.IsMatch(sDay, @"^[0-9]{1,2}$"))
                        {
                            Console.WriteLine("*** Day have to consist of 1 or 2 number! ***");
                            Console.Write("   Day (DD): ");
                            sDay = Console.ReadLine();
                        }
                        else if (Regex.IsMatch(sDay, @"^[0-9]{1}$"))
                        {
                            sDayAdd0 = "0";
                            iDay = int.Parse(sDay);
                            break;
                        }
                        else
                        {
                            iDay = int.Parse(sDay);
                            break;
                        }
                    }
                    Console.Write("   Month (MM): ");
                    string sMonth = Console.ReadLine();
                    while (true)
                    {
                        if (!Regex.IsMatch(sMonth, @"^[0-9]{1,2}$"))
                        {
                            Console.WriteLine("*** Month have to consist of 1 or 2 number!  ***");
                            Console.Write("   Month (MM): ");
                            sMonth = Console.ReadLine();
                        }
                        else if (Regex.IsMatch(sMonth, @"^[0-9]{1}$"))
                        {
                            sMonthAdd0 = "0";
                            iMonth = int.Parse(sMonth);
                            break;
                        }
                        else
                        {
                            iMonth = int.Parse(sMonth);
                            break;
                        }
                    }
                    Console.Write("   Year (YYYY): ");
                    string sYear = Console.ReadLine();
                    while (true)
                    {
                        if (!Regex.IsMatch(sYear, @"^[0-9]{4}$"))
                        {
                            Console.WriteLine("*** Year have to consist of 4 or more number! ***");
                            Console.Write("   Year (YYYY): ");
                            sYear = Console.ReadLine();
                        }
                        else
                        {
                            iYear = int.Parse(sYear);
                            break;
                        }
                    }

                    if (iYear > iNowYear)
                    {
                        Console.WriteLine("*** Incorrect Year! ***");
                    }
                    else if ((iYear == iNowYear) && (iMonth > iNowMonth))
                    {
                        Console.WriteLine("*** Incorrect Month! ***");
                    }
                    else if ((iYear < iNowYear) && (iMonth > 12))
                    {
                        Console.WriteLine("*** Incorrect Month! ***");
                    }
                    else if ((iYear == iNowYear) && (iMonth == iNowMonth) && (iDay > iNowDay))
                    {
                        Console.WriteLine("*** Incorrect Day! ***");
                    }
                    else if ((iYear < iNowYear) && (iMonth < 13) && (iDay > 31))
                    {
                        Console.WriteLine("*** Incorrect Day! ***");
                    }
                    else if ((iYear < iNowYear) && ((iMonth == 2) || (iMonth == 4) || (iMonth == 6) || (iMonth == 9) || (iMonth == 11)) && (iDay > 30))
                    {
                        Console.WriteLine("*** Incorrect Day! ***");
                    }
                    else if ((iYear < iNowYear) && ((iYear % 4 == 0) && (iYear % 100 != 0) || (iYear % 400 == 0)) && (iMonth == 2) && (iDay > 29))
                    {
                        Console.WriteLine("*** Incorrect Day! ***");
                    }
                    else if ((iYear < iNowYear) && !(((iYear % 4 == 0) && (iYear % 100 != 0) || (iYear % 400 == 0))) && (iMonth == 2) && (iDay > 28))
                    {
                        Console.WriteLine("*** Incorrect Day! ***");
                    }
                    else
                    {
                        sNewDateOfBirth = sDayAdd0 + iDay.ToString() + "-" + sMonthAdd0 + iMonth.ToString() + "-" + iYear.ToString();
                        Console.WriteLine("   Date of Birth: {0}", sNewDateOfBirth);
                        break;
                    }
                }

                string sNewStreet = SearchedPerson.Address.sStreet;
                string sNewPostalAddress = SearchedPerson.Address.sPostalAddress;
                int sNewHouseNumber = SearchedPerson.Address.iHouseNumber;
                string sNewCity = SearchedPerson.Address.sCity;
                string sNewRegNumber = SearchedPerson.sRegNumber;

                string sNewDateOfConclusion = SearchedPerson.ContractOfEmployment.sDateOfConclusion;
                string sNewContractType = SearchedPerson.ContractOfEmployment.sContractType;
                int iNewContractTime = SearchedPerson.ContractOfEmployment.iContractTime;

                Address NewAddress = new Address(sNewStreet, sNewHouseNumber, sNewPostalAddress, sNewCity);
                ContractOfEmployment NewContractOfEmployment = new ContractOfEmployment(sNewDateOfConclusion, sNewContractType, iNewContractTime);

                EmployeeList.Remove(SearchedPerson);
                EmployeeList.Add(new Person(sNewName, sNewSurname, sNewRegNumber, NewAddress, sNewDateOfBirth, NewContractOfEmployment));
            }
        }

        public void Change_Contract_of_Employment()
        {
            string sParameter;
            Console.Write("Enter the registration number of the employee whose contract requires a change: ");
            sParameter = Console.ReadLine();
            while (true)
            {
                if (!Regex.IsMatch(sParameter, @"^[0-9]{4,}$"))
                {
                    Console.WriteLine("*** The Registration Number have to consist of 4 or more number!  ***");
                    Console.Write("   Registration Number: ");
                    sParameter = Console.ReadLine();
                }
                else
                    break;
            }
            Person SearchedPerson = EmployeeList.Find(number => number.sRegNumber == sParameter);

            if (SearchedPerson != null)
            {
                Console.Write("   Enter the type of contract: ");
                string sNewContractType = Console.ReadLine();

                Console.WriteLine("Date of conclusion of the contract (DD-MM-YYYY): ");
                string sNewDateOfConclusion;
                while (true)
                {
                    int iDay, iMonth, iYear;
                    string sDayAdd0 = "", sMonthAdd0 = "", sDayAdd0_1 = "", sMonthAdd0_1 = "";
                    DateTime ActualDateTime = DateTime.Today;
                    int iNowDay = int.Parse(ActualDateTime.Day.ToString());
                    int iNowMonth = int.Parse(ActualDateTime.Month.ToString());
                    int iNowYear = int.Parse(ActualDateTime.Year.ToString());
                    if (Regex.IsMatch(ActualDateTime.Day.ToString(), @"^[0-9]{1}$"))
                    {
                        sDayAdd0_1 = "0";
                    }
                    if (Regex.IsMatch(ActualDateTime.Month.ToString(), @"^[0-9]{1}$"))
                    {
                        sDayAdd0_1 = "0";
                    }
                    Console.WriteLine(" Today's Date: {0}{1}-{2}{3}-{4}", sDayAdd0_1, iNowDay, sMonthAdd0_1, iNowMonth, iNowYear);

                    Console.Write("   Day (DD): ");
                    string sDay = Console.ReadLine();
                    while (true)
                    {
                        if (!Regex.IsMatch(sDay, @"^[0-9]{1,2}$"))
                        {
                            Console.WriteLine("*** Day have to consist of 1 or 2 number! ***");
                            Console.Write("   Day (DD): ");
                            sDay = Console.ReadLine();
                        }
                        else if (Regex.IsMatch(sDay, @"^[0-9]{1}$"))
                        {
                            sDayAdd0 = "0";
                            iDay = int.Parse(sDay);
                            break;
                        }
                        else
                        {
                            iDay = int.Parse(sDay);
                            break;
                        }
                    }
                    Console.Write("   Month (MM): ");
                    string SMiesiac = Console.ReadLine();
                    while (true)
                    {
                        if (!Regex.IsMatch(SMiesiac, @"^[0-9]{1,2}$"))
                        {
                            Console.WriteLine("*** Month have to consist of 1 or 2 number!  ***");
                            Console.Write("   Month (MM): ");
                            SMiesiac = Console.ReadLine();
                        }
                        else if (Regex.IsMatch(SMiesiac, @"^[0-9]{1}$"))
                        {
                            sMonthAdd0 = "0";
                            iMonth = int.Parse(SMiesiac);
                            break;
                        }
                        else
                        {
                            iMonth = int.Parse(SMiesiac);
                            break;
                        }
                    }
                    Console.Write("   Year (YYYY): ");
                    string SRok = Console.ReadLine();
                    while (true)
                    {
                        if (!Regex.IsMatch(SRok, @"^[0-9]{4}$"))
                        {
                            Console.WriteLine("*** Year have to consist of 4 or more number! ***");
                            Console.Write("   Year (YYYY): ");
                            SRok = Console.ReadLine();
                        }
                        else
                        {
                            iYear = int.Parse(SRok);
                            break;
                        }
                    }

                    if ((iMonth > 12))
                    {
                        Console.WriteLine("*** Incorrect Month! ***");
                    }
                    else if ((iDay > 31))
                    {
                        Console.WriteLine("*** Incorrect Day! ***");
                    }
                    else if (((iMonth == 2) || (iMonth == 4) || (iMonth == 6) || (iMonth == 9) || (iMonth == 11)) && (iDay > 30))
                    {
                        Console.WriteLine("*** Incorrect Day! ***");
                    }
                    else if (((iYear % 4 == 0) && (iYear % 100 != 0) || (iYear % 400 == 0)) && (iMonth == 2) && (iDay > 29))
                    {
                        Console.WriteLine("*** Incorrect Day! ***");
                    }
                    else if (!(((iYear % 4 == 0) && (iYear % 100 != 0) || (iYear % 400 == 0))) && (iMonth == 2) && (iDay > 28))
                    {
                        Console.WriteLine("*** Incorrect Day! ***");
                    }
                    else
                    {
                        sNewDateOfConclusion = sDayAdd0 + iDay.ToString() + "-" + sMonthAdd0 + iMonth.ToString() + "-" + iYear.ToString();
                        Console.WriteLine("   Date of conclusion: {0}", sNewDateOfConclusion);
                        break;
                    }
                }
                Console.Write("   Contract Time: ");
                string sNewContractTime = Console.ReadLine();
                int iNewTimeContract;
                while (true)
                {
                    if (!Regex.IsMatch(sNewContractTime, @"^[0-9]+$"))
                    {
                        Console.WriteLine("*** The Contract Time may not contain characters other than Numbers! ***");
                        Console.Write("   Contract Time: ");
                        sNewContractTime = Console.ReadLine();
                        iNewTimeContract = int.Parse(sNewContractTime);
                    }
                    else
                    {
                        iNewTimeContract = int.Parse(sNewContractTime);
                        break;
                    }
                }
                string sNewName = SearchedPerson.sName;
                string sNewSurname = SearchedPerson.sSurname;
                string sNewRegNumber = SearchedPerson.sRegNumber;
                string sNewDateOfBirth = SearchedPerson.sDateOfBrith;

                string sNewStreet = SearchedPerson.Address.sStreet;
                int iNewHouseNumber = SearchedPerson.Address.iHouseNumber;
                string sNewPostalAddress = SearchedPerson.Address.sPostalAddress;
                string sNewCity = SearchedPerson.Address.sCity;


                ContractOfEmployment newContractOfEmployment = new ContractOfEmployment(sNewDateOfConclusion, sNewContractType, iNewTimeContract);
                Address newAddress = new Address(sNewStreet, iNewHouseNumber, sNewPostalAddress, sNewCity);

                EmployeeList.Remove(SearchedPerson);
                EmployeeList.Add(new Person(sNewName, sNewSurname, sNewRegNumber, newAddress, sNewDateOfBirth, newContractOfEmployment));
            }
        }

        public void Delete_Employee()
        {
            {
                string sParameter;
                Console.WriteLine("Enter the registration number of the employee you want to delete:");
                sParameter = Console.ReadLine();
                while (true)
                {
                    if (!Regex.IsMatch(sParameter, @"^[0-9]{4,}$"))
                    {
                        Console.WriteLine("*** The Registration Number have to consist of 4 or more number!  ***");
                        Console.Write("   Enter the registration number of the employee you want to delete: ");
                        sParameter = Console.ReadLine();
                    }
                    else
                        break;
                }
                Person SearchedPerson = EmployeeList.Find(number => number.sRegNumber == sParameter);
                if (SearchedPerson != null)
                {
                    string x;
                    Console.WriteLine("Are you sure you want to delete{0}?", SearchedPerson);
                    Console.WriteLine("CONFIRMATION ENTER (YES) or (NO)");
                    x = Console.ReadLine();
                    if (x == "YES" || x == "NO" || x == "yes" || x == "no")
                    {
                        if (x == "YES" || x == "yes")
                        {
                            EmployeeList.Remove(SearchedPerson);
                            Console.WriteLine("You deleted {0}", SearchedPerson);
                        }
                        else
                        {
                            Console.WriteLine("The employee has not been removed!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have typed incorrectly, enter YES or NO!");
                    }
                }
            }
        }

        public void end()
        {
            Console.WriteLine();
            if (cOption != '0')
            {
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
            }
        }
    }
}