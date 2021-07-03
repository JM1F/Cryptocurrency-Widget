using APILibary;
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
    /// <summary>
    /// Model data for the main window to update the data.
    /// </summary>
    public class Model : INotifyPropertyChanged
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
        
        public Model()
        {
            //Starts Timer
            setTimer();
        }

        // Sets variables for each coin
        public string BTCPRICE { get; set; }
        public string PCP24H { get; set; }
        public string PCP24HCOLOUR { get; set; }

        public string ETH24H { get; set; }
        public string ETH24HCOLOUR { get; set; }
        public string ETHPRICE { get; set; }

        public string ADA24H { get; set; }
        public string ADA24HCOLOUR { get; set; }
        public string ADAPRICE { get; set; }

        public string BNB24H { get; set; }
        public string BNB24HCOLOUR { get; set; }
        public string BNBPRICE { get; set; }

        public string DOGE24H { get; set; }
        public string DOGE24HCOLOUR { get; set; }
        public string DOGEPRICE { get; set; }

        public string XRP24H { get; set; }
        public string XRP24HCOLOUR { get; set; }
        public string XRPPRICE { get; set; }

        public string DOT24H { get; set; }
        public string DOT24HCOLOUR { get; set; }
        public string DOTPRICE { get; set; }

        public string BTCCASH24H { get; set; }
        public string BTCCASH24HCOLOUR { get; set; }
        public string BTCCASHPRICE { get; set; }

        public string UNI24H { get; set; }
        public string UNI24HCOLOUR { get; set; }
        public string UNIPRICE { get; set; }

        public string SOL24H { get; set; }
        public string SOL24HCOLOUR { get; set; }
        public string SOLPRICE { get; set; }

        public string LTC24H { get; set; }
        public string LTC24HCOLOUR { get; set; }
        public string LTCPRICE { get; set; }







        private static System.Timers.Timer atimer;

        ColorPriceCheck n = new ColorPriceCheck();
        StringSolver stringSolver = new StringSolver();
        APIDataChecker aPIDataChecker = new APIDataChecker();

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
        /// Updates data for the buttons in the main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void atimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Call API
            var CoinAPIData = await dataLoad.LoadData();

            // Check index for coin.
            int BTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin");

            // Sets updated variables for all MainWindow elemetns.
            BTCPRICE = ("£" + CoinAPIData[BTCINDEX].current_price);
            PCP24H = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_24h_in_currency);
            PCP24HCOLOUR = n.ColourCheck(PCP24H);
            // Calls OnPropertyChanged for all variables to update the data element in MainWindow.
            OnPropertyChanged("BTCPRICE");
            OnPropertyChanged("PCP24H");
            OnPropertyChanged("PCP24HCOLOUR");

            int ETHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum");

            ETHPRICE = ("£" + CoinAPIData[ETHINDEX].current_price);
            ETH24H = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_24h_in_currency);
            ETH24HCOLOUR = n.ColourCheck(ETH24H);
            OnPropertyChanged("ETHPRICE");
            OnPropertyChanged("ETH24H");
            OnPropertyChanged("ETH24HCOLOUR");

            int ADAINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Cardano");

            ADAPRICE = ("£" + CoinAPIData[ADAINDEX].current_price);
            ADA24H = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_24h_in_currency);
            ADA24HCOLOUR = n.ColourCheck(ADA24H);
            OnPropertyChanged("ADAPRICE");
            OnPropertyChanged("ADA24H");
            OnPropertyChanged("ADA24HCOLOUR");

            int BNBINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Binance Coin");

            BNBPRICE = ("£" + CoinAPIData[BNBINDEX].current_price);
            BNB24H = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_24h_in_currency);
            BNB24HCOLOUR = n.ColourCheck(BNB24H);
            OnPropertyChanged("BNBPRICE");
            OnPropertyChanged("BNB24H");
            OnPropertyChanged("BNB24HCOLOUR");

            int DOGEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Dogecoin");

            DOGEPRICE = ("£" + CoinAPIData[DOGEINDEX].current_price);
            DOGE24H = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_24h_in_currency);
            DOGE24HCOLOUR = n.ColourCheck(DOGE24H);
            OnPropertyChanged("DOGEPRICE");
            OnPropertyChanged("DOGE24H");
            OnPropertyChanged("DOGE24HCOLOUR");

            int XRPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "XRP");

            XRPPRICE = ("£" + CoinAPIData[XRPINDEX].current_price);
            XRP24H = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_24h_in_currency);
            XRP24HCOLOUR = n.ColourCheck(XRP24H);
            OnPropertyChanged("XRPPRICE");
            OnPropertyChanged("XRP24H");
            OnPropertyChanged("XRP24HCOLOUR");

            int DOTINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Polkadot");

            DOTPRICE = ("£" + CoinAPIData[DOTINDEX].current_price);
            DOT24H = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_24h_in_currency);
            DOT24HCOLOUR = n.ColourCheck(DOT24H);
            OnPropertyChanged("DOTPRICE");
            OnPropertyChanged("DOT24H");
            OnPropertyChanged("DOT24HCOLOUR");

            int BTCCASHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin Cash");

            BTCCASHPRICE = ("£" + CoinAPIData[BTCCASHINDEX].current_price);
            BTCCASH24H = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_24h_in_currency);
            BTCCASH24HCOLOUR = n.ColourCheck(BTCCASH24H);
            OnPropertyChanged("BTCCASHPRICE");
            OnPropertyChanged("BTCCASH24H");
            OnPropertyChanged("BTCCASH24HCOLOUR");

            int UNIINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Uniswap");

            UNIPRICE = ("£" + CoinAPIData[UNIINDEX].current_price);
            UNI24H = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_24h_in_currency);
            UNI24HCOLOUR = n.ColourCheck(UNI24H);
            OnPropertyChanged("UNIPRICE");
            OnPropertyChanged("UNI24H");
            OnPropertyChanged("UNI24HCOLOUR");

            int SOLINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Solana");

            SOLPRICE = ("£" + CoinAPIData[SOLINDEX].current_price);
            SOL24H = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_24h_in_currency);
            SOL24HCOLOUR = n.ColourCheck(SOL24H);
            OnPropertyChanged("SOLPRICE");
            OnPropertyChanged("SOL24H");
            OnPropertyChanged("SOL24HCOLOUR");

            int LTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Litecoin");

            LTCPRICE = ("£" + CoinAPIData[LTCINDEX].current_price);
            LTC24H = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_24h_in_currency);
            LTC24HCOLOUR = n.ColourCheck(LTC24H);
            OnPropertyChanged("LTCPRICE");
            OnPropertyChanged("LTC24H");
            OnPropertyChanged("LTC24HCOLOUR");
        }
        
    }
}
