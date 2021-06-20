using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APILibary
{
    public class dataLoad
    {
        public static async Task<IList<ReturnModel>> LoadData()
        {
            string URL = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=gbp&order=market_cap_desc&per_page=15&sparkline=false&price_change_percentage=1h%2C24h%2C7d%2C30d%2C1y";

            using (HttpResponseMessage response = await APIHelper.APIClient.GetAsync(URL))
            {
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

