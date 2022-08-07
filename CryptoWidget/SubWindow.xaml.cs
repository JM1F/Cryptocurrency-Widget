using APILibary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CryptoWidget
{
    /// <summary>
    /// Interaction logic for SubWindow.xaml
    /// </summary>
    public partial class SubWindow : Window
    {
        // Coin name for sub window type.
        public string CoinCodeName { get; set; }
        public string CURRENCYVALUE { get; set; }
        public int CoinIndex { get; set; }

        /// <summary>
        /// SubWindow Initialize class
        /// </summary>
        /// <param name="CoinType"></param>
        public SubWindow(string CoinType, string Currency)
        {
            CURRENCYVALUE = Currency;
            // Set the variable to parameter CoinType
            CoinCodeName = CoinType;

            this.Owner = App.Current.MainWindow;

            // Set data context to the model for the sub window.
            this.DataContext = new ModelSubWindow(CoinCodeName, CURRENCYVALUE);

            InitializeComponent();
        }
        /// <summary>
        /// Gets the data at the beginning for the sub window.
        /// </summary>
        /// <returns></returns>
        public async Task GetBeginningData()
        {
            // Call API data
            var CoinAPIData = await dataLoad.LoadData(CURRENCYVALUE);
            // Calls classes for the checks the data have to go through.
            ColorPriceCheck colourCheck = new ColorPriceCheck();
            StringSolver stringSolver = new StringSolver();
            APIDataChecker aPIDataChecker = new APIDataChecker();
            BrushConverter brushConverter = new BrushConverter();

            string StringCurrency = CURRENCYVALUE[38].ToString();


            // Checks index of coin.
            CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, CoinCodeName);
            // Set the image to current coin.
            CoinImage.Source = new BitmapImage(new Uri(changeAPIImageSize(CoinAPIData[CoinIndex].image)));

            Cointitle.Text = CoinAPIData[CoinIndex].Name;

            Brush NAColour = brushConverter.ConvertFrom("#DF5F67") as SolidColorBrush;

            CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[CoinIndex].current_price);

            CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[CoinIndex].ath);

      
            if (CoinAPIData[CoinIndex].price_change_percentage_1h_in_currency == null)
            {
                CoinPriceID1Y.Text = "N/A";
                CoinPriceID1Y.Foreground = NAColour;
            }
            else
            {
                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[CoinIndex].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[CoinIndex].price_change_percentage_1h_in_currency)) as SolidColorBrush;
            }
            if (CoinAPIData[CoinIndex].price_change_percentage_24h_in_currency == null)
            {
                CoinPriceID1Y.Text = "N/A";
                CoinPriceID1Y.Foreground = NAColour;
            }
            else
            {
                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[CoinIndex].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[CoinIndex].price_change_percentage_24h_in_currency)) as SolidColorBrush;
            }
            if (CoinAPIData[CoinIndex].price_change_percentage_7d_in_currency == null)
            {
                CoinPriceID1Y.Text = "N/A";
                CoinPriceID1Y.Foreground = NAColour;
            }
            else
            {
                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[CoinIndex].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[CoinIndex].price_change_percentage_7d_in_currency)) as SolidColorBrush;
            }
            if (CoinAPIData[CoinIndex].price_change_percentage_30d_in_currency == null)
            {
                CoinPriceID1Y.Text = "N/A";
                CoinPriceID1Y.Foreground = NAColour;
            }
            else
            {
                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[CoinIndex].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[CoinIndex].price_change_percentage_30d_in_currency)) as SolidColorBrush;
            }
            if (CoinAPIData[CoinIndex].price_change_percentage_1y_in_currency == null)
            {
                CoinPriceID1Y.Text = "N/A";
                CoinPriceID1Y.Foreground = NAColour;
            }
            else
            {
                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[CoinIndex].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[CoinIndex].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
        }


        /// <summary>
        /// Checks to see when the window is loaded and gets the beginning data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            await GetBeginningData();
            
            
        }
        /// <summary>
        /// allows you to drag the titlebar when clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void titleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        /// <summary>
        /// Allows you to exit the window when the exit button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void exitButton_Click(object sender, RoutedEventArgs e)
        {
            ModelSubWindow.atimer.Stop();
            this.Close();
            
            
        }
        public string changeAPIImageSize(string originalURL)
        {
            string newURL = originalURL.Replace("/large/", "/small/");
            return newURL;
        }
    }
}
