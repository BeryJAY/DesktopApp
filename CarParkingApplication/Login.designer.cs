namespace CarParkingApplication
{
    partial class Login
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.UserTypeCombo = new MetroFramework.Controls.MetroComboBox();
            this.LoginButton = new MetroFramework.Controls.MetroButton();
            this.PasswordBox = new MetroFramework.Controls.MetroTextBox();
            this.EmailBox = new MetroFramework.Controls.MetroTextBox();
            this.htmlLabel2 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.htmlLabel3 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.htmlLabel1 = new MetroFramework.Drawing.Html.HtmlLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 244);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(179, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 244);
            this.panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metroProgressSpinner1);
            this.groupBox1.Controls.Add(this.UserTypeCombo);
            this.groupBox1.Controls.Add(this.LoginButton);
            this.groupBox1.Controls.Add(this.PasswordBox);
            this.groupBox1.Controls.Add(this.EmailBox);
            this.groupBox1.Controls.Add(this.htmlLabel2);
            this.groupBox1.Controls.Add(this.htmlLabel3);
            this.groupBox1.Controls.Add(this.htmlLabel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(311, 241);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(95, 142);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(35, 30);
            this.metroProgressSpinner1.Spinning = false;
            this.metroProgressSpinner1.TabIndex = 4;
            this.metroProgressSpinner1.UseSelectable = true;
            // 
            // UserTypeCombo
            // 
            this.UserTypeCombo.FormattingEnabled = true;
            this.UserTypeCombo.ItemHeight = 23;
            this.UserTypeCombo.Location = new System.Drawing.Point(95, 31);
            this.UserTypeCombo.Name = "UserTypeCombo";
            this.UserTypeCombo.Size = new System.Drawing.Size(131, 29);
            this.UserTypeCombo.Style = MetroFramework.MetroColorStyle.Green;
            this.UserTypeCombo.TabIndex = 3;
            this.UserTypeCombo.UseSelectable = true;
            this.UserTypeCombo.SelectedIndexChanged += new System.EventHandler(this.UserTypeCombo_SelectedIndexChanged);
            // 
            // LoginButton
            // 
            this.LoginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginButton.Location = new System.Drawing.Point(210, 168);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(95, 23);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "LOGIN";
            this.LoginButton.UseSelectable = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // PasswordBox
            // 
            // 
            // 
            // 
            this.PasswordBox.CustomButton.Image = null;
            this.PasswordBox.CustomButton.Location = new System.Drawing.Point(188, 1);
            this.PasswordBox.CustomButton.Name = "";
            this.PasswordBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.PasswordBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PasswordBox.CustomButton.TabIndex = 1;
            this.PasswordBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PasswordBox.CustomButton.UseSelectable = true;
            this.PasswordBox.CustomButton.Visible = false;
            this.PasswordBox.Lines = new string[0];
            this.PasswordBox.Location = new System.Drawing.Point(95, 112);
            this.PasswordBox.MaxLength = 32767;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '●';
            this.PasswordBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PasswordBox.SelectedText = "";
            this.PasswordBox.SelectionLength = 0;
            this.PasswordBox.SelectionStart = 0;
            this.PasswordBox.ShortcutsEnabled = true;
            this.PasswordBox.Size = new System.Drawing.Size(210, 23);
            this.PasswordBox.TabIndex = 1;
            this.PasswordBox.UseSelectable = true;
            this.PasswordBox.UseSystemPasswordChar = true;
            this.PasswordBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PasswordBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // EmailBox
            // 
            // 
            // 
            // 
            this.EmailBox.CustomButton.Image = null;
            this.EmailBox.CustomButton.Location = new System.Drawing.Point(188, 1);
            this.EmailBox.CustomButton.Name = "";
            this.EmailBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.EmailBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.EmailBox.CustomButton.TabIndex = 1;
            this.EmailBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.EmailBox.CustomButton.UseSelectable = true;
            this.EmailBox.CustomButton.Visible = false;
            this.EmailBox.Lines = new string[0];
            this.EmailBox.Location = new System.Drawing.Point(95, 76);
            this.EmailBox.MaxLength = 32767;
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.PasswordChar = '\0';
            this.EmailBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.EmailBox.SelectedText = "";
            this.EmailBox.SelectionLength = 0;
            this.EmailBox.SelectionStart = 0;
            this.EmailBox.ShortcutsEnabled = true;
            this.EmailBox.Size = new System.Drawing.Size(210, 23);
            this.EmailBox.TabIndex = 1;
            this.EmailBox.UseSelectable = true;
            this.EmailBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.EmailBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // htmlLabel2
            // 
            this.htmlLabel2.AutoScroll = true;
            this.htmlLabel2.AutoScrollMinSize = new System.Drawing.Size(59, 23);
            this.htmlLabel2.AutoSize = false;
            this.htmlLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel2.Location = new System.Drawing.Point(22, 115);
            this.htmlLabel2.Name = "htmlLabel2";
            this.htmlLabel2.Size = new System.Drawing.Size(75, 23);
            this.htmlLabel2.TabIndex = 0;
            this.htmlLabel2.Text = "Password";
            // 
            // htmlLabel3
            // 
            this.htmlLabel3.AutoScroll = true;
            this.htmlLabel3.AutoScrollMinSize = new System.Drawing.Size(23, 23);
            this.htmlLabel3.AutoSize = false;
            this.htmlLabel3.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel3.Location = new System.Drawing.Point(22, 31);
            this.htmlLabel3.Name = "htmlLabel3";
            this.htmlLabel3.Size = new System.Drawing.Size(43, 23);
            this.htmlLabel3.TabIndex = 0;
            this.htmlLabel3.Text = "As";
            // 
            // htmlLabel1
            // 
            this.htmlLabel1.AutoScroll = true;
            this.htmlLabel1.AutoScrollMinSize = new System.Drawing.Size(38, 23);
            this.htmlLabel1.AutoSize = false;
            this.htmlLabel1.BackColor = System.Drawing.SystemColors.Window;
            this.htmlLabel1.Location = new System.Drawing.Point(22, 76);
            this.htmlLabel1.Name = "htmlLabel1";
            this.htmlLabel1.Size = new System.Drawing.Size(43, 23);
            this.htmlLabel1.TabIndex = 0;
            this.htmlLabel1.Text = "Email";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarParkingApplication.Properties.Resources.fingerdumb;
            this.pictureBox1.Location = new System.Drawing.Point(16, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 185);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 324);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Text = "Car Parking";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroComboBox UserTypeCombo;
        private MetroFramework.Controls.MetroButton LoginButton;
        private MetroFramework.Controls.MetroTextBox PasswordBox;
        private MetroFramework.Controls.MetroTextBox EmailBox;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel2;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel3;
        private MetroFramework.Drawing.Html.HtmlLabel htmlLabel1;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

