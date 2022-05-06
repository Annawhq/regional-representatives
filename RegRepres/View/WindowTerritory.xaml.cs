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
using System.Windows.Shapes;
using RegRepres.Models;

namespace RegRepres.View
{
    /// <summary>
    /// Логика взаимодействия для WindowTerritory.xaml
    /// </summary>
    public partial class WindowTerritory : Window
    {
        Territory temp;
        public WindowTerritory()
        {
            InitializeComponent();
            cbRegionId.ItemsSource = Region.GetList();
            Title = "Добавить";
            btnAdd.Visibility = Visibility.Visible;
        }
        public WindowTerritory(Territory territory)
        {
            InitializeComponent();
            cbRegionId.ItemsSource = Region.GetList();
            Title = "Редактировать";
            btnUpdate.Visibility = Visibility.Visible;
            cbRegionId.SelectedValue = Region.GetList().First(e => e.RegionDiscription == territory.Region).Id;
            tbDiscription.Text = territory.Discription;
            temp = territory;
        }
        void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Territory.Add(new Territory
            {
                RegionId = (int)cbRegionId.SelectedValue,
                Discription = tbDiscription.Text.Trim()
            });
            Close();
        }
        void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            temp.RegionId = (int)cbRegionId.SelectedValue;
            temp.Discription = tbDiscription.Text.Trim();
            Territory.Update(temp);
            Close();
        }
    }
}
