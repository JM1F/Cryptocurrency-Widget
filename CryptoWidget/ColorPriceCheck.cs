using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWidget
{
    class ColorPriceCheck
    {
        public string ColourCheck(string PercentageString)
        {
            string FirstCharOfString = Convert.ToString(PercentageString[0]);

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
