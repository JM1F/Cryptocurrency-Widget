using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APILibary
{
    /// <summary>
    /// Class for API call.
    /// API data provided by coingecko.com
    /// </summary>
    public class dataLoad
    {
        

        public static async Task<IList<ReturnModel>> LoadData(string CurrencyValue)
        {

            string URL = "";

            if (CurrencyValue == "System.Windows.Controls.ComboBoxItem: £ GBP")
            {
                URL = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=gbp&order=market_cap_desc&per_page=50&sparkline=false&price_change_percentage=1h%2C24h%2C7d%2C30d%2C1y";
            }
            else if (CurrencyValue == "System.Windows.Controls.ComboBoxItem: $ USD") 
            {
                
                URL = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=50&sparkline=false&price_change_percentage=1h%2C24h%2C7d%2C30d%2C1y";
            }
            else if (CurrencyValue == "System.Windows.Controls.ComboBoxItem: € EUR")
            {
                
                URL = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=eur&order=market_cap_desc&per_page=50&sparkline=false&price_change_percentage=1h%2C24h%2C7d%2C30d%2C1y";
            }

            
            // API URL 

            using (HttpResponseMessage response = await APIHelper.APIClient.GetAsync(URL))
            {
                // Check if API call successful
                if (response.IsSuccessStatusCode)
                {
                    IList<ReturnModel> NewData = await response.Content.ReadAsAsync<IList<ReturnModel>>();
                    return NewData;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}

