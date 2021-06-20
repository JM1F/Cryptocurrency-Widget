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
        public int IndexCheck(IList<ReturnModel> Data, string CoinName)
        {
            for (int i = 0; i < Data.Count; i++) {
                if (Data[i].Name == CoinName)
                {
                    return i;
                }
                
            }
            return 0;
            
        }
    }
}
