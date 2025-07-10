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

namespace _4pr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool hod = false;
        public MainWindow main;
        public string MainPath;
        public List<Grid> tiles = new List<Grid>();
        public List<Grid> fig = new List<Grid>();
        public MainWindow()
        {
            main = this;
            InitializeComponent();
            MainPath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\","");
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    Grid grid = new Grid();
                    grid.Tag = "field";
                    grid.Height = 50;
                    grid.Width = 50;
                    Grid.SetColumn(grid, i);
                    Grid.SetRow(grid, j);
                    grid.MouseDown += ST;
                    if ((i + j) % 2 == 0)
                    {
                        grid.Background = Brushes.White;   
                    }
                    else
                    {
                        grid.Background = Brushes.Brown;
                    }
                    gameboard.Children.Add(grid);
                    tiles.Add(grid);
                }
            }
            CreateFigures();
        }
        private void ST(object sender, MouseEventArgs e)
        {
            deft();
            Grid path = sender as Grid;
            int px = Grid.GetColumn(path);
            int py = Grid.GetRow(path);
            foreach (Grid x in fig)
            {
                switch (x.Tag.ToString().Replace("_4pr.", ""))
                {
                    case "Pawn":
                        Pawn sp = x.Tag as Pawn;
                        if (sp.selected)
                        {
                            sp.Transform(px, py);
                        }
                    break;
                    case "King":
                        King sk = x.Tag as King;
                        if (sk.selected)
                        {
                            sk.Transform(px, py);
                        }
                        break;
                }
            }
        }

        private void CreateFigures()
        {
            King k = new King(0, 4, false, main);
            k.all = fig;
            fig.Add(k.figure);
            gameboard.Children.Add(k.figure);
            k = new King(7, 3, true, main);
            k.all = fig;
            fig.Add(k.figure);
            gameboard.Children.Add(k.figure);


            for (int i = 1; i <= 6; i += 5)
            {
                for (int j = 0; j <= 7; j++)
                {
                    Grid grid;
                    if (i < 5)
                    {
                        Pawn p = new Pawn(i, j, false, main);
                        p.all = fig;
                        grid = p.figure;
                    }
                    else
                    {
                        Pawn p = new Pawn(i, j, true, main);
                        p.all = fig;
                        grid = p.figure;
                    }
                    fig.Add(grid);
                    gameboard.Children.Add(grid);

                }
            }
        }
        public void deft()
        {
            foreach (Grid grid in tiles)
            {
                if (grid.Background != Brushes.White | grid.Background != Brushes.Brown)
                {
                    grid.Background = (Grid.GetColumn(grid) + Grid.GetRow(grid)) % 2 == 0 ? Brushes.White : Brushes.Brown;
                }
            }
        }
    }
}
