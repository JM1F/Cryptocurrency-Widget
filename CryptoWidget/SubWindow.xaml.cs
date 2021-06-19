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
            

            if (CoinCodeName == "bitcoin")
            {
                CoinImage.Source = new BitmapImage(new Uri("Images/bitcoin.png", UriKind.Relative));
                Cointitle.Text = "Bitcoin";
                CoinPriceID.Text = Convert.ToString("£" + data2[0].current_price);

            }
            else if (CoinCodeName == "ethereum")
            {
                CoinImage.Source = new BitmapImage(new Uri("Images/ethereum.png", UriKind.Relative));
                Cointitle.Text = "Ethereum";
                CoinPriceID.Text = Convert.ToString("£" + data2[1].current_price);

            }
            else if (CoinCodeName == "cardano")
            {
                CoinImage.Source = new BitmapImage(new Uri("Images/cardano.png", UriKind.Relative));
                Cointitle.Text = "Cardano";
                CoinPriceID.Text = Convert.ToString("£" + data2[4].current_price);
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
