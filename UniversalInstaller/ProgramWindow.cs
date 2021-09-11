using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using IWshRuntimeLibrary;

namespace UniversalInstaller
{
    using locale = Localization.Localization;

    public partial class ProgramWindow : Form
    {
        CultureInfo activeCulture;
        string activeLanguage;
        private int activeLanguageItem;
        private readonly HashSet<char> invalidPathCharacters;

        enum State
        {
            STANDBY,
            INSTALLING,
            INSTALLED
        }

        State state = State.STANDBY;
        Task installationTask = null;

        private ToolStripMenuItem[] languageItems;

        public ProgramWindow()
        {
            locale.Languages.Add("en", new locale.LanguageEntry("English", new Dictionary<string, string>
            {
                { "Languages", "Languages" },
                { "Support", "Support" },
                { "InstallerName", "Installation Wizard" },
                { "SelectInstallDir", "Select installation directory:" },
                { "Select", "Select" },
                { "CreateDesktopShortcut", "Create desktop shortcut" },
                { "CreateStartMenuShortcut", "Create start menu shortcut" },
                { "Install", "Install" },
                { "Cancel", "Cancel" },
                { "Close", "Close" },
                { "AbortInstallation", "Are you sure you want to abort installation?" },
                { "PathInvalidChars", "The path you have entered contains invalid symbols." },
                { "InstallationError", "A error has occured during the installation process:" }
            }));

            locale.Languages.Add("ru", new locale.LanguageEntry("Русский", new Dictionary<string, string>
            {
                { "Languages", "Языки" },
                { "Support", "Поддержка" },
                { "InstallerName", "Мастер Установки" },
                { "SelectInstallDir", "Выберите папку для установки:" },
                { "Select", "Выбрать" },
                { "CreateDesktopShortcut", "Создать ярлык на рабочем столе" },
                { "CreateStartMenuShortcut", "Создать ярлык в меню \"Пуск\"" },
                { "Install", "Установить" },
                { "Cancel", "Отмена" },
                { "Close", "Закрыть" },
                { "AbortInstallation", "Вы уверены, что хотите прервать установку?" },
                { "PathInvalidChars", "Путь, который Вы указали, содержит некорректные символы." },
                { "InstallationError", "Произошла ошибка во время установки:" }
            }));

            activeCulture = CultureInfo.CurrentCulture;
            activeLanguage = activeCulture.TwoLetterISOLanguageName;

            if(!locale.Languages.ContainsKey(activeCulture.TwoLetterISOLanguageName))
            {
                activeLanguage = "en";
                activeCulture = CultureInfo.GetCultureInfo(activeLanguage);
            }

            InitializeComponent();

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

            ReloadLocalizedItems();

            invalidPathCharacters = new HashSet<char>(System.IO.Path.GetInvalidPathChars());
            labelProgress.BackColor = System.Drawing.Color.Transparent;
            fieldSelectDirectory.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\" + InstallationRoutine.FolderName;
        }

        void ReloadLocalizedItems()
        {
            Text = locale.Languages[activeLanguage].GetPhrase("InstallerName");
            languagesMenuItem.Text = locale.Languages[activeLanguage].GetPhrase("Languages");
            supportMenuItem.Text = locale.Languages[activeLanguage].GetPhrase("Support");
            labelSelectDirectory.Text = locale.Languages[activeLanguage].GetPhrase("SelectInstallDir");
            buttonSelectDirectory.Text = locale.Languages[activeLanguage].GetPhrase("Select");
            buttonCancel.Text = locale.Languages[activeLanguage].GetPhrase("Cancel");
            buttonInstall.Text = locale.Languages[activeLanguage].GetPhrase(state==State.INSTALLED?"Close":"Install");
            checkBoxDesktopShortcut.Text = locale.Languages[activeLanguage].GetPhrase("CreateDesktopShortcut");
            checkBoxStartMenuShortcut.Text = locale.Languages[activeLanguage].GetPhrase("CreateStartMenuShortcut");
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

        private void supportMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bestsupport915430225.wordpress.com/");
        }

        private void buttonSelectDirectory_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog.ShowDialog(this) == DialogResult.OK) fieldSelectDirectory.Text = folderBrowserDialog.SelectedPath;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if(state == State.STANDBY) Environment.Exit(0);
            else if(state == State.INSTALLING && installationTask != null && InstallationRoutine.isRunning && MessageBox.Show(this, locale.Languages[activeLanguage].GetPhrase("AbortInstallation"), locale.Languages[activeLanguage].GetPhrase("InstallerName"), MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                InstallationRoutine.isRunning = false;
                installationTask.Wait();
                InstallationRoutine.UndoFiles();
                InstallationRoutine.UndoDirectories();
                installationTask = null;
                Environment.Exit(0);
            }
        }

        private void ProgramWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(state == State.INSTALLING && installationTask != null && InstallationRoutine.isRunning)
            {
                if(MessageBox.Show(this, locale.Languages[activeLanguage].GetPhrase("AbortInstallation"), locale.Languages[activeLanguage].GetPhrase("InstallerName"), MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    InstallationRoutine.isRunning = false;
                    installationTask.Wait();
                    InstallationRoutine.UndoFiles();
                    InstallationRoutine.UndoDirectories();
                    Environment.Exit(0);
                }
                else e.Cancel = true;
            }
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            if(state == State.INSTALLED) Environment.Exit(0);
            else if(state == State.STANDBY)
            {
                if( fieldSelectDirectory.Text.Any( x => invalidPathCharacters.Contains(x) ) ) MessageBox.Show(this, locale.Languages[activeLanguage].GetPhrase("PathInvalidChars"), locale.Languages[activeLanguage].GetPhrase("InstallerName"), MessageBoxButtons.OK);
                else
                {
                    buttonInstall.Enabled = false;
                    checkBoxDesktopShortcut.Enabled = false;
                    checkBoxStartMenuShortcut.Enabled = false;
                    buttonSelectDirectory.Enabled = false;
                    fieldSelectDirectory.Enabled = false;

                    state = State.INSTALLING;

                    try
                    {
                        installationTask = new Task( () => {
                            try
                            {
                                OnInstallationComplete(InstallationRoutine.Run(fieldSelectDirectory.Text, true, labelProgress, progressBar), null);
                            }
                            catch(Exception ex)
                            {
                                OnInstallationComplete(false, ex);
                            }
                        });
                        installationTask.Start();
                    }
                    catch(Exception ex)
                    {
                        OnInstallationComplete(false, ex);
                    }
                }
            }
        }

        void OnInstallationComplete(bool result, Exception e = null)
        {
            if(result)
            {
                state = State.INSTALLED;
                buttonInstall.Text = locale.Languages[activeLanguage].GetPhrase("Close");
                buttonInstall.Enabled = true;
                buttonCancel.Enabled = false;

                if(fieldSelectDirectory.Text.IndexOf('\\') == fieldSelectDirectory.Text.Length - 1 || fieldSelectDirectory.Text.IndexOf('/') == fieldSelectDirectory.Text.Length - 1)
                    fieldSelectDirectory.Text = fieldSelectDirectory.Text.Remove(fieldSelectDirectory.Text.Length - 1);

                if(checkBoxDesktopShortcut.Checked) CreateShortcut("Desktop", fieldSelectDirectory.Text + "\\" + InstallationRoutine.shortcutExe);
                if(checkBoxStartMenuShortcut.Checked) CreateShortcut("StartMenu", fieldSelectDirectory.Text + "\\" + InstallationRoutine.shortcutExe);

            }
            else
            {
                MessageBox.Show(this, locale.Languages[activeLanguage].GetPhrase("InstallationError") + "\n" + e.Message, locale.Languages[activeLanguage].GetPhrase("InstallerName"), MessageBoxButtons.OK);
                buttonInstall.Enabled = true;
                checkBoxDesktopShortcut.Enabled = true;
                checkBoxStartMenuShortcut.Enabled = true;
                buttonSelectDirectory.Enabled = true;
                fieldSelectDirectory.Enabled = true;

                state = State.STANDBY;
            }
        }
 
        private static void CreateShortcut(string location, string obj)
        {
            object loc = location;
            WshShell shell = new WshShell();
            string address = (string)shell.SpecialFolders.Item(ref loc) + "\\" + System.IO.Path.GetFileNameWithoutExtension(obj) + ".lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(address);
            shortcut.Description = InstallationRoutine.shortcutExe;
            shortcut.TargetPath = obj;
            shortcut.WorkingDirectory = System.IO.Path.GetDirectoryName(obj);
            shortcut.Save();
        }
    }
}
