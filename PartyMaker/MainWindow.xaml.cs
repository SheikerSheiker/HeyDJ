using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;

namespace PartyMaker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<AlcoResult> alcoResults = new List<AlcoResult>()
            {
                new AlcoResult(),
                new AlcoResult(),
                new AlcoResult(),
                new AlcoResult(),
                new AlcoResult(),
                new AlcoResult()
            };
        public MainWindow()
        {
            InitializeComponent();
            
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    List<Alco> allAlco = new List<Alco>();
        //    if ((BeerName.Text.Length != 0) && (BeerPrice.Text.Length != 0) && (BeerCount.Text.Length != 0))
        //    {
        //        Alco alco1 = new Alco { Name = BeerName.Text, Price = int.Parse(BeerPrice.Text), Count = int.Parse(BeerCount.Text) };
        //        allAlco.Add(alco1);
        //    }
        //    if ((CiderName.Text.Length != 0) && (CiderPrice.Text.Length != 0) && (CiderCount.Text.Length != 0))
        //    {
        //        Alco alco1 = new Alco { Name = CiderName.Text, Price = int.Parse(CiderPrice.Text), Count = int.Parse(CiderCount.Text) };
        //        allAlco.Add(alco1);
        //    }
        //    if ((Name1.Text.Length != 0) && (Price1.Text.Length != 0) && (Count1.Text.Length != 0))
        //    {
        //        Alco alco1 = new Alco { Name = Name1.Text, Price = int.Parse(Price1.Text), Count = int.Parse(Count1.Text) };
        //        allAlco.Add(alco1);
        //    }
        //    if ((Name2.Text.Length != 0) && (Price2.Text.Length != 0) && (Count2.Text.Length != 0))
        //    {
        //        Alco alco2 = new Alco { Name = Name2.Text, Price = int.Parse(Price2.Text), Count = int.Parse(Count2.Text) };
        //        allAlco.Add(alco2);
        //    }
        //    if ((Name3.Text.Length != 0) && (Price3.Text.Length != 0) && (Count3.Text.Length != 0))
        //    {
        //        Alco alco3 = new Alco { Name = Name3.Text, Price = int.Parse(Price3.Text), Count = int.Parse(Count3.Text) };
        //        allAlco.Add(alco3);
        //    }





        //    Result result = new Result(allAlco, AlcoSlider.Value, BeerSlider.Value);
        //    result.Show();
        //}



        //Обработчики клавиш и вставки (ну тут не могу не принять, обработчик клавиш хорошо написал Макс, по сравнению с генератором :)  )
        private void AlcoPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((!char.IsDigit(e.Text, 0)) && (e.Text != ","))
                e.Handled = true;
            if (((e.Text == ",") || (e.Text == "0")) && ((sender as TextBox).SelectionStart == 0) && ((sender as TextBox).Text != "") || (((sender as TextBox).Text != "") && ((sender as TextBox).Text[0] == '0')))
                e.Handled = true;
            if (!double.TryParse((sender as TextBox).Text + e.Text, out double a))
                e.Handled = true;
            if ((e.Text == ",") && ((sender as TextBox).Text.Length - (sender as TextBox).SelectionStart) > 2)
                e.Handled = true;
            if ((sender as TextBox).Text == "0")
            {
                (sender as TextBox).Text = e.Text;
                (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
            }
            if (((sender as TextBox).Text.Contains(",")) && ((sender as TextBox).Text.Length - (sender as TextBox).Text.IndexOf(',') > 2))
                e.Handled = true;
        }
        private void AlcoPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            //    if ((!int.TryParse((sender as TextBox).Text, out int a)) || (int.Parse((sender as TextBox).Text)<0))
            //        (sender as TextBox).Text = "";
            //    switch ((sender as TextBox).Name.ToString())
            //{
            //    case "BeerPrice":
            //        {
            //            alcoResults[0].PriceBottle = (sender as TextBox).Text;
            //            break;
            //        }
            //    case "CiderPrice":
            //        {
            //            alcoResults[1].PriceBottle = (sender as TextBox).Text;
            //            break;
            //        }
            //    case "WinePrice":
            //        {
            //            alcoResults[2].PriceBottle = (sender as TextBox).Text;
            //            break;
            //        }
            //    default:
            //        break;
            //}
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
            {
                (sender as TextBox).Text = "500";
                (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
            }
        }
        private void CharSpace_PreviewKeyDown (object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void AlcoName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Блокировать пробел, если стоим на первом месте и символ пробел, или если символ пробел и прошлый был пробел
            if ( (((sender as TextBox).SelectionStart == 0) && (e.Key == Key.Space)) || ((e.Key == Key.Space) && ((sender as TextBox).Text[(sender as TextBox).SelectionStart - 1] == ' ')) )
                e.Handled = true;
        }
        //Удаление из вставки двойных пробелов и пробелов в начале и конце
        private void AlcoName_TextChanged(object sender, TextChangedEventArgs e)
        {
            while ((sender as TextBox).Text.Contains("  "))
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Replace("  ", " ");
            }
            (sender as TextBox).Text = (sender as TextBox).Text.Trim();
        }


        //Обработчики ComboBox объема и watermark's на прайсы
        private void BeerSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BeerPriceWatermark.Text = $"Цена за {((ComboBoxItem)((sender as ComboBox).SelectedItem)).Content.ToString()}";
        }

        private void CiderSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CiderPriceWatermark.Text = $"Цена за {((ComboBoxItem)((sender as ComboBox).SelectedItem)).Content.ToString()}";
        }

        private void WineSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WinePriceWatermark.Text = $"Цена за {((ComboBoxItem)((sender as ComboBox).SelectedItem)).Content.ToString()}";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.FileName = "Document";
            ofd.DefaultExt = ".text";
            ofd.Filter = "Text documents (.txt)|*.txt";
            ofd.ShowDialog();

            StreamWriter f = new StreamWriter(ofd.FileName);
            f.WriteLine(BeerSlider.Value);
            f.WriteLine(BeerSize.Text);
            f.WriteLine(BeerPrice.Text);
            f.WriteLine(BeerCount.Text);
            f.WriteLine(CiderSize.Text);
            f.WriteLine(CiderPrice.Text);
            f.WriteLine(CiderCount.Text);
            f.WriteLine(WineSize.Text);
            f.WriteLine(WinePrice.Text);
            f.WriteLine(WineCount.Text);
            f.WriteLine(AlcoSlider.Value);
            f.WriteLine(Name1.Text);
            f.WriteLine(Price1.Text);
            f.WriteLine(Count1.Text);
            f.WriteLine(Name2.Text);
            f.WriteLine(Price2.Text);
            f.WriteLine(Count2.Text);
            f.WriteLine(Name3.Text);
            f.WriteLine(Price3.Text);
            f.WriteLine(Count3.Text);
            f.Close();
        }

        private void Load_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text documents (.txt)|*.txt";
            ofd.ShowDialog();
            if (ofd.FileName != "") // проверка на выбор файла
            {
                StreamReader f = new StreamReader(ofd.FileName);
                BeerSlider.Value = double.Parse(f.ReadLine());
                BeerSize.Text = f.ReadLine();
                BeerPrice.Text = f.ReadLine();
                BeerCount.Text = f.ReadLine();
                CiderSize.Text = f.ReadLine();
                CiderPrice.Text = f.ReadLine();
                CiderCount.Text = f.ReadLine();
                WineSize.Text = f.ReadLine();
                WinePrice.Text = f.ReadLine();
                WineCount.Text = f.ReadLine();
                AlcoSlider.Value = double.Parse(f.ReadLine());
                Name1.Text = f.ReadLine();
                Price1.Text = f.ReadLine();
                Count1.Text = f.ReadLine();
                Name2.Text = f.ReadLine();
                Price2.Text = f.ReadLine();
                Count2.Text = f.ReadLine();
                Name3.Text = f.ReadLine();
                Price3.Text = f.ReadLine();
                Count3.Text = f.ReadLine();
                f.Close();
            }
            else MessageBox.Show("Файл не выбран");        
        }

    }
}
