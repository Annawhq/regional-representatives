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
    /// Логика взаимодействия для WindowEmployee.xaml
    /// </summary>
    public partial class WindowEmployee : Window
    {
        Employee temp;
        public WindowEmployee()
        {
            InitializeComponent();
            Title = "Добавить";
            btnAdd.Visibility = Visibility.Visible;
        }
        public WindowEmployee(Employee employee)
        {
            InitializeComponent();
            Title = "Редактировать";
            btnUpdate.Visibility = Visibility.Visible;
            tbLastName.Text = employee.LastName;
            tbFirstName.Text = employee.FirstName;
            tbSecondName.Text = employee.SecondName;
            tbTitle.Text = employee.Title;
            tbBirthday.Text = employee.Birthday.ToString();
            tbAddress.Text = employee.Adress;
            tbCity.Text = employee.City;
            tbRegion.Text = employee.Region;
            tbPhone.Text = employee.Phone;
            tbEmail.Text = employee.Email;
            temp = employee;
        }
        void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Employee.Add(new Employee
            {
                LastName = tbLastName.Text.Trim(),
                FirstName = tbFirstName.Text.Trim(),
                SecondName = tbSecondName.Text.Trim(),
                Title = tbTitle.Text.Trim(),
                Birthday = tbBirthday.Text.Trim(),
                Adress = tbAddress.Text.Trim(),
                City = tbCity.Text.Trim(),
                Region = tbRegion.Text.Trim(),
                Phone = tbPhone.Text.Trim(),
                Email = tbEmail.Text.Trim()
            });
            Close();
        }
        void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            temp.LastName = tbLastName.Text.Trim();
            temp.FirstName = tbFirstName.Text.Trim();
            temp.SecondName = tbSecondName.Text.Trim();
            temp.Title = tbTitle.Text.Trim();
            temp.Birthday = tbBirthday.Text.Trim();
            temp.Adress = tbAddress.Text.Trim();
            temp.City = tbCity.Text.Trim();
            temp.Region = tbRegion.Text.Trim();
            temp.Phone = tbPhone.Text.Trim();
            temp.Email = tbEmail.Text.Trim();
            Employee.Update(temp);
            Close();
        }
    }
}
