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
            linkLabel1 = new LinkLabel();
            HidePasswordIcon = new PictureBox();
            ShowPasswordIcon = new PictureBox();
            PasswordPlaceHolderLabel = new Label();
            UsernamePlaceHolderLabel = new Label();
            passwordIconBox = new PictureBox();
            userIconBox = new PictureBox();
            ExitButton = new Button();
            PasswordTextBox = new TextBox();
            UsernameTextBox = new TextBox();
            ClearButton = new Button();
            LoginButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)HidePasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShowPasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)passwordIconBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userIconBox).BeginInit();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = SystemColors.InactiveCaption;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Impact", 10F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(56, 170);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(109, 18);
            linkLabel1.TabIndex = 28;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Forgot Password?";
            linkLabel1.VisitedLinkColor = SystemColors.ActiveCaption;
            // 
            // HidePasswordIcon
            // 
            HidePasswordIcon.BackColor = SystemColors.Window;
            HidePasswordIcon.Image = (Image)resources.GetObject("HidePasswordIcon.Image");
            HidePasswordIcon.Location = new Point(359, 137);
            HidePasswordIcon.Name = "HidePasswordIcon";
            HidePasswordIcon.Size = new Size(25, 25);
            HidePasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            HidePasswordIcon.TabIndex = 27;
            HidePasswordIcon.TabStop = false;
            HidePasswordIcon.Click += HidePasswordIcon_Click;
            // 
            // ShowPasswordIcon
            // 
            ShowPasswordIcon.BackColor = SystemColors.Window;
            ShowPasswordIcon.Image = (Image)resources.GetObject("ShowPasswordIcon.Image");
            ShowPasswordIcon.Location = new Point(390, 137);
            ShowPasswordIcon.Name = "ShowPasswordIcon";
            ShowPasswordIcon.Size = new Size(25, 25);
            ShowPasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            ShowPasswordIcon.TabIndex = 26;
            ShowPasswordIcon.TabStop = false;
            ShowPasswordIcon.Visible = false;
            ShowPasswordIcon.Click += ShowPasswordIcon_Click;
            // 
            // PasswordPlaceHolderLabel
            // 
            PasswordPlaceHolderLabel.AutoSize = true;
            PasswordPlaceHolderLabel.BackColor = Color.White;
            PasswordPlaceHolderLabel.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            PasswordPlaceHolderLabel.ForeColor = SystemColors.ActiveBorder;
            PasswordPlaceHolderLabel.Location = new Point(63, 133);
            PasswordPlaceHolderLabel.Name = "PasswordPlaceHolderLabel";
            PasswordPlaceHolderLabel.Size = new Size(107, 29);
            PasswordPlaceHolderLabel.TabIndex = 25;
            PasswordPlaceHolderLabel.Text = "Password";
            PasswordPlaceHolderLabel.Click += PasswordPlaceHolderLabel_Click;
            // 
            // UsernamePlaceHolderLabel
            // 
            UsernamePlaceHolderLabel.AutoSize = true;
            UsernamePlaceHolderLabel.BackColor = SystemColors.Window;
            UsernamePlaceHolderLabel.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            UsernamePlaceHolderLabel.ForeColor = SystemColors.ActiveBorder;
            UsernamePlaceHolderLabel.Location = new Point(63, 69);
            UsernamePlaceHolderLabel.Margin = new Padding(0);
            UsernamePlaceHolderLabel.Name = "UsernamePlaceHolderLabel";
            UsernamePlaceHolderLabel.Size = new Size(114, 29);
            UsernamePlaceHolderLabel.TabIndex = 24;
            UsernamePlaceHolderLabel.Text = "Username";
            UsernamePlaceHolderLabel.Click += UsernamePlaceHolderLabel_Click;
            // 
            // passwordIconBox
            // 
            passwordIconBox.Image = (Image)resources.GetObject("passwordIconBox.Image");
            passwordIconBox.Location = new Point(12, 131);
            passwordIconBox.Name = "passwordIconBox";
            passwordIconBox.Size = new Size(36, 36);
            passwordIconBox.SizeMode = PictureBoxSizeMode.StretchImage;
            passwordIconBox.TabIndex = 23;
            passwordIconBox.TabStop = false;
            // 
            // userIconBox
            // 
            userIconBox.Image = (Image)resources.GetObject("userIconBox.Image");
            userIconBox.Location = new Point(12, 66);
            userIconBox.Name = "userIconBox";
            userIconBox.Size = new Size(36, 36);
            userIconBox.SizeMode = PictureBoxSizeMode.StretchImage;
            userIconBox.TabIndex = 22;
            userIconBox.TabStop = false;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(223, 268);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(202, 52);
            ExitButton.TabIndex = 4;
            ExitButton.Text = "EXIT";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(56, 130);
            PasswordTextBox.MaxLength = 16;
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(369, 37);
            PasswordTextBox.TabIndex = 1;
            PasswordTextBox.UseSystemPasswordChar = true;
            PasswordTextBox.Enter += PasswordTextBox_Enter;
            PasswordTextBox.Leave += PasswordTextBox_Leave;
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(56, 66);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(369, 37);
            UsernameTextBox.TabIndex = 0;
            UsernameTextBox.Enter += UsernameTextBox_Enter;
            UsernameTextBox.Leave += UsernameTextBox_Leave;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(12, 268);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(202, 52);
            ClearButton.TabIndex = 3;
            ClearButton.Text = "CLEAR";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(12, 196);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(413, 52);
            LoginButton.TabIndex = 2;
            LoginButton.Text = "LOGIN";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            LoginButton.KeyDown += LoginButton_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(106, 11);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(225, 39);
            label1.TabIndex = 17;
            label1.Text = "PAYROLL SYSTEM";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(442, 338);
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
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)HidePasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShowPasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)passwordIconBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)userIconBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
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