using master_pol.Config;
using master_pol.Models;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace master_pol.Pages.Add
{
    public partial class Partners : Page
    {
        Models.Partners partner;
        public Partners(Models.Partners inPartner = null)
        {
            InitializeComponent();

            for (int i = 1; i < 11; i++)
            {
                Rating.Items.Add(i);
            }

            if (inPartner != null)
            {
                BtnAdd.Content = "Изменить";

                partner = inPartner;
                this.Name.Text = partner.name_company;
                this.Director.Text = partner.fio_director;
                this.Phone.Text = "8" + partner.phone;
                this.Rating.Text = partner.rating.ToString();
                this.Address.Text = partner.address;
                this.Inn.Text = partner.inn.ToString();
                this.Email.Text = partner.email;
                this.Places.Text = partner.places_sells;
                Type.SelectedItem = partner.type;
            }

            DataContext Context = new DataContext();
            foreach (var item in Context.typeCompanies)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = item.name;
                cbi.Tag = item.id;
                if (partner != null && partner.type == item.id)
                {
                    cbi.IsSelected = true;
                }
                Type.Items.Add(cbi);
            }
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.window.frame.Navigate(new Main());
        }

        private void BtnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!Regex.IsMatch(Name.Text, @"^[А-Яа-яЁё ]+$"))
            {
                MessageBox.Show("Неверное наименование", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Type.SelectedIndex == -1)
            {
                MessageBox.Show("Тип не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(Director.Text, @"^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$"))
            {
                MessageBox.Show("Неверное ФИО директора", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(Rating.Text, @"^[1-9]|10$"))
            {
                MessageBox.Show("Неверный рейтинг", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(Address.Text, @"^[А-Яа-яЁё ]+$"))
            {
                MessageBox.Show("Неверный адрес", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(Inn.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Неверный ИНН", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(Phone.Text, @"^8\d{10}$"))
            {
                MessageBox.Show("Неверный номер телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(Email.Text, @"^[a-z0-9]+(|\.[a-z0-9]+)@[a-z]+\.[a-z]{2,3}$"))
            {
                MessageBox.Show("Неверная почта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DataContext Context = new DataContext();

            if (partner == null)
            {
                Models.Partners newPartner = new Models.Partners();
                newPartner.name_company = Name.Text;
                newPartner.fio_director = Director.Text;
                newPartner.phone = long.Parse(Phone.Text.Remove(0, 1));
                newPartner.rating = int.Parse(Rating.Text);
                newPartner.address = Address.Text;
                newPartner.email = Email.Text;
                newPartner.inn = long.Parse(Inn.Text);
                newPartner.type = (int)((ComboBoxItem)Type.SelectedItem).Tag;
                newPartner.places_sells = Places.Text;

                Context.partners.Add(newPartner);
                Context.SaveChanges();

                MainWindow.window.main.CreateUI();
                MainWindow.window.OpenPages(MainWindow.Page.Main);

                MessageBox.Show("Партнёр успешно добавлен", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                partner.name_company = Name.Text;
                partner.fio_director = Director.Text;
                partner.phone = long.Parse(Phone.Text.Remove(0, 1));
                partner.rating = int.Parse(Rating.Text);
                partner.address = Address.Text;
                partner.inn = long.Parse(Inn.Text);
                partner.email = Email.Text;
                partner.type = (int)((ComboBoxItem)Type.SelectedItem).Tag;
                partner.places_sells = Places.Text;

                Context.partners.Update(partner);
                Context.SaveChanges();

                MainWindow.window.main.CreateUI();
                MainWindow.window.OpenPages(MainWindow.Page.Main);

                MessageBox.Show("Партнёр успешно изменён", "Изменение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
