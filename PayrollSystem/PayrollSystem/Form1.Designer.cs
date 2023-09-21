namespace PayrollSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.userIconBox = new System.Windows.Forms.PictureBox();
            this.passwordIconBox = new System.Windows.Forms.PictureBox();
            this.UsernamePlaceHolderLabel = new System.Windows.Forms.Label();
            this.PasswordPlaceHolderLabel = new System.Windows.Forms.Label();
            this.ShowPasswordIcon = new System.Windows.Forms.PictureBox();
            this.HidePasswordIcon = new System.Windows.Forms.PictureBox();
            this.ForgotPasswordLinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.userIconBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordIconBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HidePasswordIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(107, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "PAYROLL SYSTEM";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(13, 204);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(413, 52);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "LOGIN";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(13, 276);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(202, 52);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "CLEAR";
            this.ClearButton.UseVisualStyleBackColor = true;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(57, 74);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(369, 37);
            this.UsernameTextBox.TabIndex = 0;
            this.UsernameTextBox.Enter += new System.EventHandler(this.UsernameTextBox_Enter);
            this.UsernameTextBox.Leave += new System.EventHandler(this.UsernameTextBox_Leave);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(57, 138);
            this.PasswordTextBox.MaxLength = 16;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(369, 37);
            this.PasswordTextBox.TabIndex = 1;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            this.PasswordTextBox.Enter += new System.EventHandler(this.PasswordTextBox_Enter);
            this.PasswordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.PasswordTextBox.Leave += new System.EventHandler(this.PasswordTextBox_Leave);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(224, 276);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(202, 52);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "EXIT";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // userIconBox
            // 
            this.userIconBox.Image = ((System.Drawing.Image)(resources.GetObject("userIconBox.Image")));
            this.userIconBox.Location = new System.Drawing.Point(13, 74);
            this.userIconBox.Name = "userIconBox";
            this.userIconBox.Size = new System.Drawing.Size(36, 36);
            this.userIconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userIconBox.TabIndex = 8;
            this.userIconBox.TabStop = false;
            // 
            // passwordIconBox
            // 
            this.passwordIconBox.Image = ((System.Drawing.Image)(resources.GetObject("passwordIconBox.Image")));
            this.passwordIconBox.Location = new System.Drawing.Point(13, 139);
            this.passwordIconBox.Name = "passwordIconBox";
            this.passwordIconBox.Size = new System.Drawing.Size(36, 36);
            this.passwordIconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passwordIconBox.TabIndex = 9;
            this.passwordIconBox.TabStop = false;
            // 
            // UsernamePlaceHolderLabel
            // 
            this.UsernamePlaceHolderLabel.AutoSize = true;
            this.UsernamePlaceHolderLabel.BackColor = System.Drawing.SystemColors.Window;
            this.UsernamePlaceHolderLabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UsernamePlaceHolderLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.UsernamePlaceHolderLabel.Location = new System.Drawing.Point(64, 77);
            this.UsernamePlaceHolderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.UsernamePlaceHolderLabel.Name = "UsernamePlaceHolderLabel";
            this.UsernamePlaceHolderLabel.Size = new System.Drawing.Size(114, 29);
            this.UsernamePlaceHolderLabel.TabIndex = 10;
            this.UsernamePlaceHolderLabel.Text = "Username";
            this.UsernamePlaceHolderLabel.Click += new System.EventHandler(this.UsernamePlaceHolderLabel_Click);
            // 
            // PasswordPlaceHolderLabel
            // 
            this.PasswordPlaceHolderLabel.AutoSize = true;
            this.PasswordPlaceHolderLabel.BackColor = System.Drawing.Color.White;
            this.PasswordPlaceHolderLabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PasswordPlaceHolderLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.PasswordPlaceHolderLabel.Location = new System.Drawing.Point(64, 141);
            this.PasswordPlaceHolderLabel.Name = "PasswordPlaceHolderLabel";
            this.PasswordPlaceHolderLabel.Size = new System.Drawing.Size(107, 29);
            this.PasswordPlaceHolderLabel.TabIndex = 11;
            this.PasswordPlaceHolderLabel.Text = "Password";
            this.PasswordPlaceHolderLabel.Click += new System.EventHandler(this.PasswordPlaceHolderLabel_Click);
            // 
            // ShowPasswordIcon
            // 
            this.ShowPasswordIcon.BackColor = System.Drawing.SystemColors.Window;
            this.ShowPasswordIcon.Image = global::PayrollSystem.Properties.Resources.showPasswordIcon;
            this.ShowPasswordIcon.Location = new System.Drawing.Point(391, 145);
            this.ShowPasswordIcon.Name = "ShowPasswordIcon";
            this.ShowPasswordIcon.Size = new System.Drawing.Size(25, 25);
            this.ShowPasswordIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPasswordIcon.TabIndex = 12;
            this.ShowPasswordIcon.TabStop = false;
            this.ShowPasswordIcon.Visible = false;
            this.ShowPasswordIcon.Click += new System.EventHandler(this.HidePasswordIcon_Click);
            // 
            // HidePasswordIcon
            // 
            this.HidePasswordIcon.BackColor = System.Drawing.SystemColors.Window;
            this.HidePasswordIcon.Image = ((System.Drawing.Image)(resources.GetObject("HidePasswordIcon.Image")));
            this.HidePasswordIcon.Location = new System.Drawing.Point(391, 145);
            this.HidePasswordIcon.Name = "HidePasswordIcon";
            this.HidePasswordIcon.Size = new System.Drawing.Size(25, 25);
            this.HidePasswordIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HidePasswordIcon.TabIndex = 13;
            this.HidePasswordIcon.TabStop = false;
            this.HidePasswordIcon.Click += new System.EventHandler(this.ShowPasswordIcon_Click);
            // 
            // ForgotPasswordLinkLabel
            // 
            this.ForgotPasswordLinkLabel.ActiveLinkColor = System.Drawing.SystemColors.InactiveCaption;
            this.ForgotPasswordLinkLabel.AutoSize = true;
            this.ForgotPasswordLinkLabel.Font = new System.Drawing.Font("Impact", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForgotPasswordLinkLabel.LinkColor = System.Drawing.Color.Black;
            this.ForgotPasswordLinkLabel.Location = new System.Drawing.Point(57, 178);
            this.ForgotPasswordLinkLabel.Name = "ForgotPasswordLinkLabel";
            this.ForgotPasswordLinkLabel.Size = new System.Drawing.Size(109, 18);
            this.ForgotPasswordLinkLabel.TabIndex = 15;
            this.ForgotPasswordLinkLabel.TabStop = true;
            this.ForgotPasswordLinkLabel.Text = "Forgot Password?";
            this.ForgotPasswordLinkLabel.VisitedLinkColor = System.Drawing.SystemColors.ActiveCaption;
            this.ForgotPasswordLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(438, 340);
            this.Controls.Add(this.ForgotPasswordLinkLabel);
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
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            ((System.ComponentModel.ISupportInitialize)(this.userIconBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordIconBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPasswordIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HidePasswordIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button LoginButton;
        private Button ClearButton;
        private TextBox UsernameTextBox;
        private TextBox PasswordTextBox;
        private Button ExitButton;
        private PictureBox userIconBox;
        private PictureBox passwordIconBox;
        private Label UsernamePlaceHolderLabel;
        private Label PasswordPlaceHolderLabel;
        private PictureBox ShowPasswordIcon;
        private PictureBox HidePasswordIcon;
        private LinkLabel ForgotPasswordLinkLabel;
    }
}