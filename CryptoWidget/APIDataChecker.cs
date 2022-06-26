using APILibary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWidget
{

    class APIDataChecker
    {
        /// <summary>
        /// Looks at the data and checks what index the inputted coin is in the API.
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="CoinName"></param>
        /// <returns>Index of coin inputted. or defautls to 0 if not found.</returns>

        public int IndexCheck(IList<ReturnModel> Data, string CoinName)
        {
            // Loops through the data from the API 
            for (int i = 0; i < Data.Count; i++) {
                // Checks if the data name is the same as the parameter CoinName.
                if (Data[i].ID == CoinName)
                {
                    
                    return i;
                }
                
            }
            return 0;
            
        }
    }
}
