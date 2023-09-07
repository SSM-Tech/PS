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
            ((System.ComponentModel.ISupportInitialize)userIconBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)passwordIconBox).BeginInit();
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
            UsernameTextBox.KeyDown += Login_KeyDown;
            UsernameTextBox.Leave += UsernameTextBox_Leave;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(57, 138);
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
            UsernamePlaceHolderLabel.Location = new Point(57, 77);
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
            PasswordPlaceHolderLabel.Location = new Point(57, 141);
            PasswordPlaceHolderLabel.Name = "PasswordPlaceHolderLabel";
            PasswordPlaceHolderLabel.Size = new Size(107, 29);
            PasswordPlaceHolderLabel.TabIndex = 11;
            PasswordPlaceHolderLabel.Text = "Password";
            PasswordPlaceHolderLabel.Click += PasswordPlaceHolderLabel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(438, 340);
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
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)userIconBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)passwordIconBox).EndInit();
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
    }
}