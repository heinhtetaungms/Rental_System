using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Rental_System.rental_system.util
{
    class PasswordUtils
    {
        public static Boolean validatePassword(string password)
        {
            string strRegex = "^(?=.*[a-z])(?=.*[A-Z]).{8,16}$";
            Regex re = new Regex(strRegex);

            Boolean isMatch = re.IsMatch(password);
            if (!isMatch)
            {   
                MessageBoxUtils.error("Password length: 8 - 16. At least one lowercase and one uppercase letter", "Invalid Password");
            }

            return isMatch;
        }
        public static Boolean validatePasswordAndConfirmPassword(string password, string confirmPassword)
        {
            if(!password.Equals(confirmPassword))
            {
                MessageBoxUtils.error("Please Confirm Your Password.", "Require Text Field");
                return false;
            }
                return validatePassword(password);
        }
    }
}