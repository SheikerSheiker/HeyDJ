using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyMaker_NET_Core.Models
{
    class Alco
    {
        public string Title { get; set; }
        // "Истинное" свойство
        double _price;
        string _priceString;
        public double Price
        {
            get => _price;
            set
            {
                _price = value;

                if (!double.TryParse(PriceString, out double price) ||
                    price != value)
                {
                    PriceString = value.ToString();
                }
            }
        }

        // Свойство для строкового представления
        public string PriceString
        {
            get => _priceString;
            set
            {
                if (double.TryParse(value, out double price))
                {
                    _priceString = value;
                    if (Price != price)
                    {
                        Price = price;
                    }
                }
                //else
                //    RaisePropertyChanged();
            }
        }
    }
}
