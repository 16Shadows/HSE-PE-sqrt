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
    using locale = Localization.Localization;

    public partial class Background : Form
    {
        public Background()
        {
            InitializeComponent();
            InputText.Text = locale.Languages["en"].GetPhrase("InputNumber");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            inputBox.Text += '0';
        }
        private void button1_Click(object sender, EventArgs e)
        {
            inputBox.Text += '1';
        }
        private void button2_Click(object sender, EventArgs e)
        {
            inputBox.Text += '2';
        }
        private void button3_Click(object sender, EventArgs e)
        {
            inputBox.Text += '3';
        }
        private void button4_Click(object sender, EventArgs e)
        {
            inputBox.Text += '4';
        }
        private void button5_Click(object sender, EventArgs e)
        {
            inputBox.Text += '5';
        }
        private void button6_Click(object sender, EventArgs e)
        {
            inputBox.Text += '6';
        }
        private void button7_Click(object sender, EventArgs e)
        {
            inputBox.Text += '7';
        }
        private void button8_Click(object sender, EventArgs e)
        {
            inputBox.Text += '8';
        }
        private void button9_Click(object sender, EventArgs e)
        {
            inputBox.Text += '9';
        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
            if(inputBox.Text.Length > 0) inputBox.Text = inputBox.Text.Remove(inputBox.Text.Length-1);
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (inputBox.Text.Length == 0)
            {
                labelResult.Text = locale.Languages["en"].GetPhrase("ErrorEmpty");
                textBoxResult.Text = locale.Languages["en"].GetPhrase("Error");
            }
            else if (double.TryParse(inputBox.Text, out double value))
            {
                labelResult.Text = locale.Languages["en"].GetPhrase("Result");

                if(value >= 0) textBoxResult.Text = Math.Sqrt(value).ToString();
                else textBoxResult.Text = Math.Sqrt(Math.Abs(value)).ToString() + 'i';
            }
            else
            {
                labelResult.Text = locale.Languages["en"].GetPhrase("ErrorInvalidInput");
                textBoxResult.Text = locale.Languages["en"].GetPhrase("Error");
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            inputBox.Text += '-';
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            inputBox.Text += '.';
        }
    }
}
