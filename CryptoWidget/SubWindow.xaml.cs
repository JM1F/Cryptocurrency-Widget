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

            // Checks the coin code name
            if (CoinCodeName == "bitcoin")
            {
                // Checks index of coin.
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin");
                // Set the image to current coin.
                CoinImage.Source = new BitmapImage(new Uri("Images/bitcoin.png", UriKind.Relative));
                
                Cointitle.Text = "Bitcoin";
            }
            else if (CoinCodeName == "ethereum")
            {
                // Repeat...
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum");
                CoinImage.Source = new BitmapImage(new Uri("Images/ethereum.png", UriKind.Relative));
                Cointitle.Text = "Ethereum";
            }
            else if (CoinCodeName == "cardano")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Cardano");
                CoinImage.Source = new BitmapImage(new Uri("Images/cardano.png", UriKind.Relative));
                Cointitle.Text = "Cardano";
            }
            else if (CoinCodeName == "binancecoin")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Binance Coin");
                CoinImage.Source = new BitmapImage(new Uri("Images/binancecoin.png", UriKind.Relative));
                Cointitle.Text = "Binance";
            }
            else if (CoinCodeName == "dogecoin")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Dogecoin");
                CoinImage.Source = new BitmapImage(new Uri("Images/dogecoin.png", UriKind.Relative));
                Cointitle.Text = "Dogecoin";
            }
            else if (CoinCodeName == "xrp")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "XRP");
                CoinImage.Source = new BitmapImage(new Uri("Images/ripple.png", UriKind.Relative));
                Cointitle.Text = "XRP";
            }
            else if (CoinCodeName == "polkadot")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Polkadot");

                CoinImage.Source = new BitmapImage(new Uri("Images/polkadot.png", UriKind.Relative));
                Cointitle.Text = "Polkadot";
            }
            else if (CoinCodeName == "bitcoincash")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin Cash");

                CoinImage.Source = new BitmapImage(new Uri("Images/bitcoincash.png", UriKind.Relative));
                Cointitle.Text = "Bitcoin $";
            }
            else if (CoinCodeName == "uniswap")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Uniswap");

                CoinImage.Source = new BitmapImage(new Uri("Images/uniswap.png", UriKind.Relative));
                Cointitle.Text = "Uniswap";
            }
            else if (CoinCodeName == "solana")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Solana");

                CoinImage.Source = new BitmapImage(new Uri("Images/solana.png", UriKind.Relative));
                Cointitle.Text = "Solana";
            }
            else if (CoinCodeName == "litecoin")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Litecoin");

                CoinImage.Source = new BitmapImage(new Uri("Images/litecoin.png", UriKind.Relative));
                Cointitle.Text = "Litecoin";
            }
            else if (CoinCodeName == "chainlink")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Chainlink");

                CoinImage.Source = new BitmapImage(new Uri("Images/chainlink.png", UriKind.Relative));
                Cointitle.Text = "Chainlink";
            }
            else if (CoinCodeName == "ethereumclassic")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum Classic");

                CoinImage.Source = new BitmapImage(new Uri("Images/ethereumclassic.png", UriKind.Relative));
                Cointitle.Text = "ETC";
            }
            else if (CoinCodeName == "polygon")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Polygon");

                CoinImage.Source = new BitmapImage(new Uri("Images/polygon.png", UriKind.Relative));
                Cointitle.Text = "Polygon";
            }
            else if (CoinCodeName == "wrappedbitcoin")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Wrapped Bitcoin");

                CoinImage.Source = new BitmapImage(new Uri("Images/wrappedbitcoin.png", UriKind.Relative));
                Cointitle.Text = "WBTC";
            }
            else if (CoinCodeName == "internetcomputer")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Internet Computer");

                CoinImage.Source = new BitmapImage(new Uri("Images/internetcomputer.png", UriKind.Relative));
                Cointitle.Text = "ICP";
            }
            else if (CoinCodeName == "theta")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Theta Network");

                CoinImage.Source = new BitmapImage(new Uri("Images/theta.png", UriKind.Relative));
                Cointitle.Text = "Theta";
            }
            else if (CoinCodeName == "stellar")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Stellar");

                CoinImage.Source = new BitmapImage(new Uri("Images/stellar.png", UriKind.Relative));
                Cointitle.Text = "Stellar";
            }
            else if (CoinCodeName == "vechain")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "VeChain");

                CoinImage.Source = new BitmapImage(new Uri("Images/vechain.png", UriKind.Relative));
                Cointitle.Text = "VeChain";
            }
            else if (CoinCodeName == "dai")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Dai");

                CoinImage.Source = new BitmapImage(new Uri("Images/dai.png", UriKind.Relative));
                Cointitle.Text = "Dai";
            }
            else if (CoinCodeName == "filecoin")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Filecoin");

                CoinImage.Source = new BitmapImage(new Uri("Images/filecoin.png", UriKind.Relative));
                Cointitle.Text = "Filecoin";
            }
            else if (CoinCodeName == "tron")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "TRON");

                CoinImage.Source = new BitmapImage(new Uri("Images/tron.png", UriKind.Relative));
                Cointitle.Text = "TRON";
            }
            else if (CoinCodeName == "shibainu")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Shiba Inu");

                CoinImage.Source = new BitmapImage(new Uri("Images/shibainu.png", UriKind.Relative));
                Cointitle.Text = "Shiba Inu";
            }
            else if (CoinCodeName == "monero")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Monero");

                CoinImage.Source = new BitmapImage(new Uri("Images/monero.png", UriKind.Relative));
                Cointitle.Text = "Monero";
            }
            else if (CoinCodeName == "cosmos")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Cosmos");

                CoinImage.Source = new BitmapImage(new Uri("Images/cosmos.png", UriKind.Relative));
                Cointitle.Text = "Cosmos";
            }
            else if (CoinCodeName == "aave")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Aave");

                CoinImage.Source = new BitmapImage(new Uri("Images/AAVE.png", UriKind.Relative));
                Cointitle.Text = "Aave";

            }
            else if (CoinCodeName == "eos")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "EOS");

                CoinImage.Source = new BitmapImage(new Uri("Images/eos.png", UriKind.Relative));
                Cointitle.Text = "EOS";
            }
            else if (CoinCodeName == "algorand")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Algorand");

                CoinImage.Source = new BitmapImage(new Uri("Images/algorand.png", UriKind.Relative));
                Cointitle.Text = "Algorand";
            }
            else if (CoinCodeName == "pancakeswap")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "PancakeSwap");

                CoinImage.Source = new BitmapImage(new Uri("Images/pancakeswap.png", UriKind.Relative));
                Cointitle.Text = "CAKE";

            }
            else if (CoinCodeName == "amp")
            {
                CoinIndex = aPIDataChecker.IndexCheck(CoinAPIData, "Amp");

                CoinImage.Source = new BitmapImage(new Uri("Images/amp.png", UriKind.Relative));
                Cointitle.Text = "Amp";

            }
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
    }
}
