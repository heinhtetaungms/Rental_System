using Rental_System.rental_system.session;
using Rental_System.rental_system.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Rental_System
{
    public partial class Rent : Form
    {
        public event EventHandler ApplianceDeleted;
        private Dictionary<int, int> quantityCounters; // Track the quantity for each row
        private DataGridViewRow footerRow; // Footer row to display grand total
        private List<ApplianceSession> currentAppliances;
        private Session currentSession = SessionManager.Instance.CurrentSession;

        public Rent()
        {
            InitializeComponent();
            quantityCounters = new Dictionary<int, int>();
            currentAppliances = SessionManager.Instance.CurrentApplianceSessions;
        }

        private void Rent_Load(object sender, EventArgs e)
        {
            
            fetchData();

        }
        private void fetchData()
        {
            ConfigureDataGridView();

            int rowIndex = 0;
            foreach (ApplianceSession session in currentAppliances)
            {
                string rootDirectory = @"D:\RentalSystem\Appliances";

                Image productImage = (session.imagePath != null && File.Exists(Path.Combine(rootDirectory, session.imagePath)))
                    ? Image.FromFile(Path.Combine(rootDirectory, session.imagePath))
                    : Properties.Resources.default_no_image;

                string productName = session.name;
                decimal price = session.monthlyFee;
                int quantity = 1;
                decimal subtotal = price * quantity;

                rentDGV.Rows.Add(productImage, productName, price, "-", quantity, "+", subtotal);
                quantityCounters[rowIndex] = quantity;

                rowIndex++;
            }

            CalculateGrandTotal(false);
        }
        public void clearRentDGV()
        {
            rentDGV.Rows.Clear();
            quantityCounters.Clear();
            CalculateGrandTotal(false);
            itemsCount.Text = currentAppliances.Count().ToString();
            cartTotalAmount.Text = currentAppliances.Count().ToString();
        }

        private void ConfigureDataGridView()
        {
            rentDGV.BackgroundColor = Color.White;
            rentDGV.Font = new Font("Arial", 11, FontStyle.Regular);
            rentDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            rentDGV.AllowUserToAddRows = false;
            rentDGV.RowHeadersVisible = false;
            rentDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            rentDGV.Columns.AddRange(
                new DataGridViewImageColumn
                {
                    Name = "Image",
                    HeaderText = "Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    HeaderText = "Product Name",
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Price",
                    HeaderText = "Price",
                },
                new DataGridViewButtonColumn
                {
                    Name = "Minus",
                    HeaderText = "",
                    Text = "-",
                    UseColumnTextForButtonValue = true
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "Quantity",
                },
                new DataGridViewButtonColumn
                {
                    Name = "Plus",
                    HeaderText = "",
                    Text = "+",
                    Width = 30,
                    UseColumnTextForButtonValue = true
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Subtotal",
                    HeaderText = "Subtotal",
                    Width = 120
                },
                new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "",
                    Text = "Delete",
                    Width = 60,
                    UseColumnTextForButtonValue = true
                }
            );

            rentDGV.Columns["Image"].Width = 100;
            rentDGV.Columns["ProductName"].Width = 120;
            rentDGV.Columns["Price"].Width = 70;
            rentDGV.Columns["Quantity"].Width = 50;
            rentDGV.Columns["Plus"].Width = 30; // Adjust the width as desired
            rentDGV.Columns["Minus"].Width = 30; // Adjust the width as desired
            rentDGV.Columns["Subtotal"].Width = 100;
            rentDGV.Columns["Delete"].Width = 80;

            rentDGV.DefaultCellStyle.BackColor = Color.White;
            rentDGV.DefaultCellStyle.ForeColor = Color.Black;
            rentDGV.DefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Regular);
            rentDGV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            rentDGV.DefaultCellStyle.Padding = new Padding(8);
            rentDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            rentDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            rentDGV.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Bold);
            rentDGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            rentDGV.RowTemplate.Height = 80;
            rentDGV.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

            rentDGV.CellContentClick += RentDGV_CellContentClick; // Add the event handler
        }



        private void RentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < rentDGV.Rows.Count)
            {
                int rowIndex = e.RowIndex;
                int quantityCounter = quantityCounters[rowIndex];

                if (e.ColumnIndex == rentDGV.Columns["Minus"].Index && quantityCounter > 1)
                {
                    quantityCounter--;
                    quantityCounters[rowIndex] = quantityCounter;
                    rentDGV.Rows[rowIndex].Cells["Quantity"].Value = quantityCounter.ToString();
                    UpdateSubtotal(rowIndex);
                }
                else if (e.ColumnIndex == rentDGV.Columns["Plus"].Index)
                {
                    quantityCounter++;
                    quantityCounters[rowIndex] = quantityCounter;
                    rentDGV.Rows[rowIndex].Cells["Quantity"].Value = quantityCounter.ToString();
                    UpdateSubtotal(rowIndex);
                }
                else if (e.ColumnIndex == rentDGV.Columns["Delete"].Index)
                {
                    var confirmationResult = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmationResult == DialogResult.Yes)
                    {
                        rentDGV.Rows.RemoveAt(e.RowIndex);
                        quantityCounters.Remove(e.RowIndex);

                        // Remove from the currentAppliances list in the session
                        if (e.RowIndex < currentAppliances.Count)
                        {
                            currentAppliances.RemoveAt(e.RowIndex);
                            ApplianceDeleted?.Invoke(this, EventArgs.Empty);
                        }

                        // Recalculate grand total
                        CalculateGrandTotal(true);
                    }
                }
                CalculateGrandTotal(true);
            }
        }

        private void UpdateSubtotal(int rowIndex)
        {
            decimal price = Convert.ToDecimal(rentDGV.Rows[rowIndex].Cells["Price"].Value);
            int quantity = Convert.ToInt32(rentDGV.Rows[rowIndex].Cells["Quantity"].Value);
            decimal subtotal = price * quantity;
            rentDGV.Rows[rowIndex].Cells["Subtotal"].Value = subtotal;
        }

        private void CalculateGrandTotal(bool isUpdateMode)
        {
            decimal grandTotal = 0;

            foreach (DataGridViewRow row in rentDGV.Rows)
            {
                if (row.Cells["Subtotal"].Value != null && row.Cells["Subtotal"].Value != "")
                {
                    decimal subtotal = 0;
                    if (isUpdateMode)
                    {
                        if (row.Index != rentDGV.Rows.Count - 1)
                        {
                            subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value);
                            grandTotal += subtotal;
                        }
                    }
                    else
                    {
                        subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value);
                        grandTotal += subtotal;
                    }
                }
                cartTotalAmount.Text = grandTotal.ToString();
                itemsCount.Text = currentAppliances.Count().ToString();
            }

            if (footerRow == null)
            {
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

                for (int i = 2; i < rentDGV.Columns.Count - 2; i++)
                {
                    DataGridViewCell emptyFooterCell = new DataGridViewTextBoxCell();
                    emptyFooterCell.Value = string.Empty;
                    footerRow.Cells.Add(emptyFooterCell);
                }

                DataGridViewCell grandTotalValueCell = new DataGridViewTextBoxCell();
                grandTotalValueCell.Value = grandTotal;

                footerRow.Cells.Add(grandTotalValueCell);

                DataGridViewCell emptyCell2 = new DataGridViewTextBoxCell();
                emptyCell2.Value = string.Empty;
                footerRow.Cells.Add(emptyCell2);


                rentDGV.Rows.Add(footerRow);
            }
            else
            {
                footerRow.Cells[footerRow.Cells.Count - 2].Value = grandTotal;
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (currentSession == null)
            {
                Login login = new Login();
                login.Show();
            }
            else if (currentAppliances.Count > 0)
            {
                Checkout checkout = new Checkout();
                checkout.ShowDialog();
            }
            else
            {
                MessageBoxUtils.ok("Enjoy!", "Keep Shopping.");
                Commons.HidePreviousOpenForms<Rent>();
            }

        }
    }
}
