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
    /// Логика взаимодействия для WindowEmployeeTerritory.xaml
    /// </summary>
    public partial class WindowEmployeeTerritory : Window
    {
        EmployeeTerritory temp;
        public WindowEmployeeTerritory()
        {
            InitializeComponent();
            cbEmployeeId.ItemsSource = Employee.GetList();
            cbTerritoryId.ItemsSource = Territory.GetList();
            Title = "Добавить";
            btnAdd.Visibility = Visibility.Visible;
        }
        public WindowEmployeeTerritory(EmployeeTerritory employeeTerritory)
        {
            InitializeComponent();
            cbEmployeeId.ItemsSource = Employee.GetList();
            cbTerritoryId.ItemsSource = Territory.GetList();
            Title = "Редактировать";
            btnUpdate.Visibility = Visibility.Visible;
            cbEmployeeId.SelectedValue = Employee.GetList().First(e => e.LastName == employeeTerritory.Employee).Id;
            cbTerritoryId.SelectedValue = Territory.GetList().First(e => e.Discription == employeeTerritory.Territory).Id;
            temp = employeeTerritory;
        }
        void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            EmployeeTerritory.Add(new EmployeeTerritory
            {
                EmployeeId = (int)cbEmployeeId.SelectedValue,
                TerritoryId = (int)cbTerritoryId.SelectedValue,
            });
            Close();
        }
        void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            temp.EmployeeId = (int)cbEmployeeId.SelectedValue;
            temp.TerritoryId = (int)cbTerritoryId.SelectedValue;
            EmployeeTerritory.Update(temp);
            Close();
        }
    }
}
