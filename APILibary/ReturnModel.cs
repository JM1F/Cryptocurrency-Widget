using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILibary
{
    public class ReturnModel
    {
        public string Name { get; set; }
        public Double price_change_percentage_1h_in_currency { get; set; }
        public Double price_change_percentage_24h_in_currency { get; set; }
        public Double price_change_percentage_7d_in_currency { get; set; }
        public Double price_change_percentage_30d_in_currency { get; set; }
        //public Double price_change_percentage_1y_in_currency { get; set; }
    }
}
