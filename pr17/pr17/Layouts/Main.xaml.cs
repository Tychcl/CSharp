using pr17.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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
using static pr17.Classes.Dish;

namespace pr17
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public MainWindow mainWindow;
        public List<Dish> dishs = new List<Dish>();
        public Main(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;

            Dish dish1 = new Dish();
            dish1.img = "img-1";
            dish1.name = "сливочная";
            dish1.description = "";

            Dish.Ingredient ingredient = new Dish.Ingredient();
            ingredient.name = "соус Кунжутный";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "сыр Моцарелла";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "сыр Моцарелла мягкий";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "помидоры";
            dish1.ingredients.Add(ingredient);

            Dish.Sizes size = new Dish.Sizes();
            size.size = 23;
            size.price = 380;
            size.wes = 530;
            dish1.sizes.Add(size);

            size = new Dish.Sizes();
            size.size = 30;
            size.price = 760;
            size.wes = 700;
            dish1.sizes.Add(size);

            size = new Dish.Sizes();
            size.size = 40;
            size.price = 1210;
            size.wes = 900;
            dish1.sizes.Add(size);

            dishs.Add(dish1);
            //2 блюдо
            dish1 = new Dish();
            dish1.img = "img-2";
            dish1.name = "Бефстроганов";
            dish1.description = "";

            ingredient = new Dish.Ingredient();
            ingredient.name = "Пряная говядина";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "шампиньоны";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "грибной соус";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "моцарелла";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "соус альфредо";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "маринованные огурчики";
            dish1.ingredients.Add(ingredient);

            size = new Dish.Sizes();
            size.size = 23;
            size.price = 380;
            size.wes = 530;
            dish1.sizes.Add(size);

            size = new Dish.Sizes();
            size.size = 30;
            size.price = 660;
            size.wes = 700;
            dish1.sizes.Add(size);

            size = new Dish.Sizes();
            size.size = 40;
            size.price = 1110;
            size.wes = 900;
            dish1.sizes.Add(size);

            dishs.Add(dish1);
            //3 блюдо
            dish1 = new Dish();
            dish1.img = "img-3";
            dish1.name = "Сырная";
            dish1.description = "";

            ingredient = new Dish.Ingredient();
            ingredient.name = "Моцарелла";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "чеддер";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "пармезан";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "соус альфредо";
            dish1.ingredients.Add(ingredient);

            size = new Dish.Sizes();
            size.size = 23;
            size.price = 380;
            size.wes = 540;
            dish1.sizes.Add(size);

            size = new Dish.Sizes();
            size.size = 30;
            size.price = 665;
            size.wes = 700;
            dish1.sizes.Add(size);

            size = new Dish.Sizes();
            size.size = 40;
            size.price = 1150;
            size.wes = 900;
            dish1.sizes.Add(size);

            dishs.Add(dish1);
            //4 блюдо
            dish1 = new Dish();
            dish1.img = "img-4";
            dish1.name = "Пеперони фреш";
            dish1.description = "";

            ingredient = new Dish.Ingredient();
            ingredient.name = "Пикантная пеперони";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "моцарелла";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "томаты";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "фирменный томатный соус";
            dish1.ingredients.Add(ingredient);

            size = new Dish.Sizes();
            size.size = 23;
            size.price = 380;
            size.wes = 530;
            dish1.sizes.Add(size);

            size = new Dish.Sizes();
            size.size = 30;
            size.price = 660;
            size.wes = 700;
            dish1.sizes.Add(size);

            size = new Dish.Sizes();
            size.size = 40;
            size.price = 1110;
            size.wes = 900;
            dish1.sizes.Add(size);

            dishs.Add(dish1);
            //5 блюдо
            dish1 = new Dish();
            dish1.img = "img-5";
            dish1.name = "Жюльен";
            dish1.description = "";

            ingredient = new Dish.Ingredient();
            ingredient.name = "цыпленок";

            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "шампиньоны";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "грибной соус";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "лук";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "чеснок";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "моцарелла";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "чедр";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "пармезан";
            dish1.ingredients.Add(ingredient);

            size = new Dish.Sizes();
            size.size = 23;
            size.price = 380;
            size.wes = 530;
            dish1.sizes.Add(size);

            size = new Dish.Sizes();
            size.size = 30;
            size.price = 660;
            size.wes = 700;
            dish1.sizes.Add(size);

            size = new Dish.Sizes();
            size.size = 40;
            size.price = 1110;
            size.wes = 900;
            dish1.sizes.Add(size);

            dishs.Add(dish1);
            //6 блюдо
            dish1 = new Dish();
            dish1.img = "img-6";
            dish1.name = "Ветчина и сыр";
            dish1.description = "";

            ingredient = new Dish.Ingredient();
            ingredient.name = "ветчина";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "моцарелла";
            dish1.ingredients.Add(ingredient);

            ingredient = new Dish.Ingredient();
            ingredient.name = "соус альфредо";
            dish1.ingredients.Add(ingredient);

            size = new Dish.Sizes();
            size.size = 23;
            size.price = 380;
            size.wes = 530;
            dish1.sizes.Add(size);

            size = new Dish.Sizes();
            size.size = 30;
            size.price = 660;
            size.wes = 700;
            dish1.sizes.Add(size);

            size = new Dish.Sizes();
            size.size = 40;
            size.price = 1110;
            size.wes = 900;
            dish1.sizes.Add(size);

            dishs.Add(dish1);
            CreatePizza();

        }
        public void CreatePizza()
        {
            for (int i = 0; i < dishs.Count; i++)
            {
                var bc = new BrushConverter();

                Grid global = new Grid();
                global.Height = 100;
                global.Background = (Brush)bc.ConvertFrom("#FFECECEC");
                if (i > 0) global.Margin = new Thickness(0, 10, 0, 0);
                Image logo = new Image();
                string gg = mainWindow.localPath + "Image\\dish\\" + dishs[i].img + ".png";
                if (File.Exists(gg))
                    logo.Source = new BitmapImage(new Uri(gg));
                else
                    logo.Source = new BitmapImage(new Uri(mainWindow.localPath + "Image\\icon.png"));// указвываем картинку

                logo.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;//привязка по горизонтали
                logo.Height = 50; // устанавливаем высоту
                logo.Margin = new Thickness(10, 10, 0, -10); // устанавливаем отступы
                logo.VerticalAlignment = System.Windows.VerticalAlignment.Top;//Привязка по вертикали
                logo.Width = 50;// устанавливаем ширину
                global.Children.Add(logo); // добавляем в элемент Grid

                Label name = new Label(); // создаём текст
                name.Content = dishs[i].name;
                name.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                name.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                name.Margin = new Thickness(65, 0, 0, 0);
                name.FontWeight = FontWeights.Bold;
                global.Children.Add(name);

                Label description = new Label();
                description.Content = dishs[i].description;
                description.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                description.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                description.Margin = new Thickness(65, 20, 0, 0);
                global.Children.Add(description);

                if (dishs[i].ingredients.Count != 0)
                {
                    Label ingredient = new Label();
                    string str_ingredient = "";
                    for (int j = 0; j < dishs[i].ingredients.Count; j++)
                    {
                        str_ingredient += dishs[i].ingredients[j].name;
                        if (j != dishs[i].ingredients.Count - 1)
                            str_ingredient += ", ";
                    }

                    ingredient.Content = "Состав: " + str_ingredient;
                    ingredient.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    ingredient.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    ingredient.Margin = new Thickness(65, 40, 0, 0);
                    global.Children.Add(ingredient);
                }

                Label price = new Label();
                price.Content = "Цена: " + dishs[i].sizes[0].price + " р.";
                price.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                price.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                price.Margin = new Thickness(65, 0, 0, 10);
                global.Children.Add(price); // добавляем в элемент Grid

                Label wes = new Label(); // создаён текст
                wes.Content = "Beс: " + dishs[i].sizes[0].wes + " r.";
                wes.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                wes.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                wes.Margin = new Thickness(236, 0, 0, 10);
                global.Children.Add(wes);

                Button button1 = new Button();
                Button button2 = new Button();
                Button button3 = new Button();
                //низа
                Button minus = new Button();
                TextBox count = new TextBox();
                Button plus = new Button();
                CheckBox order = new CheckBox();

                button1.Content = dishs[i].sizes[0].size + " см.";
                button1.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button1.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button1.Margin = new Thickness(0, 10, 110, 0);
                button1.Width = 45;
                button1.Background = Brushes.White;
                button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");
                button1.Tag = i;
                button1.Click += delegate
                {
                    price.Content = "Цена: " + dishs[int.Parse(button1.Tag.ToString())].sizes[0].price + " p.";
                    wes.Content = "Вeс: " + dishs[int.Parse(button1.Tag.ToString())].sizes[0].wes + " r";
                    button1.Background = Brushes.White;
                    button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    button2.Background = (Brush)bc.ConvertFrom("#FFDD3333");
                    button2.Foreground = Brushes.White;
                    button3.Background = (Brush)bc.ConvertFrom("#FFD03333");
                    button3.Foreground = Brushes.White; // изменяем цвет текста

                    dishs[int.Parse(button1.Tag.ToString())].activeSize = 0;
                    count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[0].countOrder.ToString();
                    order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[0].orders;
                };
                global.Children.Add(button1);//добавлем в элемент Grid

                button2.Content = dishs[i].sizes[1].size + " см.";
                button2.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button2.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button2.Margin = new Thickness(0, 10, 60, 0);
                button2.Width = 45;
                button2.Tag = i;
                button2.Click += delegate
                {
                    price.Content = "Цена: " + dishs[int.Parse(button2.Tag.ToString())].sizes[1].price + " р.";
                    wes.Content = "Beс: " + dishs[int.Parse(button2.Tag.ToString())].sizes[1].wes + " r.";
                    button2.Background = Brushes.White;
                    button2.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    button1.Background = (Brush)bc.ConvertFrom("#FFD03333");
                    button1.Foreground = Brushes.White;
                    button3.Background = (Brush)bc.ConvertFrom("#FFD03333");
                    button3.Foreground = Brushes.White;

                    dishs[int.Parse(button1.Tag.ToString())].activeSize = 1;
                    count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[1].countOrder.ToString();
                    order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[1].orders;
                };
                global.Children.Add(button2); // добавляем в элемент Grid

                button3.Content = dishs[i].sizes[2].size + " см.";
                button3.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                button3.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                button3.Margin = new Thickness(0, 10, 10, 0);
                button3.Width = 45;
                button3.Tag = i;
                button3.Click += delegate
                {
                    price.Content = "Цена: " + dishs[int.Parse(button2.Tag.ToString())].sizes[2].price + " p.";
                    wes.Content = "Beс: " + dishs[int.Parse(button2.Tag.ToString())].sizes[2].wes + " г.";
                    button3.Background = Brushes.White;
                    button3.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    button1.Background = (Brush)bc.ConvertFrom("#FFDD3333");
                    button1.Foreground = Brushes.White;
                    button2.Background = (Brush)bc.ConvertFrom("#FFDD3333");
                    button2.Foreground = Brushes.White; // изменлем цвет текста

                    dishs[int.Parse(button1.Tag.ToString())].activeSize = 2;
                    count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[2].countOrder.ToString();
                    order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[2].orders;
                };
                global.Children.Add(button3);

                minus.Content = "-";
                minus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                minus.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                minus.Margin = new Thickness(0, 0, 103.6f, 10);
                minus.Width = 19;
                minus.Tag = i;
                minus.Click += delegate
                {
                    if (count.Text != "")
                    {
                        if (int.Parse(count.Text) > 0)
                        {
                            count.Text = (int.Parse(count.Text) - 1).ToString();
                            int id = int.Parse(minus.Tag.ToString());
                            dishs[id].sizes[dishs[id].activeSize].countOrder = int.Parse(count.Text);
                        }
                    }
                };
                global.Children.Add(minus); // добавлием в элемент Grid

                count.Text = "0";
                count.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                count.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                count.Margin = new Thickness(0, 0, 33.6f, 10);
                count.TextWrapping = TextWrapping.Wrap;
                count.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                count.Width = 65; // устанавливаеи ширину
                count.Height = 19; // устанавливаем высоту
                count.Tag = i;
                global.Children.Add(count);

                plus.Content = "+"; // устанавливаем текст
                plus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                plus.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                plus.Margin = new Thickness(0, 0, 9.6f, 10); // устанавливаем отступы
                plus.Width = 19;
                plus.Tag = i;
                plus.Click += delegate//назначаем действие
                {
                    if (count.Text != "")
                    {
                        if (int.Parse(count.Text) < 15)
                        {
                            count.Text = (int.Parse(count.Text) + 1).ToString();
                            int id = int.Parse(plus.Tag.ToString());
                            dishs[id].sizes[dishs[id].activeSize].countOrder = int.Parse(count.Text);
                        }
                    }
                };
                global.Children.Add(plus);

                order.Content = "Выбрать";
                order.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                order.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                order.Margin = new Thickness(0, 0, 128, 13);
                order.Tag = i;
                order.Click += delegate
                {
                    int id = int.Parse(order.Tag.ToString());
                    dishs[id].sizes[dishs[id].activeSize].orders = (bool)order.IsChecked;
                };
                global.Children.Add(order);

                parrent.Children.Add(global);

            }
        }
        private void Page(object sender, RoutedEventArgs e)
        {
            int allPrices = 0;
            for (int l = 0; l < dishs.Count; l++)
            {
                for (int s = 0; s < 3; s++)
                {
                    if (dishs[l].sizes[s].orders == true)
                    {
                        allPrices += dishs[l].sizes[s].price * dishs[l].sizes[s].countOrder;
                    }
                }
            }
            allPrice.Content = $"{allPrices}";
        }
    }
}
