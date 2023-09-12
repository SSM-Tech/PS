namespace PayrollSystem
{
    partial class AccountDetailsForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            UserIDLabel = new Label();
            EmployeeIDLabel = new Label();
            FullnameLabel = new Label();
            UsernameLabel = new Label();
            AccountDescriptionLabel = new Label();
            AccountLevelLabel = new Label();
            ExitButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(165, 29);
            label1.TabIndex = 0;
            label1.Text = "Account Details";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 132);
            label2.Name = "label2";
            label2.Size = new Size(113, 29);
            label2.TabIndex = 1;
            label2.Text = "Fullname: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 74);
            label3.Name = "label3";
            label3.Size = new Size(87, 29);
            label3.TabIndex = 2;
            label3.Text = "User ID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 161);
            label4.Name = "label4";
            label4.Size = new Size(119, 29);
            label4.TabIndex = 3;
            label4.Text = "Username:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 190);
            label5.Name = "label5";
            label5.Size = new Size(131, 29);
            label5.TabIndex = 4;
            label5.Text = "Description:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 219);
            label6.Name = "label6";
            label6.Size = new Size(153, 29);
            label6.TabIndex = 5;
            label6.Text = "Account Level:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 103);
            label7.Name = "label7";
            label7.Size = new Size(136, 29);
            label7.TabIndex = 6;
            label7.Text = "Employee ID:";
            // 
            // UserIDLabel
            // 
            UserIDLabel.AutoSize = true;
            UserIDLabel.Location = new Point(205, 74);
            UserIDLabel.Name = "UserIDLabel";
            UserIDLabel.Size = new Size(74, 29);
            UserIDLabel.TabIndex = 7;
            UserIDLabel.Text = "label8";
            // 
            // EmployeeIDLabel
            // 
            EmployeeIDLabel.AutoSize = true;
            EmployeeIDLabel.Location = new Point(205, 103);
            EmployeeIDLabel.Name = "EmployeeIDLabel";
            EmployeeIDLabel.Size = new Size(74, 29);
            EmployeeIDLabel.TabIndex = 8;
            EmployeeIDLabel.Text = "label9";
            // 
            // FullnameLabel
            // 
            FullnameLabel.AutoSize = true;
            FullnameLabel.Location = new Point(205, 132);
            FullnameLabel.Name = "FullnameLabel";
            FullnameLabel.Size = new Size(83, 29);
            FullnameLabel.TabIndex = 9;
            FullnameLabel.Text = "label10";
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(205, 161);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(79, 29);
            UsernameLabel.TabIndex = 10;
            UsernameLabel.Text = "label11";
            // 
            // AccountDescriptionLabel
            // 
            AccountDescriptionLabel.AutoSize = true;
            AccountDescriptionLabel.Location = new Point(205, 190);
            AccountDescriptionLabel.Name = "AccountDescriptionLabel";
            AccountDescriptionLabel.Size = new Size(82, 29);
            AccountDescriptionLabel.TabIndex = 11;
            AccountDescriptionLabel.Text = "label12";
            // 
            // AccountLevelLabel
            // 
            AccountLevelLabel.AutoSize = true;
            AccountLevelLabel.Location = new Point(205, 219);
            AccountLevelLabel.Name = "AccountLevelLabel";
            AccountLevelLabel.Size = new Size(83, 29);
            AccountLevelLabel.TabIndex = 12;
            AccountLevelLabel.Text = "label13";
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(205, 295);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(147, 39);
            ExitButton.TabIndex = 13;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // AccountDetailsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(548, 346);
            Controls.Add(ExitButton);
            Controls.Add(AccountLevelLabel);
            Controls.Add(AccountDescriptionLabel);
            Controls.Add(UsernameLabel);
            Controls.Add(FullnameLabel);
            Controls.Add(EmployeeIDLabel);
            Controls.Add(UserIDLabel);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "AccountDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AccountDetailsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label UserIDLabel;
        private Label EmployeeIDLabel;
        private Label FullnameLabel;
        private Label UsernameLabel;
        private Label AccountDescriptionLabel;
        private Label AccountLevelLabel;
        private Button ExitButton;
    }
}