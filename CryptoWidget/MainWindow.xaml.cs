﻿using APILibary;
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

        public string CurrencyValue { get; set; }

        public Model model1 { get; set; }

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
            CurrencyValue = "System.Windows.Controls.ComboBoxItem: £ GBP";
            model1 = new Model("System.Windows.Controls.ComboBoxItem: £ GBP");
            this.DataContext = model1;

            CurrencyCombobox.SelectionChanged += new SelectionChangedEventHandler(ComboBox_SelectionChanged);

        }
        /// <summary>
        /// Gets data from API and changes button sytles and content depending on what button data is required.
        /// </summary>
        /// <returns></returns>
        public async Task GetDataAsync()
        {
            // Calls classes for the checks the data have to go through.
            ColorPriceCheck colourCheck = new ColorPriceCheck();
            StringSolver stringSolver = new StringSolver();
            APIDataChecker aPIDataChecker = new APIDataChecker();

            // Loads data
            var CoinAPIData = await dataLoad.LoadData(CurrencyValue);

            string StringCurrency = CurrencyValue[38].ToString();
            
            // Searches for index of specific coin, so if market cap flips coin can still be displayed.
            int BTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin");
            // Sets starting text to the current price
            BTCPriceName.Text = StringCurrency + CoinAPIData[BTCINDEX].current_price;
            // ShortenStringData cuts down the long decimal places from the api and sets the text to the 24 hour price change.
            PriceData24h.Text = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_24h_in_currency);
            // Checks to see if the colour of the price is minus (red) or plus (green).
            PriceData24h.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[BTCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            // Repeats for all current coins on the widget.

            int ETHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum");

            ETHPriceName.Text = (StringCurrency + CoinAPIData[ETHINDEX].current_price);
            PriceData24hETH.Text = stringSolver.ShortenStringData(CoinAPIData[ETHINDEX].price_change_percentage_24h_in_currency);
            PriceData24hETH.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[ETHINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int ADAINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Cardano");

            ADAPriceName.Text = (StringCurrency + CoinAPIData[ADAINDEX].current_price);
            PriceData24hADA.Text = stringSolver.ShortenStringData(CoinAPIData[ADAINDEX].price_change_percentage_24h_in_currency);
            PriceData24hADA.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[ADAINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;


            int BNBINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Binance Coin");

            BNBPriceName.Text = (StringCurrency + CoinAPIData[BNBINDEX].current_price);
            PriceData24hBNB.Text = stringSolver.ShortenStringData(CoinAPIData[BNBINDEX].price_change_percentage_24h_in_currency);
            PriceData24hBNB.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[BNBINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int DOGEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Dogecoin");

            DOGEPriceName.Text = (StringCurrency + CoinAPIData[DOGEINDEX].current_price);
            PriceData24hDOGE.Text = stringSolver.ShortenStringData(CoinAPIData[DOGEINDEX].price_change_percentage_24h_in_currency);
            PriceData24hDOGE.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[DOGEINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int XRPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "XRP");

            XRPPriceName.Text = (StringCurrency + CoinAPIData[XRPINDEX].current_price);
            PriceData24hXRP.Text = stringSolver.ShortenStringData(CoinAPIData[XRPINDEX].price_change_percentage_24h_in_currency);
            PriceData24hXRP.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[XRPINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int DOTINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Polkadot");

            DOTPriceName.Text = (StringCurrency + CoinAPIData[DOTINDEX].current_price);
            PriceData24hDOT.Text = stringSolver.ShortenStringData(CoinAPIData[DOTINDEX].price_change_percentage_24h_in_currency);
            PriceData24hDOT.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[DOTINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int BTCCASHINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin Cash");

            BTCCASHPriceName.Text = (StringCurrency + CoinAPIData[BTCCASHINDEX].current_price);
            PriceData24hBTCCASH.Text = stringSolver.ShortenStringData(CoinAPIData[BTCCASHINDEX].price_change_percentage_24h_in_currency);
            PriceData24hBTCCASH.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[BTCCASHINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int UNIINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Uniswap");

            UNIPriceName.Text = (StringCurrency + CoinAPIData[UNIINDEX].current_price);
            PriceData24hUNI.Text = stringSolver.ShortenStringData(CoinAPIData[UNIINDEX].price_change_percentage_24h_in_currency);
            PriceData24hUNI.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[UNIINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int SOLINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Solana");

            SOLPriceName.Text = (StringCurrency + CoinAPIData[SOLINDEX].current_price);
            PriceData24hSOL.Text = stringSolver.ShortenStringData(CoinAPIData[SOLINDEX].price_change_percentage_24h_in_currency);
            PriceData24hSOL.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[SOLINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int LTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Litecoin");

            LTCPriceName.Text = (StringCurrency + CoinAPIData[LTCINDEX].current_price);
            PriceData24hLTC.Text = stringSolver.ShortenStringData(CoinAPIData[LTCINDEX].price_change_percentage_24h_in_currency);
            PriceData24hLTC.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[LTCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int LINKINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Chainlink");

            LINKPriceName.Text = (StringCurrency + CoinAPIData[LINKINDEX].current_price);
            PriceData24hLINK.Text = stringSolver.ShortenStringData(CoinAPIData[LINKINDEX].price_change_percentage_24h_in_currency);
            PriceData24hLINK.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[LINKINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int ETHCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Ethereum Classic");

            ETHCPriceName.Text = (StringCurrency + CoinAPIData[ETHCINDEX].current_price);
            PriceData24hETHC.Text = stringSolver.ShortenStringData(CoinAPIData[ETHCINDEX].price_change_percentage_24h_in_currency);
            PriceData24hETHC.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[ETHCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int MATICINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Polygon");

            MATICPriceName.Text = (StringCurrency + CoinAPIData[MATICINDEX].current_price);
            PriceData24hMATIC.Text = stringSolver.ShortenStringData(CoinAPIData[MATICINDEX].price_change_percentage_24h_in_currency);
            PriceData24hMATIC.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[MATICINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int WBTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Wrapped Bitcoin");

            WBTCPriceName.Text = (StringCurrency + CoinAPIData[MATICINDEX].current_price);
            PriceData24hWBTC.Text = stringSolver.ShortenStringData(CoinAPIData[WBTCINDEX].price_change_percentage_24h_in_currency);
            PriceData24hWBTC.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[WBTCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int ICPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Internet Computer");

            ICPPriceName.Text = (StringCurrency + CoinAPIData[ICPINDEX].current_price);
            PriceData24hICP.Text = stringSolver.ShortenStringData(CoinAPIData[ICPINDEX].price_change_percentage_24h_in_currency);
            PriceData24hICP.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[ICPINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int THETAINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Theta Network");

            THETAPriceName.Text = (StringCurrency + CoinAPIData[THETAINDEX].current_price);
            PriceData24hTHETA.Text = stringSolver.ShortenStringData(CoinAPIData[THETAINDEX].price_change_percentage_24h_in_currency);
            PriceData24hTHETA.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[THETAINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int XLMINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Stellar");

            XLMPriceName.Text = (StringCurrency + CoinAPIData[XLMINDEX].current_price);
            PriceData24hXLM.Text = stringSolver.ShortenStringData(CoinAPIData[XLMINDEX].price_change_percentage_24h_in_currency);
            PriceData24hXLM.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[XLMINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int VETINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "VeChain");

            VETPriceName.Text = (StringCurrency + CoinAPIData[VETINDEX].current_price);
            PriceData24hVET.Text = stringSolver.ShortenStringData(CoinAPIData[VETINDEX].price_change_percentage_24h_in_currency);
            PriceData24hVET.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[VETINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int DAIINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Dai");

            DAIPriceName.Text = (StringCurrency + CoinAPIData[DAIINDEX].current_price);
            PriceData24hDAI.Text = stringSolver.ShortenStringData(CoinAPIData[DAIINDEX].price_change_percentage_24h_in_currency);
            PriceData24hDAI.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[DAIINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int FILINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Filecoin");

            FILPriceName.Text = (StringCurrency + CoinAPIData[FILINDEX].current_price);
            PriceData24hFIL.Text = stringSolver.ShortenStringData(CoinAPIData[FILINDEX].price_change_percentage_24h_in_currency);
            PriceData24hFIL.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[FILINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int TRXINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "TRON");

            TRXPriceName.Text = (StringCurrency + CoinAPIData[TRXINDEX].current_price);
            PriceData24hTRX.Text = stringSolver.ShortenStringData(CoinAPIData[TRXINDEX].price_change_percentage_24h_in_currency);
            PriceData24hTRX.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[TRXINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int SHIBINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Shiba Inu");

            SHIBPriceName.Text = (StringCurrency + CoinAPIData[SHIBINDEX].current_price);
            PriceData24hSHIB.Text = stringSolver.ShortenStringData(CoinAPIData[SHIBINDEX].price_change_percentage_24h_in_currency);
            PriceData24hSHIB.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[SHIBINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int XMRINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Monero");

            XMRPriceName.Text = (StringCurrency + CoinAPIData[XMRINDEX].current_price);
            PriceData24hXMR.Text = stringSolver.ShortenStringData(CoinAPIData[XMRINDEX].price_change_percentage_24h_in_currency);
            PriceData24hXMR.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[XMRINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int ATOMINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Cosmos");

            ATOMPriceName.Text = (StringCurrency + CoinAPIData[ATOMINDEX].current_price);
            PriceData24hATOM.Text = stringSolver.ShortenStringData(CoinAPIData[ATOMINDEX].price_change_percentage_24h_in_currency);
            PriceData24hATOM.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[ATOMINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int AAVEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Aave");

            AAVEPriceName.Text = (StringCurrency + CoinAPIData[AAVEINDEX].current_price);
            PriceData24hAAVE.Text = stringSolver.ShortenStringData(CoinAPIData[AAVEINDEX].price_change_percentage_24h_in_currency);
            PriceData24hAAVE.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[AAVEINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int EOSINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "EOS");

            EOSPriceName.Text = (StringCurrency + CoinAPIData[EOSINDEX].current_price);
            PriceData24hEOS.Text = stringSolver.ShortenStringData(CoinAPIData[EOSINDEX].price_change_percentage_24h_in_currency);
            PriceData24hEOS.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[EOSINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int ALGOINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Algorand");

            ALGOPriceName.Text = (StringCurrency + CoinAPIData[ALGOINDEX].current_price);
            PriceData24hALGO.Text = stringSolver.ShortenStringData(CoinAPIData[ALGOINDEX].price_change_percentage_24h_in_currency);
            PriceData24hALGO.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[ALGOINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int CAKEINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "PancakeSwap");

            CAKEPriceName.Text = (StringCurrency + CoinAPIData[CAKEINDEX].current_price);
            PriceData24hCAKE.Text = stringSolver.ShortenStringData(CoinAPIData[CAKEINDEX].price_change_percentage_24h_in_currency);
            PriceData24hCAKE.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[CAKEINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            int AMPINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Amp");

            AMPPriceName.Text = (StringCurrency + CoinAPIData[AMPINDEX].current_price);
            PriceData24hAMP.Text = stringSolver.ShortenStringData(CoinAPIData[AMPINDEX].price_change_percentage_24h_in_currency);
            PriceData24hAMP.Foreground = new BrushConverter().ConvertFromString(colourCheck.ColourCheck(CoinAPIData[AMPINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;
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
            DragMove();
        }
        /// <summary>
        /// Closes the window when the exit button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            
        }
        /// <summary>
        /// Minimises the window when the minimise button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Minimisebutton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // Seperate buttons for the coins. When they are clicked a sub window is opened with the specific details.

        public void Button_ClickBTC(object sender, RoutedEventArgs e)
        {
            SubWindow btcwindow = new SubWindow("bitcoin", CurrencyValue);
            btcwindow.ShowDialog();
        }
        public void Button_ClickETH(object sender, RoutedEventArgs e)
        {
            SubWindow ethwindow = new SubWindow("ethereum", CurrencyValue);
            ethwindow.ShowDialog();
        }
        public void Button_ClickADA(object sender, RoutedEventArgs e)
        {
            SubWindow adawindow = new SubWindow("cardano", CurrencyValue);

            adawindow.ShowDialog();
        }
        public void Button_ClickBNB(object sender, RoutedEventArgs e)
        {
            SubWindow bnbwindow = new SubWindow("binancecoin", CurrencyValue);

            bnbwindow.ShowDialog();
        }
        public void Button_ClickDOGE(object sender, RoutedEventArgs e)
        {
            SubWindow dogewindow = new SubWindow("dogecoin", CurrencyValue);

            dogewindow.ShowDialog();
        }
        public void Button_ClickXRP(object sender, RoutedEventArgs e)
        {
            SubWindow xrpwindow = new SubWindow("ripple", CurrencyValue);

            xrpwindow.ShowDialog();
        }
        public void Button_ClickDOT(object sender, RoutedEventArgs e)
        {
            SubWindow polkadotwindow = new SubWindow("polkadot", CurrencyValue);

            polkadotwindow.ShowDialog();
        }
        public void Button_ClickBTCCASH(object sender, RoutedEventArgs e)
        {
            SubWindow bitcoincashwindow = new SubWindow("bitcoin-cash", CurrencyValue);

            bitcoincashwindow.ShowDialog();
        }
        public void Button_ClickUNI(object sender, RoutedEventArgs e)
        {
            SubWindow uniswapwindow = new SubWindow("uniswap", CurrencyValue);

            uniswapwindow.ShowDialog();
        }
        public void Button_ClickSOL(object sender, RoutedEventArgs e)
        {
            SubWindow solanawindow = new SubWindow("solana", CurrencyValue);

            solanawindow.ShowDialog();
        }
        public void Button_ClickLTC(object sender, RoutedEventArgs e)
        {
            SubWindow litecoinwindow = new SubWindow("litecoin", CurrencyValue);

            litecoinwindow.ShowDialog();
        }
        public void Button_ClickLINK(object sender, RoutedEventArgs e)
        {
            SubWindow chainlinkwindow = new SubWindow("chainlink", CurrencyValue);

            chainlinkwindow.ShowDialog();
        }
        public void Button_ClickETHC(object sender, RoutedEventArgs e)
        {
            SubWindow ethereumclassicwindow = new SubWindow("ethereum-classic", CurrencyValue);

            ethereumclassicwindow.ShowDialog();
        }
        public void Button_ClickMATIC(object sender, RoutedEventArgs e)
        {
            SubWindow polygonwindow = new SubWindow("matic-network", CurrencyValue);

            polygonwindow.ShowDialog();
        }
        public void Button_ClickWBTC(object sender, RoutedEventArgs e)
        {
            SubWindow wrappedbitcoinwindow = new SubWindow("wrapped-bitcoin", CurrencyValue);

            wrappedbitcoinwindow.ShowDialog();
        }
        public void Button_ClickICP(object sender, RoutedEventArgs e)
        {
            SubWindow interentcomputerwindow = new SubWindow("internet-computer", CurrencyValue);

            interentcomputerwindow.ShowDialog();
        }
        public void Button_ClickTHETA(object sender, RoutedEventArgs e)
        {
            SubWindow thetawindow = new SubWindow("theta-token", CurrencyValue);

            thetawindow.ShowDialog();
        }
        public void Button_ClickXLM(object sender, RoutedEventArgs e)
        {
            SubWindow stellarwindow = new SubWindow("stellar", CurrencyValue);

            stellarwindow.ShowDialog();
        }
        public void Button_ClickVET(object sender, RoutedEventArgs e)
        {
            SubWindow vechainwindow = new SubWindow("vechain", CurrencyValue);

            vechainwindow.ShowDialog();
        }
        public void Button_ClickDAI(object sender, RoutedEventArgs e)
        {
            SubWindow daiwindow = new SubWindow("dai", CurrencyValue);

            daiwindow.ShowDialog();
        }
        public void Button_ClickFIL(object sender, RoutedEventArgs e)
        {
            SubWindow filecoinwindow = new SubWindow("filecoin", CurrencyValue);

            filecoinwindow.ShowDialog();
        }
        public void Button_ClickTRX(object sender, RoutedEventArgs e)
        {
            SubWindow tronwindow = new SubWindow("tron", CurrencyValue);

            tronwindow.ShowDialog();
        }
        public void Button_ClickSHIB(object sender, RoutedEventArgs e)
        {
            SubWindow shibainuwindow = new SubWindow("shiba-inu", CurrencyValue);

            shibainuwindow.ShowDialog();
        }
        public void Button_ClickXMR(object sender, RoutedEventArgs e)
        {
            SubWindow monerowindow = new SubWindow("monero", CurrencyValue);

            monerowindow.ShowDialog();
        }
        public void Button_ClickATOM(object sender, RoutedEventArgs e)
        {
            SubWindow cosmoswindow = new SubWindow("cosmos", CurrencyValue);

            cosmoswindow.ShowDialog();
        }
        public void Button_ClickAAVE(object sender, RoutedEventArgs e)
        {
            SubWindow aavewindow = new SubWindow("aave", CurrencyValue);

            aavewindow.ShowDialog();
        }
        public void Button_ClickEOS(object sender, RoutedEventArgs e)
        {
            SubWindow eoswindow = new SubWindow("eos", CurrencyValue);

            eoswindow.ShowDialog();
        }
        public void Button_ClickALGO(object sender, RoutedEventArgs e)
        {
            SubWindow algorandwindow = new SubWindow("algorand", CurrencyValue);

            algorandwindow.ShowDialog();
        }
        public void Button_ClickCAKE(object sender, RoutedEventArgs e)
        {
            SubWindow pancakeswapwindow = new SubWindow("pancakeswap-token", CurrencyValue);

            pancakeswapwindow.ShowDialog();
        }
        public void Button_ClickAMP(object sender, RoutedEventArgs e)
        {
            SubWindow ampwindow = new SubWindow("amp-token", CurrencyValue);

            ampwindow.ShowDialog();
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

        public async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Model.atimer.Enabled = false;

            CurrencyValue = CurrencyCombobox.SelectedItem.ToString();
            model1 = new Model(CurrencyValue);
            this.DataContext = model1;
            await GetDataAsync();

            
        }
    }
}
