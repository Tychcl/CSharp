using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using pr18.Classes;

namespace pr18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<TypeOperation> typeOperationList = TypeOperation.AllTypeOperation();
        public List<Format> formatsList = Format.allFormats();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            foreach (TypeOperation items in typeOperationList)
            {
                typeOperation.Items.Add(items.name);
            }
            foreach (Format item in formatsList)
            {
                formats.Items.Add(item.format);
            }
        }

        public void CalculationsAllPrice()
        {
            // Вся стоимость 0
            float allPrice = 0;
            // перебираем все операции
            for (int i = 0; i < Operations.Items.Count; i++)
            {
                // создаём новый элемент как элемент класса
                TypeOperationsWindow newTOW = Operations.Items[i] as TypeOperationsWindow;
                // считаем общую стоимость
                allPrice += newTOW.price;

            }
            // выводи общую стоимость
            labelAllPrice.Content = "Общая сумма:" + allPrice;

        }

        private void DeleteOperation(object sender, RoutedEventArgs e)
        {
            // если выбрана операция
            if (Operations.SelectedIndex != -1)
            {
                //удаляем её
                Operations.Items.Remove(Operations.Items[Operations.SelectedIndex]);
                // вызываем переращёт всей стоимости
                CalculationsAllPrice();

            }
            else
                // выводим сообщение
                MessageBox.Show("Пожалуйста, выбирете операцию для удаления.");

        }

        private void EditOperation(object sender, RoutedEventArgs e)
        {
            if (Operations.SelectedIndex != -1) // Если выбрана операция
            {
                // создаём операцию как класс
                TypeOperationsWindow newTOW = Operations.Items[Operations.SelectedIndex] as TypeOperationsWindow;
                typeOperation.SelectedItem = typeOperationList.Find(x => x.id == newTOW.typeOperation).name; // Находим тип операции
                formats.SelectedItem = formatsList.Find(x => x.id == newTOW.format).format; // Находим формат операции
                if (newTOW.side == 1) TwoSides.IsChecked = false; // если сторона 1, выключаем двойную сторону
                else if (newTOW.side == 2) TwoSides.IsChecked = true; // если сторона 2, включаем двойную сторону
                Colors.IsChecked = newTOW.color; // В зависимости от операции, включаем или выключаем цветную печать
                string[] resultColor = newTOW.colorText.Split('(');
                if (resultColor.Length == 1) LotOfColor.IsChecked = false; // в зависимости от печати выключаем насыщенность
                else if (resultColor.Length == 2) LotOfColor.IsChecked = true; // в зависимости от печати включаем насыщенность
                textBoxCount.Text = newTOW.count.ToString(); // присваиваем кол-во страниц
                textBoxPrice.Text = newTOW.price.ToString(); // присваиваем цену
                addOperationButton.Content = "Изменить"; // изменяем кнопку
                Operations.Items.Remove(Operations.Items[Operations.SelectedIndex]); // удаляем операцию из списка

            }
            else MessageBox.Show("Пожалуйста, выбирете операцию для редактирования.");// выводим надпись

        }

        private void SelectedType(object sender, SelectionChangedEventArgs e)
        {
            if (typeOperation.SelectedIndex != -1)
            {
                if (typeOperation.SelectedItem as String == "Сканирование")
                {
                    formats.SelectedIndex = -1;
                    TwoSides.IsChecked = false;
                    Colors.IsChecked = false;
                    LotOfColor.IsChecked = false;
                    formats.IsEnabled = false;
                    TwoSides.IsEnabled = false;
                    Colors.IsEnabled = false;
                    LotOfColor.IsEnabled = false;

                }
                else if (typeOperation.SelectedItem as String == "Печать" || typeOperation.SelectedItem as String == "Копия")
                {
                    formats.IsEnabled = true;
                    TwoSides.IsEnabled = true;
                    Colors.IsEnabled = true;
                    if
                    (formats.SelectedItem as String == "A4")
                    {
                        TwoSides.IsEnabled = true;
                        Colors.IsEnabled = true;
                        LotOfColor.IsEnabled = false;

                    }
                    else if (formats.SelectedItem as String == "A3")
                    {
                        TwoSides.IsEnabled = true;
                        Colors.IsEnabled = false;
                        LotOfColor.IsEnabled = false;

                    }
                    else if (formats.SelectedItem as String == "A2" || formats.SelectedItem as String == "A1")
                    {
                        TwoSides.IsEnabled = false;
                        Colors.IsEnabled = true;
                        LotOfColor.IsEnabled = true;

                    }

                }
                else if (typeOperation.SelectedItem as String == "Ризограф")
                {
                    formats.SelectedIndex = 0;
                    formats.IsEnabled = false;
                    Colors.IsEnabled = false;
                    LotOfColor.IsEnabled = false;

                }
                //автозаполнение на 1
                if (textBoxCount.Text.Length == 0)
                    textBoxCount.Text = "1";
                CostCalculations();
            }

        }

        private void SelectedFormat(object sender, SelectionChangedEventArgs e)
        {
            // автозаполнение на 1
            if (formats.SelectedItem as String == "A4") // Если выбран формат A4
            {
                TwoSides.IsEnabled = true; // Включаем двойную сторону
                Colors.IsEnabled = true; // Включаем цвет
                LotOfColor.IsEnabled = false; // отключаем насыщенность

            }
            else if (formats.SelectedItem as String == "АЗ") // Если выбран формат АЗ
            {
                TwoSides.IsEnabled = true; // Включаем двойную сторону
                Colors.IsEnabled = false; // Отключаем цвет
                LotOfColor.IsEnabled = false; // Отключаем насыщенность

            }
            else
            {
                TwoSides.IsEnabled = false; // Отключаем двойную сторону
                Colors.IsEnabled = true; // Включаем цветную печать
                LotOfColor.IsEnabled = true; // Включаем насыщенность

            }
            if (textBoxCount.Text.Length == 0) // Если ничего не введено
                textBoxCount.Text = "1"; // Вводим 1
            CostCalculations(); // Вызываем функцию перерасчёта операции

        }

        private void textBoxCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            CostCalculations(); // производим перерасчёт

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void AddOperation(object sender, RoutedEventArgs e)
        {
            TypeOperationsWindow newTOW = new TypeOperationsWindow(); // Создаём новую операцию
            newTOW.typeOperationText = typeOperation.SelectedItem as String; // присваиваем текст выбранной операции
            newTOW.typeOperation = typeOperationList.Find(x => x.name == newTOW.typeOperationText).id; // получаем ID операции

            if (formats.SelectedIndex != -1) // если выбран формат
            {
                newTOW.formatText = formats.SelectedItem as String; // присваиваем текст формата
                newTOW.format = formatsList.Find(x => x.format == newTOW.formatText).id; // получаем ID формата

            }
            if (TwoSides.IsEnabled == true) // если включена двойная сторона
            {
                if (TwoSides.IsChecked == false) // если не выбрана
                    newTOW.side = 1; // запоминаем состояние
                else
                    newTOW.side = 2; // запоминаем состояние

            }
            if (Colors.IsChecked == false) // если выключена цветная печать
            {
                newTOW.colorText = "4/Б"; // запоминаем
                newTOW.color = false; // запоминаем
                if (LotOfColor.IsChecked == true) // если выбрана насыщенность
                {
                    newTOW.colorText += "(> 50%)"; // запоминаем
                    newTOW.occupancy = true; // запоминаем

                }
            }
            else
            {
                newTOW.colorText = "ЦВ"; // за  запоминаем
                newTOW.color = true; // запоминаем
                if (LotOfColor.IsChecked == true) // если выбрана насыщенноеть
                {
                    newTOW.colorText += "(> 50%)"; // запоминаем
                    newTOW.occupancy = true; // запоминаем

                }
            }
            newTOW.count = int.Parse(textBoxCount.Text); // запоминаем кол-во
            newTOW.price = float.Parse(textBoxPrice.Text); // запоминаем стоимость
            addOperationButton.Content = "Добавить"; // изменяем название клавиши
            Operations.Items.Add(newTOW); // добавляем операцию в список
            CalculationsAllPrice(); // перерасчитываем полную стоимость операций

        }

        private void ColorsChange(object sender, RoutedEventArgs e) => CostCalculations();
        public void CostCalculations()
        {
            float price = 0;
            if (typeOperation.SelectedIndex != -1)
            {
                if (typeOperation.SelectedItem as String == "Сканирование") price = 10;
                else if (typeOperation.SelectedItem as String == "Печать" | typeOperation.SelectedItem as String == "Копия")
                {
                    if (formats.SelectedItem as String == "A4")
                    {
                        if (TwoSides.IsChecked == false)
                        {
                            if (Colors.IsChecked == false)
                            {
                                if (textBoxCount.Text.Length > 0 && int.Parse(textBoxCount.Text) < 30)
                                {
                                    price = 4;
                                }
                                else 
                                { 
                                    price = 3; 
                                }
                            }
                            else
                            {
                                price = 20;
                            }
                        }
                        else
                        {
                            if (Colors.IsChecked == false)
                            {
                                if (textBoxCount.Text.Length > 0 && int.Parse(textBoxCount.Text) < 30)
                                {
                                    price = 6;
                                }
                                else
                                {
                                    price = 4;
                                }
                            }
                            else
                            {
                                price = 35;
                            } 
                        }
                    }
                    else if (formats.SelectedItem as String == "A3")
                    {
                        if (TwoSides.IsChecked == false)
                        {
                            if (textBoxCount.Text.Length > 0 && int.Parse(textBoxCount.Text) < 30) price = 8;
                            else price = 6;
                        }
                        else
                        {
                            if (textBoxCount.Text.Length > 0 && int.Parse(textBoxCount.Text) < 30) price = 12;
                            else price = 10;
                        }
                    }
                    else if (formats.SelectedItem as String == "A2")
                    {
                        if (Colors.IsChecked == false)
                        {
                            if (LotOfColor.IsChecked == false)
                                price = 35;
                            else
                                price = 50;
                        }
                        else
                        {
                            if (LotOfColor.IsChecked == false) price = 120;
                            else price = 170;
                        }
                    }
                    else if (formats.SelectedItem as String == "A1")
                    {
                        if (Colors.IsChecked == false)
                        {
                            if (LotOfColor.IsChecked == false)
                                price = 75;
                            else
                                price = 120;
                        }
                        else
                        {
                            if (LotOfColor.IsChecked == false)
                                price = 170;
                            else
                                price = 250;
                        }
                    }
                }
                else if (typeOperation.SelectedItem as String == "Ризограф")
                {
                    if (TwoSides.IsChecked == false)
                    {
                        if (textBoxCount.Text.Length > 0 && int.Parse(textBoxCount.Text) < 100) price = 1.40f;
                        else if (textBoxCount.Text.Length > 0 && int.Parse(textBoxCount.Text) < 200 && textBoxCount.Text.Length > 0 && int.Parse(textBoxCount.Text) >= 100) price = 1.10f;
                        else price = 1;
                    }
                    else
                    {
                        if (textBoxCount.Text.Length > 0 && int.Parse(textBoxCount.Text) < 100) price = 1.80f;
                        else if (textBoxCount.Text.Length > 0 && int.Parse(textBoxCount.Text) < 200 && textBoxCount.Text.Length > 0 && int.Parse(textBoxCount.Text) >= 100) price = 1.40f;
                        else price = 1.10f;
                    }
                }
            }
            if (textBoxCount.Text.Length > 0) textBoxPrice.Text = (float.Parse(textBoxCount.Text) * price).ToString();
        }

    }
}
