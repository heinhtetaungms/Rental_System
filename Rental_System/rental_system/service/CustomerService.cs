using Rental_System.rental_system.model;
using Rental_System.rental_system.util;
using System.Data;
using static Rental_System.RentalDBDataSet;

namespace Rental_System.rental_system.service
{
    class CustomerService
    {
        RentalDBDataSetTableAdapters.CUSTOMERTableAdapter customerTableAdapter = new RentalDBDataSetTableAdapters.CUSTOMERTableAdapter();

        public void save(Customer customer)
        {
            customerTableAdapter.Insert(customer.firstName, customer.lastName, customer.username, customer.password, customer.email, customer.phoneNumber, customer.dateOfBirth, customer.gender, customer.address, 1, customer.role, customer.imagePath);
        }

        public void update(Customer customer)
        {
            customerTableAdapter.updateCustomer(customer.firstName, customer.lastName, customer.username, customer.password, customer.email, customer.phoneNumber, customer.dateOfBirth.ToString(), customer.gender, customer.address, (byte?)Commons.toInt(customer.isActive), customer.role, customer.id);
        }
        public void updateCustomerProfileImage(Customer customer)
        {
            customerTableAdapter.updateCustomerProfileImage(customer.firstName, customer.lastName, customer.username, customer.password, customer.email, customer.phoneNumber, customer.dateOfBirth.ToString(), customer.gender, customer.address, (byte?)Commons.toInt(customer.isActive), customer.role, customer.imagePath, customer.id );
        }

        public DataTable findByEmailAndPassword(string email, string password)
        {
            CUSTOMERDataTable table = new CUSTOMERDataTable();
            customerTableAdapter.findByEmailAndPassword(table, email, password);
            return table;
        }

        public DataTable getData()
        {
            return customerTableAdapter.GetData();
        }
        public DataTable findById(int id)
        {
            CUSTOMERDataTable table = new CUSTOMERDataTable();
            customerTableAdapter.findByID(table, id);
            return table;
        }
    }
}
