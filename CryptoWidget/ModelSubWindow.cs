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
        
        public ModelSubWindow(string data, string Currency)
        {
            CURRENCYVALUE = Currency;
            CoinCodeName = data;
            // Starts timer.
            setTimer();
        }
        // Variables set fo different coins.
        public string CoinCodeName { get; set; }
        public string CURRENCYVALUE { get; set; }

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
            atimer = new System.Timers.Timer(6000);
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
            var CoinAPIData = await dataLoad.LoadData(CURRENCYVALUE);

            ColorPriceCheck colourCheck = new ColorPriceCheck();
            StringSolver stringSolver = new StringSolver();
            APIDataChecker aPIDataChecker = new APIDataChecker();

            string StringCurrency = CURRENCYVALUE[38].ToString();
                

            if (CoinCodeName == "bitcoin")
            {
                // Check index for coin.
                int BTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin");

                // Sets updated variables for all MainWindow elemetns.
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[BTCINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[BTCINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y); 
            }
            else if (CoinCodeName == "ethereum")
            {
                // Repeat...
                int ETHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum");

                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[ETHINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[ETHINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y); 
            }
            else if (CoinCodeName == "cardano")
            {

                int ADAINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Cardano");

                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[ADAINDEX].current_price);


                CoinPriceATH = (StringCurrency + CoinAPIData[ADAINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);


            }
            else if (CoinCodeName == "binancecoin")
            {
                int BNBINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Binance Coin");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[BNBINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[BNBINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);

            }
            else if (CoinCodeName == "dogecoin")
            {
                int DOGEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Dogecoin");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[DOGEINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[DOGEINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "xrp")
            {
                int XRPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "XRP");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[XRPINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[XRPINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "polkadot")
            {
                int DOTINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Polkadot");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[DOTINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[DOTINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                if (CoinAPIData[DOTINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPrice1Y = "N/A";
                    
                }
                else
                {
                    CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_1y_in_currency);
                    CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
                }
                
            }
            else if (CoinCodeName == "bitcoincash")
            {
                int BTCCASHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin Cash");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[BTCCASHINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[BTCCASHINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "uniswap")
            {
                int UNIINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Uniswap");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[UNIINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[UNIINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                if (CoinAPIData[UNIINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPrice1Y = "N/A";
                   
                }
                else
                {
                    CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_1y_in_currency);
                    CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
                }

                
            }
            else if (CoinCodeName == "solana")
            {
                int SOLINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Solana");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[SOLINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[SOLINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "litecoin")
            {
                int LTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Litecoin");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[LTCINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[LTCINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "chainlink")
            {
                int LINKINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Chainlink");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[LINKINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[LINKINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "ethereumclassic")
            {
                int ETHCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum Classic");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[ETHCINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[ETHCINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "polygon")
            {
                int MATICINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Polygon");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[MATICINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[MATICINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "wrappedbitcoin")
            {
                int WBTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Wrapped Bitcoin");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[WBTCINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[WBTCINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "internetcomputer")
            {
                int ICPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Internet Computer");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[ICPINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[ICPINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                if (CoinAPIData[ICPINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPrice1Y = "N/A";

                }
                else
                {
                    CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_1y_in_currency);
                    CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
                }
            }
            else if (CoinCodeName == "theta")
            {
                int THETAINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Theta Network");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[THETAINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[THETAINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "stellar")
            {
                int XLMINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Stellar");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[XLMINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[XLMINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "vechain")
            {
                int VETINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "VeChain");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[VETINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[VETINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "dai")
            {
                int DAIINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Dai");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[DAIINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[DAIINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[DAIINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[DAIINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[DAIINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[DAIINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[DAIINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "filecoin")
            {
                int FILINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Filecoin");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[FILINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[FILINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[FILINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[FILINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[FILINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[FILINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                if (CoinAPIData[FILINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPrice1Y = "N/A";

                }
                else
                {
                    CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[FILINDEX].price_change_percentage_1y_in_currency);
                    CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
                }

                
            }
            else if (CoinCodeName == "tron")
            {
                int TRXINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "TRON");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[TRXINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[TRXINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[TRXINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[TRXINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[TRXINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[TRXINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[TRXINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "shibainu")
            {
                int SHIBINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Shiba Inu");


                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[SHIBINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[SHIBINDEX].ath);
                

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[SHIBINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[SHIBINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[SHIBINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[SHIBINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                if (CoinAPIData[SHIBINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPrice1Y = "N/A";

                }
                else
                {
                    CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[SHIBINDEX].price_change_percentage_1y_in_currency);
                    CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
                }


            }
            else if (CoinCodeName == "monero")
            {
                int XMRINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Monero");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[XMRINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[XMRINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[XMRINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[XMRINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[XMRINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[XMRINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[XMRINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "cosmos")
            {
                int ATOMINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Cosmos");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[ATOMINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[ATOMINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[ATOMINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[ATOMINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[ATOMINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[ATOMINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[ATOMINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "aave")
            {
                int AAVEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Aave");


                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[AAVEINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[AAVEINDEX].ath);


                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[AAVEINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[AAVEINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[AAVEINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[AAVEINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                if (CoinAPIData[AAVEINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPrice1Y = "N/A";

                }
                else
                {
                    CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[AAVEINDEX].price_change_percentage_1y_in_currency);
                    CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
                }


            }
            else if (CoinCodeName == "eos")
            {
                int EOSINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "EOS");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[EOSINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[EOSINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[EOSINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[EOSINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[EOSINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[EOSINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[EOSINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "algorand")
            {
                int ALGOINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Algorand");
                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[ALGOINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[ALGOINDEX].ath);

                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[ALGOINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[ALGOINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[ALGOINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[ALGOINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[ALGOINDEX].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
            }
            else if (CoinCodeName == "pancakeswap")
            {
                int CAKEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "PancakeSwap");


                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[CAKEINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[CAKEINDEX].ath);


                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[CAKEINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[CAKEINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[CAKEINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[CAKEINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                if (CoinAPIData[CAKEINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPrice1Y = "N/A";

                }
                else
                {
                    CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[CAKEINDEX].price_change_percentage_1y_in_currency);
                    CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
                }


            }
            else if (CoinCodeName == "amp")
            {
                int AMPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Amp");


                CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[AMPINDEX].current_price);

                CoinPriceATH = (StringCurrency + CoinAPIData[AMPINDEX].ath);


                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[AMPINDEX].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);

                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[AMPINDEX].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);

                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[AMPINDEX].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);

                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[AMPINDEX].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);

                if (CoinAPIData[AMPINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPrice1Y = "N/A";

                }
                else
                {
                    CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[AMPINDEX].price_change_percentage_1y_in_currency);
                    CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
                }


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
