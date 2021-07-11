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
        public string CURRENCYVALUE { get; set; }
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

            // Checks the coin code name
            if (CoinCodeName == "bitcoin")
            {

                // Checks index of coin.
                int BTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin");
                // Set the image to current coin.
                CoinImage.Source = new BitmapImage(new Uri("Images/bitcoin.png", UriKind.Relative));
                
                Cointitle.Text = "Bitcoin";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[BTCINDEX].current_price);

                
                // Sets sub window elements.
                CoinPriceIDATH.Text = StringCurrency + CoinAPIData[BTCINDEX].ath;

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_1h_in_currency);
                
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BTCINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BTCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BTCINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BTCINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BTCINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "ethereum")
            {
                // Repeat...
                int ETHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum");
                CoinImage.Source = new BitmapImage(new Uri("Images/ethereum.png", UriKind.Relative));
                Cointitle.Text = "Ethereum";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[ETHINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[ETHINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = (SolidColorBrush)brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ETHINDEX].price_change_percentage_1h_in_currency));

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ETHINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ETHINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ETHINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ETHINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "cardano")
            {
                
                int ADAINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Cardano");
                CoinImage.Source = new BitmapImage(new Uri("Images/cardano.png", UriKind.Relative));
                Cointitle.Text = "Cardano";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[ADAINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[ADAINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ADAINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ADAINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ADAINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ADAINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ADAINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "binancecoin")
            {
                int BNBINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Binance Coin");
                CoinImage.Source = new BitmapImage(new Uri("Images/binancecoin.png", UriKind.Relative));
                Cointitle.Text = "Binance";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[BNBINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[BNBINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BNBINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BNBINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BNBINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BNBINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BNBINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "dogecoin")
            {
                int DOGEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Dogecoin");
                CoinImage.Source = new BitmapImage(new Uri("Images/dogecoin.png", UriKind.Relative));
                Cointitle.Text = "Dogecoin";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[DOGEINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[DOGEINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DOGEINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DOGEINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DOGEINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DOGEINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DOGEINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "xrp")
            {
                int XRPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "XRP");
                CoinImage.Source = new BitmapImage(new Uri("Images/ripple.png", UriKind.Relative));
                Cointitle.Text = "XRP";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[XRPINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[XRPINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XRPINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XRPINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XRPINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XRPINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XRPINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "polkadot")
            {
                int DOTINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Polkadot");

                CoinImage.Source = new BitmapImage(new Uri("Images/polkadot.png", UriKind.Relative));
                Cointitle.Text = "Polkadot";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[DOTINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[DOTINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DOTINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DOTINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DOTINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DOTINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                if (CoinAPIData[DOTINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPriceID1Y.Text = "N/A";
                    Brush DOTColour = brushConverter.ConvertFrom("#DF5F67") as SolidColorBrush;
                    CoinPriceID1Y.Foreground = DOTColour;
                }
                else
                {
                    CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_1y_in_currency);
                    CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DOTINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
                }
                
            }
            else if (CoinCodeName == "bitcoincash")
            {
                int BTCCASHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin Cash");

                CoinImage.Source = new BitmapImage(new Uri("Images/bitcoincash.png", UriKind.Relative));
                Cointitle.Text = "Bitcoin $";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[BTCCASHINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[BTCCASHINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BTCCASHINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BTCCASHINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BTCCASHINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BTCCASHINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[BTCCASHINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;

            }
            else if (CoinCodeName == "uniswap")
            {
                int UNIINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Uniswap");

                CoinImage.Source = new BitmapImage(new Uri("Images/uniswap.png", UriKind.Relative));
                Cointitle.Text = "Uniswap";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[UNIINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[UNIINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[UNIINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[UNIINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[UNIINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[UNIINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                if (CoinAPIData[8].price_change_percentage_1y_in_currency == null)
                {
                    CoinPriceID1Y.Text = "N/A";
                    Brush DOTColour = brushConverter.ConvertFrom("#DF5F67") as SolidColorBrush;
                    CoinPriceID1Y.Foreground = DOTColour;
                }
                else
                {
                    CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_1y_in_currency);
                    CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[UNIINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
                }

               
            }
            else if (CoinCodeName == "solana")
            {
                int SOLINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Solana");

                CoinImage.Source = new BitmapImage(new Uri("Images/solana.png", UriKind.Relative));
                Cointitle.Text = "Solana";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[SOLINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[SOLINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[SOLINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[SOLINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[SOLINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[SOLINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[SOLINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "litecoin")
            {
                int LTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Litecoin");

                CoinImage.Source = new BitmapImage(new Uri("Images/litecoin.png", UriKind.Relative));
                Cointitle.Text = "Litecoin";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[LTCINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[LTCINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[LTCINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[LTCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[LTCINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[LTCINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[LTCINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "chainlink")
            {
                int LINKINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Chainlink");

                CoinImage.Source = new BitmapImage(new Uri("Images/chainlink.png", UriKind.Relative));
                Cointitle.Text = "Chainlink";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[LINKINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[LINKINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[LINKINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[LINKINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[LINKINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[LINKINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[LINKINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "ethereumclassic")
            {
                int ETHCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum Classic");

                CoinImage.Source = new BitmapImage(new Uri("Images/ethereumclassic.png", UriKind.Relative));
                Cointitle.Text = "ETC";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[ETHCINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[ETHCINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ETHCINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ETHCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ETHCINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ETHCINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ETHCINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "polygon")
            {
                int MATICINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Polygon");

                CoinImage.Source = new BitmapImage(new Uri("Images/polygon.png", UriKind.Relative));
                Cointitle.Text = "Polygon";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[MATICINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[MATICINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[MATICINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[MATICINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[MATICINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[MATICINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[MATICINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "wrappedbitcoin")
            {
                int WBTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Wrapped Bitcoin");

                CoinImage.Source = new BitmapImage(new Uri("Images/wrappedbitcoin.png", UriKind.Relative));
                Cointitle.Text = "WBTC";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[WBTCINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[WBTCINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[WBTCINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[WBTCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[WBTCINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[WBTCINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[WBTCINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "internetcomputer")
            {
                int ICPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Internet Computer");

                CoinImage.Source = new BitmapImage(new Uri("Images/internetcomputer.png", UriKind.Relative));
                Cointitle.Text = "ICP";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[ICPINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[ICPINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ICPINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ICPINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ICPINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ICPINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                if (CoinAPIData[ICPINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPriceID1Y.Text = "N/A";
                    Brush DOTColour = brushConverter.ConvertFrom("#DF5F67") as SolidColorBrush;
                    CoinPriceID1Y.Foreground = DOTColour;
                }
                else
                {
                    CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_1y_in_currency);
                    CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ICPINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
                }

                
            }
            else if (CoinCodeName == "theta")
            {
                int THETAINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Theta Network");

                CoinImage.Source = new BitmapImage(new Uri("Images/theta.png", UriKind.Relative));
                Cointitle.Text = "Theta";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[THETAINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[THETAINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[THETAINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[THETAINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[THETAINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[THETAINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[THETAINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "stellar")
            {
                int XLMINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Stellar");

                CoinImage.Source = new BitmapImage(new Uri("Images/stellar.png", UriKind.Relative));
                Cointitle.Text = "Stellar";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[XLMINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[XLMINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XLMINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XLMINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XLMINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XLMINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XLMINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "vechain")
            {
                int VETINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "VeChain");

                CoinImage.Source = new BitmapImage(new Uri("Images/vechain.png", UriKind.Relative));
                Cointitle.Text = "VeChain";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[VETINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[VETINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[VETINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[VETINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[VETINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[VETINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[VETINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "dai")
            {
                int DAIINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Dai");

                CoinImage.Source = new BitmapImage(new Uri("Images/dai.png", UriKind.Relative));
                Cointitle.Text = "Dai";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[DAIINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[DAIINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[DAIINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DAIINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[DAIINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DAIINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[DAIINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DAIINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[DAIINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DAIINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[DAIINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[DAIINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "filecoin")
            {
                int FILINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Filecoin");

                CoinImage.Source = new BitmapImage(new Uri("Images/filecoin.png", UriKind.Relative));
                Cointitle.Text = "Filecoin";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[FILINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[FILINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[FILINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[FILINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[FILINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[FILINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[FILINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[FILINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[FILINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[FILINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                if (CoinAPIData[FILINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPriceID1Y.Text = "N/A";
                    Brush DOTColour = brushConverter.ConvertFrom("#DF5F67") as SolidColorBrush;
                    CoinPriceID1Y.Foreground = DOTColour;
                }
                else
                {
                    CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[FILINDEX].price_change_percentage_1y_in_currency);
                    CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[FILINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
                }
                
            }
            else if (CoinCodeName == "tron")
            {
                int TRXINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "TRON");

                CoinImage.Source = new BitmapImage(new Uri("Images/tron.png", UriKind.Relative));
                Cointitle.Text = "TRON";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[TRXINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[TRXINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[TRXINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[TRXINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[TRXINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[TRXINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[TRXINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[TRXINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[TRXINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[TRXINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[TRXINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[TRXINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "shibainu")
            {
                int SHIBINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Shiba Inu");

                CoinImage.Source = new BitmapImage(new Uri("Images/shibainu.png", UriKind.Relative));
                Cointitle.Text = "Shiba Inu";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[SHIBINDEX].current_price);
                

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[SHIBINDEX].ath);
                
                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[SHIBINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[SHIBINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[SHIBINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[SHIBINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[SHIBINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[SHIBINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[SHIBINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[SHIBINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                if (CoinAPIData[SHIBINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPriceID1Y.Text = "N/A";
                    Brush DOTColour = brushConverter.ConvertFrom("#DF5F67") as SolidColorBrush;
                    CoinPriceID1Y.Foreground = DOTColour;
                }
                else
                {
                    CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[SHIBINDEX].price_change_percentage_1y_in_currency);
                    CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[SHIBINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
                }

            }
            else if (CoinCodeName == "monero")
            {
                int XMRINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Monero");

                CoinImage.Source = new BitmapImage(new Uri("Images/monero.png", UriKind.Relative));
                Cointitle.Text = "Monero";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[XMRINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[XMRINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[XMRINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XMRINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[XMRINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XMRINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[XMRINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XMRINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[XMRINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XMRINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[XMRINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[XMRINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "cosmos")
            {
                int ATOMINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Cosmos");

                CoinImage.Source = new BitmapImage(new Uri("Images/cosmos.png", UriKind.Relative));
                Cointitle.Text = "Cosmos";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[ATOMINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[ATOMINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[ATOMINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ATOMINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[ATOMINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ATOMINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[ATOMINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ATOMINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[ATOMINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ATOMINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[ATOMINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ATOMINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "aave")
            {
                int AAVEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Aave");

                CoinImage.Source = new BitmapImage(new Uri("Images/AAVE.png", UriKind.Relative));
                Cointitle.Text = "Aave";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[AAVEINDEX].current_price);


                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[AAVEINDEX].ath);
                
                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[AAVEINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[AAVEINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[AAVEINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[AAVEINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[AAVEINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[AAVEINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[AAVEINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[AAVEINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                if (CoinAPIData[AAVEINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPriceID1Y.Text = "N/A";
                    Brush DOTColour = brushConverter.ConvertFrom("#DF5F67") as SolidColorBrush;
                    CoinPriceID1Y.Foreground = DOTColour;
                }
                else
                {
                    CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[AAVEINDEX].price_change_percentage_1y_in_currency);
                    CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[AAVEINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
                }

            }
            else if (CoinCodeName == "eos")
            {
                int EOSINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "EOS");

                CoinImage.Source = new BitmapImage(new Uri("Images/eos.png", UriKind.Relative));
                Cointitle.Text = "EOS";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[EOSINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[EOSINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[EOSINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[EOSINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[EOSINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[EOSINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[EOSINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[EOSINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[EOSINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[EOSINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[EOSINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[EOSINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "algorand")
            {
                int ALGOINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Algorand");

                CoinImage.Source = new BitmapImage(new Uri("Images/algorand.png", UriKind.Relative));
                Cointitle.Text = "Algorand";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[ALGOINDEX].current_price);

                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[ALGOINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[ALGOINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ALGOINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[ALGOINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ALGOINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[ALGOINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ALGOINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[ALGOINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ALGOINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[ALGOINDEX].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[ALGOINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "pancakeswap")
            {
                int CAKEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "PancakeSwap");

                CoinImage.Source = new BitmapImage(new Uri("Images/pancakeswap.png", UriKind.Relative));
                Cointitle.Text = "CAKE";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[CAKEINDEX].current_price);


                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[CAKEINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[CAKEINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[CAKEINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[CAKEINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[CAKEINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[CAKEINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[CAKEINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[CAKEINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[CAKEINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                if (CoinAPIData[CAKEINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPriceID1Y.Text = "N/A";
                    Brush DOTColour = brushConverter.ConvertFrom("#DF5F67") as SolidColorBrush;
                    CoinPriceID1Y.Foreground = DOTColour;
                }
                else
                {
                    CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[CAKEINDEX].price_change_percentage_1y_in_currency);
                    CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[CAKEINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
                }

            }
            else if (CoinCodeName == "amp")
            {
                int AMPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Amp");

                CoinImage.Source = new BitmapImage(new Uri("Images/amp.png", UriKind.Relative));
                Cointitle.Text = "Amp";
                CoinPriceID.Text = Convert.ToString(StringCurrency + CoinAPIData[AMPINDEX].current_price);


                CoinPriceIDATH.Text = (StringCurrency + CoinAPIData[AMPINDEX].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(CoinAPIData[AMPINDEX].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[AMPINDEX].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(CoinAPIData[AMPINDEX].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[AMPINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(CoinAPIData[AMPINDEX].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[AMPINDEX].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(CoinAPIData[AMPINDEX].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[AMPINDEX].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                if (CoinAPIData[AMPINDEX].price_change_percentage_1y_in_currency == null)
                {
                    CoinPriceID1Y.Text = "N/A";
                    Brush DOTColour = brushConverter.ConvertFrom("#DF5F67") as SolidColorBrush;
                    CoinPriceID1Y.Foreground = DOTColour;
                }
                else
                {
                    CoinPriceID1Y.Text = stringSolver.ShortenStringData(CoinAPIData[AMPINDEX].price_change_percentage_1y_in_currency);
                    CoinPriceID1Y.Foreground = brushConverter.ConvertFrom(colourCheck.ColourCheck(CoinAPIData[AMPINDEX].price_change_percentage_1y_in_currency)) as SolidColorBrush;
                }

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
    }
}
