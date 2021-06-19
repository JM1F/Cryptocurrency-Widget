﻿using APILibary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoWidget
{
    public class ModelSubWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ModelSubWindow(string data)
        {
            CoinCodeName = data;

            setTimer();
        }
        public string CoinCodeName { get; set; }


        public string CoinPrice { get; set; }
        public string CoinPrice1H { get; set; }
        public string CoinPrice1HColour { get; set; }
        public string CoinPrice24H { get; set; }
        public string CoinPrice24HColour { get; set; }
        public string CoinPrice7D { get; set; }
        public string CoinPrice7DColour { get; set; }
        public string CoinPrice30D { get; set; }
        public string CoinPrice30DColour { get; set; }
        public string CoinPrice1Y { get; set; }
        public string CoinPrice1YColour { get; set; }
        public string CoinPriceATH { get; set; }



        public static System.Timers.Timer atimer;


        public void setTimer()
        {
            atimer = new System.Timers.Timer(1000);
            atimer.Elapsed += atimer_Elapsed;
            atimer.AutoReset = true;
            atimer.Enabled = true;
        }

        public async void atimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var data2 = await dataLoad.LoadData();
            ColorPriceCheck n = new ColorPriceCheck();
            StringSolver stringSolver = new StringSolver();


            if (CoinCodeName == "bitcoin")
            {
                CoinPrice = Convert.ToString("£" + data2[0].current_price);

                CoinPriceATH = ("£" + data2[0].ath);

                CoinPrice1H = stringSolver.ShortenStringData(data2[0].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(data2[0].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(data2[0].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(data2[0].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(data2[0].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);

                

                Console.WriteLine(CoinPrice);
            }
            else if (CoinCodeName == "ethereum")
            {
                CoinPrice = Convert.ToString("£" + data2[1].current_price);

                CoinPriceATH = ("£" + data2[1].ath);

                CoinPrice1H = stringSolver.ShortenStringData(data2[1].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(data2[1].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(data2[1].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(data2[1].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(data2[1].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);

                

                Console.WriteLine(CoinPrice);
            }
            else if (CoinCodeName == "cardano")
            {
                CoinPrice = Convert.ToString("£" + data2[4].current_price);


                CoinPriceATH = ("£" + data2[4].ath);

                CoinPrice1H = stringSolver.ShortenStringData(data2[4].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(data2[4].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(data2[4].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(data2[4].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(data2[4].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);


            }
            else if (CoinCodeName == "binancecoin")
            {
                CoinPrice = Convert.ToString("£" + data2[3].current_price);

                CoinPriceATH = ("£" + data2[3].ath);

                CoinPrice1H = stringSolver.ShortenStringData(data2[3].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(data2[3].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(data2[3].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(data2[3].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(data2[3].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);

            }
            else if (CoinCodeName == "dogecoin")
            {
                CoinPrice = Convert.ToString("£" + data2[5].current_price);

                CoinPriceATH = ("£" + data2[5].ath);

                CoinPrice1H = stringSolver.ShortenStringData(data2[5].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(data2[5].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(data2[5].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(data2[5].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(data2[5].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "xrp")
            {
                CoinPrice = Convert.ToString("£" + data2[6].current_price);

                CoinPriceATH = ("£" + data2[6].ath);

                CoinPrice1H = stringSolver.ShortenStringData(data2[6].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(data2[6].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(data2[6].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(data2[6].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(data2[6].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "polkadot")
            {
                CoinPrice = Convert.ToString("£" + data2[8].current_price);

                CoinPriceATH = ("£" + data2[8].ath);

                CoinPrice1H = stringSolver.ShortenStringData(data2[8].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(data2[8].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(data2[8].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(data2[8].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                if (data2[8].price_change_percentage_1y_in_currency == null)
                {
                    CoinPrice1Y = "N/A";
                    CoinPrice1YColour = "White";
                }
                else
                {
                    CoinPrice1Y = stringSolver.ShortenStringData(data2[8].price_change_percentage_1y_in_currency);
                    CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);
                }
                
            }
            else if (CoinCodeName == "bitcoincash")
            {
                CoinPrice = Convert.ToString("£" + data2[9].current_price);

                CoinPriceATH = ("£" + data2[9].ath);

                CoinPrice1H = stringSolver.ShortenStringData(data2[9].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(data2[9].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(data2[9].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(data2[9].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(data2[9].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);
            }

            OnPropertyChanged("CoinPrice");

            OnPropertyChanged("CoinPriceATH");

            OnPropertyChanged("CoinPrice1H");
            OnPropertyChanged("CoinPrice1HColour");

            OnPropertyChanged("CoinPrice24H");
            OnPropertyChanged("CoinPrice24HColour");

            OnPropertyChanged("CoinPrice7D");
            OnPropertyChanged("CoinPrice7DColour");

            OnPropertyChanged("CoinPrice30D");
            OnPropertyChanged("CoinPrice30DColour");

            OnPropertyChanged("CoinPrice1Y");
            OnPropertyChanged("CoinPrice1YColour");

        }
        
    }
}
