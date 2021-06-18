using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWidget
{
    /// <summary>
    /// Gathers data form the main window and cuts the string down to 2 decimal places rather than 15. Also adds a "+" in front of the positive values.
    /// </summary>
    class StringSolver
    {
        public string ShortenStringData(string StringData)
        {
            decimal DecimalData = decimal.Parse(StringData);

            string NewStringData = DecimalData.ToString("F");
            Console.WriteLine(NewStringData);

            if (Convert.ToString(NewStringData[0]) == "-")
            {
                return NewStringData;
            }
            else
            {
                return ("+" + NewStringData);
            }
        }
    }
}
