using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWidget
{
    /// <summary>
    /// Checks if the price is negative (red) or positive (green) and returns the hex colour code for the respective.
    /// </summary>
    class ColorPriceCheck
    {
        public string ColourCheck(string PercentageString)
        {
            string FirstCharOfString = Convert.ToString(PercentageString[0]);
            // Checks first character of the string.

            if (FirstCharOfString == "-")
            {
                return "#DF5F67";
            }
            else
            {
                return "#67E356";
            }
        }
    }
}
