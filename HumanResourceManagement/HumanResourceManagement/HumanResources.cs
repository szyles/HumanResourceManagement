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
        List<Person> Results;
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
            EmployeeList.Add(new Person("Pawel", "Cybulski", "0001", newAddress0001, "30-09-1998", newContractOfEmployment)
                );
            EmployeeList.Add(new Person("Kamil", "Blaz", "0002", newAddress0002, "09-07-1998", newContractOfEmployment)
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
                Console.WriteLine("Select action:");
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
            string sName_F, sSurname_F, sRegNumber_F, sDateOfBirth_F, sDateOfConclusion_F, sContractType_F, sStreet_F, sPostalAddress_F, sCity_F, sRegNumberToCheck_F;
            int iContractTime_F, iHouseNumber_F;

            Console.WriteLine("--- Personal Data ---");

            sName_F = F.sText(
                "Name", "Name cannot contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                );
            sSurname_F = F.sText(

                "Surname", "Surname cannot contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                );
            sRegNumberToCheck_F = F.sText(
                "Registration Number", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
                );

            sRegNumber_F = RegistrationNumberCheck(sRegNumberToCheck_F);

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
            Console.WriteLine("Selecting anything apart given options will result in personal choose contract type option [by hand]");
            Console.WriteLine("1.B2B");
            Console.WriteLine("2.Trial");
            Console.WriteLine("3.Fixed - term contract");

            Option = Console.ReadKey(true).KeyChar;

            sContractType_F = "";

            switch (Option)
            {
                case '1':
                    sContractType_F = "B2B";
                    break;
                case '2':
                    sContractType_F = "Trial";
                    break;
                case '3':
                    sContractType_F = "Fixed - term contract";
                    break;
                default:
                    sContractType_F = F.sText(
                "Contract type", "Contract type may not contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                );

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

                        Results = EmployeeList.FindAll(tag => tag.sSurname.Equals(sParameter));

                        if (Results != null)
                        {
                            foreach (Person O in Results)
                            {
                                Console.WriteLine(O.ToString());
                            }
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
                        Results = EmployeeList.FindAll(tag => tag.sName.Equals(sParameter));

                        if (Results != null)
                        {
                            foreach (Person O in Results)
                            {
                                Console.WriteLine(O.ToString());
                            }
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
                        Results = EmployeeList.FindAll(tag => tag.sRegNumber.Equals(sParameter));

                        if (Results != null)
                        {
                            foreach (Person O in Results)
                            {
                                Console.WriteLine(O.ToString());
                            }
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

                        Results = EmployeeList.FindAll(tag => tag.Address.sCity.Equals(sParameter));

                        if (Results != null)
                        {
                            foreach (Person O in Results)
                            {
                                Console.WriteLine(O.ToString());
                            }
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

                        Results = EmployeeList.FindAll(tag => tag.ContractOfEmployment.sContractType.Equals(sParameter));

                        if (Results != null)
                        {
                            foreach (Person O in Results)
                            {
                                Console.WriteLine(O.ToString());
                            }
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
                        Results = EmployeeList.FindAll(tag => tag.sDateOfBrith.Equals(sParameter));

                        if (Results != null)
                        {
                            foreach (Person O in Results)
                            {
                                Console.WriteLine(O.ToString());
                            }
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
            string sParameter, sCheckingParameter;
            sCheckingParameter = F.sText(
                "Enter the registration number of the person whose address you want to edit", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
                );

            sParameter = RegistrationNumberToChangeDataCheck(sCheckingParameter);

            Person SearchedPerson = EmployeeList.Find(number => number.sRegNumber == sParameter);

            if (SearchedPerson != null){
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

                Address NewAddress = new Address(sNewStreet, iNewNumber, sNewPostalAddress, sNewCity);
                EmployeeList.Add(new Person(SearchedPerson.sName, SearchedPerson.sSurname, SearchedPerson.sRegNumber, NewAddress, SearchedPerson.sDateOfBrith, SearchedPerson.ContractOfEmployment));
                EmployeeList.Remove(SearchedPerson);
            }
        }

        public void Change_Personal_Data()
        {
            string sParameter, sCheckingParameter;
            sCheckingParameter = F.sText(
                "Enter the registration number of the person whose personal data you want to change", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
                );

            sParameter = RegistrationNumberToChangeDataCheck(sCheckingParameter);

            Person SearchedPerson = EmployeeList.Find(number => number.sRegNumber == sParameter);

            if (SearchedPerson != null)
            {
                Console.WriteLine("Person data to change personal data {0}", SearchedPerson);
                string sNewName = F.sText(
                    "Name", "Name cannot contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                    );

                string sNewSurname = F.sText(
                    "Surname", "Surname cannot contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                    );
                string sNewDateOfBirth = F.DateOf(
                    "Birth"
                    );

                EmployeeList.Add(new Person(sNewName, sNewSurname, SearchedPerson.sRegNumber, SearchedPerson.Address, sNewDateOfBirth, SearchedPerson.ContractOfEmployment));
                EmployeeList.Remove(SearchedPerson);
            }
        }

        public void Change_Contract_of_Employment()
        {
            string sParameter, sCheckingParameter;

            sCheckingParameter = F.sText(
                "Enter the registration number of the employee whose contract requires a change", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
                );

            sParameter = RegistrationNumberToChangeDataCheck(sCheckingParameter);
            Person SearchedPerson = EmployeeList.Find(number => number.sRegNumber == sParameter);

            if (SearchedPerson != null)
            {
                char Option;
                Console.WriteLine("Choose Contract Type: ");
                Console.WriteLine("Selecting anything apart given options will result in personal choose contract type option [by hand]");
                Console.WriteLine("1.B2B");
                Console.WriteLine("2.Trial");
                Console.WriteLine("3.Fixed - term contract");

                Option = Console.ReadKey(true).KeyChar;

                string sNewContractType = "";

                switch (Option)
                {
                    case '1':
                        sNewContractType = "B2B";
                        break;
                    case '2':
                        sNewContractType = "Trial";
                        break;
                    case '3':
                        sNewContractType = "Fixed - term contract";
                        break;
                    default:
                        sNewContractType = F.sText(
                    "Contract type", "Contract type may not contain characters other than letters!", "^[a-zA-Z]+(\\s?\\-?[a-zA-Z]*)*$"
                    );
                        break;

                }

                string sNewDateOfConclusion = F.DateOf(
                    "Conclusion"
                    );
                int iNewTimeContract = F.iNumber(
                "Contract time", "The Contract Time may not contain characters other than numbers!", "^[0-9]+$"
                );


                ContractOfEmployment newContractOfEmployment = new ContractOfEmployment(sNewDateOfConclusion, sNewContractType, iNewTimeContract);

                EmployeeList.Add(new Person(SearchedPerson.sName, SearchedPerson.sSurname, SearchedPerson.sRegNumber, SearchedPerson.Address, SearchedPerson.sDateOfBrith, newContractOfEmployment));
                EmployeeList.Remove(SearchedPerson);
            }
        }

        public string RegistrationNumberCheck(string sRegistrationNumberToCheck)
        {
            bool bContainsItem = EmployeeList.Exists(tag => tag.sRegNumber.Equals(sRegistrationNumberToCheck));
           
            while (bContainsItem == true) 
            {
                sRegistrationNumberToCheck = F.sText(
                "Registration Number", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
        );
                bContainsItem = EmployeeList.Exists(tag => tag.sRegNumber.Equals(sRegistrationNumberToCheck));
            } 

            return sRegistrationNumberToCheck;
        }

        public string RegistrationNumberToChangeDataCheck(string sRegistrationNumberToChangeDataCheck)
        {
            bool bContainsItem = EmployeeList.Exists(tag => tag.sRegNumber.Equals(sRegistrationNumberToChangeDataCheck));

            while (bContainsItem == false)
            {
                sRegistrationNumberToChangeDataCheck = F.sText(
                "Registration Number", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
        );
                bContainsItem = EmployeeList.Exists(tag => tag.sRegNumber.Equals(sRegistrationNumberToChangeDataCheck));
            }

            return sRegistrationNumberToChangeDataCheck;
        }


        public void Delete_Employee()
        {
            {
                string sParameter, sGivenParameter;
                Console.WriteLine("Enter the registration number of the employee you want to delete:");
                sGivenParameter = F.sText(
                "Enter the registration number of the employee you want to delete", "The Registration Number have to consist of 4 or more number!", "^[0-9]{4,}$"
                );

                sParameter = RegistrationNumberToChangeDataCheck(sGivenParameter);

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