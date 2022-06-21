using APILibary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

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
        public int CoinIndex { get; set; }

        public static System.Timers.Timer atimer;

        /// <summary>
        /// Set up for a minute timer.
        /// </summary>
        public void setTimer()
        {
            atimer = new System.Timers.Timer(30000);
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
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin");
            }
            else if (CoinCodeName == "ethereum")
            {
                // Repeat...
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum");
            }
            else if (CoinCodeName == "cardano")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Cardano");
            }
            else if (CoinCodeName == "binancecoin")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Binance Coin");
            }
            else if (CoinCodeName == "dogecoin")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Dogecoin");
            }
            else if (CoinCodeName == "xrp")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "XRP");
            }
            else if (CoinCodeName == "polkadot")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Polkadot");
            }
            else if (CoinCodeName == "bitcoincash")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin Cash");
            }
            else if (CoinCodeName == "uniswap")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Uniswap");
            }
            else if (CoinCodeName == "solana")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Solana");
            }
            else if (CoinCodeName == "litecoin")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Litecoin");
            }
            else if (CoinCodeName == "chainlink")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Chainlink");
            }
            else if (CoinCodeName == "ethereumclassic")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum Classic");
            }
            else if (CoinCodeName == "polygon")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Polygon");
            }
            else if (CoinCodeName == "wrappedbitcoin")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Wrapped Bitcoin");
            }
            else if (CoinCodeName == "internetcomputer")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Internet Computer");
            }
            else if (CoinCodeName == "theta")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Theta Network");
            }
            else if (CoinCodeName == "stellar")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Stellar");
            }
            else if (CoinCodeName == "vechain")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "VeChain");
            }
            else if (CoinCodeName == "dai")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Dai");
            }
            else if (CoinCodeName == "filecoin")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Filecoin");
            }
            else if (CoinCodeName == "tron")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "TRON");
            }
            else if (CoinCodeName == "shibainu")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Shiba Inu");
            }
            else if (CoinCodeName == "monero")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Monero");
            }
            else if (CoinCodeName == "cosmos")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Cosmos");
            }
            else if (CoinCodeName == "aave")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Aave");
            }
            else if (CoinCodeName == "eos")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "EOS");
            }
            else if (CoinCodeName == "algorand")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Algorand");
            }
            else if (CoinCodeName == "pancakeswap")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "PancakeSwap");
            }
            else if (CoinCodeName == "amp")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Amp");
            }
            BrushConverter brushConverter = new BrushConverter();

            CoinPrice = Convert.ToString(StringCurrency + CoinAPIData[CoinIndex].current_price);

            CoinPriceATH = (StringCurrency + CoinAPIData[CoinIndex].ath);

            if (CoinAPIData[CoinIndex].price_change_percentage_1h_in_currency == null)
            {
                CoinPrice1H = "N/A";
            }
            else
            {
                CoinPrice1H = stringSolver.ShortenStringData(CoinAPIData[CoinIndex].price_change_percentage_1h_in_currency);
                CoinPrice1HColour = colourCheck.ColourCheck(CoinPrice1H);
            }

            if (CoinAPIData[CoinIndex].price_change_percentage_24h_in_currency == null)
            {
                CoinPrice24H = "N/A";
            }
            else
            {
                CoinPrice24H = stringSolver.ShortenStringData(CoinAPIData[CoinIndex].price_change_percentage_24h_in_currency);
                CoinPrice24HColour = colourCheck.ColourCheck(CoinPrice24H);
            }

            if (CoinAPIData[CoinIndex].price_change_percentage_7d_in_currency == null)
            {
                CoinPrice7D = "N/A";
            }
            else
            {
                CoinPrice7D = stringSolver.ShortenStringData(CoinAPIData[CoinIndex].price_change_percentage_7d_in_currency);
                CoinPrice7DColour = colourCheck.ColourCheck(CoinPrice7D);
            }

            if (CoinAPIData[CoinIndex].price_change_percentage_30d_in_currency == null)
            {
                CoinPrice30D = "N/A";
            }
            else
            {
                CoinPrice30D = stringSolver.ShortenStringData(CoinAPIData[CoinIndex].price_change_percentage_30d_in_currency);
                CoinPrice30DColour = colourCheck.ColourCheck(CoinPrice30D);
            }

            if (CoinAPIData[CoinIndex].price_change_percentage_1y_in_currency == null)
            {
                CoinPrice1Y = "N/A";
            }
            else
            {
                CoinPrice1Y = stringSolver.ShortenStringData(CoinAPIData[CoinIndex].price_change_percentage_1y_in_currency);
                CoinPrice1YColour = colourCheck.ColourCheck(CoinPrice1Y);
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
