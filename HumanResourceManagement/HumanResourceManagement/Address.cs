using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;


namespace HumanResourceManagement
{
    class Address
    {
        public string sStreet { get; set; }
        public int iHouseNumber { get; set; }
        public string sPostalAddress { get; set; }
        public string sCity { get; set; }

        public Address(string sStreet, int iHouseNumber, string sPostalAddress, string sCity)
        {
            this.sStreet = sStreet;
            this.iHouseNumber = iHouseNumber;
            this.sPostalAddress = sPostalAddress;
            this.sCity = sCity;
        }
    }
}