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
using System.Windows.Shapes;


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
            int incrementValue = 0;

            foreach (var coinIndex in CoinAPIData)
            {
                Console.WriteLine(coinIndex.Name);
                Button testTB = new Button
                {
                    Background = new BrushConverter().ConvertFromString("#161616") as SolidColorBrush,
                    Margin = new Thickness(18, incrementValue, 18, 3700 - incrementValue),
                    Style = (Style)FindResource("MainButtons"),
                    Name = "testButton",
                    BorderThickness = new Thickness(0)
                };

                Grid buttonContentGrid = new Grid
                {
                    Width = 223,
                    Height = 61,
                };
                buttonContentGrid.Children.Add(
                    new TextBlock
                    {
                        Text = coinIndex.Name,
                        Foreground = new BrushConverter().ConvertFromString("#FFFFFF") as SolidColorBrush,
                        Margin = new Thickness(65, 7, 49, 35),
                        FontSize = 16,
                        TextDecorations = TextDecorations.Underline,
                        FontFamily = new FontFamily("Montserrat Medium")
                    }
                );

                TextBlock pricePercentageTextBlock = new TextBlock
                {
                    DataContext = model1
                };

                Binding TextColour = new Binding("textColour")
                {
                    Mode = BindingMode.TwoWay
                };

                pricePercentageTextBlock.SetBinding(TextBlock.TextProperty, TextColour);

                Binding TextPrice = new Binding("textPrice")
                {
                    Mode = BindingMode.TwoWay
                };
                pricePercentageTextBlock.SetBinding(TextBlock.TextProperty, TextPrice);

                pricePercentageTextBlock.Text =
                    stringSolver.ShortenStringData(coinIndex.price_change_percentage_24h_in_currency);

                pricePercentageTextBlock.Foreground =
                    new BrushConverter().ConvertFromString(
                            colourCheck.ColourCheck(coinIndex.price_change_percentage_24h_in_currency)) as
                        SolidColorBrush;
                Image coinImage = new Image()
                {
                    Height = 50,
                    MaxHeight = 70,
                    MaxWidth = 60,
                    Source = new BitmapImage(new Uri(changeAPIImageSize(coinIndex.image))),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(5,0,0,0)
                };
                Rectangle separatorRectangle = new Rectangle()
                {
                    Fill = (Brush)new BrushConverter().ConvertFromString("#545454"),
                    Margin = Margin = new Thickness(18, incrementValue + 60, 18, 3700 - incrementValue),
                    Height = 1
                };

                buttonContentGrid.Children.Add(pricePercentageTextBlock);
                buttonContentGrid.Children.Add(coinImage);

                ParentGrid.Children.Add(testTB);
                ParentGrid.Children.Add(separatorRectangle);

                testTB.Content = buttonContentGrid;


                incrementValue += 75;
            }

            // Repeats for all current coins on the widget.

        }
        public string changeAPIImageSize(string originalURL)
        {
            string newURL = originalURL.Replace("/large/", "/small/");
            return newURL;
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

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            
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