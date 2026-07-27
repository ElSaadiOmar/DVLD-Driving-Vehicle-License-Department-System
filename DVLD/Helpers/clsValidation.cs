using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD.Helpers
{
    internal class clsValidation
    {
        static public bool ValidateEmail(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
                return false;
            try
            {
                MailAddress Address = new MailAddress(Email);
                return      Address.Address == Email;
            }
            catch 
            {
                return false;
            }
        }
    }
}
