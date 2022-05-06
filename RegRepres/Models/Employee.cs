using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.Data;

namespace RegRepres.Models
{
    public class Employee : Model
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string Title { get; set; }
        public string Birthday { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public static List<Employee> GetList()
        {
            var list = new List<Employee>();
            try
            {
                using(var connect = new SQLiteConnection(_ConnectionString))
                {
                    connect.Open();
                    var command = connect.CreateCommand();
                    command.CommandText = "SELECT * FROM employee";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string lastname = reader.GetString(1);
                        string firstname = reader.GetString(2);
                        string secondname = reader.GetString(3);
                        string title = reader.GetString(4);
                        string birthday = reader.GetString(5);
                        string address = reader.GetString(6);
                        string city = reader.GetString(7);
                        string region = reader.GetString(8);
                        string phone = reader.GetString(9);
                        string email = reader.GetString(10);
                        var employee = new Employee
                        {
                            Id = id,
                            LastName = lastname,
                            FirstName = firstname,
                            SecondName = secondname,
                            Title = title,
                            Birthday = birthday,
                            Adress = address,
                            City = city,
                            Region = region,
                            Phone = phone,
                            Email = email
                        };
                        list.Add(employee);
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return list;
        }
        public static void Add(Employee employee)
        {
            try
            {
                using (var connect = new SQLiteConnection(_ConnectionString))
                {
                    connect.Open();
                    var command = connect.CreateCommand();
                    command.CommandText = String.Format(@"INSERT INTO employee (lastname, firstname, secondname, title, birthday, adress, city, region, phone, email) VALUES (@lastname, @firstname, @secondname, @title, @birthday, @adress, @city, @region, @phone, @email)");
                    command.Parameters.AddWithValue("lastname", employee.LastName);
                    command.Parameters.AddWithValue("firstname", employee.FirstName);
                    command.Parameters.AddWithValue("secondname", employee.SecondName);
                    command.Parameters.AddWithValue("title", employee.Title);
                    command.Parameters.AddWithValue("birthday", employee.Birthday.ToString());
                    command.Parameters.AddWithValue("adress", employee.Adress);
                    command.Parameters.AddWithValue("city", employee.City);
                    command.Parameters.AddWithValue("region", employee.Region);
                    command.Parameters.AddWithValue("phone", employee.Phone);
                    command.Parameters.AddWithValue("email", employee.Email);
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void Update(Employee employee)
        {
            try
            {
                using (var connect = new SQLiteConnection(_ConnectionString))
                {
                    connect.Open();
                    var command = connect.CreateCommand();
                    command.CommandText = String.Format(@"UPDATE employee SET lastname=@lastname, firstname=@firstname, secondname=@secondname, title=@title, birthday=@birthday, adress=@adress, city=@city, region=@region, phone=@phone, email=@email WHERE id=@id");
                    command.Parameters.AddWithValue("lastname", employee.LastName);
                    command.Parameters.AddWithValue("firstname", employee.FirstName);
                    command.Parameters.AddWithValue("secondname", employee.SecondName);
                    command.Parameters.AddWithValue("title", employee.Title);
                    command.Parameters.AddWithValue("birthday", employee.Birthday);
                    command.Parameters.AddWithValue("adress", employee.Adress);
                    command.Parameters.AddWithValue("city", employee.City);
                    command.Parameters.AddWithValue("region", employee.Region);
                    command.Parameters.AddWithValue("phone", employee.Phone);
                    command.Parameters.AddWithValue("email", employee.Email);
                    command.Parameters.AddWithValue("id", employee.Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void Delete(Employee employee)
        {
            try
            {
                using (var connect = new SQLiteConnection(_ConnectionString))
                {
                    connect.Open();
                    var command = connect.CreateCommand();
                    command.CommandText = String.Format(@"DELETE FROM employee WHERE id = @id");
                    command.Parameters.AddWithValue("id", employee.Id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public Employee()
        {

        }
    }
}
