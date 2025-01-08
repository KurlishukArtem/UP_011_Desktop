using System;
using System.Collections.Generic;
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
using YP01MasterFloor.Models;

namespace master_pol.Elements
{
    /// <summary>
    /// Логика взаимодействия для History_item.xaml
    /// </summary>
    public partial class History_item : UserControl
    {
        public History_item(ProcGetHistPartner hist)
        {
            InitializeComponent();
            Name.Content = hist.name;
            Count.Content = "Количество: " + hist.countProduct;
            Date.Content = "Дата продажи: " + hist.dateSell.ToString("dd.mm.yyyy");
        }
    }
}
