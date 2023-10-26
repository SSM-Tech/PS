namespace Payroll_System
{
    partial class MenuForm
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
            HeaderPanel = new Panel();
            UsernameLabel = new Label();
            SidePanel = new Panel();
            LogoutButton = new Button();
            HomeFormButton = new Button();
            AccountDetailsButton = new Button();
            TicketsFormButton = new Button();
            DTRFormButton = new Button();
            PayslipFormButton = new Button();
            ManageAccoountFormButton = new Button();
            MainPanel = new Panel();
            HeaderPanel.SuspendLayout();
            SidePanel.SuspendLayout();
            SuspendLayout();
            // 
            // HeaderPanel
            // 
            HeaderPanel.BackColor = SystemColors.ActiveCaption;
            HeaderPanel.Controls.Add(UsernameLabel);
            HeaderPanel.Dock = DockStyle.Top;
            HeaderPanel.Location = new Point(0, 0);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(1500, 40);
            HeaderPanel.TabIndex = 15;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(3, 8);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(221, 29);
            UsernameLabel.TabIndex = 13;
            UsernameLabel.Text = "Welcome, Username!";
            // 
            // SidePanel
            // 
            SidePanel.BackColor = SystemColors.ActiveCaption;
            SidePanel.Controls.Add(LogoutButton);
            SidePanel.Controls.Add(HomeFormButton);
            SidePanel.Controls.Add(AccountDetailsButton);
            SidePanel.Controls.Add(TicketsFormButton);
            SidePanel.Controls.Add(DTRFormButton);
            SidePanel.Controls.Add(PayslipFormButton);
            SidePanel.Controls.Add(ManageAccoountFormButton);
            SidePanel.Dock = DockStyle.Left;
            SidePanel.Location = new Point(0, 40);
            SidePanel.Name = "SidePanel";
            SidePanel.Size = new Size(244, 660);
            SidePanel.TabIndex = 14;
            // 
            // LogoutButton
            // 
            LogoutButton.Image = Properties.Resources.logout;
            LogoutButton.ImageAlign = ContentAlignment.MiddleLeft;
            LogoutButton.Location = new Point(3, 613);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(238, 35);
            LogoutButton.TabIndex = 6;
            LogoutButton.Text = "LOGOUT";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // HomeFormButton
            // 
            HomeFormButton.ForeColor = SystemColors.ControlText;
            HomeFormButton.Image = Properties.Resources.home;
            HomeFormButton.ImageAlign = ContentAlignment.MiddleLeft;
            HomeFormButton.Location = new Point(3, 6);
            HomeFormButton.Name = "HomeFormButton";
            HomeFormButton.Size = new Size(238, 35);
            HomeFormButton.TabIndex = 0;
            HomeFormButton.Text = "HOME";
            HomeFormButton.UseVisualStyleBackColor = true;
            HomeFormButton.Click += HomeFormButton_Click;
            // 
            // AccountDetailsButton
            // 
            AccountDetailsButton.Image = Properties.Resources.profile;
            AccountDetailsButton.ImageAlign = ContentAlignment.MiddleLeft;
            AccountDetailsButton.Location = new Point(3, 47);
            AccountDetailsButton.Name = "AccountDetailsButton";
            AccountDetailsButton.Size = new Size(238, 35);
            AccountDetailsButton.TabIndex = 1;
            AccountDetailsButton.Text = "ACCOUNT DETAILS";
            AccountDetailsButton.UseVisualStyleBackColor = true;
            AccountDetailsButton.Click += AccountDetailsButton_Click;
            // 
            // TicketsFormButton
            // 
            TicketsFormButton.Image = Properties.Resources.tickets;
            TicketsFormButton.ImageAlign = ContentAlignment.MiddleLeft;
            TicketsFormButton.Location = new Point(3, 211);
            TicketsFormButton.Name = "TicketsFormButton";
            TicketsFormButton.Size = new Size(238, 35);
            TicketsFormButton.TabIndex = 5;
            TicketsFormButton.Text = "TICKETS";
            TicketsFormButton.UseVisualStyleBackColor = true;
            TicketsFormButton.Visible = false;
            TicketsFormButton.Click += TicketsFormButton_Click;
            // 
            // DTRFormButton
            // 
            DTRFormButton.Image = Properties.Resources.dtr;
            DTRFormButton.ImageAlign = ContentAlignment.MiddleLeft;
            DTRFormButton.Location = new Point(3, 88);
            DTRFormButton.Name = "DTRFormButton";
            DTRFormButton.Size = new Size(238, 35);
            DTRFormButton.TabIndex = 2;
            DTRFormButton.Text = "DTR";
            DTRFormButton.UseVisualStyleBackColor = true;
            DTRFormButton.Click += DTRFormButton_Click;
            // 
            // PayslipFormButton
            // 
            PayslipFormButton.Image = Properties.Resources.payslip;
            PayslipFormButton.ImageAlign = ContentAlignment.MiddleLeft;
            PayslipFormButton.Location = new Point(3, 129);
            PayslipFormButton.Name = "PayslipFormButton";
            PayslipFormButton.Size = new Size(238, 35);
            PayslipFormButton.TabIndex = 3;
            PayslipFormButton.Text = "PAY SLIP";
            PayslipFormButton.UseVisualStyleBackColor = true;
            PayslipFormButton.Click += PayslipFormButton_Click;
            // 
            // ManageAccoountFormButton
            // 
            ManageAccoountFormButton.Image = Properties.Resources.Manage_Accounts;
            ManageAccoountFormButton.ImageAlign = ContentAlignment.MiddleLeft;
            ManageAccoountFormButton.Location = new Point(3, 170);
            ManageAccoountFormButton.Name = "ManageAccoountFormButton";
            ManageAccoountFormButton.Size = new Size(238, 35);
            ManageAccoountFormButton.TabIndex = 4;
            ManageAccoountFormButton.Text = "MANAGE ACCOUNT";
            ManageAccoountFormButton.UseVisualStyleBackColor = true;
            ManageAccoountFormButton.Visible = false;
            ManageAccoountFormButton.Click += ManageAccoountFormButton_Click;
            // 
            // MainPanel
            // 
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(244, 40);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1256, 660);
            MainPanel.TabIndex = 16;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1500, 700);
            Controls.Add(MainPanel);
            Controls.Add(SidePanel);
            Controls.Add(HeaderPanel);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeForm";
            Click += LogoutButton_Click;
            Enter += MenuForm_Enter;
            HeaderPanel.ResumeLayout(false);
            HeaderPanel.PerformLayout();
            SidePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel HeaderPanel;
        private Panel SidePanel;
        private Label UsernameLabel;
        private Button LogoutButton;
        private Button HomeFormButton;
        private Button AccountDetailsButton;
        private Button TicketsFormButton;
        private Button DTRFormButton;
        private Button PayslipFormButton;
        private Button ManageAccoountFormButton;
        private Panel MainPanel;
    }
}