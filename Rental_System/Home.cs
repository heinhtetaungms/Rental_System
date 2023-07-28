using Rental_System.rental_system.session;
using Rental_System.rental_system.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_System
{
    public partial class Home : Form
    {
        
       
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //fetch Session
            Session currentSession = SessionManager.Instance.CurrentSession;

            signInNav.Visible = currentSession == null;
            signOutNav.Visible = currentSession != null;
            orderNav.Visible = currentSession != null;
            usersNav.Visible = currentSession?.role == "ROLE_ADMIN";
            profileImage.Visible = currentSession != null;
            applianceTypeFormNav.Visible = currentSession?.role == "ROLE_ADMIN";
            appliancesFormNav.Visible = currentSession?.role == "ROLE_ADMIN";

            // Set the margin for the profileImage control
            const int profileImageMarginRight = 10;
            profileImage.Margin = new Padding(profileImage.Margin.Left, profileImage.Margin.Top, profileImageMarginRight, profileImage.Margin.Bottom);

            // Adjust padding for each navigation item
            const int paddingValue = 60;
            const int defaultPaddingValue = 10; // Default padding value for non-visible items

            signInNav.Margin = new Padding(signInNav.Visible ? paddingValue : defaultPaddingValue, signInNav.Margin.Top, 0, signInNav.Margin.Bottom);
            signOutNav.Margin = new Padding(signOutNav.Visible ? paddingValue : defaultPaddingValue, signOutNav.Margin.Top, 0, signOutNav.Margin.Bottom);
            orderNav.Margin = new Padding(orderNav.Visible ? paddingValue : defaultPaddingValue, orderNav.Margin.Top, 0, orderNav.Margin.Bottom);
            usersNav.Margin = new Padding(usersNav.Visible ? paddingValue : defaultPaddingValue, usersNav.Margin.Top, 0, usersNav.Margin.Bottom);
            applianceTypeFormNav.Margin = new Padding(applianceTypeFormNav.Visible ? paddingValue : defaultPaddingValue, applianceTypeFormNav.Margin.Top, 0, applianceTypeFormNav.Margin.Bottom);
            appliancesFormNav.Margin = new Padding(appliancesFormNav.Visible ? paddingValue : defaultPaddingValue, appliancesFormNav.Margin.Top, 0, appliancesFormNav.Margin.Bottom);

            

            if (currentSession == null || currentSession.imagePath == null)
            {
                Image image = Properties.Resources.default_profile;
                profileImage.Image = image;
            }else
            {
                string rootDirectory = @"D:\RentalSystem\ProfileImages";
                string imageRelativePath = currentSession.imagePath.TrimStart('\\');
                string combinedPath = Path.Combine(rootDirectory, imageRelativePath);
                profileImage.Image = Image.FromFile(combinedPath);
            }
            Refresh();
        }


        private void signOutNav_Click(object sender, EventArgs e)
        {
            SessionManager.Instance.InvalidateSession();

            Commons.HidePreviousOpenForms<Home>();

            Home home = new Home();
            home.Show();
        }

        private void signInNav_Click(object sender, EventArgs e)
        {
            
            Login loginForm = new Login();
            loginForm.Show();

        }

        private void usersNav_Click(object sender, EventArgs e)
        {
            Customers customersForm = new Customers();
            customersForm.Show();
        }

        private void profileImage_Click(object sender, EventArgs e)
        {
            Profile profileForm = new Profile();
            profileForm.Show();
            
        }

     
        private void homeNav_Click(object sender, EventArgs e)
        {
            Appliances appliances = new Appliances();
            appliances.Show();
        }

        private void applianceTypeFormNav_Click(object sender, EventArgs e)
        {
            ApplianceTypeForm applianceTypeForm = new ApplianceTypeForm();
            applianceTypeForm.Show();
        }

        private void appliancesFormNav_Click(object sender, EventArgs e)
        {
            AppliancesForm appliancesForm = new AppliancesForm();
            appliancesForm.Show();
        }

        private void orderNav_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Show();
        }
    }
}

