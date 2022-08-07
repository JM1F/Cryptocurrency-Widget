using APILibary;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public Model(string Currency)
        {
            CURRENCYVALUE = Currency;
            //Starts Timer
            setTimer();
            
        }

        public string textColour { get; set; }
        public string textPrice { get; set; }

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

        public string LINK24H { get; set; }
        public string LINK24HCOLOUR { get; set; }
        public string LINKPRICE { get; set; }

        public string ETHC24H { get; set; }
        public string ETHC24HCOLOUR { get; set; }
        public string ETHCPRICE { get; set; }

        public string MATIC24H { get; set; }
        public string MATIC24HCOLOUR { get; set; }
        public string MATICPRICE { get; set; }

        public string WBTC24H { get; set; }
        public string WBTC24HCOLOUR { get; set; }
        public string WBTCPRICE { get; set; }

        public string ICP24H { get; set; }
        public string ICP24HCOLOUR { get; set; }
        public string ICPPRICE { get; set; }

        public string THETA24H { get; set; }
        public string THETA24HCOLOUR { get; set; }
        public string THETAPRICE { get; set; }

        public string XLM24H { get; set; }
        public string XLM24HCOLOUR { get; set; }
        public string XLMPRICE { get; set; }

        public string VET24H { get; set; }
        public string VET24HCOLOUR { get; set; }
        public string VETPRICE { get; set; }

        public string DAI24H { get; set; }
        public string DAI24HCOLOUR { get; set; }
        public string DAIPRICE { get; set; }

        public string FIL24H { get; set; }
        public string FIL24HCOLOUR { get; set; }
        public string FILPRICE { get; set; }

        public string TRX24H { get; set; }
        public string TRX24HCOLOUR { get; set; }
        public string TRXPRICE { get; set; }

        public string SHIB24H { get; set; }
        public string SHIB24HCOLOUR { get; set; }
        public string SHIBPRICE { get; set; }

        public string XMR24H { get; set; }
        public string XMR24HCOLOUR { get; set; }
        public string XMRPRICE { get; set; }

        public string ATOM24H { get; set; }
        public string ATOM24HCOLOUR { get; set; }
        public string ATOMPRICE { get; set; }

        public string AAVE24H { get; set; }
        public string AAVE24HCOLOUR { get; set; }
        public string AAVEPRICE { get; set; }

        public string EOS24H { get; set; }
        public string EOS24HCOLOUR { get; set; }
        public string EOSPRICE { get; set; }

        public string ALGO24H { get; set; }
        public string ALGO24HCOLOUR { get; set; }
        public string ALGOPRICE { get; set; }

        public string CAKE24H { get; set; }
        public string CAKE24HCOLOUR { get; set; }
        public string CAKEPRICE { get; set; }

        public string AMP24H { get; set; }
        public string AMP24HCOLOUR { get; set; }
        public string AMPPRICE { get; set; }

        public string CURRENCYVALUE { get; set; }

        public static System.Timers.Timer atimer;

        ColorPriceCheck colourCheck = new ColorPriceCheck();
        StringSolver stringSolver = new StringSolver();
        APIDataChecker aPIDataChecker = new APIDataChecker();

        
        /// <summary>
        /// Set up for a minute timer.
        /// </summary>
        
        public void setTimer()
        {
            atimer = new System.Timers.Timer(5000);
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
            var CoinAPIData = await dataLoad.LoadData(CURRENCYVALUE);

            string SttringCurrency = CURRENCYVALUE[38].ToString();
            
            // Check index for coin.
            int BTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "bitcoin");

            textPrice = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_24h_in_currency);
            textColour = colourCheck.ColourCheck(textPrice);
            OnPropertyChanged("textPrice");
            OnPropertyChanged("textColour");
            Console.WriteLine(textPrice);

            // Sets updated variables for all MainWindow elemetns.
            BTCPRICE = (SttringCurrency + CoinAPIData[BTCINDEX].current_price);
            PCP24H = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_24h_in_currency);
            PCP24HCOLOUR = colourCheck.ColourCheck(PCP24H);
            // Calls OnPropertyChanged for all variables to update the data element in MainWindow.
            OnPropertyChanged("BTCPRICE");
            OnPropertyChanged("PCP24H");
            OnPropertyChanged("PCP24HCOLOUR");

            int ETHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "ethereum");

            ETHPRICE = (SttringCurrency + CoinAPIData[ETHINDEX].current_price);
            ETH24H = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_24h_in_currency);
            ETH24HCOLOUR = colourCheck.ColourCheck(ETH24H);
            OnPropertyChanged("ETHPRICE");
            OnPropertyChanged("ETH24H");
            OnPropertyChanged("ETH24HCOLOUR");

            int ADAINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "cardano");

            ADAPRICE = (SttringCurrency + CoinAPIData[ADAINDEX].current_price);
            ADA24H = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_24h_in_currency);
            ADA24HCOLOUR = colourCheck.ColourCheck(ADA24H);
            OnPropertyChanged("ADAPRICE");
            OnPropertyChanged("ADA24H");
            OnPropertyChanged("ADA24HCOLOUR");

            int BNBINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "binancecoin");

            BNBPRICE = (SttringCurrency + CoinAPIData[BNBINDEX].current_price);
            BNB24H = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_24h_in_currency);
            BNB24HCOLOUR = colourCheck.ColourCheck(BNB24H);
            OnPropertyChanged("BNBPRICE");
            OnPropertyChanged("BNB24H");
            OnPropertyChanged("BNB24HCOLOUR");

            int DOGEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "dogecoin");

            DOGEPRICE = (SttringCurrency + CoinAPIData[DOGEINDEX].current_price);
            DOGE24H = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_24h_in_currency);
            DOGE24HCOLOUR = colourCheck.ColourCheck(DOGE24H);
            OnPropertyChanged("DOGEPRICE");
            OnPropertyChanged("DOGE24H");
            OnPropertyChanged("DOGE24HCOLOUR");

            int XRPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "ripple");

            XRPPRICE = (SttringCurrency + CoinAPIData[XRPINDEX].current_price);
            XRP24H = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_24h_in_currency);
            XRP24HCOLOUR = colourCheck.ColourCheck(XRP24H);
            OnPropertyChanged("XRPPRICE");
            OnPropertyChanged("XRP24H");
            OnPropertyChanged("XRP24HCOLOUR");

            int DOTINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "polkadot");

            DOTPRICE = (SttringCurrency + CoinAPIData[DOTINDEX].current_price);
            DOT24H = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_24h_in_currency);
            DOT24HCOLOUR = colourCheck.ColourCheck(DOT24H);
            OnPropertyChanged("DOTPRICE");
            OnPropertyChanged("DOT24H");
            OnPropertyChanged("DOT24HCOLOUR");

            int BTCCASHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "bitcoin-cash");

            BTCCASHPRICE = (SttringCurrency + CoinAPIData[BTCCASHINDEX].current_price);
            BTCCASH24H = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_24h_in_currency);
            BTCCASH24HCOLOUR = colourCheck.ColourCheck(BTCCASH24H);
            OnPropertyChanged("BTCCASHPRICE");
            OnPropertyChanged("BTCCASH24H");
            OnPropertyChanged("BTCCASH24HCOLOUR");

            int UNIINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "uniswap");

            UNIPRICE = (SttringCurrency + CoinAPIData[UNIINDEX].current_price);
            UNI24H = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_24h_in_currency);
            UNI24HCOLOUR = colourCheck.ColourCheck(UNI24H);
            OnPropertyChanged("UNIPRICE");
            OnPropertyChanged("UNI24H");
            OnPropertyChanged("UNI24HCOLOUR");

            int SOLINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "solana");

            SOLPRICE = (SttringCurrency + CoinAPIData[SOLINDEX].current_price);
            SOL24H = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_24h_in_currency);
            SOL24HCOLOUR = colourCheck.ColourCheck(SOL24H);
            OnPropertyChanged("SOLPRICE");
            OnPropertyChanged("SOL24H");
            OnPropertyChanged("SOL24HCOLOUR");

            int LTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "litecoin");

            LTCPRICE = (SttringCurrency + CoinAPIData[LTCINDEX].current_price);
            LTC24H = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_24h_in_currency);
            LTC24HCOLOUR = colourCheck.ColourCheck(LTC24H);
            OnPropertyChanged("LTCPRICE");
            OnPropertyChanged("LTC24H");
            OnPropertyChanged("LTC24HCOLOUR");

            int LINKINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "chainlink");

            LINKPRICE = (SttringCurrency + CoinAPIData[LINKINDEX].current_price);
            LINK24H = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_24h_in_currency);
            LINK24HCOLOUR = colourCheck.ColourCheck(LINK24H);
            OnPropertyChanged("LINKPRICE");
            OnPropertyChanged("LINK24H");
            OnPropertyChanged("LINK24HCOLOUR");

            int ETHCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "ethereum-classic");

            ETHCPRICE = (SttringCurrency + CoinAPIData[ETHCINDEX].current_price);
            ETHC24H = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_24h_in_currency);
            ETHC24HCOLOUR = colourCheck.ColourCheck(ETHC24H);
            OnPropertyChanged("ETHCPRICE");
            OnPropertyChanged("ETHC24H");
            OnPropertyChanged("ETHC24HCOLOUR");

            int MATICINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "matic-network");

            MATICPRICE = (SttringCurrency + CoinAPIData[MATICINDEX].current_price);
            MATIC24H = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_24h_in_currency);
            MATIC24HCOLOUR = colourCheck.ColourCheck(MATIC24H);
            OnPropertyChanged("MATICPRICE");
            OnPropertyChanged("MATIC24H");
            OnPropertyChanged("MATIC24HCOLOUR");

            int WBTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "wrapped-bitcoin");

            WBTCPRICE = (SttringCurrency + CoinAPIData[WBTCINDEX].current_price);
            WBTC24H = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_24h_in_currency);
            WBTC24HCOLOUR = colourCheck.ColourCheck(WBTC24H);
            OnPropertyChanged("WBTCPRICE");
            OnPropertyChanged("WBTC24H");
            OnPropertyChanged("WBTC24HCOLOUR");

            int ICPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "internet-computer");

            ICPPRICE = (SttringCurrency + CoinAPIData[ICPINDEX].current_price);
            ICP24H = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_24h_in_currency);
            ICP24HCOLOUR = colourCheck.ColourCheck(ICP24H);
            OnPropertyChanged("ICPPRICE");
            OnPropertyChanged("ICP24H");
            OnPropertyChanged("ICP24HCOLOUR");

            int THETAINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "theta-token");

            THETAPRICE = (SttringCurrency + CoinAPIData[THETAINDEX].current_price);
            THETA24H = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_24h_in_currency);
            THETA24HCOLOUR = colourCheck.ColourCheck(THETA24H);
            OnPropertyChanged("THETAPRICE");
            OnPropertyChanged("THETA24H");
            OnPropertyChanged("THETA24HCOLOUR");

            int XLMINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "stellar");

            XLMPRICE = (SttringCurrency + CoinAPIData[XLMINDEX].current_price);
            XLM24H = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_24h_in_currency);
            XLM24HCOLOUR = colourCheck.ColourCheck(XLM24H);
            OnPropertyChanged("XLMPRICE");
            OnPropertyChanged("XLM24H");
            OnPropertyChanged("XLM24HCOLOUR");

            int VETINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "vechain");

            VETPRICE = (SttringCurrency + CoinAPIData[VETINDEX].current_price);
            VET24H = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_24h_in_currency);
            VET24HCOLOUR = colourCheck.ColourCheck(VET24H);
            OnPropertyChanged("VETPRICE");
            OnPropertyChanged("VET24H");
            OnPropertyChanged("VET24HCOLOUR");

            int DAIINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "dai");

            DAIPRICE = (SttringCurrency + CoinAPIData[DAIINDEX].current_price);
            DAI24H = stringSolver.ShortenStringData(CoinAPIData[DAIINDEX].price_change_percentage_24h_in_currency);
            DAI24HCOLOUR = colourCheck.ColourCheck(DAI24H);
            OnPropertyChanged("DAIPRICE");
            OnPropertyChanged("DAI24H");
            OnPropertyChanged("DAI24HCOLOUR");

            int FILINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "filecoin");

            FILPRICE = (SttringCurrency + CoinAPIData[FILINDEX].current_price);
            FIL24H = stringSolver.ShortenStringData(CoinAPIData[FILINDEX].price_change_percentage_24h_in_currency);
            FIL24HCOLOUR = colourCheck.ColourCheck(FIL24H);
            OnPropertyChanged("FILPRICE");
            OnPropertyChanged("FIL24H");
            OnPropertyChanged("FIL24HCOLOUR");

            int TRXINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "tron");

            TRXPRICE = (SttringCurrency + CoinAPIData[TRXINDEX].current_price);
            TRX24H = stringSolver.ShortenStringData(CoinAPIData[TRXINDEX].price_change_percentage_24h_in_currency);
            TRX24HCOLOUR = colourCheck.ColourCheck(TRX24H);
            OnPropertyChanged("TRXPRICE");
            OnPropertyChanged("TRX24H");
            OnPropertyChanged("TRX24HCOLOUR");

            int SHIBINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "shiba-inu");

            SHIBPRICE = (SttringCurrency + CoinAPIData[SHIBINDEX].current_price);
            SHIB24H = stringSolver.ShortenStringData(CoinAPIData[SHIBINDEX].price_change_percentage_24h_in_currency);
            SHIB24HCOLOUR = colourCheck.ColourCheck(SHIB24H);
            OnPropertyChanged("SHIBPRICE");
            OnPropertyChanged("SHIB24H");
            OnPropertyChanged("SHIB24HCOLOUR");

            int XMRINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "monero");

            XMRPRICE = (SttringCurrency + CoinAPIData[XMRINDEX].current_price);
            XMR24H = stringSolver.ShortenStringData(CoinAPIData[XMRINDEX].price_change_percentage_24h_in_currency);
            XMR24HCOLOUR = colourCheck.ColourCheck(XMR24H);
            OnPropertyChanged("XMRPRICE");
            OnPropertyChanged("XMR24H");
            OnPropertyChanged("XMR24HCOLOUR");

            int ATOMINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "cosmos");

            ATOMPRICE = (SttringCurrency + CoinAPIData[ATOMINDEX].current_price);
            ATOM24H = stringSolver.ShortenStringData(CoinAPIData[ATOMINDEX].price_change_percentage_24h_in_currency);
            ATOM24HCOLOUR = colourCheck.ColourCheck(ATOM24H);
            OnPropertyChanged("ATOMPRICE");
            OnPropertyChanged("ATOM24H");
            OnPropertyChanged("ATOM24HCOLOUR");

            int AAVEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "aave");

            AAVEPRICE = (SttringCurrency + CoinAPIData[AAVEINDEX].current_price);
            AAVE24H = stringSolver.ShortenStringData(CoinAPIData[AAVEINDEX].price_change_percentage_24h_in_currency);
            AAVE24HCOLOUR = colourCheck.ColourCheck(AAVE24H);
            OnPropertyChanged("AAVEPRICE");
            OnPropertyChanged("AAVE24H");
            OnPropertyChanged("AAVE24HCOLOUR");

            int EOSINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "eos");

            EOSPRICE = (SttringCurrency + CoinAPIData[EOSINDEX].current_price);
            EOS24H = stringSolver.ShortenStringData(CoinAPIData[EOSINDEX].price_change_percentage_24h_in_currency);
            EOS24HCOLOUR = colourCheck.ColourCheck(EOS24H);
            OnPropertyChanged("EOSPRICE");
            OnPropertyChanged("EOS24H");
            OnPropertyChanged("EOS24HCOLOUR");


            int ALGOINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Algorand");

            ALGOPRICE = (SttringCurrency + CoinAPIData[ALGOINDEX].current_price);
            ALGO24H = stringSolver.ShortenStringData(CoinAPIData[ALGOINDEX].price_change_percentage_24h_in_currency);
            ALGO24HCOLOUR = colourCheck.ColourCheck(ALGO24H);
            OnPropertyChanged("ALGOPRICE");
            OnPropertyChanged("ALGO24H");
            OnPropertyChanged("ALGO24HCOLOUR");

            int CAKEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "pancakeswap-token");

            CAKEPRICE = (SttringCurrency + CoinAPIData[CAKEINDEX].current_price);
            CAKE24H = stringSolver.ShortenStringData(CoinAPIData[CAKEINDEX].price_change_percentage_24h_in_currency);
            CAKE24HCOLOUR = colourCheck.ColourCheck(CAKE24H);
            OnPropertyChanged("CAKEPRICE");
            OnPropertyChanged("CAKE24H");
            OnPropertyChanged("CAKE24HCOLOUR");

            int AMPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "amp-token");

            AMPPRICE = (SttringCurrency + CoinAPIData[AMPINDEX].current_price);
            AMP24H = stringSolver.ShortenStringData(CoinAPIData[AMPINDEX].price_change_percentage_24h_in_currency);
            AMP24HCOLOUR = colourCheck.ColourCheck(AMP24H);
            OnPropertyChanged("AMPPRICE");
            OnPropertyChanged("AMP24H");
            OnPropertyChanged("AMP24HCOLOUR");
        }
        
    }
}
