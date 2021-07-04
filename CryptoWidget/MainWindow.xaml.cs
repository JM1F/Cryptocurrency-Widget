using APILibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace CryptoWidget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        // Generate mutex
        Mutex WindowMutex = new Mutex(true, "817c2420-b9e5-4ea2-973d-33a28ef33ea6");


        /// <summary>
        /// Main window Initialize
        /// </summary>
        public MainWindow()
        {
            // Check if window already open, if so close current attempt to start up.
            if (!WindowMutex.WaitOne(TimeSpan.Zero, false))
            {
                Close();
            }
            else
            {
                WindowMutex.ReleaseMutex();
            }
            APIHelper.InitializeClient();
            InitializeComponent();
            this.DataContext = new Model();
            
        }
        /// <summary>
        /// Gets data from API and changes button sytles and content depending on what button data is required.
        /// </summary>
        /// <returns></returns>
        public async Task GetDataAsync()
        {
            // Calls classes for the checks the data have to go through.
            ColorPriceCheck n = new ColorPriceCheck();
            StringSolver stringSolver = new StringSolver();
            APIDataChecker aPIDataChecker = new APIDataChecker();

            // Loads data
            var CoinAPIData = await dataLoad.LoadData();

            
            // Searches for index of specific coin, so if market cap flips coin can still be displayed.
            int BTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin");
            // Sets starting text to the current price
            BTCPriceName.Text = ("£" + CoinAPIData[BTCINDEX].current_price);
            // ShortenStringData cuts down the long decimal places from the api and sets the text to the 24 hour price change.
            PriceData24h.Text = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_24h_in_currency);
            // Checks to see if the colour of the price is minus (red) or plus (green).
            PriceData24h.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[BTCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            // Repeats for all current coins on the widget.

            int ETHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum");

            ETHPriceName.Text = ("£" + CoinAPIData[ETHINDEX].current_price);
            PriceData24hETH.Text = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_24h_in_currency);
            PriceData24hETH.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[ETHINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int ADAINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Cardano");

            ADAPriceName.Text = ("£" + CoinAPIData[ADAINDEX].current_price);
            PriceData24hADA.Text = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_24h_in_currency);
            PriceData24hADA.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[ADAINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;


            int BNBINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Binance Coin");

            BNBPriceName.Text = ("£" + CoinAPIData[BNBINDEX].current_price);
            PriceData24hBNB.Text = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_24h_in_currency);
            PriceData24hBNB.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[BNBINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int DOGEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Dogecoin");

            DOGEPriceName.Text = ("£" + CoinAPIData[DOGEINDEX].current_price);
            PriceData24hDOGE.Text = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_24h_in_currency);
            PriceData24hDOGE.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[DOGEINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int XRPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "XRP");

            XRPPriceName.Text = ("£" + CoinAPIData[XRPINDEX].current_price);
            PriceData24hXRP.Text = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_24h_in_currency);
            PriceData24hXRP.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[XRPINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int DOTINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Polkadot");

            DOTPriceName.Text = ("£" + CoinAPIData[DOTINDEX].current_price);
            PriceData24hDOT.Text = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_24h_in_currency);
            PriceData24hDOT.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[DOTINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int BTCCASHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin Cash");

            BTCCASHPriceName.Text = ("£" + CoinAPIData[BTCCASHINDEX].current_price);
            PriceData24hBTCCASH.Text = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_24h_in_currency);
            PriceData24hBTCCASH.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[BTCCASHINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int UNIINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Uniswap");

            UNIPriceName.Text = ("£" + CoinAPIData[UNIINDEX].current_price);
            PriceData24hUNI.Text = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_24h_in_currency);
            PriceData24hUNI.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[UNIINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int SOLINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Solana");

            SOLPriceName.Text = ("£" + CoinAPIData[SOLINDEX].current_price);
            PriceData24hSOL.Text = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_24h_in_currency);
            PriceData24hSOL.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[SOLINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int LTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Litecoin");

            LTCPriceName.Text = ("£" + CoinAPIData[LTCINDEX].current_price);
            PriceData24hLTC.Text = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_24h_in_currency);
            PriceData24hLTC.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[LTCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int LINKINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Chainlink");

            LINKPriceName.Text = ("£" + CoinAPIData[LINKINDEX].current_price);
            PriceData24hLINK.Text = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_24h_in_currency);
            PriceData24hLINK.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[LINKINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int ETHCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum Classic");

            ETHCPriceName.Text = ("£" + CoinAPIData[ETHCINDEX].current_price);
            PriceData24hETHC.Text = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_24h_in_currency);
            PriceData24hETHC.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[ETHCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int MATICINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Polygon");

            MATICPriceName.Text = ("£" + CoinAPIData[MATICINDEX].current_price);
            PriceData24hMATIC.Text = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_24h_in_currency);
            PriceData24hMATIC.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[MATICINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int WBTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Wrapped Bitcoin");

            WBTCPriceName.Text = ("£" + CoinAPIData[MATICINDEX].current_price);
            PriceData24hWBTC.Text = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_24h_in_currency);
            PriceData24hWBTC.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[WBTCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int ICPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Internet Computer");

            ICPPriceName.Text = ("£" + CoinAPIData[ICPINDEX].current_price);
            PriceData24hICP.Text = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_24h_in_currency);
            PriceData24hICP.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[ICPINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int THETAINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Theta Network");

            THETAPriceName.Text = ("£" + CoinAPIData[THETAINDEX].current_price);
            PriceData24hTHETA.Text = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_24h_in_currency);
            PriceData24hTHETA.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[THETAINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int XLMINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Stellar");

            XLMPriceName.Text = ("£" + CoinAPIData[XLMINDEX].current_price);
            PriceData24hXLM.Text = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_24h_in_currency);
            PriceData24hXLM.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[XLMINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int VETINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "VeChain");

            VETPriceName.Text = ("£" + CoinAPIData[VETINDEX].current_price);
            PriceData24hVET.Text = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_24h_in_currency);
            PriceData24hVET.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[VETINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int DAIINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Dai");

            DAIPriceName.Text = ("£" + CoinAPIData[DAIINDEX].current_price);
            PriceData24hDAI.Text = stringSolver.ShortenStringData(CoinAPIData[DAIINDEX].price_change_percentage_24h_in_currency);
            PriceData24hDAI.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[DAIINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int FILINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Filecoin");

            FILPriceName.Text = ("£" + CoinAPIData[FILINDEX].current_price);
            PriceData24hFIL.Text = stringSolver.ShortenStringData(CoinAPIData[FILINDEX].price_change_percentage_24h_in_currency);
            PriceData24hFIL.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[FILINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int TRXINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "TRON");

            TRXPriceName.Text = ("£" + CoinAPIData[TRXINDEX].current_price);
            PriceData24hTRX.Text = stringSolver.ShortenStringData(CoinAPIData[TRXINDEX].price_change_percentage_24h_in_currency);
            PriceData24hTRX.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[TRXINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

        }

        /// <summary>
        /// when the window is loaded the data is called.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {     
            await GetDataAsync();  
        }

        /// <summary>
        /// Allows you to drag the title bar at the top around.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void titleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        /// <summary>
        /// Closes the window when the exit button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Minimises the window when the minimise button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Minimisebutton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // Seperate buttons for the coins. When they are clicked a sub window is opened with the specific details.

        public void Button_ClickBTC(object sender, RoutedEventArgs e)
        {
            SubWindow btcwindow = new SubWindow("bitcoin");
            btcwindow.ShowDialog();
        }
        public void Button_ClickETH(object sender, RoutedEventArgs e)
        {
           
            SubWindow ethwindow = new SubWindow("ethereum");
            ethwindow.ShowDialog();

        }
        public void Button_ClickADA(object sender, RoutedEventArgs e)
        {
            SubWindow adawindow = new SubWindow("cardano");

            adawindow.ShowDialog();
        }
        public void Button_ClickBNB(object sender, RoutedEventArgs e)
        {
            SubWindow bnbwindow = new SubWindow("binancecoin");

            bnbwindow.ShowDialog();
        }
        public void Button_ClickDOGE(object sender, RoutedEventArgs e)
        {
            SubWindow dogewindow = new SubWindow("dogecoin");

            dogewindow.ShowDialog();
        }
        public void Button_ClickXRP(object sender, RoutedEventArgs e)
        {
            SubWindow xrpwindow = new SubWindow("xrp");

            xrpwindow.ShowDialog();
        }
        public void Button_ClickDOT(object sender, RoutedEventArgs e)
        {
            SubWindow polkadotwindow = new SubWindow("polkadot");

            polkadotwindow.ShowDialog();
        }
        public void Button_ClickBTCCASH(object sender, RoutedEventArgs e)
        {
            SubWindow bitcoincashwindow = new SubWindow("bitcoincash");

            bitcoincashwindow.ShowDialog();
        }
        public void Button_ClickUNI(object sender, RoutedEventArgs e)
        {
            SubWindow uniswapwindow = new SubWindow("uniswap");

            uniswapwindow.ShowDialog();
        }
        public void Button_ClickSOL(object sender, RoutedEventArgs e)
        {
            SubWindow solanawindow = new SubWindow("solana");

            solanawindow.ShowDialog();
        }
        public void Button_ClickLTC(object sender, RoutedEventArgs e)
        {
            SubWindow litecoinwindow = new SubWindow("litecoin");

            litecoinwindow.ShowDialog();
        }
        public void Button_ClickLINK(object sender, RoutedEventArgs e)
        {
            SubWindow chainlinkwindow = new SubWindow("chainlink");

            chainlinkwindow.ShowDialog();
        }
        public void Button_ClickETHC(object sender, RoutedEventArgs e)
        {
            SubWindow ethereumclassicwindow = new SubWindow("ethereumclassic");

            ethereumclassicwindow.ShowDialog();
        }
        public void Button_ClickMATIC(object sender, RoutedEventArgs e)
        {
            SubWindow polygonwindow = new SubWindow("polygon");

            polygonwindow.ShowDialog();
        }
        public void Button_ClickWBTC(object sender, RoutedEventArgs e)
        {
            SubWindow wrappedbitcoinwindow = new SubWindow("wrappedbitcoin");

            wrappedbitcoinwindow.ShowDialog();
        }
        public void Button_ClickICP(object sender, RoutedEventArgs e)
        {
            SubWindow interentcomputerwindow = new SubWindow("internetcomputer");

            interentcomputerwindow.ShowDialog();
        }
        public void Button_ClickTHETA(object sender, RoutedEventArgs e)
        {
            SubWindow thetawindow = new SubWindow("theta");

            thetawindow.ShowDialog();
        }
        public void Button_ClickXLM(object sender, RoutedEventArgs e)
        {
            SubWindow stellarwindow = new SubWindow("stellar");

            stellarwindow.ShowDialog();
        }
        public void Button_ClickVET(object sender, RoutedEventArgs e)
        {
            SubWindow vechainwindow = new SubWindow("vechain");

            vechainwindow.ShowDialog();
        }
        public void Button_ClickDAI(object sender, RoutedEventArgs e)
        {
            SubWindow daiwindow = new SubWindow("dai");

            daiwindow.ShowDialog();
        }
        public void Button_ClickFIL(object sender, RoutedEventArgs e)
        {
            SubWindow filecoinwindow = new SubWindow("filecoin");

            filecoinwindow.ShowDialog();
        }
        public void Button_ClickTRX(object sender, RoutedEventArgs e)
        {
            SubWindow tronwindow = new SubWindow("tron");

            tronwindow.ShowDialog();
        }
        /// <summary>
        /// Handles the hyperlink request when clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
