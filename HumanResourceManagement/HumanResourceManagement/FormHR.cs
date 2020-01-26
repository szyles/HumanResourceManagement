using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace HumanResourceManagement
{
    class FormHR
    {
        public string sText(string what, string error_msg, string pattern)
        {
            Console.Write("   "+what+": ");
            string sText = Console.ReadLine();
            while (true)
            {
                if (!Regex.IsMatch(sText, pattern))
                {
                    Console.WriteLine("***  "+error_msg+" ***");
                    Console.Write("   " + what + ": ");
                    sText = Console.ReadLine();
                }
                else
                    break;
            }
            return sText;
        }
        public int iNumber(string what, string error_msg, string pattern)
        {
            Console.Write("   "+what+": ");
            int iNumber_F;
            string sNumber_F = Console.ReadLine();
            while (true)
            {
                if (!Regex.IsMatch(sNumber_F, pattern))
                {
                    Console.WriteLine("*** " + error_msg + " ***");
                    Console.Write("   " + what + ": ");
                    sNumber_F = Console.ReadLine();
                    iNumber_F = Convert.ToInt32(sNumber_F);
                }
                else
                {
                    iNumber_F = Convert.ToInt32(sNumber_F);
                    break;
                }
            }
            return iNumber_F;
        }
        // sType 
        public string DateOf(string sType)
        {
            string sDateOf_F;
            if (sType == "Birth")
                Console.WriteLine("  Date Of Birth:");
            if (sType == "Conclusion")
                Console.WriteLine("  Date Of Conclusion:");
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

                if (sType == "Birth")
                {
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
                        sDateOf_F = sDayAdd0 + iDay.ToString() + "-" + sMonthAdd0 + iMonth.ToString() + "-" + iYear.ToString();
                        Console.WriteLine("Date Of Brith: {0}", sDateOf_F);
                        break;
                    }
                }
                if (sType == "Conclusion")
                {
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
                        sDateOf_F = sDayAdd0 + iDay.ToString() + "-" + sMonthAdd0 + iMonth.ToString() + "-" + iYear.ToString();
                        Console.WriteLine("Date of conclusion: {0}", sDateOf_F);
                        break;
                    }
                }
            }
            return sDateOf_F;
        }
    }
}
