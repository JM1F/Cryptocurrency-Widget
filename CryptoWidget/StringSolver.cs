using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWidget
{
    /// <summary>
    /// Gathers data fromm the main window and cuts the string down to 2 decimal places rather than 15. Also adds a "+" in front of the positive values.
    /// </summary>
    class StringSolver
    {
        public string ShortenStringData(string StringData)
        {
            // Change string data to decimal.
            decimal DecimalData = decimal.Parse(StringData);
            // "F" cuts down the string data to 2 decimal places
            string NewStringData = DecimalData.ToString("F");
           
            // Checks to see if the first character starts with a "-".
            if (Convert.ToString(NewStringData[0]) == "-")
            {
                // returns current string if the value is negative, this is because the API automatically adds the minus in the string.
                return NewStringData;
            }

            // returns string with an added plus if the value is positive.
            return ("+" + NewStringData);
        }
    }
}
