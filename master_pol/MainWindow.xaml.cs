using master_pol.Pages;
using System.Windows;
namespace master_pol
{
    public partial class MainWindow : Window
    {
        public static MainWindow window;
        public Main main;
        public MainWindow()
        {
            InitializeComponent();
            window = this;
            main = new Main();
            OpenPages(Page.Main);
        }
        public enum Page
        {
            Main, Partners
        }

        public void OpenPages(Page pages)
        {
            if (pages == Page.Main) { frame.Navigate(main); }
            if (pages == Page.Partners) { frame.Navigate(new Pages.Add.Partners()); }
        }
    }
}
