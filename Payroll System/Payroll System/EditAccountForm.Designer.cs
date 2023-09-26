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
            CancelButton = new Button();
            panel1 = new Panel();
            TxtPass = new TextBox();
            label1 = new Label();
            ConfirmButton = new Button();
            TxtDOB = new TextBox();
            TxtLastName = new TextBox();
            label8 = new Label();
            TxtFirstName = new TextBox();
            TxtUsername = new TextBox();
            label4 = new Label();
            label2 = new Label();
            TxtSex = new TextBox();
            label7 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(3, 618);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(495, 54);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "CANCEL";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(TxtPass);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(ConfirmButton);
            panel1.Controls.Add(TxtDOB);
            panel1.Controls.Add(TxtLastName);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(TxtFirstName);
            panel1.Controls.Add(TxtUsername);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(TxtSex);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(CancelButton);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(501, 675);
            panel1.TabIndex = 24;
            // 
            // TxtPass
            // 
            TxtPass.Anchor = AnchorStyles.None;
            TxtPass.BorderStyle = BorderStyle.FixedSingle;
            TxtPass.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtPass.Location = new Point(22, 491);
            TxtPass.Name = "TxtPass";
            TxtPass.Size = new Size(459, 56);
            TxtPass.TabIndex = 39;
            TxtPass.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Location = new Point(3, 459);
            label1.Name = "label1";
            label1.Size = new Size(168, 29);
            label1.TabIndex = 38;
            label1.Text = "Input Password:";
            // 
            // ConfirmButton
            // 
            ConfirmButton.Location = new Point(3, 558);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(495, 54);
            ConfirmButton.TabIndex = 37;
            ConfirmButton.Text = "CONFIRM";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // TxtDOB
            // 
            TxtDOB.Anchor = AnchorStyles.None;
            TxtDOB.BorderStyle = BorderStyle.FixedSingle;
            TxtDOB.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtDOB.Location = new Point(22, 400);
            TxtDOB.Name = "TxtDOB";
            TxtDOB.Size = new Size(459, 56);
            TxtDOB.TabIndex = 34;
            // 
            // TxtLastName
            // 
            TxtLastName.Anchor = AnchorStyles.None;
            TxtLastName.BackColor = SystemColors.Control;
            TxtLastName.BorderStyle = BorderStyle.FixedSingle;
            TxtLastName.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtLastName.Location = new Point(22, 127);
            TxtLastName.Name = "TxtLastName";
            TxtLastName.Size = new Size(459, 56);
            TxtLastName.TabIndex = 36;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.BackColor = SystemColors.Control;
            label8.Location = new Point(3, 368);
            label8.Name = "label8";
            label8.Size = new Size(137, 29);
            label8.TabIndex = 30;
            label8.Text = "Date of Birth:";
            // 
            // TxtFirstName
            // 
            TxtFirstName.Anchor = AnchorStyles.None;
            TxtFirstName.BackColor = SystemColors.Control;
            TxtFirstName.BorderStyle = BorderStyle.FixedSingle;
            TxtFirstName.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtFirstName.Location = new Point(24, 36);
            TxtFirstName.Name = "TxtFirstName";
            TxtFirstName.Size = new Size(459, 56);
            TxtFirstName.TabIndex = 31;
            // 
            // TxtUsername
            // 
            TxtUsername.Anchor = AnchorStyles.None;
            TxtUsername.BorderStyle = BorderStyle.FixedSingle;
            TxtUsername.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtUsername.Location = new Point(22, 218);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.Size = new Size(459, 56);
            TxtUsername.TabIndex = 33;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(3, 95);
            label4.Name = "label4";
            label4.Size = new Size(117, 29);
            label4.TabIndex = 35;
            label4.Text = "Last Name:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Location = new Point(3, 4);
            label2.Name = "label2";
            label2.Size = new Size(121, 29);
            label2.TabIndex = 27;
            label2.Text = "First Name:";
            // 
            // TxtSex
            // 
            TxtSex.Anchor = AnchorStyles.None;
            TxtSex.BorderStyle = BorderStyle.FixedSingle;
            TxtSex.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtSex.Location = new Point(22, 309);
            TxtSex.Name = "TxtSex";
            TxtSex.Size = new Size(459, 56);
            TxtSex.TabIndex = 32;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.BackColor = SystemColors.Control;
            label7.Location = new Point(3, 277);
            label7.Name = "label7";
            label7.Size = new Size(55, 29);
            label7.TabIndex = 29;
            label7.Text = "Sex: ";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Location = new Point(3, 186);
            label3.Name = "label3";
            label3.Size = new Size(119, 29);
            label3.TabIndex = 28;
            label3.Text = "Username:";
            // 
            // EditAccountForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(525, 699);
            Controls.Add(panel1);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "EditAccountForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditAccountForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
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