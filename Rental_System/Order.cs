using Rental_System.rental_system.model;
using Rental_System.rental_system.service;
using Rental_System.rental_system.session;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Rental_System
{
    public partial class Order : Form
    {
        private OrderService orderService;
        private AppliancesService appliancesService;
        private CustomerService customerService;
        private Session currentSession = SessionManager.Instance.CurrentSession;
        private DataGridViewRow footerRow; // Footer row to display grand total

        public Order()
        {
            InitializeComponent();
            orderService = new OrderService();
            appliancesService = new AppliancesService();
            customerService = new CustomerService();
        }

        private AppliancesModel findApplianceById(int id) => AppliancesModel.extractAppliancesModelFromDataTable(appliancesService.findById(id)).FirstOrDefault();
        private Customer findByCustomerId(int id) => Customer.extractCustomerFromDataTable(customerService.findById(id)).FirstOrDefault();

        private DataTable getFilteredDataTable()
        {
            DateTime startDate = startDatePicker.Value.Date;
            DateTime endDate = endDatePicker.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Start date cannot be later than end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

           
            return currentSession.role.Equals("ROLE_ADMIN")
                ? orderService.GET_DATA_BY_DATES(startDate, endDate)
                : orderService.findByCustomerIdAndDates(currentSession.id, startDate, endDate);
        }

        private void Order_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            // Auto-select next 14 days for endDatePicker
            endDatePicker.Value = DateTime.Today.AddDays(14);
            fetchData();
        }

        private void fetchData()
        {
            // Clear existing rows in DataGridView before adding new data
            orderDGV.Rows.Clear();

            var dataTable = getFilteredDataTable();
            if (dataTable != null)
            {
                var orders = OrderModel.extractOrderModelFromDataTable(dataTable);
                foreach (var order in orders)
                {
                    var appliance = findApplianceById(order.applianceId);
                    var customer = findByCustomerId(order.customerId);

                    string rootDirectory = @"D:\RentalSystem\Appliances";
                    Image productImage = (appliance.imagePath != null && File.Exists(Path.Combine(rootDirectory, appliance.imagePath)))
                        ? Image.FromFile(Path.Combine(rootDirectory, appliance.imagePath))
                        : Properties.Resources.default_no_image;

                    orderDGV.Rows.Add(productImage, appliance.name, customer.username, order.startDate, order.endDate, order.rented_months, order.totalPrice);
                }
            }

            CalculateGrandTotal();
        }

        private void ConfigureDataGridView()
        {
            orderDGV.BackgroundColor = Color.White;
            orderDGV.Font = new Font("Arial", 11, FontStyle.Regular);
            orderDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderDGV.AllowUserToAddRows = false;
            orderDGV.RowHeadersVisible = false;
            orderDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            orderDGV.Columns.AddRange(
                new DataGridViewImageColumn
                {
                    Name = "Image",
                    HeaderText = "Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    HeaderText = "Product Name",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Name",
                    HeaderText = "Customer Name",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "StartDate",
                    HeaderText = "Start Date",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "EndDate",
                    HeaderText = "End Date",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "RentedMonths",
                    HeaderText = "Rented Months",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TotalPrice",
                    HeaderText = "Total Price",
                    Width = 80
                }

            );

            orderDGV.DefaultCellStyle.BackColor = Color.White;
            orderDGV.DefaultCellStyle.ForeColor = Color.Black;
            orderDGV.DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Regular);
            orderDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            orderDGV.DefaultCellStyle.Padding = new Padding(8);
            orderDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            orderDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            orderDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            orderDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            orderDGV.RowTemplate.Height = 80;

            orderDGV.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;



        }
        private void CalculateGrandTotal()
        {
            decimal grandTotal = 0;

            foreach (DataGridViewRow row in orderDGV.Rows)
            {
                if (row.Cells["TotalPrice"].Value != null && row.Cells["TotalPrice"].Value != "")
                {
                    decimal subtotal = 0;
                    
                    subtotal = Convert.ToDecimal(row.Cells["TotalPrice"].Value);
                    grandTotal += subtotal;
                    
                }
                
            }
            footerRow = new DataGridViewRow();
            footerRow.DefaultCellStyle.BackColor = Color.LightGray;
            footerRow.DefaultCellStyle.ForeColor = Color.Black;
            footerRow.DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            footerRow.Height = 50;

            DataGridViewCell emptyCell = new DataGridViewTextBoxCell();
            emptyCell.Value = string.Empty;
            footerRow.Cells.Add(emptyCell);

            DataGridViewCell grandTotalCell = new DataGridViewTextBoxCell();
            grandTotalCell.Value = "Grand Total:";
            footerRow.Cells.Add(grandTotalCell);

            for (int i = 2; i < orderDGV.Columns.Count - 1; i++)
            {
                DataGridViewCell emptyFooterCell = new DataGridViewTextBoxCell();
                emptyFooterCell.Value = string.Empty;
                footerRow.Cells.Add(emptyFooterCell);
            }

            DataGridViewCell grandTotalValueCell = new DataGridViewTextBoxCell();
            grandTotalValueCell.Value = grandTotal;

            footerRow.Cells.Add(grandTotalValueCell);


            orderDGV.Rows.Add(footerRow);


        }


        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateEndDate();
            fetchData();
        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateStartDate();
            fetchData();
        }

        private void UpdateEndDate()
        {
            endDatePicker.MinDate = startDatePicker.Value;
        }

        private void UpdateStartDate()
        {
            startDatePicker.MaxDate = endDatePicker.Value;
        }
    }
}
