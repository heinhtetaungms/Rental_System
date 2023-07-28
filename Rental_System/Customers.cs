using Rental_System.rental_system;
using Rental_System.rental_system.model;
using Rental_System.rental_system.service;
using Rental_System.rental_system.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_System
{
    public partial class Customers : Form
    {
        private CustomerService customerService;
        private int id;
        public Customers()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            initializeDGV();
        }
        private void initializeDGV()
        {
            customersDGV.DataSource = customerService.getData();
            customersDGV.RowHeadersVisible = false;
            customersDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            customersDGV.Columns.RemoveAt(11);
            customersDGV.Refresh();
        }

        private void customersDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = customersDGV.Rows[e.RowIndex];
            id = Convert.ToInt32(row.Cells[0].Value);
            inputFirstName.Text = row.Cells[1].Value.ToString();
            inputLastName.Text = row.Cells[2].Value.ToString();
            inputUserName.Text = row.Cells[3].Value.ToString();
            inputPassword.Text = row.Cells[4].Value.ToString();
            inputEmail.Text = row.Cells[5].Value.ToString();
            inputPhoneNumber.Text = row.Cells[6].Value.ToString();
            inputDateOfBirth.Text = row.Cells[7].Value.ToString();
            inputGender.Text = row.Cells[8].Value.ToString();
            inputAddress.Text = row.Cells[9].Value.ToString();
            if(row.Cells[10].Value.ToString() == "1")
            {
                cbIsActive.Checked = true;
            }
            else
            {
                cbIsActive.Checked = false;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();            
        }
        private void clearData()
        {
            inputFirstName.Clear();
            inputLastName.Clear();
            inputUserName.Clear();
            inputPassword.Clear();
            inputEmail.Clear();
            inputPhoneNumber.Clear();
            inputDateOfBirth.Value = DateTime.Today;
            inputGender.Items.Clear();
            inputGender.Items.AddRange(new object[] {"MALE", "FEMALE"});
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = validateFields();
            if (isValid)
            {
                Customer customer = new Customer(id, inputFirstName.Text, inputLastName.Text, inputUserName.Text, inputPassword.Text,
                    inputEmail.Text, inputPhoneNumber.Text, inputDateOfBirth.Value, inputGender.Text, inputAddress.Text, cbIsActive.Checked, "ROLE_USER");
                customerService.update(customer);
                MessageBoxUtils.ok("Updated Success!", customer.email + " was successfully updated.");
                clearData();
                initializeDGV();
            }
        }
        private Boolean validateFields()
        {
            return validateEmptyFields() && validateEmptyComboBox() && PasswordUtils.validatePassword(inputPassword.Text);
        }
        private Boolean validateEmptyFields()
        {
            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(inputFirstName);
            textBoxList.Add(inputLastName);
            textBoxList.Add(inputUserName);
            textBoxList.Add(inputPassword);
            textBoxList.Add(inputPhoneNumber);
            textBoxList.Add(inputAddress);


            return FieldUtils.validateEmptyFields(textBoxList);
        }
        private Boolean validateEmptyComboBox()
        {
            List<ComboBox> boxes = new List<ComboBox>();
            boxes.Add(inputGender);
            return FieldUtils.validateEmptyComboBox(boxes);
        }
    }
}
