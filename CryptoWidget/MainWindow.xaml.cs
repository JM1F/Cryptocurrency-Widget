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
            
            
        }
        public async Task GetDataAsync()
        {
            var data2 = await dataLoad.LoadData();

            NameData.Text = data2[0].Name;
            Console.WriteLine(data2);
            PriceData1h.Text = Convert.ToString(data2[0].price_change_percentage_1h_in_currency);
            PriceData24h.Text = Convert.ToString(data2[0].price_change_percentage_24h_in_currency);
            string PriceData1y = Convert.ToString(data2[0].price_change_percentage_1y_in_currency);
        }

       

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {     
            
            await GetDataAsync();
           
            this.DataContext = new Model();
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

    }
}
