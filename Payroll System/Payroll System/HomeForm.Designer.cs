namespace Payroll_System
{
    partial class HomeForm
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
            UsernameLabel = new Label();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            AccountDetailsButton = new Button();
            logoutButton = new Button();
            SuspendLayout();
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(12, 9);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(221, 29);
            UsernameLabel.TabIndex = 13;
            UsernameLabel.Text = "Welcome, Username!";
            // 
            // button5
            // 
            button5.Location = new Point(228, 177);
            button5.Name = "button5";
            button5.Size = new Size(210, 67);
            button5.TabIndex = 10;
            button5.Text = "TICKETS";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(12, 250);
            button4.Name = "button4";
            button4.Size = new Size(210, 67);
            button4.TabIndex = 11;
            button4.Text = "PAY SLIP";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(228, 104);
            button3.Name = "button3";
            button3.Size = new Size(210, 67);
            button3.TabIndex = 8;
            button3.Text = "MANAGE ACCOUNT";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(12, 177);
            button2.Name = "button2";
            button2.Size = new Size(210, 67);
            button2.TabIndex = 9;
            button2.Text = "DTR";
            button2.UseVisualStyleBackColor = true;
            // 
            // AccountDetailsButton
            // 
            AccountDetailsButton.Location = new Point(12, 104);
            AccountDetailsButton.Name = "AccountDetailsButton";
            AccountDetailsButton.Size = new Size(210, 67);
            AccountDetailsButton.TabIndex = 7;
            AccountDetailsButton.Text = "ACCOUNT DETAILS";
            AccountDetailsButton.UseVisualStyleBackColor = true;
            AccountDetailsButton.Click += AccountDetailsButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(228, 250);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(210, 67);
            logoutButton.TabIndex = 12;
            logoutButton.Text = "LOGOUT";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(450, 417);
            Controls.Add(UsernameLabel);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(AccountDetailsButton);
            Controls.Add(logoutButton);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UsernameLabel;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button AccountDetailsButton;
        private Button logoutButton;
    }
}