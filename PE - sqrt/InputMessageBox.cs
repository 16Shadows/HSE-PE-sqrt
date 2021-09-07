using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE___sqrt
{
    public partial class InputMessageBox : Form
    {
        public InputMessageBox(string caption, string text, string buttonOKText = "OK", string buttonCancelText = "Cancel")
        {
            InitializeComponent();
            Text = caption;
            labelText.Text = text;
            buttonOK.Text = buttonOKText;
            buttonCancel.Text = buttonCancelText;

            UpdateBounds();

            inputBox.Size = new Size(Size.Width - 26, inputBox.Size.Height);

            AcceptButton = buttonOK;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }
    }
}
