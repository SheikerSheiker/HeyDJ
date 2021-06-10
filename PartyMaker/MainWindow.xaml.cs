using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Alco> allAlco = new List<Alco>();
            if ((BeerName1.Text.Length != 0) && (BeerPrice1.Text.Length != 0) && (BeerCount1.Text.Length != 0))
            {
                Alco alco1 = new Alco { Name = BeerName1.Text, Price = int.Parse(BeerPrice1.Text), Count = int.Parse(BeerCount1.Text) };
                allAlco.Add(alco1);
            }
            if ((BeerName2.Text.Length != 0) && (BeerPrice2.Text.Length != 0) && (BeerCount2.Text.Length != 0))
            {
                Alco alco1 = new Alco { Name = BeerName2.Text, Price = int.Parse(BeerPrice2.Text), Count = int.Parse(BeerCount2.Text) };
                allAlco.Add(alco1);
            }
            if ((Name1.Text.Length != 0) && (Price1.Text.Length != 0) && (Count1.Text.Length != 0))
            {
                Alco alco1 = new Alco { Name = Name1.Text, Price = int.Parse(Price1.Text), Count = int.Parse(Count1.Text) };
                allAlco.Add(alco1);
            }
            if ((Name2.Text.Length != 0) && (Price2.Text.Length != 0) && (Count2.Text.Length != 0))
            {
                Alco alco2 = new Alco { Name = Name2.Text, Price = int.Parse(Price2.Text), Count = int.Parse(Count2.Text) };
                allAlco.Add(alco2);
            }
            if ((Name3.Text.Length != 0) && (Price3.Text.Length != 0) && (Count3.Text.Length != 0))
            {
                Alco alco3 = new Alco { Name = Name3.Text, Price = int.Parse(Price3.Text), Count = int.Parse(Count3.Text) };
                allAlco.Add(alco3);
            }



            Result result = new Result(allAlco, AlcoSlider.Value, BeerSlider.Value);
            result.Show();
        }

        private void BeerPrice1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
        private void BeerPrice1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(BeerPrice1.Text, out int a))
                BeerPrice1.Text = "";
        }

        private void BeerPrice2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void BeerPrice2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BeerCount1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void BeerCount1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Price1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Price1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Price2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Price2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Price3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Price3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Count1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Count1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Count2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Count2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Count3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Count3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
