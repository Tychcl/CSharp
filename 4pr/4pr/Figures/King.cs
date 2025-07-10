using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows;

namespace _4pr
{
    public class King
    {
        public int x;
        public int y;
        public bool black;
        public bool selected;
        public Grid figure = new Grid();
        public List<Grid> all = new List<Grid>();
        public MainWindow main;
        public King(int x, int y, bool black, MainWindow main)
        {
            this.black = black;
            this.main = main;
            figure.Tag = this;
            figure.Height = black ? 51 : 50;
            figure.Width = 50;
            Grid.SetRow(figure, x);
            Grid.SetColumn(figure, y);
            this.y = Grid.GetRow(figure);
            this.x = Grid.GetColumn(figure);
            if (black)
            {
                figure.Background = new ImageBrush(new BitmapImage(new Uri(main.MainPath+"\\Images\\KW.png")));
            }
            else
            {
                figure.Background = new ImageBrush(new BitmapImage(new Uri(main.MainPath + "\\Images\\KB.png")));
            }
            figure.MouseDown += SelectFigure;
        }
        public void SelectFigure(object sender, MouseEventArgs e)
        {
            if (sender is null)
            {
                this.selected = false;
                normal();
                return;
            }
            foreach (Grid x in all)
            {
                switch (x.Tag.ToString().Replace("_4pr.", ""))
                {
                    case "Pawn":
                        Pawn selected = x.Tag as Pawn;
                        if (selected.selected & selected.black != this.black)
                        {
                            selected.attack(this.x, this.y, this.figure);
                            return;
                        }
                        if (selected.selected & selected.figure != this.figure)
                        {
                            selected.selected = false;
                            selected.normal();
                        }
                        break;
                    case "King":
                        King sk = x.Tag as King;
                        if (sk.selected & sk.black != this.black)
                        {
                            sk.attack(this.x, this.y, this.figure);
                            return;
                        }
                        if (sk.selected & sk.figure != this.figure)
                        {
                            sk.selected = false;
                            sk.normal();
                        }
                        break;
                }
            }
            this.selected = main.hod == this.black ? true : false;
            if (selected & this.black == main.hod)
            {
                foreach (Grid tile in main.tiles)
                {
                    int x = Grid.GetColumn(tile);
                    int y = Grid.GetRow(tile);
                    if ((Math.Abs(this.x - x) == 1 & Math.Abs(this.y - y) < 2) | (Math.Abs(this.y - y) == 1 & Math.Abs(this.x - x) < 2))
                    {
                        Grid el = all.Find(g => Grid.GetColumn(g) == x & Grid.GetRow(g) == y);
                        tile.Background = el == null ? Brushes.Green : el.Height != this.figure.Height ? Brushes.Red : tile.Background ;
                    }
                }
                figure.Background = new ImageBrush(new BitmapImage(new Uri(main.MainPath + "\\Images\\KS.png")));
            }
            else
            {
                normal();
            }
        }
        public void normal()
        {
            main.deft();
            if (black)
            {
                figure.Background = new ImageBrush(new BitmapImage(new Uri(main.MainPath + "\\Images\\KW.png")));
            }
            else
            {
                figure.Background = new ImageBrush(new BitmapImage(new Uri(main.MainPath + "\\Images\\KB.png")));
            }
        }
        public void Transform(int x, int y)
        {
            if ((Math.Abs(this.x - x) == 1 & Math.Abs(this.y - y) < 2) | (Math.Abs(this.y - y) == 1 & Math.Abs(this.x - x) < 2))
            {
                this.x = x;
                this.y = y;
                Grid.SetColumn(figure, x);
                Grid.SetRow(figure, y);
                SelectFigure(null, null);
                main.hod = !main.hod;
            }
        }
        public void attack(int x, int y, Grid grid)
        {
            if ((Math.Abs(this.x - x) == 1 & Math.Abs(this.y - y) < 2) | (Math.Abs(this.y - y) == 1 & Math.Abs(this.x - x) < 2))
            {
                all.Remove(grid);
                main.gameboard.Children.Remove(grid);
                this.x = x;
                this.y = y;
                Grid.SetColumn(figure, x);
                Grid.SetRow(figure, y);
                SelectFigure(null, null);
                main.hod = !main.hod;
            }
        }
    }
}
