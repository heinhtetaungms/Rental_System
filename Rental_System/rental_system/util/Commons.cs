using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace Rental_System.rental_system.util
{
    class Commons
    {
        
        public static bool isHidden(string targetForm)
        {
            Form formToClose = Application.OpenForms[targetForm];
            if (formToClose != null && !formToClose.IsDisposed && formToClose.Visible)
            {
                return true;
            }
            return false;
        }
        public static List<T> GetPreviousOpenForms<T>(Form form) where T : Form
        {
            List<T> previousForms = Application.OpenForms
                .OfType<T>()
                .Where(f => f != form)
                .ToList();

            return previousForms;
        }

        private static List<T> GetPreviousOpenForms<T>() where T : Form
        {
            List<T> previousForms = Application.OpenForms
                .OfType<T>()
                .ToList();

            return previousForms;
        }

        public static void HidePreviousOpenForms<T>() where T : Form
        {
            List<T> previousForm = GetPreviousOpenForms<T>();
            foreach (T form in previousForm)
            {
                form.Hide();
            }
        }
 
        public static int toInt(bool isActive)
        {
            return Convert.ToInt32(isActive);
        }

    }
}
