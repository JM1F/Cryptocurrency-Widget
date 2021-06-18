﻿using APILibary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;


namespace CryptoWidget
{
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;



        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public Model()
        {
            
            setTimer();
        }
        public string BTCPRICE { get; set; }
        public string ETH24H { get; set; }
        public string ETH24HCOLOUR { get; set; }

        public string ETHPRICE { get; set; }
        public string PCP1H { get; set; }
        public string PCP1HCOLOUR { get; set; }

        public string PCP24H { get; set; }
        public string PCP24HCOLOUR { get; set; }
        public string PCP7D { get; set; }

        public string PCP30D { get; set; }

        public string PCP30DCOLOUR { get; set; }
        public string PCP1Y { get; set; }
        public string PCP1YCOLOUR { get; set; }




        private static System.Timers.Timer atimer;

        ColorPriceCheck n = new ColorPriceCheck();
        StringSolver stringSolver = new StringSolver();

        public void setTimer()
        {
            atimer = new System.Timers.Timer(10000);
            atimer.Elapsed += atimer_Elapsed;
            atimer.AutoReset = true;
            atimer.Enabled = true;
        }
        
        private async void atimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            

            var data2 = await dataLoad.LoadData();

            BTCPRICE = ("£" + data2[0].current_price);
            

            PCP24H = stringSolver.ShortenStringData(data2[0].price_change_percentage_24h_in_currency);
            PCP24HCOLOUR = n.ColourCheck(PCP24H);

            OnPropertyChanged("BTCPRICE");
            OnPropertyChanged("PCP24H");
            OnPropertyChanged("PCP24HCOLOUR");

            ETHPRICE = ("£" + data2[1].current_price);
            ETH24H = stringSolver.ShortenStringData(data2[1].price_change_percentage_24h_in_currency);
            ETH24HCOLOUR = n.ColourCheck(ETH24H);

            OnPropertyChanged("ETHPRICE");
            OnPropertyChanged("ETH24H");
            OnPropertyChanged("ETH24HCOLOUR");

        }
        
    }
}
