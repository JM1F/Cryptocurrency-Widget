using APILibary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;



namespace CryptoWidget
{
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;



        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public Model()
        {
            setTimer();
        }
        public string PCP1H { get; set; }

        private static System.Timers.Timer atimer;
        
        public void setTimer()
        {
            atimer = new System.Timers.Timer(1000);
            atimer.Elapsed += atimer_Elapsed;
            atimer.AutoReset = true;
            atimer.Enabled = true;
        }
        
        private async void atimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var data2 = await dataLoad.LoadData();

            PCP1H = data2[0].price_change_percentage_1h_in_currency;
            Console.WriteLine(data2[0].price_change_percentage_1h_in_currency);
            OnPropertyChanged("PCP1H");
            
        }
    }
}
