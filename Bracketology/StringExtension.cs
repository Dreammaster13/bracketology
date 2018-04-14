using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOOTBALL
{
    public static class StringExtension
    {
        public static string RemoveWhiteSpace(this string s)
        {
            string returnString = "";
            foreach(char c in s)
            {
                if (c > ' ') returnString += c;
            }

            return returnString;
        }
    }
}
