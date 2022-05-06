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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegRepres.Models;
using System.Data.SQLite;
using RegRepres.View;

namespace RegRepres
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dgEmployee.ItemsSource = Employee.GetList();
            dgRegion.ItemsSource = Region.GetList();
            dgTerritory.ItemsSource = Territory.GetList();
            dgEmployeeTerritory.ItemsSource = EmployeeTerritory.GetList();
        }

        void Employee_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowEmployee();
            window.ShowDialog();
            dgEmployee.ItemsSource = Employee.GetList();
        }

        void Employee_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            var employee = dgEmployee.SelectedItem as Employee;
            if(employee != null)
            {
                var window = new WindowEmployee(employee);
                window.ShowDialog();
                dgEmployee.ItemsSource = Employee.GetList();
            }
        }

        void Employee_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var employee = dgEmployee.SelectedItem as Employee;
            if (employee != null)
            {
                var dialog = MessageBox.Show("Удалить запись?", "Требуется подтверждение.", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (dialog == MessageBoxResult.Yes)
                {
                    Employee.Delete(employee);
                    dgEmployee.ItemsSource = Employee.GetList();
                }
            }
        }

        void Region_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowRegion();
            window.ShowDialog();
            dgRegion.ItemsSource = Region.GetList();
        }

        void Region_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            var region = dgRegion.SelectedItem as Region;
            if (region != null)
            {
                var window = new WindowRegion(region);
                window.ShowDialog();
                dgRegion.ItemsSource = Region.GetList();
            }
        }

        void Region_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var region = dgRegion.SelectedItem as Region;
            if (region != null)
            {
                var dialog = MessageBox.Show("Удалить запись?", "Требуется подтверждение.", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (dialog == MessageBoxResult.Yes)
                {
                    Region.Delete(region);
                    dgRegion.ItemsSource = Region.GetList();
                }
            }
        }

        void Territory_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowTerritory();
            window.ShowDialog();
            dgTerritory.ItemsSource = Territory.GetList();
        }

        void Territory_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            var territory = dgTerritory.SelectedItem as Territory;
            if (territory != null)
            {
                var window = new WindowTerritory(territory);
                window.ShowDialog();
                dgTerritory.ItemsSource = Territory.GetList();
            }
        }

        void Territory_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var territory = dgTerritory.SelectedItem as Territory;
            if (territory != null)
            {
                var dialog = MessageBox.Show("Удалить запись?", "Требуется подтверждение.", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (dialog == MessageBoxResult.Yes)
                {
                    Territory.Delete(territory);
                    dgTerritory.ItemsSource = Territory.GetList();
                }
            }
        }

        void EmployeeTerritory_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowEmployeeTerritory();
            window.ShowDialog();
            dgEmployeeTerritory.ItemsSource = EmployeeTerritory.GetList();
        }

        void EmployeeTerritory_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            var employeeTerritory = dgEmployeeTerritory.SelectedItem as EmployeeTerritory;
            if (employeeTerritory != null)
            {
                var window = new WindowEmployeeTerritory(employeeTerritory);
                window.ShowDialog();
                dgEmployeeTerritory.ItemsSource = EmployeeTerritory.GetList();
            }
        }

        void EmployeeTerritory_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var employeeTerritory = dgEmployeeTerritory.SelectedItem as EmployeeTerritory;
            if (employeeTerritory != null)
            {
                var dialog = MessageBox.Show("Удалить запись?", "Требуется подтверждение.", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
                if (dialog == MessageBoxResult.Yes)
                {
                    EmployeeTerritory.Delete(employeeTerritory);
                    dgEmployeeTerritory.ItemsSource = EmployeeTerritory.GetList();
                }
            }
        }

    }
}
