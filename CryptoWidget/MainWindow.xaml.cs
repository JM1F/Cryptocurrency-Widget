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
        

        Mutex WindowMutex = new Mutex(true, "817c2420-b9e5-4ea2-973d-33a28ef33ea6");

        public MainWindow()
        {
            
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
        public async Task GetDataAsync()
        {
            ColorPriceCheck n = new ColorPriceCheck();
            StringSolver stringSolver = new StringSolver();
            APIDataChecker aPIDataChecker = new APIDataChecker();

            var CoinAPIData = await dataLoad.LoadData();

            int BTCINDEX = aPIDataChecker.IndexCheck(CoinAPIData, "Bitcoin");

            BTCPriceName.Text = ("£" + CoinAPIData[BTCINDEX].current_price);
            PriceData24h.Text = stringSolver.ShortenStringData(CoinAPIData[BTCINDEX].price_change_percentage_24h_in_currency);
            PriceData24h.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(CoinAPIData[BTCINDEX].price_change_percentage_24h_in_currency)) as SolidColorBrush;

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


        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {     
            
            await GetDataAsync();
           
        }


        private void titleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Minimisebutton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

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

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
