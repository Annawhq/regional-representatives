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
    /// Логика взаимодействия для WindowRegion.xaml
    /// </summary>
    public partial class WindowRegion : Window
    {
        Region temp;
        public WindowRegion()
        {
            InitializeComponent();
            Title = "Добавить";
            btnAdd.Visibility = Visibility.Visible;
        }
        public WindowRegion(Region region)
        {
            InitializeComponent();
            Title = "Редактировать";
            btnUpdate.Visibility = Visibility.Visible;
            tbRegionDiscription.Text = region.RegionDiscription;
            temp = region;
        }
        void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Region.Add(new Region
            {
                RegionDiscription = tbRegionDiscription.Text.Trim(),
            });
            Close();
        }
        void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            temp.RegionDiscription = tbRegionDiscription.Text.Trim();
            Region.Update(temp);
            Close();
        }
    }
}
