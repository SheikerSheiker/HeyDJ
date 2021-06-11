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
                //string fullPrice = item.FullPrice.Remove(item.FullPrice.Length - 2);
                //while (fullPrice.Contains(' '))
                //{
                //    fullPrice = fullPrice.Remove(fullPrice.IndexOf(' '),1);
                //}
                string fullPrice = "";
                for (int i = 0; i < item.FullPrice.Length - 2; i++)
                {
                    if (Char.IsDigit(item.FullPrice[i]))
                        fullPrice += item.FullPrice[i];
                }
                total += int.Parse(fullPrice);
            }

            ListViewResults.ItemsSource = results;
            TotalPrice(total);
        }

        public void TotalPrice(int total) => TotalBlock.Text = $"Итоговая стоимость: {total:C0}";
    }
}
