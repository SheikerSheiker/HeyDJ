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
            if ((BeerName.Text.Length != 0) && (BeerPrice.Text.Length != 0) && (BeerCount.Text.Length != 0))
            {
                Alco alco1 = new Alco { Name = BeerName.Text, Price = int.Parse(BeerPrice.Text), Count = int.Parse(BeerCount.Text) };
                allAlco.Add(alco1);
            }
            if ((CiderName.Text.Length != 0) && (CiderPrice.Text.Length != 0) && (CiderCount.Text.Length != 0))
            {
                Alco alco1 = new Alco { Name = CiderName.Text, Price = int.Parse(CiderPrice.Text), Count = int.Parse(CiderCount.Text) };
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



        //Обработчики клавиш и вставки (ну тут не могу не принять, обработчик клавиш хорошо написал Макс, по сравнению с генератором :)  )
        private void AlcoPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
            if ((e.Text=="0") && ((sender as TextBox).SelectionStart==0) && ((sender as TextBox).Text != "") || (((sender as TextBox).Text != "") && ((sender as TextBox).Text[0]=='0')))
                e.Handled = true;
            if ((sender as TextBox).Text == "0")
            {
                (sender as TextBox).Text = e.Text;
                (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
            }
        }
        private void AlcoPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
                if ((!int.TryParse((sender as TextBox).Text, out int a)) || (int.Parse((sender as TextBox).Text)<0))
                    (sender as TextBox).Text = "";
        }

       
        private void AlcoCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
            if ((e.Text == "0") && ((sender as TextBox).SelectionStart == 0) && ((sender as TextBox).Text != "") || (((sender as TextBox).Text != "") && ((sender as TextBox).Text[0] == '0')))
                e.Handled = true;
        }

        private void AlcoCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((!int.TryParse((sender as TextBox).Text, out int a)) || (int.Parse((sender as TextBox).Text) <= 0))
            {
                (sender as TextBox).Text = "";
                return;
            }
            if (int.Parse((sender as TextBox).Text) > 500)
                (sender as TextBox).Text = "500";
        }
    }
}
