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
            this.logoutButton = new System.Windows.Forms.Button();
            this.AccountDetailsButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(228, 250);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(210, 67);
            this.logoutButton.TabIndex = 5;
            this.logoutButton.Text = "LOGOUT";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // AccountDetailsButton
            // 
            this.AccountDetailsButton.Location = new System.Drawing.Point(12, 104);
            this.AccountDetailsButton.Name = "AccountDetailsButton";
            this.AccountDetailsButton.Size = new System.Drawing.Size(210, 67);
            this.AccountDetailsButton.TabIndex = 0;
            this.AccountDetailsButton.Text = "ACCOUNT DETAILS";
            this.AccountDetailsButton.UseVisualStyleBackColor = true;
            this.AccountDetailsButton.Click += new System.EventHandler(this.AccountDetailsButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 67);
            this.button2.TabIndex = 2;
            this.button2.Text = "DTR";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(228, 104);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(210, 67);
            this.button3.TabIndex = 1;
            this.button3.Text = "MANAGE ACCOUNT";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 250);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(210, 67);
            this.button4.TabIndex = 4;
            this.button4.Text = "PAY SLIP";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(228, 177);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(210, 67);
            this.button5.TabIndex = 3;
            this.button5.Text = "TICKETS";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(12, 9);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(221, 29);
            this.UsernameLabel.TabIndex = 6;
            this.UsernameLabel.Text = "Welcome, Username!";
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(450, 429);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AccountDetailsButton);
            this.Controls.Add(this.logoutButton);
            this.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

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