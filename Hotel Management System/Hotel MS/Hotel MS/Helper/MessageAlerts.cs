using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_MS.Helper
{
    public class MessageAlerts
    {
        public void SuccessMessage()
        {
            MessageBox.Show("Action successfully performed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void ErrorMessage()
        {
            MessageBox.Show("An error occured!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void UserDefinedSuccessMessage(string msg)
        {
            MessageBox.Show(msg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void UserDefinedErrorMessage(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public DialogResult QuestionMessage(string msg)
        {
            return MessageBox.Show(msg, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
