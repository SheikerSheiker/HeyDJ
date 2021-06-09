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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PartyMaker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBlock beerLiters = new TextBlock();
            double x = 0;
            for (; x <= 5; x += 0.5)
            {
                beerLiters.Inlines.Add($"{x}");
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] arr = new string[5];
            arr[0] = "Пиво " + (Math.Ceiling(BeerSlider.Value * int.Parse(BeerPeople.Text) / 0.5)).ToString() + " " + BeerPrice.Text + " " + (Math.Ceiling(BeerSlider.Value * int.Parse(BeerPeople.Text) / 0.5) * int.Parse(BeerPrice.Text)).ToString();
            arr[1] = "Сидо " + (Math.Ceiling(BeerSlider.Value * int.Parse(SeedrPeople.Text) / 0.5)).ToString() + " " + SeedrPrice.Text + " " + (Math.Ceiling(BeerSlider.Value * int.Parse(SeedrPeople.Text) / 0.5) * int.Parse(SeedrPrice.Text)).ToString();
            arr[2] = "Водка " + (Math.Ceiling(AlcoSlider.Value * int.Parse(VodkaPeople.Text) / 0.5)).ToString() + " " + VodkaPrice.Text + " " + (Math.Ceiling(AlcoSlider.Value * int.Parse(VodkaPeople.Text) / 0.5) * int.Parse(VodkaPrice.Text)).ToString();
            arr[3] = "Виски " + (Math.Ceiling(AlcoSlider.Value * int.Parse(WhiskeyPeople.Text) / 0.5)).ToString() + " " + WhiskeyPrice.Text + " " + (Math.Ceiling(AlcoSlider.Value * int.Parse(WhiskeyPeople.Text) / 0.5) * int.Parse(WhiskeyPrice.Text)).ToString();
            arr[4] = "Коньяк " + (Math.Ceiling(AlcoSlider.Value * int.Parse(CognacPeople.Text) / 0.5)).ToString() + " " + CognacPrice.Text + " " + (Math.Ceiling(AlcoSlider.Value * int.Parse(CognacPeople.Text) / 0.5) * int.Parse(CognacPrice.Text)).ToString();
            Result result = new Result(arr);
            result.Show();
        }

        private void BeerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void VodkaPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void WhiskeyPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CognacPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void VodkaPeople_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void WhiskeyPeople_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CognacPeople_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
