using APILibary;
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
    /// <summary>
    /// Model data for the sub window to update the data.
    /// Very similar to the Model.cs for the MainWindow.
    /// </summary>
    public class ModelSubWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Checks if the property has changed.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public ModelSubWindow(string data)
        {
            CoinCodeName = data;
            // Starts timer.
            setTimer();
        }
        // Variables set fo different coins.
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

        /// <summary>
        /// Set up for a minute timer.
        /// </summary>
        public void setTimer()
        {
            atimer = new System.Timers.Timer(60000);
            // When the timer elapses atimer_Elapsed is called.
            atimer.Elapsed += atimer_Elapsed;
            atimer.AutoReset = true;
            atimer.Enabled = true;
        }
        /// <summary>
        /// atimer_Elapsed for the Sub window.
        /// Similar to the Model for MainWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void atimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            /// Call API
            var CoinAPIData = await dataLoad.LoadData();

            ColorPriceCheck n = new ColorPriceCheck();
            StringSolver stringSolver = new StringSolver();
            APIDataChecker aPIDataChecker = new APIDataChecker();


            if (CoinCodeName == "bitcoin")
            {
                // Check index for coin.
                int index = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin");

                // Sets updated variables for all MainWindow elemetns.
                CoinPrice = Convert.ToString("£" + CoinAPIData[index].current_price);

                CoinPriceATH = ("£" + CoinAPIData[index].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);

                

                
            }
            else if (CoinCodeName == "ethereum")
            {
                // Repeat...
                int index = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum");

                CoinPrice = Convert.ToString("£" + CoinAPIData[index].current_price);

                CoinPriceATH = ("£" + CoinAPIData[index].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);

                

                
            }
            else if (CoinCodeName == "cardano")
            {

                int index = aPIDataChecker.IndexCheck(CoinAPIData, "Cardano");

                CoinPrice = Convert.ToString("£" + CoinAPIData[index].current_price);


                CoinPriceATH = ("£" + CoinAPIData[index].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);


            }
            else if (CoinCodeName == "binancecoin")
            {
                int index = aPIDataChecker.IndexCheck(CoinAPIData, "Binance Coin");
                CoinPrice = Convert.ToString("£" + CoinAPIData[index].current_price);

                CoinPriceATH = ("£" + CoinAPIData[index].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);

            }
            else if (CoinCodeName == "dogecoin")
            {
                int index = aPIDataChecker.IndexCheck(CoinAPIData, "Dogecoin");
                CoinPrice = Convert.ToString("£" + CoinAPIData[index].current_price);

                CoinPriceATH = ("£" + CoinAPIData[index].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "xrp")
            {
                int index = aPIDataChecker.IndexCheck(CoinAPIData, "XRP");
                CoinPrice = Convert.ToString("£" + CoinAPIData[6].current_price);

                CoinPriceATH = ("£" + CoinAPIData[index].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "polkadot")
            {
                int index = aPIDataChecker.IndexCheck(CoinAPIData, "Polkadot");
                CoinPrice = Convert.ToString("£" + CoinAPIData[index].current_price);

                CoinPriceATH = ("£" + CoinAPIData[index].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                if (CoinAPIData[8].price_change_percentage_1y_in_currency == null)
                {
                    CoinPrice1Y = "N/A";
                    
                }
                else
                {
                    CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1y_in_currency);
                    CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);
                }
                
            }
            else if (CoinCodeName == "bitcoincash")
            {
                int BTCCASHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin Cash");
                CoinPrice = Convert.ToString("£" + CoinAPIData[BTCCASHINDEX].current_price);

                CoinPriceATH = ("£" + CoinAPIData[BTCCASHINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "uniswap")
            {
                int UNIINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Uniswap");
                CoinPrice = Convert.ToString("£" + CoinAPIData[UNIINDEX].current_price);

                CoinPriceATH = ("£" + CoinAPIData[UNIINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                if (CoinAPIData[UNIINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPrice1Y = "N/A";
                   
                }
                else
                {
                    CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_1y_in_currency);
                    CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);
                }

                
            }
            else if (CoinCodeName == "solana")
            {
                int SOLINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Solana");
                CoinPrice = Convert.ToString("£" + CoinAPIData[SOLINDEX].current_price);

                CoinPriceATH = ("£" + CoinAPIData[SOLINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "litecoin")
            {
                int LTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Litecoin");
                CoinPrice = Convert.ToString("£" + CoinAPIData[LTCINDEX].current_price);

                CoinPriceATH = ("£" + CoinAPIData[LTCINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "chainlink")
            {
                int LINKINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Chainlink");
                CoinPrice = Convert.ToString("£" + CoinAPIData[LINKINDEX].current_price);

                CoinPriceATH = ("£" + CoinAPIData[LINKINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = n.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "ethereumclassic")
            {
                int ETHCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum Classic");
                CoinPrice = Convert.ToString("£" + CoinAPIData[ETHCINDEX].current_price);

                CoinPriceATH = ("£" + CoinAPIData[ETHCINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = n.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = n.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = n.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = n.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_1y_in_currency);
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
