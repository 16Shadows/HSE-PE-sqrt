
namespace PE___sqrt
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
            this.ProgramMenu = new System.Windows.Forms.MenuStrip();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languagesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.precisionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputField = new System.Windows.Forms.TextBox();
            this.errorField = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.buttonPoint = new System.Windows.Forms.Button();
            this.buttonErase = new System.Windows.Forms.Button();
            this.buttonEraseAll = new System.Windows.Forms.Button();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.historyBox = new System.Windows.Forms.TextBox();
            this.ProgramMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgramMenu
            // 
            this.ProgramMenu.AllowMerge = false;
            this.ProgramMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(196)))), ((int)(((byte)(238)))));
            this.ProgramMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem,
            this.supportMenuItem});
            this.ProgramMenu.Location = new System.Drawing.Point(0, 0);
            this.ProgramMenu.Name = "ProgramMenu";
            this.ProgramMenu.Size = new System.Drawing.Size(769, 24);
            this.ProgramMenu.TabIndex = 0;
            this.ProgramMenu.Text = "ProgramMenu";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languagesMenuItem,
            this.precisionMenuItem});
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsMenuItem.Text = "Settings";
            // 
            // languagesMenuItem
            // 
            this.languagesMenuItem.Name = "languagesMenuItem";
            this.languagesMenuItem.Size = new System.Drawing.Size(180, 22);
            this.languagesMenuItem.Text = "Language";
            // 
            // precisionMenuItem
            // 
            this.precisionMenuItem.Name = "precisionMenuItem";
            this.precisionMenuItem.Size = new System.Drawing.Size(180, 22);
            this.precisionMenuItem.Text = "Precision";
            // 
            // supportMenuItem
            // 
            this.supportMenuItem.Name = "supportMenuItem";
            this.supportMenuItem.Size = new System.Drawing.Size(61, 20);
            this.supportMenuItem.Text = "Support";
            // 
            // inputField
            // 
            this.inputField.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputField.Location = new System.Drawing.Point(12, 27);
            this.inputField.Name = "inputField";
            this.inputField.Size = new System.Drawing.Size(743, 38);
            this.inputField.TabIndex = 1;
            this.inputField.TabStop = false;
            this.inputField.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.inputField.WordWrap = false;
            // 
            // errorField
            // 
            this.errorField.BackColor = System.Drawing.SystemColors.Window;
            this.errorField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.errorField.Location = new System.Drawing.Point(12, 71);
            this.errorField.Name = "errorField";
            this.errorField.ReadOnly = true;
            this.errorField.ShortcutsEnabled = false;
            this.errorField.Size = new System.Drawing.Size(743, 23);
            this.errorField.TabIndex = 2;
            this.errorField.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 80);
            this.button1.TabIndex = 3;
            this.button1.TabStop = false;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(102, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 80);
            this.button2.TabIndex = 4;
            this.button2.TabStop = false;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(192, 104);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 80);
            this.button3.TabIndex = 5;
            this.button3.TabStop = false;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button4.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(12, 194);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 80);
            this.button4.TabIndex = 6;
            this.button4.TabStop = false;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button7.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(12, 284);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(80, 80);
            this.button7.TabIndex = 7;
            this.button7.TabStop = false;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonMinus
            // 
            this.buttonMinus.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonMinus.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMinus.Location = new System.Drawing.Point(12, 374);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(80, 80);
            this.buttonMinus.TabIndex = 8;
            this.buttonMinus.TabStop = false;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = false;
            this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button5.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(102, 194);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 80);
            this.button5.TabIndex = 9;
            this.button5.TabStop = false;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button6.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(192, 194);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(80, 80);
            this.button6.TabIndex = 10;
            this.button6.TabStop = false;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button8.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(102, 284);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(80, 80);
            this.button8.TabIndex = 11;
            this.button8.TabStop = false;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button9.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.Location = new System.Drawing.Point(192, 284);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(80, 80);
            this.button9.TabIndex = 12;
            this.button9.TabStop = false;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button0
            // 
            this.button0.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button0.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.button0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button0.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button0.Location = new System.Drawing.Point(102, 374);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(80, 80);
            this.button0.TabIndex = 13;
            this.button0.TabStop = false;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = false;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // buttonPoint
            // 
            this.buttonPoint.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonPoint.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonPoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPoint.Location = new System.Drawing.Point(192, 374);
            this.buttonPoint.Name = "buttonPoint";
            this.buttonPoint.Size = new System.Drawing.Size(80, 80);
            this.buttonPoint.TabIndex = 14;
            this.buttonPoint.TabStop = false;
            this.buttonPoint.Text = ".";
            this.buttonPoint.UseVisualStyleBackColor = false;
            this.buttonPoint.Click += new System.EventHandler(this.buttonPoint_Click);
            // 
            // buttonErase
            // 
            this.buttonErase.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonErase.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonErase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonErase.Location = new System.Drawing.Point(283, 104);
            this.buttonErase.Name = "buttonErase";
            this.buttonErase.Size = new System.Drawing.Size(80, 80);
            this.buttonErase.TabIndex = 15;
            this.buttonErase.TabStop = false;
            this.buttonErase.Text = "<-";
            this.buttonErase.UseVisualStyleBackColor = false;
            this.buttonErase.Click += new System.EventHandler(this.buttonErase_Click);
            // 
            // buttonEraseAll
            // 
            this.buttonEraseAll.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonEraseAll.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonEraseAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEraseAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEraseAll.Location = new System.Drawing.Point(282, 194);
            this.buttonEraseAll.Name = "buttonEraseAll";
            this.buttonEraseAll.Size = new System.Drawing.Size(80, 80);
            this.buttonEraseAll.TabIndex = 16;
            this.buttonEraseAll.TabStop = false;
            this.buttonEraseAll.Text = "С";
            this.buttonEraseAll.UseVisualStyleBackColor = false;
            this.buttonEraseAll.Click += new System.EventHandler(this.buttonEraseAll_Click);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonCalculate.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCalculate.Location = new System.Drawing.Point(283, 284);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(80, 170);
            this.buttonCalculate.TabIndex = 17;
            this.buttonCalculate.TabStop = false;
            this.buttonCalculate.Text = "=";
            this.buttonCalculate.UseVisualStyleBackColor = false;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // historyBox
            // 
            this.historyBox.Location = new System.Drawing.Point(369, 101);
            this.historyBox.Multiline = true;
            this.historyBox.Name = "historyBox";
            this.historyBox.Size = new System.Drawing.Size(386, 353);
            this.historyBox.TabIndex = 18;
            this.historyBox.WordWrap = false;
            // 
            // ProgramWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(196)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(769, 465);
            this.Controls.Add(this.historyBox);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.buttonEraseAll);
            this.Controls.Add(this.buttonErase);
            this.Controls.Add(this.buttonPoint);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.errorField);
            this.Controls.Add(this.inputField);
            this.Controls.Add(this.ProgramMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.ProgramMenu;
            this.MaximizeBox = false;
            this.Name = "ProgramWindow";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time to sqrt";
            this.Load += new System.EventHandler(this.ProgramWindow_Load);
            this.ProgramMenu.ResumeLayout(false);
            this.ProgramMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ProgramMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languagesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem precisionMenuItem;
        private System.Windows.Forms.TextBox inputField;
        private System.Windows.Forms.TextBox errorField;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button buttonPoint;
        private System.Windows.Forms.Button buttonErase;
        private System.Windows.Forms.Button buttonEraseAll;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.TextBox historyBox;
    }
}