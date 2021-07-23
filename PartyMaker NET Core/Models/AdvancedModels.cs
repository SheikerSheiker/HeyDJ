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
        public double Price { get; set; }
        public Alco(string Title, double Price)
        {
            this.Title = Title;
            this.Price = Price;
        }
        public Alco()
        {

        }

    }
    //class PairAlcoAndSize
    //{
    //    Alco alco;
    //    double size;
    //}
    //class Person
    //{
    //    ObservableCollection<PairAlcoAndSize> AllAlco = new ObservableCollection<PairAlcoAndSize>();
    //}
}
