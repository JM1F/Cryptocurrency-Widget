using APILibary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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

        public static string CoinCodeName;


        public SubWindow(string CoinType)
        {
            this.Owner = App.Current.MainWindow;
            CoinCodeName = CoinType;
            this.DataContext = new ModelSubWindow(CoinCodeName);
            InitializeComponent();


        }
        public async Task GetBeginningData()
        {
            var data2 = await dataLoad.LoadData();

            ColorPriceCheck n = new ColorPriceCheck();
            StringSolver stringSolver = new StringSolver();

            if (CoinCodeName == "bitcoin")
            {
                CoinImage.Source = new BitmapImage(new Uri("Images/bitcoin.png", UriKind.Relative));
                Cointitle.Text = "Bitcoin";
                CoinPriceID.Text = Convert.ToString("£" + data2[0].current_price);

                CoinPriceIDATH.Text = ("£" + data2[0].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(data2[0].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[0].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(data2[0].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[0].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(data2[0].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[0].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(data2[0].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[0].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(data2[0].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[0].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "ethereum")
            {
                CoinImage.Source = new BitmapImage(new Uri("Images/ethereum.png", UriKind.Relative));
                Cointitle.Text = "Ethereum";
                CoinPriceID.Text = Convert.ToString("£" + data2[1].current_price);

                CoinPriceIDATH.Text = ("£" + data2[1].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(data2[1].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[1].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(data2[1].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[1].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(data2[1].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[1].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(data2[1].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[1].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(data2[1].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[1].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "cardano")
            {
                CoinImage.Source = new BitmapImage(new Uri("Images/cardano.png", UriKind.Relative));
                Cointitle.Text = "Cardano";
                CoinPriceID.Text = Convert.ToString("£" + data2[4].current_price);

                CoinPriceIDATH.Text = ("£" + data2[4].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(data2[4].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[4].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(data2[4].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[4].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(data2[4].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[4].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(data2[4].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[4].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(data2[4].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[4].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "binancecoin")
            {
                CoinImage.Source = new BitmapImage(new Uri("Images/binancecoin.png", UriKind.Relative));
                Cointitle.Text = "Binance";
                CoinPriceID.Text = Convert.ToString("£" + data2[3].current_price);

                CoinPriceIDATH.Text = ("£" + data2[3].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(data2[3].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[3].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(data2[3].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[3].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(data2[3].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[3].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(data2[3].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[3].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(data2[3].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[3].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
            else if (CoinCodeName == "dogecoin")
            {
                CoinImage.Source = new BitmapImage(new Uri("Images/dogecoin.png", UriKind.Relative));
                Cointitle.Text = "Dogecoin";
                CoinPriceID.Text = Convert.ToString("£" + data2[5].current_price);

                CoinPriceIDATH.Text = ("£" + data2[5].ath);

                CoinPriceID1H.Text = stringSolver.ShortenStringData(data2[5].price_change_percentage_1h_in_currency);
                CoinPriceID1H.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[5].price_change_percentage_1h_in_currency)) as SolidColorBrush;

                CoinPriceID24H.Text = stringSolver.ShortenStringData(data2[5].price_change_percentage_24h_in_currency);
                CoinPriceID24H.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[5].price_change_percentage_24h_in_currency)) as SolidColorBrush;

                CoinPriceID7D.Text = stringSolver.ShortenStringData(data2[5].price_change_percentage_7d_in_currency);
                CoinPriceID7D.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[5].price_change_percentage_7d_in_currency)) as SolidColorBrush;

                CoinPriceID30D.Text = stringSolver.ShortenStringData(data2[5].price_change_percentage_30d_in_currency);
                CoinPriceID30D.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[5].price_change_percentage_30d_in_currency)) as SolidColorBrush;

                CoinPriceID1Y.Text = stringSolver.ShortenStringData(data2[5].price_change_percentage_1y_in_currency);
                CoinPriceID1Y.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[5].price_change_percentage_1y_in_currency)) as SolidColorBrush;
            }
        }




        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            await GetBeginningData();

        }

        private void titleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ModelSubWindow.atimer.Stop();
        }
    }
}
