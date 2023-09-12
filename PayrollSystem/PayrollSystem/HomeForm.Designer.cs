namespace PayrollSystem
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
            logoutButton = new Button();
            AccountDetailsButton = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            UsernameLabel = new Label();
            SuspendLayout();
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(228, 250);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(210, 67);
            logoutButton.TabIndex = 0;
            logoutButton.Text = "LOGOUT";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // AccountDetailsButton
            // 
            AccountDetailsButton.Location = new Point(12, 104);
            AccountDetailsButton.Name = "AccountDetailsButton";
            AccountDetailsButton.Size = new Size(210, 67);
            AccountDetailsButton.TabIndex = 1;
            AccountDetailsButton.Text = "ACCOUNT DETAILS";
            AccountDetailsButton.UseVisualStyleBackColor = true;
            AccountDetailsButton.Click += AccountDetailsButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 177);
            button2.Name = "button2";
            button2.Size = new Size(210, 67);
            button2.TabIndex = 2;
            button2.Text = "DTR";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(228, 104);
            button3.Name = "button3";
            button3.Size = new Size(210, 67);
            button3.TabIndex = 3;
            button3.Text = "MANAGE ACCOUNT";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(12, 250);
            button4.Name = "button4";
            button4.Size = new Size(210, 67);
            button4.TabIndex = 4;
            button4.Text = "PAY SLIP";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(228, 177);
            button5.Name = "button5";
            button5.Size = new Size(210, 67);
            button5.TabIndex = 5;
            button5.Text = "TICKETS";
            button5.UseVisualStyleBackColor = true;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(12, 9);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(221, 29);
            UsernameLabel.TabIndex = 6;
            UsernameLabel.Text = "Welcome, Username!";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(450, 429);
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

        private Button logoutButton;
        private Button AccountDetailsButton;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label UsernameLabel;
    }
}