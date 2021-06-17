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
       

        private static System.Timers.Timer atimer;


        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SubWindow(string CoinType)
        {
            InitializeComponent();
            this.Owner = App.Current.MainWindow;
            CoinCodeName = CoinType;

            

         
            setTimer();
           

        }
        public async Task GetBeginningData()
        {
            var data2 = await dataLoad.LoadData();
            

            if (CoinCodeName == "bitcoin")
            {
                CoinImage.Source = new BitmapImage(new Uri("Images/bitcoin.png", UriKind.Relative));
                Cointitle.Text = "Bitcoin";
                

            }
            else if (CoinCodeName == "ethereum")
            {
                CoinImage.Source = new BitmapImage(new Uri("Images/ethereum.png", UriKind.Relative));
                Cointitle.Text = "Ethereum";
                

            }
        }

        public async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            await GetBeginningData();

        }

        public void setTimer()
        {
            atimer = new System.Timers.Timer(1000);
            atimer.Elapsed += atimer_Elapsed;
            atimer.AutoReset = true;
            atimer.Enabled = true;
        }

        public async void atimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var data2 = await dataLoad.LoadData();
            
            if (CoinCodeName == "bitcoin")
            {
               

            }
            else if (CoinCodeName == "ethereum")
            {
                Console.WriteLine("HelloETH");
            }

        }



            private void titleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            atimer.Stop();
        }
    }
}
