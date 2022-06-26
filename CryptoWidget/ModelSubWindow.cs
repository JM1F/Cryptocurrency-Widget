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


            // Check index for coin.
            CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, CoinCodeName);
            
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
