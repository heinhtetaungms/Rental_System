using Rental_System.rental_system.model;
using Rental_System.rental_system.service;
using Rental_System.rental_system.session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental_System
{
    public partial class Appliances : Form
    {
        private ApplianceTypeService applianceTypeService;
        private AppliancesService appliancesService;

        public Appliances()
        {
            InitializeComponent();
            applianceTypeService = new ApplianceTypeService();
            appliancesService = new AppliancesService();
        }

        private async void Appliances_Load(object sender, EventArgs e)
        {
            await LoadApplianceTypesAsync();
            await LoadAllAppliancesAsync();
            UpdateCartSummary();
        }

        // Event handler for clicking on an appliance type PictureBox
        private async void ApplianceType_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox && pictureBox.Tag is int applianceTypeId)
            {
                await LoadAppliancesByApplianceTypeId(applianceTypeId);
            }
        }

        private async Task LoadApplianceTypesAsync()
        {
            string rootDirectory = @"D:\RentalSystem\ApplianceType";
            DataTable dataTable = applianceTypeService.GET_DATA();
            List<ApplianceType> applianceTypes = ApplianceType.extractApplianceTypeFromDataTable(dataTable);

            appliancesTypeListViewPanel.Controls.AddRange(applianceTypes
                .Select(applianceType =>
                {
                    Panel panel = new Panel
                    {
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(10),
                        Padding = new Padding(5),
                        Width = 120,
                        Height = 140
                    };

                    PictureBox pictureBox = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Dock = DockStyle.Top,
                        Height = 100,
                        Tag = applianceType.id,
                        Image = (applianceType.imagePath != null && File.Exists(Path.Combine(rootDirectory, applianceType.imagePath)))
                                ? Image.FromFile(Path.Combine(rootDirectory, applianceType.imagePath))
                                : Properties.Resources.default_no_image,
                        Cursor = Cursors.Hand
                    };

                    pictureBox.Click += ApplianceType_Click; // Add the event handler here

                    Label label = new Label
                    {
                        Text = applianceType.name,
                        Dock = DockStyle.Bottom,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    panel.Controls.AddRange(new Control[] { pictureBox, label });
                    return panel;
                }).ToArray());

            appliancesTypeListViewPanel.HorizontalScroll.Visible = false;
        }




        private async Task LoadAllAppliancesAsync()
        {
            appliancesListViewPanel.Controls.Clear();
            DataTable dataTable = appliancesService.GET_DATA();
            List<AppliancesModel> appliances = AppliancesModel.extractAppliancesModelFromDataTable(dataTable);
            await LoadImagesAsync(appliances, appliancesListViewPanel);
        }

        private async Task LoadAppliancesByApplianceTypeId(int applianceTypeId)
        {
            appliancesListViewPanel.Controls.Clear();
            DataTable dataTable = appliancesService.findByApplianceTypeId(applianceTypeId);
            List<AppliancesModel> appliances = AppliancesModel.extractAppliancesModelFromDataTable(dataTable);
            await LoadImagesAsync(appliances, appliancesListViewPanel);
        }

        public void UpdateCartSummary()
        {
            cartPanel.Controls.Clear();
            string cartItemsCount = SessionManager.Instance.CurrentApplianceSessions.Count.ToString();

            Button addToCartView = new Button
            {
                Dock = DockStyle.Bottom,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Size = new Size(100, 60),
                Image = Properties.Resources.view_cart,
                ImageAlign = ContentAlignment.MiddleCenter,
                Text = cartItemsCount,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.RoyalBlue,
                Font = new Font(Font.FontFamily, 14f, FontStyle.Regular)
            };

            addToCartView.Click += (s, e) =>
            {
                Rent rent = new Rent();
                rent.ApplianceDeleted += (sender, args) => UpdateCartSummary();
                rent.ShowDialog();
            };

            cartPanel.Location = new Point(1310, cartPanel.Location.Y);
            cartPanel.Controls.Add(addToCartView);
        }

        private async Task LoadImagesAsync(List<AppliancesModel> appliances, Panel panel)
        {
            foreach (AppliancesModel appliance in appliances)
            {
                Panel cardPanel = new Panel
                {
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    Padding = new Padding(5),
                    Width = 200,
                    Height = 250
                };

                PictureBox pictureBox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Dock = DockStyle.Top,
                    Height = 150
                };

                Label nameLabel = new Label
                {
                    Text = appliance.name,
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleCenter,
                };

                Label priceLabel = new Label
                {
                    Text = appliance.monthlyFee.ToString() + " £",
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleCenter,
                };

                Button addToCartButton = new Button
                {
                    Dock = DockStyle.Bottom,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    Size = new Size(100, 30),
                    Text = "View",
                    TextAlign = ContentAlignment.MiddleCenter,
                };

                addToCartButton.Click += (s, e) =>
                {
                    AppliancesModel selectedAppliance = appliance;
                    ApplianceDetails applianceDetails = new ApplianceDetails(selectedAppliance);
                    applianceDetails.AddToCartClicked += (sender, args) => UpdateCartSummary();
                    applianceDetails.ShowDialog();
                };

                priceLabel.Font = new Font(priceLabel.Font.FontFamily, 14f, FontStyle.Regular);

                cardPanel.Controls.AddRange(new Control[] { pictureBox, nameLabel, priceLabel, addToCartButton });
                panel.Controls.Add(cardPanel);

                await LoadImageAsync(appliance, pictureBox);
            }
        }

        private async Task LoadImageAsync(AppliancesModel appliance, PictureBox pictureBox)
        {
            await Task.Run(() =>
            {
                if (!pictureBox.IsDisposed)
                {
                    string rootDirectory = @"D:\RentalSystem\Appliances";
                    pictureBox.Invoke(new Action(() =>
                    {
                        pictureBox.Image = (appliance.imagePath != null && File.Exists(Path.Combine(rootDirectory, appliance.imagePath)))
                                        ? Image.FromFile(Path.Combine(rootDirectory, appliance.imagePath))
                                        : Properties.Resources.default_no_image;
                        pictureBox.Tag = appliance.id;
                    }));
                }
            });
        }
    }
}
