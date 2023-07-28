using Rental_System.rental_system.model;
using Rental_System.rental_system.session;
using Rental_System.rental_system.util;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Rental_System
{
    public partial class ApplianceDetails : Form
    {
        public event EventHandler AddToCartClicked;

        private AppliancesModel appliancesModel;
        private decimal subTotalFee { get; set; }
        public int rentedMonths { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public ApplianceDetails(AppliancesModel appliancesModel)
        {
            InitializeComponent();
            this.appliancesModel = appliancesModel;
        }

       

        private void ApplianceDetails_Load(object sender, EventArgs e)
        {
            endDatePicker.Value = startDatePicker.Value.AddMonths(appliancesModel.minimumRentalPeriod);

            startDatePicker.MinDate = DateTime.MinValue;
            startDatePicker.MaxDate = endDatePicker.Value;
            endDatePicker.MinDate = startDatePicker.Value;
            endDatePicker.MaxDate = DateTime.MaxValue;

            initializeApplianceImage(appliancesModel.imagePath);
            initializeAddToCartButton();
            initializeData();
            UpdateMonthlyFee();
        }
       
        private void initializeAddToCartButton()
        {


            Panel cardPanel = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Width = 120,
                Height = 45
            };

            Button addToCartButton = new Button
            {
                Dock = DockStyle.Bottom,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Size = new Size(120, 45),
                BackColor = Color.DarkSeaGreen,
                Image = Properties.Resources.add_to_cart,
                ImageAlign = ContentAlignment.MiddleCenter,
             

            };
            addToCartButton.Click += (s, e) =>
            {   
                //update value
                appliancesModel.monthlyFee = subTotalFee;
                appliancesModel.rentedMonths = rentedMonths;
                appliancesModel.startDate = startDate;
                appliancesModel.endDate = endDate;

                ApplianceSession applianceSession = Sessions.createApplianceSession(appliancesModel);
                SessionManager.Instance.AddApplianceSession(applianceSession);

                AddToCartClicked?.Invoke(this, EventArgs.Empty);
                MessageBoxUtils.ok("Success", "Appliance " + applianceSession.name +" was added.");

            };
            cardPanel.Controls.AddRange(new Control[] {addToCartButton });
            cartPanel.Controls.Add(cardPanel);

        }

        public void initializeData()
        {
            lblName.Text = appliancesModel.name;
            lblBrand.Text = appliancesModel.brandName;
            lblModel.Text = appliancesModel.model;
            lblDimensions.Text = appliancesModel.dimensions;
            lblColor.Text = appliancesModel.color;
            lblEnergyConsumption.Text = appliancesModel.energyConsumption;
            lblMonthlyFee.Text = appliancesModel.monthlyFee.ToString();
            lblMinimumRentalPeriod.Text = appliancesModel.minimumRentalPeriod.ToString();
            lblTypicalUsage.Text = appliancesModel.typicalUsage;
            lblEstimatedAnnualCost.Text = appliancesModel.estimatedAnnualCost.ToString();
            lblDescription.Text = appliancesModel.description;
            lblSubTotal.Text = appliancesModel.monthlyFee.ToString();

            subTotalFee = appliancesModel.monthlyFee;
            startDate = startDatePicker.Value;
            endDate = endDatePicker.Value;
            rentedMonths = appliancesModel.minimumRentalPeriod;
        }
        

        private void initializeApplianceImage(string imagePath)
        {
            if (imagePath != "" && imagePath != null)
            {
                try
                {
                    string rootDirectory = @"D:\RentalSystem\Appliances";
                    string imageRelativePath = imagePath.TrimStart('\\');
                    string combinedPath = Path.Combine(rootDirectory, imageRelativePath);
                    string fileExtension = Path.GetExtension(combinedPath).ToLower();
                    imageView.Image = Image.FromFile(combinedPath);

                    string pureImageName = imageRelativePath.Substring(imageRelativePath.IndexOf('/') + 1);
                    
                }
                catch (FileNotFoundException)
                {
                    Image image = Properties.Resources.default_no_image;
                    imageView.Image = image;
                }
            }
            else
            {
                Image image = Properties.Resources.default_no_image;
                imageView.Image = image;
             }

        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateEndDate();
            UpdateMonthlyFee();
        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateStartDate();
            UpdateMonthlyFee();
        }

        private void UpdateEndDate()
        {
            // Set the minimum date for the end date picker
            endDatePicker.MinDate = startDatePicker.Value;
        }

        private void UpdateStartDate()
        {
            // Set the maximum date for the start date picker
            startDatePicker.MaxDate = endDatePicker.Value;
        }

        private void UpdateMonthlyFee()
        {
            // Get the selected start date and end date
            DateTime startDate = startDatePicker.Value.Date;
            DateTime endDate = endDatePicker.Value.Date;

            // Calculate the difference in months between start and end dates
            int differenceInMonths = GetElapsedMonths(startDate, endDate);
            differenceInMonths = differenceInMonths - 1;

            // Calculate the updated monthly fee
            decimal subTotalFee = appliancesModel.monthlyFee * differenceInMonths;

            // Update the label with the updated monthly fee value
            lblSubTotal.Text = subTotalFee.ToString();
            
            //reAssign values with updated values
            this.subTotalFee = subTotalFee;
            this.startDate = startDate;
            this.endDate = endDate;
            this.rentedMonths = differenceInMonths;
        }

        private int GetElapsedMonths(DateTime startDate, DateTime endDate)
        {
            int elapsedMonths = 0;

            while (startDate.AddMonths(elapsedMonths) <= endDate)
            {
                elapsedMonths++;
            }

            return elapsedMonths;
        }

      

       
    }
}
