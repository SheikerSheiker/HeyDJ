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
using System.Configuration;

namespace PartyMaker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<AlcoResult> alcoResults = new ObservableCollection<AlcoResult>();
        public MainWindow()
        {
            InitializeComponent();
            ic.ItemsSource = alcoResults;
        }

        //Обработчики клавиш и вставки (ну тут не могу не принять, обработчик клавиш хорошо написал Макс, по сравнению с генератором :)  )
        private int FindItem(string name)
        {
            int i = -1;
            foreach (var item in alcoResults)
            {
                i++;
                if (item.Name == name)
                    return i;
            }
            return -1;
        }

        private double DeleteMoneyFormat(string money)
        {
            double total;
            string fullPrice = "";
            for (int i = 0; i < money.Length - 2; i++)
            {
                if (Char.IsDigit(money[i]))
                    fullPrice += money[i];
            }
            total = double.Parse(fullPrice) / 100;
            return total;
        }

        private void Calculate()
        {
            if ((!BeerPrice.Text.Equals(string.Empty)) && (!BeerCount.Text.Equals(string.Empty)))
            {
                int item = FindItem("Пиво");
                if (item == -1)
                {
                    alcoResults.Add(new AlcoResult());
                    item = alcoResults.Count - 1;
                    alcoResults[item].Name = "Пиво";
                }
                string s = ((ComboBoxItem)((BeerSize as ComboBox).SelectedItem)).Content.ToString();
                s = s.Remove(s.Length - 2);
                double beerSize = double.Parse(s.Replace('.', ','));
                alcoResults[item].Count = BeerCount.Text;
                alcoResults[item].PriceBottle = String.Format("{0:C2}", double.Parse(BeerPrice.Text));
                alcoResults[item].CountBottle = Convert.ToInt32(Math.Ceiling(BeerSlider.Value * int.Parse(alcoResults[item].Count) / beerSize)).ToString();
                alcoResults[item].FullPrice = String.Format("{0:C2}", int.Parse(alcoResults[item].CountBottle) * DeleteMoneyFormat(alcoResults[item].PriceBottle));
                alcoResults[item].EachPrice = String.Format("{0:C2}", (DeleteMoneyFormat(alcoResults[item].FullPrice) / int.Parse(alcoResults[item].Count)));
            }
            if ((!CiderPrice.Text.Equals(string.Empty)) && (!CiderCount.Text.Equals(string.Empty)))
            {
                int item = FindItem("Сидр");
                if (item == -1)
                {
                    alcoResults.Add(new AlcoResult());
                    item = alcoResults.Count - 1;
                    alcoResults[item].Name = "Сидр";
                }
                string s = ((ComboBoxItem)((CiderSize as ComboBox).SelectedItem)).Content.ToString();
                s = s.Remove(s.Length - 2);
                double ciderSize = double.Parse(s.Replace('.', ','));
                alcoResults[item].Count = CiderCount.Text;
                alcoResults[item].PriceBottle = String.Format("{0:C2}", double.Parse(CiderPrice.Text));
                alcoResults[item].CountBottle = Convert.ToInt32(Math.Ceiling(BeerSlider.Value * int.Parse(alcoResults[item].Count) / ciderSize)).ToString();
                alcoResults[item].FullPrice = String.Format("{0:C2}", int.Parse(alcoResults[item].CountBottle) * DeleteMoneyFormat(alcoResults[item].PriceBottle));
                alcoResults[item].EachPrice = String.Format("{0:C2}", (DeleteMoneyFormat(alcoResults[item].FullPrice) / int.Parse(alcoResults[item].Count)));
            }
            if ((!WinePrice.Text.Equals(string.Empty)) && (!WineCount.Text.Equals(string.Empty)))
            {
                int item = FindItem("Вино");
                if (item == -1)
                {
                    alcoResults.Add(new AlcoResult());
                    item = alcoResults.Count - 1;
                    alcoResults[item].Name = "Вино";
                }
                string s = ((ComboBoxItem)((WineSize as ComboBox).SelectedItem)).Content.ToString();
                s = s.Remove(s.Length - 2);
                double wineSize = double.Parse(s.Replace('.', ','));
                alcoResults[item].Count = WineCount.Text;
                alcoResults[item].PriceBottle = String.Format("{0:C2}", double.Parse(WinePrice.Text));
                alcoResults[item].CountBottle = Convert.ToInt32(Math.Ceiling(BeerSlider.Value * int.Parse(alcoResults[item].Count) / wineSize)).ToString();
                alcoResults[item].FullPrice = String.Format("{0:C2}", int.Parse(alcoResults[item].CountBottle) * DeleteMoneyFormat(alcoResults[item].PriceBottle));
                alcoResults[item].EachPrice = String.Format("{0:C2}", (DeleteMoneyFormat(alcoResults[item].FullPrice) / int.Parse(alcoResults[item].Count)));
            }
            //Крепкий алкоголь
            if ((!Name1.Text.Equals(string.Empty)) && (!Price1.Text.Equals(string.Empty)) && (!Count1.Text.Equals(string.Empty)))
            {
                int item = FindItem(Name1.Text);
                if (item == -1)
                {
                    alcoResults.Add(new AlcoResult());
                    item = alcoResults.Count - 1;
                    alcoResults[item].Name = Name1.Text;
                }
                alcoResults[item].Count = Count1.Text;
                alcoResults[item].PriceBottle = String.Format("{0:C2}", double.Parse(Price1.Text));
                alcoResults[item].CountBottle = Convert.ToInt32(Math.Ceiling(AlcoSlider.Value * int.Parse(alcoResults[item].Count) / 0.5)).ToString();
                alcoResults[item].FullPrice = String.Format("{0:C2}", int.Parse(alcoResults[item].CountBottle) * DeleteMoneyFormat(alcoResults[item].PriceBottle));
                alcoResults[item].EachPrice = String.Format("{0:C2}", (DeleteMoneyFormat(alcoResults[item].FullPrice) / int.Parse(alcoResults[item].Count)));
            }

            if ((!Name2.Text.Equals(string.Empty)) && (!Price2.Text.Equals(string.Empty)) && (!Count2.Text.Equals(string.Empty)))
            {
                int item = FindItem(Name2.Text);
                if (item == -1)
                {
                    alcoResults.Add(new AlcoResult());
                    item = alcoResults.Count - 1;
                    alcoResults[item].Name = Name2.Text;
                }
                alcoResults[item].Count = Count2.Text;
                alcoResults[item].PriceBottle = String.Format("{0:C2}", double.Parse(Price2.Text));
                alcoResults[item].CountBottle = Convert.ToInt32(Math.Ceiling(AlcoSlider.Value * int.Parse(alcoResults[item].Count) / 0.5)).ToString();
                alcoResults[item].FullPrice = String.Format("{0:C2}", int.Parse(alcoResults[item].CountBottle) * DeleteMoneyFormat(alcoResults[item].PriceBottle));
                alcoResults[item].EachPrice = String.Format("{0:C2}", (DeleteMoneyFormat(alcoResults[item].FullPrice) / int.Parse(alcoResults[item].Count)));
            }

            if ((!Name3.Text.Equals(string.Empty)) && (!Price3.Text.Equals(string.Empty)) && (!Count3.Text.Equals(string.Empty)))
            {
                int item = FindItem(Name3.Text);
                if (item == -1)
                {
                    alcoResults.Add(new AlcoResult());
                    item = alcoResults.Count - 1;
                    alcoResults[item].Name = Name3.Text;
                }
                alcoResults[item].Count = Count3.Text;
                alcoResults[item].PriceBottle = String.Format("{0:C2}", double.Parse(Price3.Text));
                alcoResults[item].CountBottle = Convert.ToInt32(Math.Ceiling(AlcoSlider.Value * int.Parse(alcoResults[item].Count) / 0.5)).ToString();
                alcoResults[item].FullPrice = String.Format("{0:C2}", int.Parse(alcoResults[item].CountBottle) * DeleteMoneyFormat(alcoResults[item].PriceBottle));
                alcoResults[item].EachPrice = String.Format("{0:C2}", (DeleteMoneyFormat(alcoResults[item].FullPrice) / int.Parse(alcoResults[item].Count)));
            }

            //Подсчет общего
            double total = 0;
            double each = 0;
            foreach (var item in alcoResults)
            {
                total += DeleteMoneyFormat(item.FullPrice);
                each += DeleteMoneyFormat(item.EachPrice);
            }
            TotalBlock.Text = String.Format("{0:C2}", total);
            EachBlock.Text = String.Format("С каждого по {0:C2}", each);
        }
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
            if ((!double.TryParse((sender as TextBox).Text, out double a)) || (double.Parse((sender as TextBox).Text) < 0))
                (sender as TextBox).Text = "";

            if ((sender as TextBox).Text.Equals(string.Empty))
                switch ((sender as TextBox).Name)
                {
                    case "BeerPrice":
                        {
                            if (FindItem("Пиво") != -1)
                                alcoResults.Remove(alcoResults[FindItem("Пиво")]);
                            break;
                        }
                    case "CiderPrice":
                        {
                            if (FindItem("Сидр") != -1)
                                alcoResults.Remove(alcoResults[FindItem("Сидр")]);
                            break;
                        }
                    case "WinePrice":
                        {
                            if (FindItem("Вино") != -1)
                                alcoResults.Remove(alcoResults[FindItem("Вино")]);
                            break;
                        }
                    case "Price1":
                        {
                            if (FindItem(Name1.Text) != -1)
                                alcoResults.Remove(alcoResults[FindItem(Name1.Text)]);
                            break;
                        }
                    case "Price2":
                        {
                            if (FindItem(Name2.Text) != -1)
                                alcoResults.Remove(alcoResults[FindItem(Name2.Text)]);
                            break;
                        }
                    case "Price3":
                        {
                            if (FindItem(Name3.Text) != -1)
                                alcoResults.Remove(alcoResults[FindItem(Name3.Text)]);
                            break;
                        }
                    default:
                        break;
                }
            Calculate();
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
            if ((sender as TextBox).Text.Equals(string.Empty))
                switch ((sender as TextBox).Name)
                {
                    case "BeerCount":
                        {
                            if (FindItem("Пиво") != -1)
                                alcoResults.Remove(alcoResults[FindItem("Пиво")]);
                            break;
                        }
                    case "CiderCount":
                        {
                            if (FindItem("Сидр") != -1)
                                alcoResults.Remove(alcoResults[FindItem("Сидр")]);
                            break;
                        }
                    case "WineCount":
                        {
                            if (FindItem("Вино") != -1)
                                alcoResults.Remove(alcoResults[FindItem("Вино")]);
                            break;
                        }
                    case "Count1":
                        {
                            if (FindItem(Name1.Text) != -1)
                                alcoResults.Remove(alcoResults[FindItem(Name1.Text)]);
                            break;
                        }
                    case "Count2":
                        {
                            if (FindItem(Name2.Text) != -1)
                                alcoResults.Remove(alcoResults[FindItem(Name2.Text)]);
                            break;
                        }
                    case "Count3":
                        {
                            if (FindItem(Name3.Text) != -1)
                                alcoResults.Remove(alcoResults[FindItem(Name3.Text)]);
                            break;
                        }
                    default:
                        break;
                }
            if ((!int.TryParse((sender as TextBox).Text, out int a)) || (int.Parse((sender as TextBox).Text) <= 0))
            {
                (sender as TextBox).Text = "";
            }
            if ((int.TryParse((sender as TextBox).Text, out int b)) && (int.Parse((sender as TextBox).Text) > 500))
            {
                (sender as TextBox).Text = "500";
                (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;
            }
            Calculate();
        }
        private void CharSpace_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void AlcoName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Блокировать пробел, если стоим на первом месте и символ пробел, или если символ пробел и прошлый был пробел
            if ((((sender as TextBox).SelectionStart == 0) && (e.Key == Key.Space)) || ((e.Key == Key.Space) && ((sender as TextBox).Text[(sender as TextBox).SelectionStart - 1] == ' ')))
                e.Handled = true;
        }
        //Удаление из вставки двойных пробелов и пробелов в начале и конце
        string oldTextTB;
        private void AlcoName_TextChanged(object sender, TextChangedEventArgs e)
        {
            while ((sender as TextBox).Text.Contains("  "))
            {
                (sender as TextBox).Text = (sender as TextBox).Text.Replace("  ", " ");
            }
            (sender as TextBox).Text = (sender as TextBox).Text.Trim();
            if ((sender as TextBox).Text.Equals(string.Empty))
                switch ((sender as TextBox).Name)
                {
                    case "Name1":
                        {
                            if (FindItem(oldTextTB) != -1)
                                alcoResults.Remove(alcoResults[FindItem(oldTextTB)]);
                            break;
                        }
                    case "Name2":
                        {
                            if (FindItem(oldTextTB) != -1)
                                alcoResults.Remove(alcoResults[FindItem(oldTextTB)]);
                            break;
                        }
                    case "Name3":
                        {
                            if (FindItem(oldTextTB) != -1)
                                alcoResults.Remove(alcoResults[FindItem(oldTextTB)]);
                            break;
                        }
                    default:
                        break;
                }
            else
            {
                (sender as TextBox).Text = (sender as TextBox).Text[0].ToString().ToUpper() + (sender as TextBox).Text.Substring(1);
                (sender as TextBox).CaretIndex = (sender as TextBox).Text.Length;
                if (FindItem(oldTextTB) != -1)
                    alcoResults[FindItem(oldTextTB)].Name = (sender as TextBox).Text;
            }
            Calculate();
        }
        private void Name_PreviewKeyDown(object sender, KeyEventArgs e)
        {
                oldTextTB = (sender as TextBox).Text;
        }

        //Обработчики ComboBox объема и watermark's на прайс
        bool flagBeerCombo = true;
        private void BeerSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BeerPriceWatermark.Text = $"Цена за {((ComboBoxItem)((sender as ComboBox).SelectedItem)).Content.ToString()}";
            if (flagBeerCombo)
                flagBeerCombo = false;
            else
                Calculate();
        }
        bool flagCiderCombo = true;
        private void CiderSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CiderPriceWatermark.Text = $"Цена за {((ComboBoxItem)((sender as ComboBox).SelectedItem)).Content.ToString()}";
            if (flagCiderCombo)
                flagCiderCombo = false;
            else
                Calculate();
        }
        bool flagWineCombo = true;
        private void WineSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WinePriceWatermark.Text = $"Цена за {((ComboBoxItem)((sender as ComboBox).SelectedItem)).Content.ToString()}";
            if (flagWineCombo)
                flagWineCombo = false;
            else
                Calculate();
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

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text documents (.txt)|*.txt";
            ofd.ShowDialog();
            if (ofd.FileName != "") // проверка на выбор файла
            {
                StreamReader f = new StreamReader(ofd.FileName);
                alcoResults.Clear();
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
        int flagSlider = 0;
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (flagSlider < 2)
                flagSlider++;
            else
                Calculate();
        }

        private bool isFocused = false;
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            isFocused = true;
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (isFocused)
            {
                isFocused = false;
                (sender as TextBox).SelectAll();
            }
        }
    }
}
