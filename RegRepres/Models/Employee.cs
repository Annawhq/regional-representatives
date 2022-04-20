using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegRepres.Models
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string Role { get; set; }
        public DateTime Birthday { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Employee(int id, string firstName, string lastName, string secondName, string role, 
            DateTime birthday, string adress, string city, string region, string phone, string email)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.SecondName = secondName;
            this.Role = role;
            this.Birthday = birthday;
            this.Adress = adress;
            this.City = city;
            this.Region = region;
            this.Phone = phone;
            this.Email = email;
        }
        public Employee()
        {

        }
    }
}
