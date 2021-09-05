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

    public partial class ProgramWindow : Form
    {
        private string activeLanguage;
        private int activeLanguageItem;

        private ToolStripMenuItem[] languageItems;

        public ProgramWindow()
        {
            activeLanguage = "en";

            Task<bool> loadTask = Task.Run( () => locale.Load() );
            loadTask.GetAwaiter().OnCompleted(OnLocaleLoaded);

            InitializeComponent();

            HideUI();
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
                    { "Precision", "Precision" }
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

            ShowUI();
        }

        void ReloadLocalizedItems()
        {
            languagesMenuItem.Text = locale.Languages[activeLanguage].GetPhrase("Languages");
            supportMenuItem.Text = locale.Languages[activeLanguage].GetPhrase("Support");
            settingsMenuItem.Text = locale.Languages[activeLanguage].GetPhrase("Settings");
            precisionMenuItem.Text = locale.Languages[activeLanguage].GetPhrase("Precision");
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
                    break;
                }

            ReloadLocalizedItems();
        }

        void HideUI()
        {

        }

        void ShowUI()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputField.Text += '1';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inputField.Text += '2';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inputField.Text += '3';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inputField.Text += '4';
        }

        private void button5_Click(object sender, EventArgs e)
        {
            inputField.Text += '5';
        }

        private void button6_Click(object sender, EventArgs e)
        {
            inputField.Text += '6';
        }

        private void button7_Click(object sender, EventArgs e)
        {
            inputField.Text += '7';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            inputField.Text += '8';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            inputField.Text += '9';
        }

        private void button0_Click(object sender, EventArgs e)
        {
            inputField.Text += '0';
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            inputField.Text += '-';
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            inputField.Text += '.';
        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
            if(inputField.Text.Length > 0)
                inputField.Text = inputField.Text.Remove(inputField.Text.Length-1, 1);
        }

        private void buttonEraseAll_Click(object sender, EventArgs e)
        {
            inputField.Text = "";
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            errorField.Text = "Trying to parse " + inputField.Text;
            if(BigNumbers.BigRational.TryParse(inputField.Text, out BigNumbers.BigRational value))
            {
                //inputField.Text = value.SqrtFast().ToString("F99");
                inputField.Text = value.Sqrt().ToString(10);
                //inputField.Text = value.SqrtNewton(3).ToString(10);
            }
        }

        private void ProgramWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
