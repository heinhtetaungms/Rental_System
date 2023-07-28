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
    public partial class ApplianceTypeForm : Form
    {
        private ApplianceTypeService applianceTypeService;

        public ApplianceTypeForm()
        {
            InitializeComponent();
            applianceTypeService = new ApplianceTypeService();
        }
        private bool isUpdate;
        private string fileExtension { get; set; }
        private string selectedFileName { get; set; }


        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = validateFields();
            
            if (isValid && isUpdate)
            {
                updateApplianceTypeData();
            }
            else if(isValid && !isUpdate)
            {
                saveApplianceTypeData();
            }
            clear();
            initializeDataGridView();
            applianceTypeDGV.CellFormatting += ApplianceTypeDGV_CellFormatting;
        }

        private void updateApplianceTypeData()
        {
            int upcomingID = Convert.ToInt32(inputId.Text);
            string imagePath = getImagePath(upcomingID);
            applianceTypeService.update(inputName.Text, inputUsageTips.Text, inputDescription.Text, imagePath, Convert.ToInt32(inputId.Text));
            MessageBoxUtils.ok("Success", "Successfully Updated.");
        }

        private void saveApplianceTypeData()
        {
            int upcomingID = generateNextIdForApplianceType();
            string imagePath = getImagePath(upcomingID);
            ApplianceType applianceType = new ApplianceType(0, inputName.Text, inputUsageTips.Text, inputDescription.Text, imagePath);
            applianceTypeService.save(applianceType);
            MessageBoxUtils.ok("Success", "Successfully Saved.");
        }

        private string getImagePath(int upcomingID)
        {
            string relativePath = null;
            
            //Save the selected image into the user's profile
            if(selectedFileName != null)
            {
                string applianceTypeImagePath = GetApplianceTypeImagePath(upcomingID);    //Get the path to save the image
                string savedFilePath = Path.Combine(applianceTypeImagePath, selectedFileName);
                relativePath = SaveApplianceTypeImage(imageView.Image, upcomingID, savedFilePath, GetImageFormat(fileExtension));
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
            textBoxList.Add(inputUsageTips);
            textBoxList.Add(inputDescription);
            
            return FieldUtils.validateEmptyFields(textBoxList);
        }

        private void ApplianceTypeForm_Load(object sender, EventArgs e)
        {
            applianceTypeDGV.RowTemplate.Height = 60;
            
            initializeDataGridView();
            initializeDefaultImage();
            ConfigureDataGridView();
            applianceTypeDGV.Refresh();
        }

        private void initializeDefaultImage()
        {
            Image image = Properties.Resources.default_no_image;
            imageView.Image = image;
            selectedFileName = null;
        }

        private void initializeApplianceTypeImage(string imagePath)
        {
            if (imagePath != "" && imagePath != null)
            {
                try
                {
                    string rootDirectory = @"D:\RentalSystem\ApplianceType";
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

            // Add a new column for the delete button
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Name = "DeleteButton";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            applianceTypeDGV.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            applianceTypeDGV.Columns.Add(deleteButtonColumn);
            applianceTypeDGV.CellContentClick += applianceTypeDGV_CellContentClick; // Add the event handler
            applianceTypeDGV.CellFormatting += ApplianceTypeDGV_CellFormatting;

        }

        private void applianceTypeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == applianceTypeDGV.Columns["DeleteButton"].Index)
            {
                // Handle the delete button click
                int rowIndex = e.RowIndex;
                int applianceId = Convert.ToInt32(applianceTypeDGV.Rows[rowIndex].Cells["ID"].Value);

                // Show a confirmation message box before deleting the row
                DialogResult result = MessageBox.Show("Are you sure you want to delete this appliance?", "Confirm Delete",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Delete the row from the database and refresh the DataGridView
                    applianceTypeService.deleteById(applianceId);
                    initializeDataGridView();
                }
            }

        }

        private void initializeDataGridView()
        {
            DataTable dataTable = applianceTypeService.GET_DATA();
            applianceTypeDGV.DataSource = dataTable;
            applianceTypeDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Set the "imagePath" column's Visible property to false
            applianceTypeDGV.Columns["IMAGEPATH"].Visible = false;
        }

        private void clear()
        {
            inputId.Text = "";
            inputName.Text = "";
            inputUsageTips.Text = "";
            inputDescription.Text = "";
            initializeDefaultImage();
            isUpdate = false;
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void applianceTypeDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = applianceTypeDGV.Rows[e.RowIndex];
            inputId.Text = row.Cells["ID"].Value.ToString();
            inputName.Text = row.Cells["Name"].Value.ToString();
            inputUsageTips.Text = row.Cells["USAGE_TIPS"].Value.ToString();
            inputDescription.Text = row.Cells["DESCRIPTION"].Value.ToString();
            string imagePath = row.Cells["IMAGEPATH"].Value.ToString();
            
            initializeApplianceTypeImage(imagePath);
            
            isUpdate = true;
        }
        private void ApplianceTypeDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == applianceTypeDGV.Columns["DeleteButton"].Index)
            {
                CustomizeDeleteButtonCell(applianceTypeDGV.Rows[e.RowIndex].Cells[e.ColumnIndex]);
            }
        }

        private void CustomizeDeleteButtonCell(DataGridViewCell cell)
        {
            cell.Style.BackColor = Color.Red;
            cell.Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
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

        private int generateNextIdForApplianceType()
        {
            DataTable dataTable = applianceTypeService.findLatestRecord();
            List<ApplianceType> applianceTypes = ApplianceType.extractApplianceTypeFromDataTable(dataTable);
            if(applianceTypes.Count == 0)
            {
                return 1;
            }
            ApplianceType applianceType = applianceTypes.First();
            return applianceType.id + 1;
        }

        private string GetApplianceTypeImagePath(int upcomingId)
        {
            string rootDirectory = @"D:\RentalSystem\ApplianceType\" + upcomingId;
            if (!Directory.Exists(rootDirectory))
            {
                Directory.CreateDirectory(rootDirectory);
            }
            return rootDirectory;
        }

        private string SaveApplianceTypeImage(Image image, int upcomingID, string filePath, ImageFormat format)
        {
            if (File.Exists(filePath))
            {
                // Image file already exists, no need to save again
                return MakeRelativeURI(GetApplianceTypeImagePath(upcomingID), filePath);
            }

            try
            {
                image.Save(filePath, format);
                return MakeRelativeURI(GetApplianceTypeImagePath(upcomingID), filePath);
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
