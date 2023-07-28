using System;
using System.Collections.Generic;
using System.Data;

namespace Rental_System.rental_system.model
{
    class Customer
    {   
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public bool isActive { get; set; }
        public string role { get; set; }
        public string imagePath { get; set; }
        
        public Customer() { }
        
        public Customer(int id,string firstName, string lastName, string username, string password, string email, string phoneNumber, DateTime dateOfBirth, string gender, string address, bool isActive, string role, string imagePath)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.address = address;
            this.isActive = isActive;
            this.role = role;
            this.imagePath = imagePath;
        }
        public Customer(int id, string firstName, string lastName, string username, string password, string email, string phoneNumber, DateTime dateOfBirth, string gender, string address, bool isActive, string role)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.address = address;
            this.isActive = isActive;
            this.role = role;
        }


        public static List<Customer> extractCustomerFromDataTable(DataTable dataTable)
        {
            List<Customer> customerList = new List<Customer>();

            foreach (DataRow row in dataTable.Rows)
            {
                    int id = row.Field<int>("ID");
                    string firstName = row.Field<string>("FIRSTNAME");
                    string lastName = row.Field<string>("LASTNAME");
                    string username = row.Field<string>("USERNAME");
                    string password = row.Field<string>("PASSWORD");
                    string email = row.Field<string>("EMAIL");
                    string phoneNumber = row.Field<string>("PHONENUMBER");
                    DateTime dateOfBirth = row.Field<DateTime>("DATEOFBIRTH");
                    string gender = row.Field<string>("GENDER");
                    string address = row.Field<string>("ADDRESS");
                    int isActive = Convert.ToInt32(row["ISACTIVE"]);
                    string role = row.Field<string>("ROLE");
                    string imagePath = row.Field<string>("IMAGEPATH");

                Customer customer = new Customer(id, firstName, lastName, username, password, email, phoneNumber, dateOfBirth, gender, address, Convert.ToBoolean(isActive), role, imagePath);
        
                customerList.Add(customer);
            }

            return customerList;
        }
    }
}
