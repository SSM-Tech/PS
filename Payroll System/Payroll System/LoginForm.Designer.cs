namespace Payroll_System
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.HidePasswordIcon = new System.Windows.Forms.PictureBox();
            this.ShowPasswordIcon = new System.Windows.Forms.PictureBox();
            this.PasswordPlaceHolderLabel = new System.Windows.Forms.Label();
            this.UsernamePlaceHolderLabel = new System.Windows.Forms.Label();
            this.passwordIconBox = new System.Windows.Forms.PictureBox();
            this.userIconBox = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HidePasswordIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordIconBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userIconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.SystemColors.InactiveCaption;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(56, 170);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(109, 18);
            this.linkLabel1.TabIndex = 28;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgot Password?";
            this.linkLabel1.VisitedLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // HidePasswordIcon
            // 
            this.HidePasswordIcon.BackColor = System.Drawing.SystemColors.Window;
            this.HidePasswordIcon.Image = ((System.Drawing.Image)(resources.GetObject("HidePasswordIcon.Image")));
            this.HidePasswordIcon.Location = new System.Drawing.Point(359, 137);
            this.HidePasswordIcon.Name = "HidePasswordIcon";
            this.HidePasswordIcon.Size = new System.Drawing.Size(25, 25);
            this.HidePasswordIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HidePasswordIcon.TabIndex = 27;
            this.HidePasswordIcon.TabStop = false;
            this.HidePasswordIcon.Click += new System.EventHandler(this.HidePasswordIcon_Click);
            // 
            // ShowPasswordIcon
            // 
            this.ShowPasswordIcon.BackColor = System.Drawing.SystemColors.Window;
            this.ShowPasswordIcon.Image = ((System.Drawing.Image)(resources.GetObject("ShowPasswordIcon.Image")));
            this.ShowPasswordIcon.Location = new System.Drawing.Point(390, 137);
            this.ShowPasswordIcon.Name = "ShowPasswordIcon";
            this.ShowPasswordIcon.Size = new System.Drawing.Size(25, 25);
            this.ShowPasswordIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPasswordIcon.TabIndex = 26;
            this.ShowPasswordIcon.TabStop = false;
            this.ShowPasswordIcon.Visible = false;
            this.ShowPasswordIcon.Click += new System.EventHandler(this.ShowPasswordIcon_Click);
            // 
            // PasswordPlaceHolderLabel
            // 
            this.PasswordPlaceHolderLabel.AutoSize = true;
            this.PasswordPlaceHolderLabel.BackColor = System.Drawing.Color.White;
            this.PasswordPlaceHolderLabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PasswordPlaceHolderLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.PasswordPlaceHolderLabel.Location = new System.Drawing.Point(63, 133);
            this.PasswordPlaceHolderLabel.Name = "PasswordPlaceHolderLabel";
            this.PasswordPlaceHolderLabel.Size = new System.Drawing.Size(107, 29);
            this.PasswordPlaceHolderLabel.TabIndex = 25;
            this.PasswordPlaceHolderLabel.Text = "Password";
            this.PasswordPlaceHolderLabel.Click += new System.EventHandler(this.PasswordPlaceHolderLabel_Click);
            // 
            // UsernamePlaceHolderLabel
            // 
            this.UsernamePlaceHolderLabel.AutoSize = true;
            this.UsernamePlaceHolderLabel.BackColor = System.Drawing.SystemColors.Window;
            this.UsernamePlaceHolderLabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsernamePlaceHolderLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.UsernamePlaceHolderLabel.Location = new System.Drawing.Point(63, 69);
            this.UsernamePlaceHolderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.UsernamePlaceHolderLabel.Name = "UsernamePlaceHolderLabel";
            this.UsernamePlaceHolderLabel.Size = new System.Drawing.Size(114, 29);
            this.UsernamePlaceHolderLabel.TabIndex = 24;
            this.UsernamePlaceHolderLabel.Text = "Username";
            this.UsernamePlaceHolderLabel.Click += new System.EventHandler(this.UsernamePlaceHolderLabel_Click);
            // 
            // passwordIconBox
            // 
            this.passwordIconBox.Image = ((System.Drawing.Image)(resources.GetObject("passwordIconBox.Image")));
            this.passwordIconBox.Location = new System.Drawing.Point(12, 131);
            this.passwordIconBox.Name = "passwordIconBox";
            this.passwordIconBox.Size = new System.Drawing.Size(36, 36);
            this.passwordIconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passwordIconBox.TabIndex = 23;
            this.passwordIconBox.TabStop = false;
            // 
            // userIconBox
            // 
            this.userIconBox.Image = ((System.Drawing.Image)(resources.GetObject("userIconBox.Image")));
            this.userIconBox.Location = new System.Drawing.Point(12, 66);
            this.userIconBox.Name = "userIconBox";
            this.userIconBox.Size = new System.Drawing.Size(36, 36);
            this.userIconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userIconBox.TabIndex = 22;
            this.userIconBox.TabStop = false;
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::Payroll_System.Properties.Resources.Exit;
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitButton.Location = new System.Drawing.Point(223, 268);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(202, 52);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "EXIT";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(56, 130);
            this.PasswordTextBox.MaxLength = 16;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(369, 37);
            this.PasswordTextBox.TabIndex = 1;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.Enter += new System.EventHandler(this.PasswordTextBox_Enter);
            this.PasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginButton_KeyDown);
            this.PasswordTextBox.Leave += new System.EventHandler(this.PasswordTextBox_Leave);
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(56, 66);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(369, 37);
            this.UsernameTextBox.TabIndex = 0;
            this.UsernameTextBox.Enter += new System.EventHandler(this.UsernameTextBox_Enter);
            this.UsernameTextBox.Leave += new System.EventHandler(this.UsernameTextBox_Leave);
            // 
            // ClearButton
            // 
            this.ClearButton.Image = global::Payroll_System.Properties.Resources.clear;
            this.ClearButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClearButton.Location = new System.Drawing.Point(12, 268);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(202, 52);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "CLEAR";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LoginButton.Image = ((System.Drawing.Image)(resources.GetObject("LoginButton.Image")));
            this.LoginButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoginButton.Location = new System.Drawing.Point(12, 196);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(413, 52);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "LOGIN";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(106, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 39);
            this.label1.TabIndex = 17;
            this.label1.Text = "PAYROLL SYSTEM";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(442, 338);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.HidePasswordIcon);
            this.Controls.Add(this.ShowPasswordIcon);
            this.Controls.Add(this.PasswordPlaceHolderLabel);
            this.Controls.Add(this.UsernamePlaceHolderLabel);
            this.Controls.Add(this.passwordIconBox);
            this.Controls.Add(this.userIconBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.HidePasswordIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordIconBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userIconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LinkLabel linkLabel1;
        private PictureBox HidePasswordIcon;
        private PictureBox ShowPasswordIcon;
        private Label PasswordPlaceHolderLabel;
        private Label UsernamePlaceHolderLabel;
        private PictureBox passwordIconBox;
        private PictureBox userIconBox;
        private Button ExitButton;
        private TextBox PasswordTextBox;
        private TextBox UsernameTextBox;
        private Button ClearButton;
        private Button LoginButton;
        private Label label1;
    }
}