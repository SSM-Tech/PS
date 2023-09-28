namespace Payroll_System
{
    partial class EditPasswordForm
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtConfNewPass = new System.Windows.Forms.TextBox();
            this.TxtNewPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.TxtOldPass = new System.Windows.Forms.TextBox();
            this.TxtConfOldPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(3, 516);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(495, 54);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "CANCEL";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.TxtConfNewPass);
            this.panel1.Controls.Add(this.TxtNewPass);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtPass);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ConfirmButton);
            this.panel1.Controls.Add(this.TxtOldPass);
            this.panel1.Controls.Add(this.TxtConfOldPass);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 573);
            this.panel1.TabIndex = 25;
            // 
            // TxtConfNewPass
            // 
            this.TxtConfNewPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtConfNewPass.BackColor = System.Drawing.SystemColors.Control;
            this.TxtConfNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtConfNewPass.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtConfNewPass.Location = new System.Drawing.Point(22, 315);
            this.TxtConfNewPass.Name = "TxtConfNewPass";
            this.TxtConfNewPass.Size = new System.Drawing.Size(459, 56);
            this.TxtConfNewPass.TabIndex = 41;
            this.TxtConfNewPass.UseSystemPasswordChar = true;
            // 
            // TxtNewPass
            // 
            this.TxtNewPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtNewPass.BackColor = System.Drawing.SystemColors.Control;
            this.TxtNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtNewPass.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtNewPass.Location = new System.Drawing.Point(22, 224);
            this.TxtNewPass.Name = "TxtNewPass";
            this.TxtNewPass.Size = new System.Drawing.Size(459, 56);
            this.TxtNewPass.TabIndex = 40;
            this.TxtNewPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(3, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 29);
            this.label3.TabIndex = 39;
            this.label3.Text = "Confirm Old Password:";
            // 
            // TxtPass
            // 
            this.TxtPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPass.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPass.Location = new System.Drawing.Point(172, 720);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.Size = new System.Drawing.Size(459, 56);
            this.TxtPass.TabIndex = 7;
            this.TxtPass.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(153, 688);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 29);
            this.label1.TabIndex = 38;
            this.label1.Text = "Input Password:";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(3, 456);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(495, 54);
            this.ConfirmButton.TabIndex = 8;
            this.ConfirmButton.Text = "CONFIRM";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // TxtOldPass
            // 
            this.TxtOldPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtOldPass.BackColor = System.Drawing.SystemColors.Control;
            this.TxtOldPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtOldPass.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtOldPass.Location = new System.Drawing.Point(22, 42);
            this.TxtOldPass.Name = "TxtOldPass";
            this.TxtOldPass.Size = new System.Drawing.Size(459, 56);
            this.TxtOldPass.TabIndex = 1;
            this.TxtOldPass.UseSystemPasswordChar = true;
            // 
            // TxtConfOldPass
            // 
            this.TxtConfOldPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtConfOldPass.BackColor = System.Drawing.SystemColors.Control;
            this.TxtConfOldPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtConfOldPass.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtConfOldPass.Location = new System.Drawing.Point(22, 133);
            this.TxtConfOldPass.Name = "TxtConfOldPass";
            this.TxtConfOldPass.Size = new System.Drawing.Size(459, 56);
            this.TxtConfOldPass.TabIndex = 0;
            this.TxtConfOldPass.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 29);
            this.label4.TabIndex = 35;
            this.label4.Text = "New Password:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 29);
            this.label2.TabIndex = 27;
            this.label2.Text = "Old Password:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(3, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 29);
            this.label7.TabIndex = 29;
            this.label7.Text = "Confirm New Password";
            // 
            // EditPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(525, 597);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "EditPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditPasswordForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button CancelButton;
        private Panel panel1;
        private Label label3;
        private TextBox TxtPass;
        private Label label1;
        private Button ConfirmButton;
        private TextBox TxtOldPass;
        private TextBox TxtConfOldPass;
        private Label label4;
        private Label label2;
        private Label label7;
        private TextBox TxtConfNewPass;
        private TextBox TxtNewPass;
    }
}