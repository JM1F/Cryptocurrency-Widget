using APILibary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoWidget
{
    public class ModelSubWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ModelSubWindow(string data)
        {
            CoinCodeName = data;

            setTimer();
        }
        public string CoinCodeName { get; set; }

        public string CoinPrice { get; set; }


        public static System.Timers.Timer atimer;


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
                CoinPrice = Convert.ToString("£" + data2[0].current_price);
                OnPropertyChanged("CoinPrice");
                Console.WriteLine(CoinPrice);
            }
            else if (CoinCodeName == "ethereum")
            {
                CoinPrice = Convert.ToString("£" + data2[1].current_price);
                OnPropertyChanged("CoinPrice");

                Console.WriteLine(CoinPrice);
            }

        }
        
    }
}
