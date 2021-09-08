﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace PE___sqrt
{
    using locale = Localization.Localization;

    public partial class ProgramWindow : Form
    {
        private CultureInfo activeCulture;
        private string activeLanguage;
        private int activeLanguageItem;
        private int precision;
        private int historyLength;

        private ToolStripMenuItem[] languageItems;

        public ProgramWindow()
        {
            activeCulture = CultureInfo.CurrentCulture;
            activeLanguage = activeCulture.TwoLetterISOLanguageName;
            precision = 5;
            historyLength = 0;

            Task<bool> loadTask = Task.Run( () => locale.Load() );
            loadTask.GetAwaiter().OnCompleted(OnLocaleLoaded);

            InitializeComponent();

            AcceptButton = buttonCalculate;

            SetUIActive(false);
        }

        public void OnLocaleLoaded()
        {
            if(locale.Languages.Count == 0 || !locale.Languages.ContainsKey("en"))
            {
                locale.Languages.Add("en", new locale.LanguageEntry("English", new Dictionary<string, string>
                {
                    { "Languages", "Languages" },
                    { "Support", "Support" },
                    { "Settings", "Settings" },
                    { "Precision", "Precision" },
                    { "Error", "Error" },
                    { "ErrorInputEmpty", "Error: Input field is empty" },
                    { "ErrorInputInvalid", "Error: {0} is not a valid number" },
                    { "PrecisionBoxCaption", "Precision" },
                    { "PrecisionBoxText", "Input precision (number of digits in the fractional part):" },
                    { "InputBoxButtonOk", "OK" },
                    { "InputBoxButtonCancel", "Cancel" },
                    { "PrecisionParseFailed", "Input a non-negative whole number!" },
                    { "Done", "Done" },
                    { "Calculating", "Calculating..." }
                }));
            }

            languageItems = new ToolStripMenuItem[locale.Languages.Count];
            int i = 0;

            foreach(KeyValuePair<string, locale.LanguageEntry> kvp in locale.Languages)
            {
                languageItems[i] = new ToolStripMenuItem(kvp.Value.LanguageName)
                {
                    Name = kvp.Value.LanguageName,
                    AutoSize = true
                };
                languageItems[i].Click += new EventHandler(SetActiveLanguage);

                languagesMenuItem.DropDownItems.Add(languageItems[i]);

                if(kvp.Key.Equals(activeLanguage))
                {
                    languageItems[i].Checked = true;
                    activeLanguageItem = i;
                }

                i++;
            }

            SetUIActive(true);
            ReloadLocalizedItems();
        }

        void ReloadLocalizedItems()
        {
            languagesMenuItem.Text = locale.Languages[activeLanguage].GetPhrase("Languages");
            supportMenuItem.Text = locale.Languages[activeLanguage].GetPhrase("Support");
            settingsMenuItem.Text = locale.Languages[activeLanguage].GetPhrase("Settings");
            precisionMenuItem.Text = locale.Languages[activeLanguage].GetPhrase("Precision");
            buttonPoint.Text = activeCulture.NumberFormat.NumberDecimalSeparator;
        }

        void SetActiveLanguage(object sender, EventArgs e)
        {
            languageItems[activeLanguageItem].Checked = false;

            for(int i = 0; i < languageItems.Length; i++)
                if(languageItems[i] == sender)
                {
                    languageItems[i].Checked = true;
                    activeLanguageItem = i;
                    activeLanguage = locale.Languages.First(x => { return x.Value.LanguageName.Equals(languageItems[i].Name); }).Key;
                    activeCulture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.Equals(activeLanguage) ? CultureInfo.CurrentCulture : CultureInfo.GetCultureInfo(activeLanguage);
                    break;
                }

            ReloadLocalizedItems();
        }

        void SetUIActive(bool active = true)
        {
            ProgramMenu.Visible = active;
            inputField.Visible = active;
            errorField.Visible = active;
            historyBox.Visible = active;
            button0.Visible = active;
            button1.Visible = active;
            button2.Visible = active;
            button3.Visible = active;
            button4.Visible = active;
            button5.Visible = active;
            button6.Visible = active;
            button7.Visible = active;
            button8.Visible = active;
            button9.Visible = active;
            buttonErase.Visible = active;
            buttonEraseAll.Visible = active;
            buttonCalculate.Visible = active;
            buttonPoint.Visible = active;
            buttonMinus.Visible = active;
        }

        void SetInputActive(bool active = true)
        {
            inputField.ReadOnly = !active;
            button0.Enabled = active;
            button1.Enabled = active;
            button2.Enabled = active;
            button3.Enabled = active;
            button4.Enabled = active;
            button5.Enabled = active;
            button6.Enabled = active;
            button7.Enabled = active;
            button8.Enabled = active;
            button9.Enabled = active;
            buttonMinus.Enabled = active;
            buttonPoint.Enabled = active;
            buttonErase.Enabled = active;
            buttonEraseAll.Enabled = active;
            buttonCalculate.Enabled = active;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputField.Text += '1';
            inputField.SelectionStart = inputField.Text.Length;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inputField.Text += '2';
            inputField.SelectionStart = inputField.Text.Length;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inputField.Text += '3';
            inputField.SelectionStart = inputField.Text.Length;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inputField.Text += '4';
            inputField.SelectionStart = inputField.Text.Length;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            inputField.Text += '5';
            inputField.SelectionStart = inputField.Text.Length;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            inputField.Text += '6';
            inputField.SelectionStart = inputField.Text.Length;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            inputField.Text += '7';
            inputField.SelectionStart = inputField.Text.Length;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            inputField.Text += '8';
            inputField.SelectionStart = inputField.Text.Length;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            inputField.Text += '9';
            inputField.SelectionStart = inputField.Text.Length;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            inputField.Text += '0';
            inputField.SelectionStart = inputField.Text.Length;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            inputField.Text += '+';
            inputField.SelectionStart = inputField.Text.Length;
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            inputField.Text += '-';
            inputField.SelectionStart = inputField.Text.Length;
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if(inputField.Text.IndexOf(activeCulture.NumberFormat.NumberDecimalSeparator) == -1)
            {
                inputField.Text += activeCulture.NumberFormat.NumberDecimalSeparator;
                inputField.SelectionStart = inputField.Text.Length;
            }
        }

        private void buttonImaginaryUnit_Click(object sender, EventArgs e)
        {
            if(inputField.Text.IndexOf('i') == -1)
            {
                inputField.Text += 'i';
                inputField.SelectionStart = inputField.Text.Length;
            }
        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
            if(inputField.Text.Length > 0)
                inputField.Text = inputField.Text.Remove(inputField.Text.Length-1, 1);

            inputField.SelectionStart = inputField.Text.Length;
        }

        private void buttonEraseAll_Click(object sender, EventArgs e)
        {
            inputField.Text = "";
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if(inputField.Text.Length == 0) errorField.Text = locale.Languages[activeLanguage].GetPhrase("ErrorInputEmpty");
            else if(BigNumbers.BigRational.TryParse(inputField.Text, out BigNumbers.BigRational rationalValue, activeCulture.NumberFormat))
            {
                SetInputActive(false);
                errorField.Text = locale.Languages[activeLanguage].GetPhrase("Calculating");
                
                if(rationalValue >= BigNumbers.BigRational.Zero)
                {
                    Task<BigNumbers.BigRational> calcTask = new Task<BigNumbers.BigRational>( () => { return BigNumbers.BigRational.Sqrt(rationalValue, precision); } );
                    calcTask.GetAwaiter().OnCompleted( () => OnRationalResultCalculated(rationalValue, calcTask.Result) );
                    calcTask.Start();
                }
                else
                {
                    Task<BigNumbers.BigRational> calcTask = new Task<BigNumbers.BigRational>( () => { return BigNumbers.BigRational.Sqrt(BigNumbers.BigRational.Abs(rationalValue), precision); } );
                    calcTask.GetAwaiter().OnCompleted( () => OnRationalResultCalculated(rationalValue, calcTask.Result) );
                    calcTask.Start();
                }
                
            }
            else if(BigNumbers.BigComplex.TryParse(inputField.Text, out BigNumbers.BigComplex complexValue, activeCulture.NumberFormat))
            {
                SetInputActive(false);
                errorField.Text = locale.Languages[activeLanguage].GetPhrase("Calculating");

                Task<BigNumbers.BigComplex> calcTask = new Task<BigNumbers.BigComplex>( () => { return BigNumbers.BigComplex.Sqrt(complexValue, precision); } );
                calcTask.GetAwaiter().OnCompleted( () => OnComplexResultCalculated(complexValue, calcTask.Result) );
                calcTask.Start();
            }
            else errorField.Text = string.Format(locale.Languages[activeLanguage].GetPhrase("ErrorInputInvalid"), inputField.Text);
        }

        void AppendHistoryLine(string line)
        {
            if(historyLength == 0)  
            {
                ++historyLength;
                historyBox.Text = line;
            }
            else if(historyLength < 25)
            {
                ++historyLength;
                historyBox.Text += "\r\n" + line;
            }
            else
            {
                historyBox.Text = historyBox.Text.Substring(historyBox.Text.IndexOf("\r\n")+2) + "\r\n" + line;
            }
            historyBox.SelectionStart = historyBox.Text.Length;
        }

        void OnRationalResultCalculated(BigNumbers.BigRational source, BigNumbers.BigRational value)
        {
            errorField.Text = locale.Languages[activeLanguage].GetPhrase("Done");
            if(source.Negative) inputField.Text = value.ToString(precision, activeCulture.NumberFormat) + 'i';
            else inputField.Text = value.ToString(precision, activeCulture.NumberFormat);
            AppendHistoryLine("sqrt(" + source.ToString(precision, activeCulture.NumberFormat) + ") = " + inputField.Text);
            SetInputActive(true);
        }

        void OnComplexResultCalculated(BigNumbers.BigComplex source, BigNumbers.BigComplex value)
        {
            errorField.Text = locale.Languages[activeLanguage].GetPhrase("Done");
            inputField.Text = value.ToString(precision, activeCulture.NumberFormat);
            AppendHistoryLine("sqrt(" + source.ToString(precision, activeCulture.NumberFormat) + ") = " + inputField.Text);
            SetInputActive(true);
        }

        private void precisionMenuItem_Click(object sender, EventArgs e)
        {
            InputMessageBox precisionInput = new InputMessageBox(locale.Languages[activeLanguage].GetPhrase("PrecisionBoxCaption"),
                                                                 locale.Languages[activeLanguage].GetPhrase("PrecisionBoxText"),
                                                                 locale.Languages[activeLanguage].GetPhrase("InputBoxButtonOk"),
                                                                 locale.Languages[activeLanguage].GetPhrase("InputBoxButtonCancel"));

            if(precisionInput.ShowDialog() == DialogResult.OK)
            {
                int prec;
                while( !int.TryParse(precisionInput.inputBox.Text, out prec) || prec < 0 )
                {
                    MessageBox.Show(this, locale.Languages[activeLanguage].GetPhrase("PrecisionParseFailed"),
                                          locale.Languages[activeLanguage].GetPhrase("Error"),
                                          MessageBoxButtons.OK);

                    if(precisionInput.ShowDialog(this) != DialogResult.OK) return;
                }

                precision = prec;
            }

            precisionInput.Dispose();
        }

        private void supportMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bestsupport915430225.wordpress.com/");
        }
    }
}
