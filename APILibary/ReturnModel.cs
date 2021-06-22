using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace APILibary
{
    /// <summary>
    /// Return Model for the API calls.
    /// </summary>
    public class ReturnModel
    {
        public string current_price { get; set; }
        public string Name { get; set; }
        public string ath { get; set; }
        public string price_change_percentage_1h_in_currency { get; set; }
        public string price_change_percentage_24h_in_currency { get; set; }
        public string price_change_percentage_7d_in_currency { get; set; }
        public string price_change_percentage_30d_in_currency { get; set; }
        public string price_change_percentage_1y_in_currency { get; set; }
    }
}