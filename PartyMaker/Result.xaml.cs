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
using System.Windows.Shapes;

namespace PartyMaker
{
    /// <summary>
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public class Res
    {
        public string name { get; set; }
        public int count { get; set; }
        public int price { get; set; }
        public int sum { get; set; }
        public Res(string name, int count, int price, int sum)
        {
            this.name = name;
            this.count = count;
            this.price = price;
            this.sum = sum;
        }
    }

    public partial class Result : Window
    {
        public Result(List<Alco> allAlco, double alcoSliderValue, double beerSliderValue)
        {
            InitializeComponent();

            List<AlcoResult> results = new List<AlcoResult>();
            int total = 0;

            foreach (var item in allAlco)
            {
                results.Add(item.TransformToResult(alcoSliderValue, beerSliderValue));
            }
            foreach (var item in results)
            {
                total += int.Parse(item.FullPrice);
            }

            ListViewResults.ItemsSource = results;
            TotalPrice(total);
            this.SizeToContent = SizeToContent.Height;
        }

        public void TotalPrice (int total) => TotalBlock.Text = $"Итоговая стоимость: {total:C0}";
    }
}
