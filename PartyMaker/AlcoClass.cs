using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PartyMaker
{
    public class AlcoResult : INotifyPropertyChanged
    {
        private string name;
        private string countBottle;
        private string priceBottle;
        private string fullPrice;
        private string eachPrice;
        public string Count { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string CountBottle
        {
            get
            {
                return countBottle;
            }
            set
            {
                countBottle = value;
                OnPropertyChanged("CountBottle");
            }
        }
        public string PriceBottle
        {
            get
            {
                return priceBottle;
            }
            set
            {
                priceBottle = value;
                OnPropertyChanged("PriceBottle");
            }
        }
        public string FullPrice
        {
            get
            {
                return fullPrice;
            }
            set
            {
                fullPrice = value;
                OnPropertyChanged("FullPrice");
            }
        }
        public string EachPrice
        {
            get
            {
                return eachPrice;
            }
            set
            {
                eachPrice = value;
                OnPropertyChanged("EachPrice");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
