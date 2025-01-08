using master_pol.Config;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace master_pol.Pages
{
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            CreateUI();
        }
        public void CreateUI()
        {
            parent.Children.Clear();
            foreach (var partner in new DataContext().partners)
            {
                parent.Children.Add(new Elements.Partner_item(partner));
            }
        }

        public void CreateHistUI(int partnerId)
        {
            parent.Children.Clear();
            using (DataContext Context= new DataContext())
            {
                var Sells = Context.procGetHistPartner.FromSqlRaw("CALL GetHistPartner(@p0)", partnerId).ToList();
                foreach (var hist in Sells)
                {
                    parent.Children.Add(new Elements.History_item(hist));
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.window.OpenPages(MainWindow.Page.Partners);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.window.main.List.Content = "Партнёры";
            MainWindow.window.main.BtnBack.Visibility = Visibility.Hidden;
            MainWindow.window.main.Add.Visibility = Visibility.Visible;
            MainWindow.window.main.CreateUI();
        }
    }
}
