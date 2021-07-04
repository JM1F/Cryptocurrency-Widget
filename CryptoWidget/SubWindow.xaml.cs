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
        public static string CoinCodeName;

        /// <summary>
        /// SubWindow Initialize class
        /// </summary>
        /// <param name="CoinType"></param>
        public SubWindow(string CoinType)
        {
            // Set the variable to parameter CoinType
            CoinCodeName = CoinType;

            this.Owner = App.Current.MainWindow;
            // Set data context to the model for the sub window.
            this.DataContext = new ModelSubWindow(CoinCodeName);

            InitializeComponent();
        }
        /// <summary>
        /// Gets the data at the beginning for the sub window.
        /// </summary>
        /// <returns></returns>
        public async Task GetBeginningData()
        {
            // Call API data
            var CoinAPIData = await dataLoad.LoadData();
            // Calls classes for the checks the data have to go through.
            ColorPriceCheck n = new ColorPriceCheck();
            StringSolver stringSolver = new StringSolver();
            APIDataChecker aPIDataChecker = new APIDataChecker();
            BrushConverter brushConverter = new BrushConverter();

            // Checks the coin code name
            if (CoinCodeName == "bitcoin")
            {

                // Checks index of coin.
                int index = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin");
                // Set the image to current coin.
                CoinImage.Source = new BitmapImage(new Uri("Images/bitcoin.png", UriKind.Relative));
                
                Cointitle.Text = "Bitcoin";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[index].current_price);

                
                // Sets sub window elements.
                CoinPriceIDATH.Text = "£" + CoinAPIData[index].ath;

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1h_in_currency);
                
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "ethereum")
            {
                // Repeat...
                int index = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum");
                CoinImage.Source = new BitmapImage(new Uri("Images/ethereum.png", UriKind.Relative));
                Cointitle.Text = "Ethereum";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[index].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[index].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = (SolidColorBrush)brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_1h_in_currency));

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "cardano")
            {
                
                int index = aPIDataChecker.IndexCheck(CoinAPIData, "Cardano");
                CoinImage.Source = new BitmapImage(new Uri("Images/cardano.png", UriKind.Relative));
                Cointitle.Text = "Cardano";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[index].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[index].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "binancecoin")
            {
                int index = aPIDataChecker.IndexCheck(CoinAPIData, "Binance Coin");
                CoinImage.Source = new BitmapImage(new Uri("Images/binancecoin.png", UriKind.Relative));
                Cointitle.Text = "Binance";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[index].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[index].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "dogecoin")
            {
                int index = aPIDataChecker.IndexCheck(CoinAPIData, "Dogecoin");
                CoinImage.Source = new BitmapImage(new Uri("Images/dogecoin.png", UriKind.Relative));
                Cointitle.Text = "Dogecoin";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[index].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[index].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "xrp")
            {
                int index = aPIDataChecker.IndexCheck(CoinAPIData, "XRP");
                CoinImage.Source = new BitmapImage(new Uri("Images/ripple.png", UriKind.Relative));
                Cointitle.Text = "XRP";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[index].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[index].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[index].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[index].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "polkadot")
            {
                CoinImage.Source = new BitmapImage(new Uri("Images/polkadot.png", UriKind.Relative));
                Cointitle.Text = "Polkadot";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[8].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[8].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[8].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[8].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[8].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[8].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[8].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[8].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[8].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[8].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                if (CoinAPIData[8].price_change_percentage_1y_in_currency == null)
                {
                    CoinPriceID1Y.Text = "N/A";
                    Brush DOTColour = brushConverter.ConvertFrom("#DF5F67") as SolidColorBrush;
                    CoinPriceID1Y.Foreground = DOTColour;
                }
                else
                {
                    CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[8].price_change_percentage_1y_in_currency);
                    CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[8].price_change_percentage_1y_in_currency)) as SolidColorBrush;
                }
                
            }
            else if (CoinCodeName == "bitcoincash")
            {
                int BTCCASHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin Cash");

                CoinImage.Source = new BitmapImage(new Uri("Images/bitcoincash.png", UriKind.Relative));
                Cointitle.Text = "Bitcoin $";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[BTCCASHINDEX].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[BTCCASHINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[BTCCASHINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[BTCCASHINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[BTCCASHINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[BTCCASHINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[BTCCASHINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;

            }
            else if (CoinCodeName == "uniswap")
            {
                int UNIINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Uniswap");

                CoinImage.Source = new BitmapImage(new Uri("Images/uniswap.png", UriKind.Relative));
                Cointitle.Text = "Uniswap";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[UNIINDEX].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[UNIINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[UNIINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[UNIINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[UNIINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[UNIINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                if (CoinAPIData[8].price_change_percentage_1y_in_currency == null)
                {
                    CoinPriceID1Y.Text = "N/A";
                    Brush DOTColour = brushConverter.ConvertFrom("#DF5F67") as SolidColorBrush;
                    CoinPriceID1Y.Foreground = DOTColour;
                }
                else
                {
                    CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_1y_in_currency);
                    CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[UNIINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
                }

               
            }
            else if (CoinCodeName == "solana")
            {
                int SOLINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Solana");

                CoinImage.Source = new BitmapImage(new Uri("Images/solana.png", UriKind.Relative));
                Cointitle.Text = "Solana";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[SOLINDEX].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[SOLINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[SOLINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[SOLINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[SOLINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[SOLINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[SOLINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "litecoin")
            {
                int LTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Litecoin");

                CoinImage.Source = new BitmapImage(new Uri("Images/litecoin.png", UriKind.Relative));
                Cointitle.Text = "Litecoin";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[LTCINDEX].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[LTCINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[LTCINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[LTCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[LTCINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[LTCINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[LTCINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "chainlink")
            {
                int LINKINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Chainlink");

                CoinImage.Source = new BitmapImage(new Uri("Images/chainlink.png", UriKind.Relative));
                Cointitle.Text = "Chainlink";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[LINKINDEX].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[LINKINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[LINKINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[LINKINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[LINKINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[LINKINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[LINKINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "ethereumclassic")
            {
                int ETHCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum Classic");

                CoinImage.Source = new BitmapImage(new Uri("Images/ethereumclassic.png", UriKind.Relative));
                Cointitle.Text = "ETC";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[ETHCINDEX].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[ETHCINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[ETHCINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[ETHCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[ETHCINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[ETHCINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[ETHCINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "polygon")
            {
                int MATICINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Polygon");

                CoinImage.Source = new BitmapImage(new Uri("Images/polygon.png", UriKind.Relative));
                Cointitle.Text = "Polygon";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[MATICINDEX].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[MATICINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[MATICINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[MATICINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[MATICINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[MATICINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[MATICINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "wrappedbitcoin")
            {
                int WBTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Wrapped Bitcoin");

                CoinImage.Source = new BitmapImage(new Uri("Images/wrappedbitcoin.png", UriKind.Relative));
                Cointitle.Text = "WBTC";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[WBTCINDEX].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[WBTCINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[WBTCINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[WBTCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[WBTCINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[WBTCINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[WBTCINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "internetcomputer")
            {
                int ICPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Internet Computer");

                CoinImage.Source = new BitmapImage(new Uri("Images/internetcomputer.png", UriKind.Relative));
                Cointitle.Text = "ICP";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[ICPINDEX].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[ICPINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[ICPINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[ICPINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[ICPINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[ICPINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                if (CoinAPIData[8].price_change_percentage_1y_in_currency == null)
                {
                    CoinPriceID1Y.Text = "N/A";
                    Brush DOTColour = brushConverter.ConvertFrom("#DF5F67") as SolidColorBrush;
                    CoinPriceID1Y.Foreground = DOTColour;
                }
                else
                {
                    CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_1y_in_currency);
                    CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[ICPINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
                }

                
            }
            else if (CoinCodeName == "theta")
            {
                int THETAINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Theta Network");

                CoinImage.Source = new BitmapImage(new Uri("Images/theta.png", UriKind.Relative));
                Cointitle.Text = "Theta";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[THETAINDEX].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[THETAINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[THETAINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[THETAINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[THETAINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[THETAINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[THETAINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "stellar")
            {
                int XLMINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Stellar");

                CoinImage.Source = new BitmapImage(new Uri("Images/stellar.png", UriKind.Relative));
                Cointitle.Text = "Stellar";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[XLMINDEX].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[XLMINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[XLMINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[XLMINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[XLMINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[XLMINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[XLMINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "vechain")
            {
                int VETINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "VeChain");

                CoinImage.Source = new BitmapImage(new Uri("Images/vechain.png", UriKind.Relative));
                Cointitle.Text = "VeChain";
                CoinPriceID.Text = Convert.ToString("£" + CoinAPIData[VETINDEX].current_price);

                CoinPriceIDATH.Text = ("£" + CoinAPIData[VETINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[VETINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[VETINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[VETINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[VETINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(n.ColourCheck(CoinAPIData[VETINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
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
            this.Close();
            ModelSubWindow.atimer.Stop();
            
        }
    }
}
