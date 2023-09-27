namespace Payroll_System
{
    partial class EditAccountForm
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
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.TxtDOB = new System.Windows.Forms.TextBox();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtSex = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(3, 618);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(495, 54);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "CANCEL";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.TxtPass);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ConfirmButton);
            this.panel1.Controls.Add(this.TxtDOB);
            this.panel1.Controls.Add(this.TxtLastName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.TxtFirstName);
            this.panel1.Controls.Add(this.TxtUsername);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TxtSex);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 675);
            this.panel1.TabIndex = 24;
            // 
            // TxtPass
            // 
            this.TxtPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPass.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtPass.Location = new System.Drawing.Point(22, 491);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.Size = new System.Drawing.Size(459, 56);
            this.TxtPass.TabIndex = 39;
            this.TxtPass.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 29);
            this.label1.TabIndex = 38;
            this.label1.Text = "Input Password:";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(3, 558);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(495, 54);
            this.ConfirmButton.TabIndex = 37;
            this.ConfirmButton.Text = "CONFIRM";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // TxtDOB
            // 
            this.TxtDOB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtDOB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDOB.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtDOB.Location = new System.Drawing.Point(22, 400);
            this.TxtDOB.Name = "TxtDOB";
            this.TxtDOB.Size = new System.Drawing.Size(459, 56);
            this.TxtDOB.TabIndex = 34;
            // 
            // TxtLastName
            // 
            this.TxtLastName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtLastName.BackColor = System.Drawing.SystemColors.Control;
            this.TxtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtLastName.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtLastName.Location = new System.Drawing.Point(22, 127);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(459, 56);
            this.TxtLastName.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(3, 368);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 29);
            this.label8.TabIndex = 30;
            this.label8.Text = "Date of Birth:";
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtFirstName.BackColor = System.Drawing.SystemColors.Control;
            this.TxtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtFirstName.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtFirstName.Location = new System.Drawing.Point(24, 36);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(459, 56);
            this.TxtFirstName.TabIndex = 31;
            // 
            // TxtUsername
            // 
            this.TxtUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUsername.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtUsername.Location = new System.Drawing.Point(22, 218);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(459, 56);
            this.TxtUsername.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 29);
            this.label4.TabIndex = 35;
            this.label4.Text = "Last Name:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 29);
            this.label2.TabIndex = 27;
            this.label2.Text = "First Name:";
            // 
            // TxtSex
            // 
            this.TxtSex.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtSex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSex.Font = new System.Drawing.Font("Impact", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtSex.Location = new System.Drawing.Point(22, 309);
            this.TxtSex.Name = "TxtSex";
            this.TxtSex.Size = new System.Drawing.Size(459, 56);
            this.TxtSex.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(3, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 29);
            this.label7.TabIndex = 29;
            this.label7.Text = "Sex: ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(3, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 29);
            this.label3.TabIndex = 28;
            this.label3.Text = "Username:";
            // 
            // EditAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(525, 699);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "EditAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditAccountForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button CancelButton;
        private Panel panel1;
        private TextBox TxtPass;
        private Label label1;
        private Button ConfirmButton;
        private TextBox TxtDOB;
        private TextBox TxtLastName;
        private Label label8;
        private TextBox TxtFirstName;
        private TextBox TxtUsername;
        private Label label4;
        private Label label2;
        private TextBox TxtSex;
        private Label label7;
        private Label label3;
    }
}