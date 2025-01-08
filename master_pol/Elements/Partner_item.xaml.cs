using master_pol.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace master_pol.Elements
{
    /// <summary>
    /// Логика взаимодействия для Partner_item.xaml
    /// </summary>
    public partial class Partner_item : UserControl
    {
        public Models.Partners partner;
        public Partner_item(Models.Partners inPartner)
        {
            InitializeComponent();
            partner = inPartner;
            this.Name.Content = new DataContext().typeCompanies.FirstOrDefault(x => x.id == partner.type).name + " | " + partner.name_company;
            this.Discount.Content = CalculateDiscount(partner.id) + "%";
            this.Director.Content = partner.fio_director;
            this.Phone.Content = "+7 " + partner.phone.ToString().Insert(3, " ").Insert(7, " ").Insert(10, " ").Insert(13, " ");
            this.Rating.Content = "Рейтинг: " + partner.rating;
        }

        static public int CalculateDiscount(int id)
        {
            using (DataContext Context = new DataContext())
            {
                var Sells = Context.procGetHistPartner.FromSqlRaw("CALL GetHistPartner(@p0)", id).ToList();
                var count = Sells.Sum(x => x.countProduct);
                if (count >= 10000 && count < 50000)
                    return 5;
                else if (count >= 50000 && count < 300000)
                    return 10;
                else if (count >= 300000)
                    return 15;
                else
                    return 0;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.window.frame.Navigate(new Pages.Add.Partners(partner));
        }

        private void BtnHist_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.window.main.List.Content = "История | " + partner.name_company;
            MainWindow.window.main.BtnBack.Visibility = Visibility.Visible;
            MainWindow.window.main.Add.Visibility = Visibility.Hidden;
            MainWindow.window.main.CreateHistUI(partner.id);
        }
    }
}
