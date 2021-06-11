using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyMaker
{
    public class Alco
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public AlcoResult TransformToResult(double alcoSliderValue, double beerSliderValue)
        {
            double sliderValue;
            sliderValue = ((Name == "Пиво") || (Name == "Сидр")) ? beerSliderValue : alcoSliderValue;
            int intCountBottle = Convert.ToInt32(Math.Ceiling(sliderValue * Count / 0.5));
            AlcoResult result = new AlcoResult { Name = Name, CountBottle = Convert.ToInt32(Math.Ceiling(sliderValue * Count / 0.5)).ToString(), PriceBottle = String.Format("{0:C0}", Price), FullPrice = String.Format("{0:C0}", intCountBottle * Price)};
            return result;
        }
    }

    public class AlcoResult
    {
        public string Name { get; set; }
        public string CountBottle { get; set; }
        public string PriceBottle { get; set; }
        public string FullPrice { get; set; }
    }
}
