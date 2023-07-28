using Rental_System.rental_system;
using Rental_System.rental_system.model;
using Rental_System.rental_system.service;
using Rental_System.rental_system.util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Rental_System
{
    public partial class CustomerRegister : Form
    {
        private CustomerService customerService;
        public CustomerRegister()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            doCustomerRegisterProcess();
            
        }

        private void doCustomerRegisterProcess()
        {

            bool isValid = validateFields();
            if (isValid)
            {
                Customer customer = new Customer(0, inputFirstName.Text, inputLastName.Text, inputUserName.Text, inputPassword.Text,
                    inputEmail.Text, inputPhoneNumber.Text, inputDateOfBirth.Value, inputGender.Text, inputAddress.Text, true, "ROLE_USER", null);
                customerService.save(customer);
                MessageBoxUtils.ok("Register Success!", customer.email + " was successfully registered.");
                Commons.HidePreviousOpenForms<CustomerRegister>();
            }
        }

        private bool validateFields()
        {
            return validateEmptyFields() && validateEmptyComboBox() && validateEmptyCheckBox() && PasswordUtils.validatePasswordAndConfirmPassword(inputPassword.Text, inputConfirmPassword.Text);
        }

        private bool validateEmptyFields()
        {
            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(inputFirstName);
            textBoxList.Add(inputLastName);
            textBoxList.Add(inputUserName);
            textBoxList.Add(inputEmail);
            textBoxList.Add(inputPassword);
            textBoxList.Add(inputPhoneNumber);
            textBoxList.Add(inputAddress);
            
            return FieldUtils.validateEmptyFields(textBoxList);
        }
        private bool validateEmptyComboBox()
        {
            List<ComboBox> boxes = new List<ComboBox>();
            boxes.Add(inputGender);
            return FieldUtils.validateEmptyComboBox(boxes);
        }

        private bool validateEmptyCheckBox()
        {
            List<CheckBox> boxes = new List<CheckBox>();
            boxes.Add(termsOfService);
            return FieldUtils.validateEmptyCheckBox(boxes);
        }

        private void CustomerRegister_Load(object sender, EventArgs e)
        {

        }

        private void customerLoginLink_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            Commons.HidePreviousOpenForms<CustomerRegister>();
        }
    }
}
