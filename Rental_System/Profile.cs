using Rental_System.rental_system;
using Rental_System.rental_system.model;
using Rental_System.rental_system.service;
using Rental_System.rental_system.session;
using Rental_System.rental_system.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Rental_System
{
    public partial class Profile : Form
    {
        Session currentSession = SessionManager.Instance.CurrentSession;
        private CustomerService customerService;
        public Profile()
        {
            InitializeComponent();
            customerService = new CustomerService();
        }
        private string savedFilePath;
        private string fileExtension;

        private void Profile_Load(object sender, EventArgs e)
        {
            
            if(currentSession == null || currentSession.imagePath == null)
            {
                Image image = Properties.Resources.default_profile;
                profileImage.Image = image;
            }
            else
            {
                try
                {
                    string rootDirectory = @"D:\RentalSystem\ProfileImages";
                    string imageRelativePath = currentSession.imagePath.TrimStart('\\');
                    string combinedPath = Path.Combine(rootDirectory, imageRelativePath);
                    profileImage.Image = Image.FromFile(combinedPath);
                }catch(FileNotFoundException)
                {
                    Image image = Properties.Resources.default_profile;
                    profileImage.Image = image;
                }
            }
            initialize();
        }

        private void initialize()
        {
            inputFirstName.Text = currentSession.firstName;
            inputLastName.Text = currentSession.lastName;
            inputUserName.Text = currentSession.username;
            inputDateOfBirth.Value = currentSession.dateOfBirth;
            inputEmail.Text = currentSession.email;
            inputPhoneNumber.Text = currentSession.phoneNumber;
            inputPassword.Text = currentSession.password;
            inputAddress.Text = currentSession.address;
        }

        private string GetProfileImagePath(int userId)
        {
            string rootDirectory = @"D:\RentalSystem\ProfileImages\" + userId ;
            if (!Directory.Exists(rootDirectory))
            {
                Directory.CreateDirectory(rootDirectory);
            }
            return rootDirectory;
        }

        private string SaveProfileImage(Image image, string filePath, ImageFormat format)
        {
            try
            {     
                image.Save(filePath, format);
               
                string relativePath = GetRelativePath(GetProfileImagePath(currentSession.id), filePath);
                return relativePath;     
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving image: {ex.Message}");
            }
            return null;
        }      
        private string GetRelativePath(string basePath, string filePath)
        {
            Uri baseUri = new Uri(basePath);
            Uri fileUri = new Uri(filePath);
            return baseUri.MakeRelativeUri(fileUri).ToString();
        }
        private void profileImage_Click(object sender, EventArgs e)
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
                        profileImage.Image = Image.FromFile(selectedFilePath);

                        //Save the selected image into the user's profile
                        string profileImagePath = GetProfileImagePath(currentSession.id);    //Get the path to save the image
                        string savedFilePath = Path.Combine(profileImagePath, selectedFileName);
                        this.savedFilePath = savedFilePath;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool isValid = validateFields();
            if(isValid)
            {
                if (savedFilePath == null)
                {
                    Customer customer = new Customer(currentSession.id, inputFirstName.Text, inputLastName.Text, inputUserName.Text, inputPassword.Text,
                        inputEmail.Text, inputPhoneNumber.Text, inputDateOfBirth.Value, currentSession.gender, inputAddress.Text, currentSession.isActive, currentSession.role);
                    customerService.update(customer);
                }
                else
                {
                    string relativePath = SaveProfileImage(profileImage.Image, savedFilePath, GetImageFormat(fileExtension));
                    Customer customer = new Customer(currentSession.id, inputFirstName.Text, inputLastName.Text, inputUserName.Text, inputPassword.Text,
                        inputEmail.Text, inputPhoneNumber.Text, inputDateOfBirth.Value, currentSession.gender, inputAddress.Text, currentSession.isActive, currentSession.role, relativePath);
                    customerService.updateCustomerProfileImage(customer);
                }
                Commons.HidePreviousOpenForms<Profile>();
            }
        }

        private bool validateFields()
        {
            return validateEmptyFields() && PasswordUtils.validatePassword(inputPassword.Text);
        }
        private bool validateEmptyFields()
        {
            List<TextBox> textBoxList = new List<TextBox>();
            textBoxList.Add(inputFirstName);
            textBoxList.Add(inputLastName);
            textBoxList.Add(inputUserName);
            textBoxList.Add(inputEmail);
            textBoxList.Add(inputPhoneNumber);
            textBoxList.Add(inputPassword);
            textBoxList.Add(inputAddress);

            return FieldUtils.validateEmptyFields(textBoxList);
        }
    }
}
