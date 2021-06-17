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

            var data2 = await dataLoad.LoadData();

            NameData.Text = data2[0].Name;


            
            PriceData1h.Text = Convert.ToString(data2[0].price_change_percentage_1h_in_currency);
            string PriceData1hString = Convert.ToString(data2[0].price_change_percentage_1h_in_currency);
            PriceData1h.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(PriceData1hString)) as SolidColorBrush;

            
            PriceData24h.Text = Convert.ToString(data2[0].price_change_percentage_24h_in_currency);

            PriceData7d.Text = Convert.ToString(data2[0].price_change_percentage_7d_in_currency);

            

            PriceData30d.Text = Convert.ToString(data2[0].price_change_percentage_30d_in_currency);
            PriceData30d.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[0].price_change_percentage_30d_in_currency)) as SolidColorBrush;
            

            PriceData1y.Text = Convert.ToString(data2[0].price_change_percentage_1y_in_currency);
            PriceData1y.Foreground = new BrushConverter().ConvertFromString(n.ColourCheck(data2[0].price_change_percentage_1y_in_currency)) as SolidColorBrush;

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

        public void Button_Click(object sender, RoutedEventArgs e)
        {

            SubWindow btcwindow = new SubWindow("bitcoin");
            
            btcwindow.ShowDialog();

        }
        public void Button_Click2(object sender, RoutedEventArgs e)
        {



            SubWindow ethwindow = new SubWindow("ethereum");

            ethwindow.ShowDialog();



        }

    }
}
