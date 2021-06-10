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
            if ((e.Text=="0") && (BeerPrice1.SelectionStart==0) && (BeerPrice1.Text != "") || ((BeerPrice1.Text != "") && (BeerPrice1.Text[0]=='0')))
                e.Handled = true;
            if (BeerPrice1.Text == "0")
            {
                BeerPrice1.Text = e.Text;
                BeerPrice1.SelectionStart = BeerPrice1.Text.Length;
            }
        }
        private void BeerPrice1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!int.TryParse(BeerPrice1.Text, out int a)) || (int.Parse(BeerPrice1.Text)<0))
                BeerPrice1.Text = "";
        }

        private void BeerPrice2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
            if ((e.Text=="0") && (BeerPrice2.SelectionStart==0) && (BeerPrice2.Text != "") || ((BeerPrice2.Text != "") && (BeerPrice2.Text[0]=='0')))
                e.Handled = true;
            if (BeerPrice2.Text == "0")
            {
                BeerPrice2.Text = e.Text;
                BeerPrice2.SelectionStart = BeerPrice2.Text.Length;
            }
        }

        private void BeerPrice2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!int.TryParse(BeerPrice2.Text, out int a)) || (int.Parse(BeerPrice2.Text) < 0))
                BeerPrice2.Text = "";
        }

        private void BeerCount1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
            if ((e.Text == "0") && (BeerCount1.SelectionStart == 0) && (BeerCount1.Text != "") || ((BeerCount1.Text != "") && (BeerCount1.Text[0] == '0')))
                e.Handled = true;
        }

        private void BeerCount1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!int.TryParse(BeerCount1.Text, out int a)) || (int.Parse(BeerCount1.Text) <= 0))
            {
                BeerCount1.Text = "";
                return;
            }
            if (int.Parse(BeerCount1.Text) > 500)
                BeerCount1.Text = "500";
        }

        private void BeerCount2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
            if ((e.Text == "0") && (BeerCount2.SelectionStart == 0) && (BeerCount2.Text != "") || ((BeerCount2.Text != "") && (BeerCount2.Text[0] == '0')))
                e.Handled = true;
        }

        private void BeerCount2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!int.TryParse(BeerCount2.Text, out int a)) || (int.Parse(BeerCount2.Text) <= 0))
            {
                BeerCount2.Text = "";
                return;
            }
            if (int.Parse(BeerCount2.Text) > 500)
                BeerCount2.Text = "500";
        }

        private void Price1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
            if ((e.Text == "0") && (Price1.SelectionStart == 0) && (Price1.Text != "") || ((Price1.Text != "") && (Price1.Text[0] == '0')))
                e.Handled = true;
            if (Price1.Text == "0")
            {
                Price1.Text = e.Text;
                Price1.SelectionStart = Price1.Text.Length;
            }
        }

        private void Price1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!int.TryParse(Price1.Text, out int a)) || (int.Parse(Price1.Text) < 0))
                Price1.Text = "";
        }

        private void Price2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
            if ((e.Text == "0") && (Price2.SelectionStart == 0) && (Price2.Text != "") || ((Price2.Text != "") && (Price2.Text[0] == '0')))
                e.Handled = true;
            if (Price2.Text == "0")
            {
                Price2.Text = e.Text;
                Price2.SelectionStart = Price2.Text.Length;
            }
        }

        private void Price2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!int.TryParse(Price2.Text, out int a)) || (int.Parse(Price2.Text) < 0))
                Price2.Text = "";
        }

        private void Price3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
            if ((e.Text == "0") && (Price3.SelectionStart == 0) && (Price3.Text != "") || ((Price3.Text != "") && (Price3.Text[0] == '0')))
                e.Handled = true;
            if (Price3.Text == "0")
            {
                Price3.Text = e.Text;
                Price3.SelectionStart = Price3.Text.Length;
            }
        }

        private void Price3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!int.TryParse(Price3.Text, out int a)) || (int.Parse(Price3.Text) < 0))
                Price3.Text = "";
        }

        private void Count1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
            if ((e.Text == "0") && (Count1.SelectionStart == 0) && (Count1.Text != "") || ((Count1.Text != "") && (Count1.Text[0] == '0')))
                e.Handled = true;
        }

        private void Count1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!int.TryParse(Count1.Text, out int a)) || (int.Parse(Count1.Text) <= 0))
            {
                Count1.Text = "";
                return;
            }
            if (int.Parse(Count1.Text) > 500)
                Count1.Text = "500";
        }

        private void Count2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
            if ((e.Text == "0") && (Count2.SelectionStart == 0) && (Count2.Text != "") || ((Count2.Text != "") && (Count2.Text[0] == '0')))
                e.Handled = true;
        }

        private void Count2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!int.TryParse(Count2.Text, out int a)) || (int.Parse(Count2.Text) <= 0))
            {
                Count2.Text = "";
                return;
            }
            if (int.Parse(Count2.Text) > 500)
                Count2.Text = "500";
        }

        private void Count3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
            if ((e.Text == "0") && (Count3.SelectionStart == 0) && (Count3.Text != "") || ((Count3.Text != "") && (Count3.Text[0] == '0')))
                e.Handled = true;
        }

        private void Count3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!int.TryParse(Count3.Text, out int a)) || (int.Parse(Count3.Text) <= 0))
            {
                Count3.Text = "";
                return;
            }
            if (int.Parse(Count3.Text) > 500)
                Count3.Text = "500";
        }     
    }
}
