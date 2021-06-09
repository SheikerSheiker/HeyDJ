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
        public Result(string[] arr)
        {
            InitializeComponent();
            List<Res> qwe = new List<Res>();
            string[] str;
            str = arr[0].Split(' ');
            qwe.Add(new Res((str[0]), int.Parse(str[1]), int.Parse(str[2]), int.Parse(str[3]))); 
            str = arr[1].Split(' ');
            qwe.Add(new Res((str[0]), int.Parse(str[1]), int.Parse(str[2]), int.Parse(str[3])));
            str = arr[2].Split(' ');
            qwe.Add(new Res((str[0]), int.Parse(str[1]), int.Parse(str[2]), int.Parse(str[3])));
            str = arr[3].Split(' ');
            qwe.Add(new Res((str[0]), int.Parse(str[1]), int.Parse(str[2]), int.Parse(str[3])));
            str = arr[4].Split(' ');
            qwe.Add(new Res((str[0]), int.Parse(str[1]), int.Parse(str[2]), int.Parse(str[3])));
            grid.ItemsSource = qwe;
        }


        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
