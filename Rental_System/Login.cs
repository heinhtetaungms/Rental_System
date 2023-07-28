using Rental_System.rental_system;
using Rental_System.rental_system.model;
using Rental_System.rental_system.service;
using Rental_System.rental_system.session;
using Rental_System.rental_system.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Rental_System
{
    public partial class Login : Form
    {
        private CustomerService customerService;
        public Login()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }

        private void customerRegisterLink_Click(object sender, EventArgs e)
        {
            CustomerRegister customerRegister = new CustomerRegister();
            customerRegister.Show();

            Commons.HidePreviousOpenForms<Login>();
        }
        
        private void btnCustomerLogin_Click(object sender, EventArgs e)
        {
            bool isValid = validateCustomerFields();
            if (isValid)
            {
                doLoginProcess(inputCustomerEmail.Text, inputCustomerPassword.Text, "ROLE_USER");
            }
        }

        private Dictionary<string, int> loginAttempts = new Dictionary<string, int>();

        private void doLoginProcess(string email, string passwordText, string expectedRole)
        {
            const int maxLoginAttempts = 3; // Maximum allowed login attempts

            if (loginAttempts.TryGetValue(email, out int loginCount) && loginCount >= maxLoginAttempts)
            {
                MessageBoxUtils.error("Too many login attempts. Please try again later.", "Login Error");
                return;
            }

            DataTable dataTable = customerService.findByEmailAndPassword(email, passwordText);
            List<Customer> customers = Customer.extractCustomerFromDataTable(dataTable);

            if (customers.Count == 1 && customers.First().role == expectedRole)
            {
                loginAttempts[email] = 0; // Reset login attempts on successful login

                Session session = Sessions.createSession(customers.First());
                SessionManager.Instance.CurrentSession = session;

                Commons.HidePreviousOpenForms<Login>();
                Home home = new Home();
                home.Show();

                if (Commons.isHidden("Home"))
                {
                    Form formToHide = Application.OpenForms["Home"];
                    formToHide.Hide();
                }
                else
                {
                    List<Home> previousForm = Commons.GetPreviousOpenForms<Home>(home);
                    foreach (Home form in previousForm)
                    {
                        form.Hide();
                    }
                }

                MessageBoxUtils.ok("Login Success!", email + " was successfully logged in.");
            }
            else
            {
                loginAttempts[email] = loginAttempts.ContainsKey(email) ? loginAttempts[email] + 1 : 1; // Increment login attempts
                MessageBoxUtils.error("Incorrect username or password.", "Error!");
            }
        }


        private bool validateCustomerFields()
        {
            return validateCustomerEmptyFields() && PasswordUtils.validatePassword(inputCustomerPassword.Text);
        }
        
        private bool validateAdminFields()
        {
            return validateAdminEmptyFields() &&  PasswordUtils.validatePassword(inputAdminPassword.Text);
        }
        
        private bool validateCustomerEmptyFields()
        {
            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(inputCustomerEmail);
            return FieldUtils.validateEmptyFields(textBoxList);
        }
        
        private bool validateAdminEmptyFields()
        {
            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(inputAdminPassword);
            return FieldUtils.validateEmptyFields(textBoxList);
        }
      
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            bool isValid = validateAdminFields();
            if(isValid)
            {
                doLoginProcess(inputAdminEmail.Text, inputAdminPassword.Text, "ROLE_ADMIN");
            }
            
        }

   
        private void adminRegisterLink_Click(object sender, EventArgs e)
        {
            AdminRegister adminRegister = new AdminRegister();
            adminRegister.Show();

            Commons.HidePreviousOpenForms<Login>();
        }
    }
}
