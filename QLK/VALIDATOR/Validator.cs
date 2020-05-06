using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLK.VALIDATOR
{
    class Validator
    {
        internal static bool isValidName(string text)
        {
            return text.Trim().Length > 0;
        }

        internal static bool isValidUsernameName(string text)
        {

            string validUserNamePattern = "^[aA-zZ]\\w{4,29}$";
            return new Regex(validUserNamePattern, RegexOptions.IgnoreCase).IsMatch(text);
        }

        internal static bool isValidPassword(string text)
        {
            if (text.Contains(" "))
            {
                return false;
            }
            return text.Trim().Length > 5;
        }

        internal static bool isValidUnit(string text)
        {
            string validUserNamePattern = "[A-Za-zÀ-ú0-9]";
            return new Regex(validUserNamePattern, RegexOptions.IgnoreCase).IsMatch(text);
        }

        internal static bool isValidPhoneNumber(string text)
        {
            string validPhoneNumber = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            return new Regex(validPhoneNumber, RegexOptions.IgnoreCase).IsMatch(text);
        }
    }
}
