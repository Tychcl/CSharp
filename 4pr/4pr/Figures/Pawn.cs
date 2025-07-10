using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace _4pr
{
    public class Pawn
    {
        public int x;
        public int y;
        public bool black;
        public bool selected;
        public Grid figure = new Grid();
        public List<Grid> all = new List<Grid>();
        public MainWindow main;
        public Pawn(int x, int y, bool black, MainWindow main) 
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
                figure.Background = new ImageBrush(new BitmapImage(new Uri(main.MainPath+"\\Images\\Pawn (black).png")));
            }
            else
            {
                figure.Background = new ImageBrush(new BitmapImage(new Uri(main.MainPath + "\\Images\\Pawn.png")));
            }
            figure.MouseDown += SelectFigure;
        }
        public void SelectFigure(object sender, MouseEventArgs e)
        {
            if(sender is null)
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
                        Pawn sp = x.Tag as Pawn;
                        if (sp.selected & sp.black != this.black)
                        {
                            sp.attack(this.x, this.y, this.figure);
                            return;
                        }
                        if (sp.selected & sp.figure != this.figure)
                        {
                            sp.selected = false;
                            sp.normal();
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
            this.selected = main.hod == this.black?true:false;
            if (selected & this.black == main.hod)
            {
                foreach (Grid tile in main.tiles)
                {
                    int x = Grid.GetColumn(tile);
                    int y = Grid.GetRow(tile);
                    if ((this.black & (this.y - 1 == y) | !this.black & (this.y + 1 == y)) & (this.x - 1 == x | this.x + 1 == x))
                    {
                        Grid el = all.Find(g => Grid.GetColumn(g) == x & Grid.GetRow(g) == y);
                        tile.Background = el == null ? tile.Background : el.Height != this.figure.Height ? Brushes.Red : tile.Background;
                    }
                    if ((this.black & (this.y - 1 == y | (this.y == 6 & this.y - 2 == y)) | !this.black & this.y + 1 == y | (this.y == 1 & this.y + 2 == y)) & this.x == x)
                    {
                        Grid el = all.Find(g => Grid.GetColumn(g) == x & Grid.GetRow(g) == y);
                        tile.Background = el == null ? Brushes.Green : tile.Background;
                    }
                }
                figure.Background = new ImageBrush(new BitmapImage(new Uri(main.MainPath + "\\Images\\Pawn (select).png")));
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
                figure.Background = new ImageBrush(new BitmapImage(new Uri(main.MainPath + "\\Images\\Pawn (black).png")));
            }
            else
            {
                figure.Background = new ImageBrush(new BitmapImage(new Uri(main.MainPath + "\\Images\\Pawn.png")));
            }
        }
        public void Transform(int x, int y)
        {
            if ((this.black & (this.y -1 == y | (this.y == 6 & this.y -2 == y)) | !this.black & this.y+1==y | (this.y == 1 & this.y + 2 == y)) & this.x == x)
            {
                this.x = x;
                this.y = y;
                Grid.SetColumn(figure, x);
                Grid.SetRow(figure, y);
                SelectFigure(null, null);
                main.hod = !main.hod;
            }
        }
        public void attack(int x, int y,Grid grid)
        {
            if((this.black & (this.y - 1 == y) | !this.black & (this.y + 1 == y))  & (this.x - 1 == x | this.x + 1 == x))
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
