
namespace UniversalInstaller
{
    partial class ProgramWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSelectDirectory = new System.Windows.Forms.Label();
            this.ProgramMenu = new System.Windows.Forms.MenuStrip();
            this.languagesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldSelectDirectory = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonSelectDirectory = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.checkBoxDesktopShortcut = new System.Windows.Forms.CheckBox();
            this.checkBoxStartMenuShortcut = new System.Windows.Forms.CheckBox();
            this.ProgramMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSelectDirectory
            // 
            this.labelSelectDirectory.AutoSize = true;
            this.labelSelectDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSelectDirectory.Location = new System.Drawing.Point(12, 35);
            this.labelSelectDirectory.Name = "labelSelectDirectory";
            this.labelSelectDirectory.Size = new System.Drawing.Size(201, 20);
            this.labelSelectDirectory.TabIndex = 0;
            this.labelSelectDirectory.Text = "Select installation directory:";
            // 
            // ProgramMenu
            // 
            this.ProgramMenu.AllowMerge = false;
            this.ProgramMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(196)))), ((int)(((byte)(238)))));
            this.ProgramMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languagesMenuItem,
            this.supportMenuItem});
            this.ProgramMenu.Location = new System.Drawing.Point(0, 0);
            this.ProgramMenu.Name = "ProgramMenu";
            this.ProgramMenu.Size = new System.Drawing.Size(506, 24);
            this.ProgramMenu.TabIndex = 1;
            this.ProgramMenu.Text = "ProgramMenu";
            // 
            // languagesMenuItem
            // 
            this.languagesMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.languagesMenuItem.Name = "languagesMenuItem";
            this.languagesMenuItem.Size = new System.Drawing.Size(71, 20);
            this.languagesMenuItem.Text = "Language";
            // 
            // supportMenuItem
            // 
            this.supportMenuItem.Name = "supportMenuItem";
            this.supportMenuItem.Size = new System.Drawing.Size(61, 20);
            this.supportMenuItem.Text = "Support";
            this.supportMenuItem.Click += new System.EventHandler(this.supportMenuItem_Click);
            // 
            // fieldSelectDirectory
            // 
            this.fieldSelectDirectory.Location = new System.Drawing.Point(16, 58);
            this.fieldSelectDirectory.Name = "fieldSelectDirectory";
            this.fieldSelectDirectory.Size = new System.Drawing.Size(373, 20);
            this.fieldSelectDirectory.TabIndex = 2;
            // 
            // buttonSelectDirectory
            // 
            this.buttonSelectDirectory.Location = new System.Drawing.Point(395, 56);
            this.buttonSelectDirectory.Name = "buttonSelectDirectory";
            this.buttonSelectDirectory.Size = new System.Drawing.Size(99, 23);
            this.buttonSelectDirectory.TabIndex = 3;
            this.buttonSelectDirectory.Text = "Select";
            this.buttonSelectDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectDirectory.Click += new System.EventHandler(this.buttonSelectDirectory_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(395, 167);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(99, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonInstall
            // 
            this.buttonInstall.Location = new System.Drawing.Point(290, 167);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(99, 23);
            this.buttonInstall.TabIndex = 5;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 138);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(428, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 6;
            // 
            // labelProgress
            // 
            this.labelProgress.BackColor = System.Drawing.Color.Transparent;
            this.labelProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelProgress.Location = new System.Drawing.Point(450, 141);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(44, 17);
            this.labelProgress.TabIndex = 7;
            this.labelProgress.Text = "0%";
            this.labelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxDesktopShortcut
            // 
            this.checkBoxDesktopShortcut.AutoSize = true;
            this.checkBoxDesktopShortcut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxDesktopShortcut.Location = new System.Drawing.Point(26, 84);
            this.checkBoxDesktopShortcut.Name = "checkBoxDesktopShortcut";
            this.checkBoxDesktopShortcut.Size = new System.Drawing.Size(178, 21);
            this.checkBoxDesktopShortcut.TabIndex = 8;
            this.checkBoxDesktopShortcut.Text = "Create desktop shortcut";
            this.checkBoxDesktopShortcut.UseVisualStyleBackColor = true;
            // 
            // checkBoxStartMenuShortcut
            // 
            this.checkBoxStartMenuShortcut.AutoSize = true;
            this.checkBoxStartMenuShortcut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxStartMenuShortcut.Location = new System.Drawing.Point(26, 111);
            this.checkBoxStartMenuShortcut.Name = "checkBoxStartMenuShortcut";
            this.checkBoxStartMenuShortcut.Size = new System.Drawing.Size(195, 21);
            this.checkBoxStartMenuShortcut.TabIndex = 9;
            this.checkBoxStartMenuShortcut.Text = "Create start menu shortcut";
            this.checkBoxStartMenuShortcut.UseVisualStyleBackColor = true;
            // 
            // ProgramWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(196)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(506, 198);
            this.Controls.Add(this.checkBoxStartMenuShortcut);
            this.Controls.Add(this.checkBoxDesktopShortcut);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSelectDirectory);
            this.Controls.Add(this.fieldSelectDirectory);
            this.Controls.Add(this.ProgramMenu);
            this.Controls.Add(this.labelSelectDirectory);
            this.MainMenuStrip = this.ProgramMenu;
            this.Name = "ProgramWindow";
            this.ShowIcon = false;
            this.Text = "ProgramWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgramWindow_FormClosing);
            this.ProgramMenu.ResumeLayout(false);
            this.ProgramMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectDirectory;
        private System.Windows.Forms.MenuStrip ProgramMenu;
        private System.Windows.Forms.ToolStripMenuItem languagesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportMenuItem;
        private System.Windows.Forms.TextBox fieldSelectDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonSelectDirectory;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.CheckBox checkBoxDesktopShortcut;
        private System.Windows.Forms.CheckBox checkBoxStartMenuShortcut;
    }
}

