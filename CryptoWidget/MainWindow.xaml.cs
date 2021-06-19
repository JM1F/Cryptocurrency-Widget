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


namespace CryptoWidget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        public MainWindow()
        {
            APIHelper.InitializeClient();
            InitializeComponent();
            this.DataContext = new Model();
            
        }
        public async Task GetDataAsync()
        {
            ColorPriceCheck n = new ColorPriceCheck();
            StringSolver stringSolver = new StringSolver();

            var data2 = await dataLoad.LoadData();

            BTCPriceName.Text = ("£" + data2[0].current_price);
            PriceData24h.Text = stringSolver.ShortenStringData(data2[0].price_change_percentage_24h_in_currency);
            PriceData24h.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[0].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            ETHPriceName.Text = ("£" + data2[1].current_price);
            PriceData24hETH.Text = stringSolver.ShortenStringData(data2[1].price_change_percentage_24h_in_currency);
            PriceData24hETH.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[1].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            ADAPriceName.Text = ("£" + data2[4].current_price);
            PriceData24hADA.Text = stringSolver.ShortenStringData(data2[4].price_change_percentage_24h_in_currency);
            PriceData24hADA.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[4].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            BNBPriceName.Text = ("£" + data2[3].current_price);
            PriceData24hBNB.Text = stringSolver.ShortenStringData(data2[3].price_change_percentage_24h_in_currency);
            PriceData24hBNB.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[3].price_change_percentage_24h_in_currency)) as SolidColorBrush;

            DOGEPriceName.Text = ("£" + data2[5].current_price);
            PriceData24hDOGE.Text = stringSolver.ShortenStringData(data2[5].price_change_percentage_24h_in_currency);
            PriceData24hDOGE.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[5].price_change_percentage_24h_in_currency)) as SolidColorBrush;

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

    }
}
