using Rental_System.rental_system;
using Rental_System.rental_system.model;
using Rental_System.rental_system.service;
using Rental_System.rental_system.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Rental_System
{
    public partial class AppliancesForm : Form
    {
        private ApplianceTypeService applianceTypeService;
        private AppliancesService appliancesService;

        public AppliancesForm()
        {
            InitializeComponent();
            applianceTypeService = new ApplianceTypeService();
            appliancesService = new AppliancesService();
        }

        private bool isUpdate;
        private string fileExtension { get; set; }
        private string selectedFileName { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = validateFields();

            if (isValid && isUpdate)
            {
                updateAppliancesData();
                clear();
            }
            else if (isValid && !isUpdate)
            {
                saveAppliancesData();
                clear();
            }        
            initializeDataGridView();
        }
        
        private void updateAppliancesData()
        {
            int upcomingID = Convert.ToInt32(inputId.Text);
            string imagePath = getImagePath(upcomingID);
            int applianceTypeId = (int)cboApplianceType.SelectedValue;
            appliancesService.update(inputName.Text, inputBrandName.Text, inputModel.Text,
                                        inputDimensions.Text, inputColor.Text, inputEnergyConsumption.Text, inputMonthlyFee.Text, inputMinimumRentalPeriod.Text,
                                        inputTypicalUsage.Text, inputEstimatedAnnualCost.Text, inputDescription.Text, imagePath, applianceTypeId, inputId.Text);
            MessageBoxUtils.ok("Success", "Successfully Updated.");
        }

        private void saveAppliancesData()
        {
            int upcomingID = generateNextIdForAppliances();
            string imagePath = getImagePath(upcomingID);
            int applianceTypeId = (int)cboApplianceType.SelectedValue;
            AppliancesModel appliancesModel = new AppliancesModel(0, inputName.Text, inputBrandName.Text, inputModel.Text,
                                        inputDimensions.Text, inputColor.Text, inputEnergyConsumption.Text, Convert.ToDecimal(inputMonthlyFee.Text), Convert.ToInt32(inputMinimumRentalPeriod.Text),
                                        inputTypicalUsage.Text, Convert.ToDecimal(inputEstimatedAnnualCost.Text), inputDescription.Text, imagePath, applianceTypeId);
            appliancesService.save(appliancesModel);
            MessageBoxUtils.ok("Success", "Successfully Saved.");
        }

        private string getImagePath(int upcomingID)
        {
            string relativePath = null;

            //Save the selected image into the user's profile
            if (selectedFileName != null)
            {
                string appliancesImagePath = GetAppliancesImagePath(upcomingID);    //Get the path to save the image
                string savedFilePath = Path.Combine(appliancesImagePath, selectedFileName);
                relativePath = SaveAppliancesImage(imageView.Image, upcomingID, savedFilePath, GetImageFormat(fileExtension));
            }
            return relativePath;
        }

        private bool validateFields()
        {
            return validateEmptyFields();
        }

        private bool validateEmptyFields()
        {
            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(inputName);
            textBoxList.Add(inputBrandName);
            textBoxList.Add(inputModel);
            textBoxList.Add(inputDimensions);
            textBoxList.Add(inputColor);
            textBoxList.Add(inputEnergyConsumption);
            textBoxList.Add(inputMonthlyFee);
            textBoxList.Add(inputMinimumRentalPeriod);
            textBoxList.Add(inputEstimatedAnnualCost);
            
      //    textBoxList.Add(inputDescription);

            return FieldUtils.validateEmptyFields(textBoxList);
        }

        private void AppliancesForm_Load(object sender, EventArgs e)
        {
            appliancesDGV.RowTemplate.Height = 60;
            initializeApplianceType();
            initializeDataGridView();
            initializeDefaultImage();
            ConfigureDataGridView();
            appliancesDGV.Refresh();
        }
      
        public void initializeApplianceType()
        {
            cboApplianceType.DisplayMember = "Name";
            cboApplianceType.ValueMember = "Id";
            cboApplianceType.DataSource = applianceTypeService.GET_DATA();
        }

        private void initializeDefaultImage()
        {
            Image image = Properties.Resources.default_no_image;
            imageView.Image = image;
            selectedFileName = null;
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
                    this.selectedFileName = pureImageName;
                    this.fileExtension = fileExtension;
                }
                catch (FileNotFoundException)
                {
                    Image image = Properties.Resources.default_no_image;
                    imageView.Image = image;
                    selectedFileName = null;
                }
            }
            else
            {
                Image image = Properties.Resources.default_no_image;
                imageView.Image = image;
                selectedFileName = null;
            }

        }

        private void ConfigureDataGridView()
        {
            appliancesDGV.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;

            // Add a new column for the delete button
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Name = "DeleteButton";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            appliancesDGV.Columns.Add(deleteButtonColumn);
            appliancesDGV.CellContentClick += appliancesDGV_CellContentClick; // Add the event handler
            appliancesDGV.CellFormatting += AppliancesDGV_CellFormatting;

        }

        private void AppliancesDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == appliancesDGV.Columns["DeleteButton"].Index)
            {
                CustomizeDeleteButtonCell(appliancesDGV.Rows[e.RowIndex].Cells[e.ColumnIndex]);
            }
        }

        private void CustomizeDeleteButtonCell(DataGridViewCell cell)
        {
            cell.Style.BackColor = Color.Red;
            cell.Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
        }

        private void initializeDataGridView()
        {
            DataTable dataTable = appliancesService.GET_DATA();
            appliancesDGV.DataSource = dataTable;
            appliancesDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Set the "imagePath" column's Visible property to false
            appliancesDGV.Columns["IMAGEPATH"].Visible = false;
        }

        private void appliancesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == appliancesDGV.Columns["DeleteButton"].Index)
            {
                // Handle the delete button click
                int rowIndex = e.RowIndex;
                int applianceId = Convert.ToInt32(appliancesDGV.Rows[rowIndex].Cells["ID"].Value);

                // Show a confirmation message box before deleting the row
                DialogResult result = MessageBox.Show("Are you sure you want to delete this appliance?", "Confirm Delete",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Delete the row from the database and refresh the DataGridView
                    appliancesService.deleteById(applianceId);
                    initializeDataGridView();
                }
            }
        
        }


        private void clear()
        {
            inputId.Text = "";
            inputName.Text = "";
            inputBrandName.Text = "";
            inputModel.Text = "";
            inputDimensions.Text = "";
            inputColor.Text = "";
            inputEnergyConsumption.Text = "";
            inputMonthlyFee.Text = "";
            inputMinimumRentalPeriod.Text = "";
            inputTypicalUsage.Text = "";
            inputEstimatedAnnualCost.Text = "";
            inputDescription.Text = "";
            initializeDefaultImage();
            initializeApplianceType();
            isUpdate = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void appliancesDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = appliancesDGV.Rows[e.RowIndex];
                inputId.Text = row.Cells["ID"].Value.ToString();
                inputName.Text = row.Cells["Name"].Value.ToString();
                inputBrandName.Text = row.Cells["BrandName"].Value.ToString();
                inputModel.Text = row.Cells["Model"].Value.ToString();
                inputDimensions.Text = row.Cells["Dimensions"].Value.ToString();
                inputColor.Text = row.Cells["Color"].Value.ToString();

                inputEnergyConsumption.Text = row.Cells["Energy_Consumption"].Value.ToString();
                inputMonthlyFee.Text = row.Cells["Monthly_Fee"].Value.ToString();
                inputMinimumRentalPeriod.Text = row.Cells["Minimum_Rental_Period"].Value.ToString();
                inputTypicalUsage.Text = row.Cells["Typical_Usage"].Value.ToString();
                inputEstimatedAnnualCost.Text = row.Cells["Estimated_Annual_Cost"].Value.ToString();
                inputDescription.Text = row.Cells["Description"].Value.ToString();

                string imagePath = row.Cells["ImagePath"].Value.ToString();
                string applianceTypeId = row.Cells["Appliance_Type_Id"].Value.ToString();

                cboApplianceType.SelectedValue = applianceTypeId;
                initializeApplianceImage(imagePath);

                isUpdate = true;
            }
        }


        private void imageView_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Profile Image";
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFileName = openFileDialog.SafeFileName;
                    string selectedFilePath = openFileDialog.FileName;
                    string fileExtension = Path.GetExtension(selectedFilePath).ToLower();

                    //Check if the selected file is an image
                    if (IsImageFile(fileExtension))
                    {
                        //Load the selected image into the picturebox
                        imageView.Image = Image.FromFile(selectedFilePath);

                        this.selectedFileName = selectedFileName;
                        this.fileExtension = fileExtension;
                    }
                    else
                    {
                        MessageBoxUtils.error("Error!", "Please select a valid image file.");
                    }

                }
            }
        }

        private bool IsImageFile(string fileExtension)
        {
            string[] validExtensions = { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };
            return Array.Exists(validExtensions, ext => ext.Equals(fileExtension));
        }

        private ImageFormat GetImageFormat(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".png":
                    return ImageFormat.Png;
                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".gif":
                    return ImageFormat.Gif;
                case ".bmp":
                    return ImageFormat.Bmp;
                default:
                    throw new NotSupportedException("Unsupported image format.");
            }
        }

        private int generateNextIdForAppliances()
        {
            DataTable dataTable = appliancesService.findLatestRecord();
            List<AppliancesModel> appliances = AppliancesModel.extractAppliancesModelFromDataTable(dataTable);
            if (appliances.Count == 0)
            {
                return 1;
            }
            AppliancesModel appliance = appliances.First();
            return appliance.id + 1;
        }

        private string GetAppliancesImagePath(int upcomingId)
        {
            string rootDirectory = @"D:\RentalSystem\Appliances\" + upcomingId;
            if (!Directory.Exists(rootDirectory))
            {
                Directory.CreateDirectory(rootDirectory);
            }
            return rootDirectory;
        }
        
        private string SaveAppliancesImage(Image image, int upcomingID, string filePath, ImageFormat format)
        {
            if (File.Exists(filePath))
            {
                // Image file already exists, no need to save again
                return MakeRelativeURI(GetAppliancesImagePath(upcomingID), filePath);
            }

            try
            {
                image.Save(filePath, format);
                return MakeRelativeURI(GetAppliancesImagePath(upcomingID), filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving image: {ex.Message}");
            }
            return null;
        }

        private string MakeRelativeURI(string basePath, string filePath)
        {
            Uri baseUri = new Uri(basePath);
            Uri fileUri = new Uri(filePath);
            return baseUri.MakeRelativeUri(fileUri).ToString();
        }

        
    }
}
