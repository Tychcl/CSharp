using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CustomWindow.Controls;

namespace TychkclLibraryFund
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : CWWindow
    {
        public static MainWindow main;
        public enum Page
        {
            user, library, literature, refill,
            ruser, rlibrary, rliterature, rrefill
        }
        public MainWindow()
        {
            InitializeComponent();
            main = this;
            OpenPage(Page.library);
        }

        public void OpenPage(Page p)
        {
            if(Page.user == p)
            {

            }
            if (Page.library == p)
            {
                frame.Navigate(new Pages.Library.View());
            }
            if (Page.literature == p)
            {

            }
            if (Page.refill == p)
            {

            }
            if (Page.ruser == p)
            {

            }
            if (Page.rlibrary == p)
            {

            }
            if (Page.rliterature == p)
            {

            }
            if (Page.rrefill == p)
            {

            }
        }
    }
}