using Rental_System.rental_system.util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Rental_System.rental_system
{
    class FieldUtils
    {
        public static Boolean validateEmptyFields(List<TextBox> textBoxes)
        {

            foreach(TextBox box in textBoxes){
                if (box.Text == "")
                {
                    MessageBoxUtils.error(box.Name + " cannot be empty.", "Require Text Field");
                    return false;
                }
            }

            return true;
        }
      
        public static Boolean validateEmptyComboBox(List<ComboBox> comboBoxes)
        {

            foreach (ComboBox box in comboBoxes)
            {
                if (box.Text == "")
                {
                    MessageBoxUtils.error(box.Name + " cannot be empty.", "Require Text Field");
                    return false;
                }
            }

            return true;
        }
        public static Boolean validateEmptyCheckBox(List<CheckBox> checkBoxes)
        {

            foreach (CheckBox box in checkBoxes)
            {
                if (box.CheckState == CheckState.Unchecked)
                {
                    MessageBoxUtils.error(box.Name + " must be selected.", "Require Text Field");
                    return false;
                }
            }

            return true;
        }
    }
}
