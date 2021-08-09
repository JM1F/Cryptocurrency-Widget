using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace APILibary
{
    /// <summary>
    /// API Helper class that initlializes a new HttpClient that is ready for json data. 
    /// </summary>
    public static class APIHelper
    {
        public static HttpClient APIClient { get; set; }

        public static void InitializeClient()
        {
            
            APIClient = new HttpClient();
            APIClient.DefaultRequestHeaders.Accept.Clear();
            APIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
