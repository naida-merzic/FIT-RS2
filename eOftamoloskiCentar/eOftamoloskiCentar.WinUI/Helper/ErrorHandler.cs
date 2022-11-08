using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eOftamoloskiCentar.WinUI.Helper
{
    static class ErrorHandler
    {
        public const string txtfield = "Required field";
        public const string CheckedListBoxfield = "You need to choose at least one item";
        public const string FormatChecker = "Incorrect format";

        public static bool RequiredFiled(Control control, ErrorProvider err, string message = txtfield)
        {
            bool valid = true;

            if (control is TextBox && string.IsNullOrEmpty((control as TextBox).Text))
                valid = false;
            else if (control is ComboBox && (control as ComboBox).SelectedIndex == -1)
                valid = false;
            else if (control is RichTextBox && string.IsNullOrEmpty((control as RichTextBox).Text))
                valid = false;
            else if (control is PictureBox && (control as PictureBox).Image == null)
                valid = false;
            else if (control is CheckedListBox)
                valid = false;
            else if (control is CheckBox)
                valid = false;

            if (!valid)
            {
                err.SetError(control, message);
                return false;
            }

            err.Clear();
            return true;
        }

        public static bool CheckCLB(CheckedListBox control, ErrorProvider err, string message = "Check role!")
        {
            if (control.CheckedItems.Count <=0)
            {
                err.SetError(control, message);
                return false;
            }
            err.Clear();
            return true;
        }
        public static bool checkPass(Control control, Control control1, ErrorProvider err, string message = FormatChecker)
        {
            if (control.Text != control1.Text)
            {
                err.SetError(control, message);
                return false;
            }
            err.Clear();
            return true;
        }

        public static bool CheckFormatOfEmail(Control control, ErrorProvider err, string message = FormatChecker)
        {
            string emailCheck = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if (!Regex.IsMatch(control.Text, emailCheck))
            {
                err.SetError(control, message);
                return false;
            }
            err.Clear();
            return true;
        }
        
        public static bool PhoneCheck(Control control, ErrorProvider err, string message = FormatChecker)
        {
            string phoneCheck = "^(?:[+0]9)?[0-9]{9,10}$";
            if (!Regex.IsMatch(control.Text, phoneCheck))
            {
                err.SetError(control, message);
                return false;
            }
            err.Clear();
            return true;
        }

        
    }
}
