using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_System.rental_system.model
{
    class OrderModel
    {
        public int id { get; set; }
        public int rented_months { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public decimal totalPrice { get; set; }
        public int customerId { get; set; }
        public int applianceId { get; set; }
        public OrderModel() {}
        public OrderModel(int id, int rented_months, DateTime startDate, DateTime endDate, decimal totalPrice, int customerId, int applianceId) {
            this.id = id;
            this.rented_months = rented_months;
            this.startDate = startDate;
            this.endDate = endDate;
            this.totalPrice = totalPrice;
            this.customerId = customerId;
            this.applianceId = applianceId;
        }
        public static List<OrderModel> extractOrderModelFromDataTable(DataTable dataTable)
        {
            List<OrderModel> orderModelList = new List<OrderModel>();

            foreach (DataRow row in dataTable.Rows)
            {
                int id = row.Field<int>("ID");
                int? rentedMonth = row.IsNull("RENTED_MONTHS") ? 0 : row.Field<int>("RENTED_MONTHS");
                DateTime startDate = row.Field<DateTime>("START_DATE");
                DateTime endDate = row.Field<DateTime>("END_DATE");
                decimal? totalPrice = row.IsNull("TOTAL_PRICE") ? 0 : row.Field<decimal>("TOTAL_PRICE");
                int customerId = row.Field<int>("CUSTOMERID");
                int applianceId = row.Field<int>("APPLIANCEID");

                
                OrderModel order = new OrderModel(
                    id,
                    rentedMonth ?? 0,
                    startDate,
                    endDate,
                    totalPrice ?? 0,
                    customerId,
                    applianceId
                    );

                orderModelList.Add(order);
            }

            return orderModelList;
        }

    }
}
