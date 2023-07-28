using Rental_System.rental_system.model;
using System;
using System.Data;
using static Rental_System.RentalDBDataSet;

namespace Rental_System.rental_system.service
{
    class OrderService
    {
        RentalDBDataSetTableAdapters.ORDERTableAdapter ordersTableAdapter = new RentalDBDataSetTableAdapters.ORDERTableAdapter();

        public void save(OrderModel order)
        {
            ordersTableAdapter.Insert(order.rented_months, order.startDate, order.endDate, order.totalPrice, order.customerId, order.applianceId);
        }
        public ORDERDataTable GET_DATA()
        {
            return ordersTableAdapter.GetData();
        }
        public DataTable findByCustomerId(int customerId)
        {
            ORDERDataTable table = new ORDERDataTable();
            ordersTableAdapter.findByCustomerID(table, customerId);
            return table;
        }
        public DataTable GET_DATA_BY_DATES(DateTime startDate, DateTime endDate)
        {
            ORDERDataTable table = new ORDERDataTable();
            ordersTableAdapter.findByDates(table, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
            return table;
        }

        public DataTable findByCustomerIdAndDates(int customerId, DateTime startDate, DateTime endDate)
        {
            ORDERDataTable table = new ORDERDataTable();
            ordersTableAdapter.findByCustomerIdAndDates(table, customerId, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
            return table;
        }
    }
}
