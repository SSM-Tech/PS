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
            label1 = new Label();
            LoginButton = new Button();
            ClearButton = new Button();
            UsernameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            ExitButton = new Button();
            userIconBox = new PictureBox();
            passwordIconBox = new PictureBox();
            UsernamePlaceHolderLabel = new Label();
            PasswordPlaceHolderLabel = new Label();
            ShowPasswordIcon = new PictureBox();
            HidePasswordIcon = new PictureBox();
            linkLabel1 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)userIconBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)passwordIconBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShowPasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HidePasswordIcon).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(107, 19);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(225, 39);
            label1.TabIndex = 0;
            label1.Text = "PAYROLL SYSTEM";
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(13, 204);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(413, 52);
            LoginButton.TabIndex = 2;
            LoginButton.Text = "LOGIN";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(13, 276);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(202, 52);
            ClearButton.TabIndex = 3;
            ClearButton.Text = "CLEAR";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(57, 74);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(369, 37);
            UsernameTextBox.TabIndex = 0;
            UsernameTextBox.Enter += UsernameTextBox_Enter;
            UsernameTextBox.Leave += UsernameTextBox_Leave;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(57, 138);
            PasswordTextBox.MaxLength = 16;
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(369, 37);
            PasswordTextBox.TabIndex = 1;
            PasswordTextBox.UseSystemPasswordChar = true;
            PasswordTextBox.Enter += PasswordTextBox_Enter;
            PasswordTextBox.KeyDown += Login_KeyDown;
            PasswordTextBox.Leave += PasswordTextBox_Leave;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(224, 276);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(202, 52);
            ExitButton.TabIndex = 4;
            ExitButton.Text = "EXIT";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // userIconBox
            // 
            userIconBox.Image = (Image)resources.GetObject("userIconBox.Image");
            userIconBox.Location = new Point(13, 74);
            userIconBox.Name = "userIconBox";
            userIconBox.Size = new Size(36, 36);
            userIconBox.SizeMode = PictureBoxSizeMode.StretchImage;
            userIconBox.TabIndex = 8;
            userIconBox.TabStop = false;
            // 
            // passwordIconBox
            // 
            passwordIconBox.Image = (Image)resources.GetObject("passwordIconBox.Image");
            passwordIconBox.Location = new Point(13, 139);
            passwordIconBox.Name = "passwordIconBox";
            passwordIconBox.Size = new Size(36, 36);
            passwordIconBox.SizeMode = PictureBoxSizeMode.StretchImage;
            passwordIconBox.TabIndex = 9;
            passwordIconBox.TabStop = false;
            // 
            // UsernamePlaceHolderLabel
            // 
            UsernamePlaceHolderLabel.AutoSize = true;
            UsernamePlaceHolderLabel.BackColor = SystemColors.Window;
            UsernamePlaceHolderLabel.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            UsernamePlaceHolderLabel.ForeColor = SystemColors.ActiveBorder;
            UsernamePlaceHolderLabel.Location = new Point(64, 77);
            UsernamePlaceHolderLabel.Margin = new Padding(0);
            UsernamePlaceHolderLabel.Name = "UsernamePlaceHolderLabel";
            UsernamePlaceHolderLabel.Size = new Size(114, 29);
            UsernamePlaceHolderLabel.TabIndex = 10;
            UsernamePlaceHolderLabel.Text = "Username";
            UsernamePlaceHolderLabel.Click += UsernamePlaceHolderLabel_Click;
            // 
            // PasswordPlaceHolderLabel
            // 
            PasswordPlaceHolderLabel.AutoSize = true;
            PasswordPlaceHolderLabel.BackColor = Color.White;
            PasswordPlaceHolderLabel.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordPlaceHolderLabel.ForeColor = SystemColors.ActiveBorder;
            PasswordPlaceHolderLabel.Location = new Point(64, 141);
            PasswordPlaceHolderLabel.Name = "PasswordPlaceHolderLabel";
            PasswordPlaceHolderLabel.Size = new Size(107, 29);
            PasswordPlaceHolderLabel.TabIndex = 11;
            PasswordPlaceHolderLabel.Text = "Password";
            PasswordPlaceHolderLabel.Click += PasswordPlaceHolderLabel_Click;
            // 
            // ShowPasswordIcon
            // 
            ShowPasswordIcon.BackColor = SystemColors.Window;
            ShowPasswordIcon.Image = Properties.Resources.showPasswordIcon;
            ShowPasswordIcon.Location = new Point(391, 145);
            ShowPasswordIcon.Name = "ShowPasswordIcon";
            ShowPasswordIcon.Size = new Size(25, 25);
            ShowPasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            ShowPasswordIcon.TabIndex = 12;
            ShowPasswordIcon.TabStop = false;
            ShowPasswordIcon.Visible = false;
            ShowPasswordIcon.Click += ShowPasswordIcon_Click;
            // 
            // HidePasswordIcon
            // 
            HidePasswordIcon.BackColor = SystemColors.Window;
            HidePasswordIcon.Image = (Image)resources.GetObject("HidePasswordIcon.Image");
            HidePasswordIcon.Location = new Point(391, 145);
            HidePasswordIcon.Name = "HidePasswordIcon";
            HidePasswordIcon.Size = new Size(25, 25);
            HidePasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            HidePasswordIcon.TabIndex = 13;
            HidePasswordIcon.TabStop = false;
            HidePasswordIcon.Click += HidePasswordIcon_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = SystemColors.InactiveCaption;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(57, 178);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(109, 18);
            linkLabel1.TabIndex = 15;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Forgot Password?";
            linkLabel1.VisitedLinkColor = SystemColors.ActiveCaption;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(438, 340);
            Controls.Add(linkLabel1);
            Controls.Add(HidePasswordIcon);
            Controls.Add(ShowPasswordIcon);
            Controls.Add(PasswordPlaceHolderLabel);
            Controls.Add(UsernamePlaceHolderLabel);
            Controls.Add(passwordIconBox);
            Controls.Add(userIconBox);
            Controls.Add(ExitButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(UsernameTextBox);
            Controls.Add(ClearButton);
            Controls.Add(LoginButton);
            Controls.Add(label1);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(6, 5, 6, 5);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGIN";
            ((System.ComponentModel.ISupportInitialize)userIconBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)passwordIconBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShowPasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)HidePasswordIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private LinkLabel linkLabel1;
    }
}