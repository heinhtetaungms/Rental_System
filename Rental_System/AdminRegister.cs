using Rental_System.rental_system;
using Rental_System.rental_system.model;
using Rental_System.rental_system.service;
using Rental_System.rental_system.util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Rental_System
{
    public partial class AdminRegister : Form
    {
        private CustomerService customerService;

        public AdminRegister()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            doAdminRegisterProcess();
            
        }

        private void doAdminRegisterProcess()
        {
            bool isValid = validateFields();
            if (isValid)
            {
                
                Customer admin = new Customer(0, inputFirstName.Text, inputLastName.Text, inputUserName.Text, inputPassword.Text,
                    inputEmail.Text, null, inputDateOfBirth.Value, inputGender.Text, null, true, "ROLE_ADMIN", null);
                customerService.save(admin);

                MessageBoxUtils.ok("Register Success!", admin.email + " was successfully registered.");
                Commons.HidePreviousOpenForms<AdminRegister>();
            }
        }

        private bool validateFields()
        {
            return validateEmptyFields() && validateEmptyCheckBox() && PasswordUtils.validatePasswordAndConfirmPassword(inputPassword.Text, inputConfirmPassword.Text);
        }

        private bool validateEmptyFields()
        {
            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(inputFirstName);
            textBoxList.Add(inputLastName);
            textBoxList.Add(inputUserName);
            textBoxList.Add(inputPassword);
            textBoxList.Add(inputConfirmPassword);

            return FieldUtils.validateEmptyFields(textBoxList);
        }
        private bool validateEmptyCheckBox()
        {
            List<CheckBox> boxes = new List<CheckBox>();
            boxes.Add(termsOfService);
            return FieldUtils.validateEmptyCheckBox(boxes);
        }

        private void AdminRegister_Load(object sender, EventArgs e)
        {

        }

        private void adminLoginLink_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();           
            Commons.HidePreviousOpenForms<AdminRegister>();
        }
    }
}
