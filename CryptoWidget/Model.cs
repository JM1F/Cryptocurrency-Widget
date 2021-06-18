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
        public string PCP1HCOLOUR { get; set; }
        public string PCP24H { get; set; }
        public string PCP7D { get; set; }
        public string PCP30D { get; set; }
        public string PCP30DCOLOUR { get; set; }
        public string PCP1Y { get; set; }
        public string PCP1YCOLOUR { get; set; }




        private static System.Timers.Timer atimer;

        ColorPriceCheck n = new ColorPriceCheck();

        public void setTimer()
        {
            atimer = new System.Timers.Timer(10000);
            atimer.Elapsed += atimer_Elapsed;
            atimer.AutoReset = true;
            atimer.Enabled = true;
        }
        
        private async void atimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            

            var data2 = await dataLoad.LoadData();

            
            PCP1H = data2[0].price_change_percentage_1h_in_currency;
            PCP1HCOLOUR = n.ColourCheck(PCP1H);

            Console.WriteLine(data2[0].price_change_percentage_30d_in_currency);

            PCP24H = data2[0].price_change_percentage_24h_in_currency;
            PCP7D = data2[0].price_change_percentage_7d_in_currency;


            PCP30D = data2[0].price_change_percentage_30d_in_currency;
            PCP30DCOLOUR = n.ColourCheck(PCP30D);

            PCP1Y = data2[0].price_change_percentage_1y_in_currency;
            PCP1YCOLOUR = n.ColourCheck(PCP1Y);



            OnPropertyChanged("PCP1H");
            OnPropertyChanged("PCP1HCOLOUR");

            OnPropertyChanged("PCP24H");

            OnPropertyChanged("PCP7D");

            OnPropertyChanged("PCP30D");
            OnPropertyChanged("PCP30DCOLOUR");

            OnPropertyChanged("PCP1Y");
            OnPropertyChanged("PCP1YCOLOUR");
        }
        
    }
}
