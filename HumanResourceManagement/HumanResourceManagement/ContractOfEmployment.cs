using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace HumanResourceManagement
{
    class ContractOfEmployment
    {
        public string sDateOfConclusion { get; set; }
        public string sContractType { get; set; }
        public int iContractTime { get; set; }

        public ContractOfEmployment(string sDateOfConclusion, string sContractType, int iContractTime)
        {
            this.sDateOfConclusion = sDateOfConclusion;
            this.sContractType = sContractType;
            this.iContractTime = iContractTime;
        }
    }
}