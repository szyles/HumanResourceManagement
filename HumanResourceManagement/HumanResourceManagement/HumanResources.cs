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
        FormHR F = new FormHR();
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
            string sName_F, sSurname_F, sRegNumber_F, sDateOfBirth_F, sDateOfConclusion_F, sContractType_F, sStreet_F, sPostalAddress_F, sCity_F;
            int iContractTime_F, iHouseNumber_F;
            
            Console.WriteLine("--- Personal Data ---");

            sName_F = F.sText(
                "Name", "Name cannot contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                );
            sSurname_F = F.sText(
                "Surname", "Surname cannot contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                );
            string sTest = F.sText(
                "Registration Number", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
                );
            sRegNumber_F = IdentificationNumberCheck(sTest);


            sDateOfBirth_F = F.DateOf(
                "Birth"
                );

            Console.WriteLine("--- Address ---");
                sStreet_F = F.sText(
                "Street", "The Street must not contain other signs than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                );
            iHouseNumber_F = F.iNumber(
                "House Number", "The House Number cannot contain characters other than numbers!", "^[0-9]+$"
                );
                sPostalAddress_F = F.sText(
                "Postal Address (XX-XXX)", "Postal Address have to contain " + "-" + " and cannot contain characters other than numbers!", "^[0-9]{2}-[0-9]{3}$"
                );
            sCity_F = F.sText(
                "City", "The City must not contain other signs than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                );

            Console.WriteLine("--- Contract---");
                sDateOfConclusion_F = F.DateOf(
                    "Conclusion"
                    );

            char Option;
            Console.WriteLine("Choose Contract Type: ");
            Console.WriteLine("1.B2B");
            Console.WriteLine("2.Trial");
            Console.WriteLine("2.Fixed - term contract");

            Option = Console.ReadKey(true).KeyChar;

            sContractType_F = "";

            switch (Option)
            {
                default:
                    break;

                case '1':
                    sContractType_F = "B2B";
                    break;
                case '2':
                    sContractType_F = "Trial";
                    break;
                case '3':
                    sContractType_F = "Fixed - term contract";
                    break;

            }
            iContractTime_F = F.iNumber(
                "Contract time", "The Contract Time may not contain characters other than numbers!", "^[0-9]+$"
                );

            Address newAddress = new Address(
                sStreet_F, iHouseNumber_F, sPostalAddress_F, sCity_F
                );
            ContractOfEmployment newContractOfEmployment = new ContractOfEmployment(
                sDateOfConclusion_F, sContractType_F, iContractTime_F
                );

            EmployeeList.Add(
                new Person(
                    sName_F, sSurname_F, sRegNumber_F, newAddress, sDateOfBirth_F, newContractOfEmployment
                    )
                );
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

                string sParameter;
                switch (cOption)
                {
                    case '0':
                        break;
                    case '1':
                        sParameter = F.sText(
                             "Please enter the person's surname", "Surname cannot contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                            );

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
                        sParameter = F.sText(
                             "Please enter the person's name", "Name cannot contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                            );
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
                        sParameter = F.sText(
                            "Please enter the person's Registration Number", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
                            );
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
                        sParameter = F.sText(
                            "Please enter the city in which the person lives", "City cannot contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                            );
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
                        sParameter = F.sText(
                            "Please enter the Contract Type of the person", "Contract type may not contain characters other than letters!", "^[a-zA-Z]+$"
                            );

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
                        sParameter = F.DateOf(
                            "Birth"
                            );
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
                        Console.WriteLine("Action wasn't selected! ");
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
            sParameter = F.sText(
                "Enter the registration number of the person whose address you want to edit", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
                );
           
            Person SearchedPerson = EmployeeList.Find(number => number.sRegNumber == sParameter);

            if (SearchedPerson != null)
            {
                Console.WriteLine(" Person details for editing the home address {0}", SearchedPerson);
                string sNewStreet = F.sText(
                "Street", "The Street must not contain other signs than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                );
                int iNewNumber = F.iNumber(
                "House Number", "The House Number cannot contain characters other than numbers!", "^[0-9]+$"
                );
                string sNewPostalAddress = F.sText(
                "Postal Address (XX-XXX)", "Postal Address have to contain " + "-" + " and cannot contain characters other than numbers!", "^[0-9]{2}-[0-9]{3}$"
                );
                string sNewCity = F.sText(
                "City", "The City must not contain other signs than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                );

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
            sParameter = F.sText(
                "Enter the registration number of the person whose personal data you want to change", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
                );

            Person SearchedPerson = EmployeeList.Find(number => number.sRegNumber == sParameter);

            if (SearchedPerson != null)
            {
                Console.WriteLine("Person data to change personal data {0}", SearchedPerson);
                sNewName = F.sText(
                    "Name", "Name cannot contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                    );

                sNewSurname = F.sText(
                    "Surname", "Surname cannot contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                    );
                sNewDateOfBirth = F.DateOf(
                    "Birth"
                    );

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

            sParameter = F.sText(
                "Enter the registration number of the employee whose contract requires a change", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
                );
            Person SearchedPerson = EmployeeList.Find(number => number.sRegNumber == sParameter);

            if (SearchedPerson != null)
            {
                string sNewContractType = F.sText(
                "Contract type", "Contract type may not contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                );

                string sNewDateOfConclusion = F.DateOf(
                    "Conclusion"
                    );
                int iNewTimeContract = F.iNumber(
                "Contract time", "The Contract Time may not contain characters other than numbers!", "^[0-9]+$"
                );
               
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
                sParameter = F.sText(
                "Enter the registration number of the employee you want to delete", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
                );
                Person SearchedPerson = EmployeeList.Find(number => number.sRegNumber == sParameter);
                if (SearchedPerson != null)
                {
                    Console.WriteLine("Are you sure you want to delete{0}?", SearchedPerson);
                    Console.WriteLine("CONFIRMATION ENTER ([1] YES) or ([2] NO)");
                    char cOption = Console.ReadKey(true).KeyChar;
                    Console.Clear();

                    switch (cOption)
                    {
                        case '1':
                            EmployeeList.Remove(SearchedPerson);
                            Console.WriteLine("You deleted {0}", SearchedPerson);
                            break;
                        case '2':
                            Console.WriteLine("The employee has not been removed!");
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public string IdentificationNumberCheck(string sIdentificationNumberToCheck)
        {
            /*int iWorkersIdentificationNumbers = 100;
            string[] IdentificationNumberTabel = new string[iWorkersIdentificationNumbers];
            int iNumber = 0;

            foreach (Person O in EmployeeList)
            {
                IdentificationNumberTabel[iNumber] = O.sRegNumber;
                iNumber++;
            }*/

            //for (int iCheckingNumber = 0; iCheckingNumber < iWorkersIdentificationNumbers; iCheckingNumber++){
            do{
                if (EmployeeList.Exists(x => x.sRegNumber == sIdentificationNumberToCheck)){
                    Console.WriteLine("This number is occupied. Pick another one.");
                    string sRegNumber_F = F.sText(
                "Registration Number", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$");
                    sIdentificationNumberToCheck = sRegNumber_F;
                } else {
                    Console.WriteLine("1");
                }
            } while (EmployeeList.Exists(x => x.sRegNumber != sIdentificationNumberToCheck));
            // }
            return sIdentificationNumberToCheck;
        }

        public string IdentificationNumberCheckForChangingData(string sIdentificationNumberToCheck2)
        {
            //Address TestingAddress = new Address("",0, "", "");
            //ContractOfEmployment TestingContract = new ContractOfEmployment("", "", 0);
            do
            {
                if (EmployeeList.Exists(x => x.sRegNumber == sIdentificationNumberToCheck2))
                {
                    Console.WriteLine("test");
                    string sTest = sIdentificationNumberToCheck2;
                    sIdentificationNumberToCheck2 = sTest;
                }
                else
                {
                    Console.WriteLine("There is no ID match. Please try again");
                    sIdentificationNumberToCheck2 = F.sText(
                    "Enter the registration number of the employee whose contract requires a change", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
                    );

                }

            } while (EmployeeList.Exists(x => x.sRegNumber == sIdentificationNumberToCheck2));

            return sIdentificationNumberToCheck2;
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