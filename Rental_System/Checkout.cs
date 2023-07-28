using Rental_System.rental_system;
using Rental_System.rental_system.model;
using Rental_System.rental_system.service;
using Rental_System.rental_system.session;
using Rental_System.rental_system.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Rental_System
{
    public partial class Checkout : Form
    {
        private List<ApplianceSession> currentAppliances;
        private Session currentSession = SessionManager.Instance.CurrentSession;
        private OrderService checkoutService;

        public Checkout()
        {
            InitializeComponent();
            currentAppliances = SessionManager.Instance.CurrentApplianceSessions;
            checkoutService = new OrderService();
        }

        private void Checkout_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isValid = validateEmptyFields();
            if (isValid)
            {
                saveOrderAppliaction();
                MessageBoxUtils.ok("Success!", "You have successfully place an order. Please check it out email.");
                Commons.HidePreviousOpenForms<Checkout>();
            }
        }
        private bool validateEmptyFields()
        {
            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(inputEmail);

            return FieldUtils.validateEmptyFields(textBoxList);
        }
        private void saveOrderAppliaction()
        {
            foreach (ApplianceSession appliance in currentAppliances)
            {
                OrderModel order = new OrderModel(0, appliance.rentedMonths, appliance.startDate, appliance.endDate, appliance.monthlyFee, currentSession.id, appliance.id);
                checkoutService.save(order);                
            }
            //invalidate current appliance session
            SessionManager.Instance.ClearApplianceSessions();

            // Get the instance of the Appliances form and call the UpdateCartItemCount method
            var appliancesForm = Application.OpenForms.OfType<Appliances>().FirstOrDefault();
            appliancesForm?.UpdateCartSummary();

            //Clear Rent Grid View
            var rentForm = Application.OpenForms.OfType<Rent>().FirstOrDefault();
            rentForm?.clearRentDGV();
        }
    }
}
