using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;


namespace HumanResourceManagement
{
    class Person
    {

        public string sName { get; set; }
        public string sSurname { get; set; }
        public string sRegNumber { get; private set; }
        public Address Address { get; set; }
        public string sDateOfBrith { get; set; }
        public ContractOfEmployment ContractOfEmployment { get; set; }

        public override string ToString()
        {
            return "Dane Osobowe: " + sName
                + " " + sSurname
                + " " + sRegNumber
                + " " + Address.sCity
                + " " + sDateOfBrith
                + " " + ContractOfEmployment.sContractType;
        }
        public string Date()
        {
            return "Dane Osobowe:\n " + sName
                + "\n " + sSurname
                + "\n " + sDateOfBrith
                + "\n " + Address.sStreet
                + "\n " + Address.iHouseNumber
                + "\n " + Address.sPostalAddress
                + "\n " + Address.sCity
                + "\n " + ContractOfEmployment.sContractType
                + "\n " + ContractOfEmployment.sDateOfConclusion
                + "\n " + ContractOfEmployment.iContractTime;
        }

        public Person(string sName, string sSurname, string sRegNumber, Address Address, string sDateOfBrith, ContractOfEmployment ContractOfEmployment)
        {
            this.sName = sName;
            this.sSurname = sSurname;
            this.sRegNumber = sRegNumber;
            this.Address = Address;
            this.sDateOfBrith = sDateOfBrith;
            this.ContractOfEmployment = ContractOfEmployment;
        }
    }
}