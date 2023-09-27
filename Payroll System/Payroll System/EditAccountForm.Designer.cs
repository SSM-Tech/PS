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
            RBTNPreferNotToSay = new RadioButton();
            RBTNOther = new RadioButton();
            RBTNFemale = new RadioButton();
            RBTNMale = new RadioButton();
            DOBCalendar = new DateTimePicker();
            TxtPass = new TextBox();
            label1 = new Label();
            ConfirmButton = new Button();
            TxtLastName = new TextBox();
            label8 = new Label();
            TxtFirstName = new TextBox();
            label4 = new Label();
            label2 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(3, 606);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(495, 54);
            CancelButton.TabIndex = 9;
            CancelButton.Text = "CANCEL";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(RBTNPreferNotToSay);
            panel1.Controls.Add(RBTNOther);
            panel1.Controls.Add(RBTNFemale);
            panel1.Controls.Add(RBTNMale);
            panel1.Controls.Add(DOBCalendar);
            panel1.Controls.Add(TxtPass);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(ConfirmButton);
            panel1.Controls.Add(TxtLastName);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(TxtFirstName);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(CancelButton);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(501, 663);
            panel1.TabIndex = 24;
            // 
            // RBTNPreferNotToSay
            // 
            RBTNPreferNotToSay.AutoSize = true;
            RBTNPreferNotToSay.Location = new Point(255, 265);
            RBTNPreferNotToSay.Name = "RBTNPreferNotToSay";
            RBTNPreferNotToSay.Size = new Size(194, 33);
            RBTNPreferNotToSay.TabIndex = 5;
            RBTNPreferNotToSay.TabStop = true;
            RBTNPreferNotToSay.Text = "Prefer Not To Say";
            RBTNPreferNotToSay.UseVisualStyleBackColor = true;
            RBTNPreferNotToSay.CheckedChanged += RBTNPreferNotToSay_CheckedChanged;
            // 
            // RBTNOther
            // 
            RBTNOther.AutoSize = true;
            RBTNOther.Location = new Point(255, 226);
            RBTNOther.Name = "RBTNOther";
            RBTNOther.Size = new Size(85, 33);
            RBTNOther.TabIndex = 4;
            RBTNOther.TabStop = true;
            RBTNOther.Text = "Other";
            RBTNOther.UseVisualStyleBackColor = true;
            RBTNOther.CheckedChanged += RBTNOther_CheckedChanged;
            // 
            // RBTNFemale
            // 
            RBTNFemale.AutoSize = true;
            RBTNFemale.Location = new Point(42, 265);
            RBTNFemale.Name = "RBTNFemale";
            RBTNFemale.Size = new Size(102, 33);
            RBTNFemale.TabIndex = 3;
            RBTNFemale.TabStop = true;
            RBTNFemale.Text = "Female";
            RBTNFemale.UseVisualStyleBackColor = true;
            RBTNFemale.CheckedChanged += RBTNFemale_CheckedChanged;
            // 
            // RBTNMale
            // 
            RBTNMale.AutoSize = true;
            RBTNMale.Location = new Point(42, 226);
            RBTNMale.Name = "RBTNMale";
            RBTNMale.Size = new Size(78, 33);
            RBTNMale.TabIndex = 2;
            RBTNMale.TabStop = true;
            RBTNMale.Text = "Male";
            RBTNMale.UseVisualStyleBackColor = true;
            RBTNMale.CheckedChanged += RBTNMale_CheckedChanged;
            // 
            // DOBCalendar
            // 
            DOBCalendar.Format = DateTimePickerFormat.Custom;
            DOBCalendar.Location = new Point(22, 333);
            DOBCalendar.Name = "DOBCalendar";
            DOBCalendar.Size = new Size(459, 37);
            DOBCalendar.TabIndex = 6;
            DOBCalendar.Value = new DateTime(2023, 9, 28, 2, 24, 18, 0);
            // 
            // TxtPass
            // 
            TxtPass.Anchor = AnchorStyles.None;
            TxtPass.BorderStyle = BorderStyle.FixedSingle;
            TxtPass.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtPass.Location = new Point(22, 484);
            TxtPass.Name = "TxtPass";
            TxtPass.Size = new Size(459, 56);
            TxtPass.TabIndex = 7;
            TxtPass.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Location = new Point(3, 452);
            label1.Name = "label1";
            label1.Size = new Size(168, 29);
            label1.TabIndex = 38;
            label1.Text = "Input Password:";
            // 
            // ConfirmButton
            // 
            ConfirmButton.Location = new Point(0, 546);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(495, 54);
            ConfirmButton.TabIndex = 8;
            ConfirmButton.Text = "CONFIRM";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // TxtLastName
            // 
            TxtLastName.Anchor = AnchorStyles.None;
            TxtLastName.BackColor = SystemColors.Control;
            TxtLastName.BorderStyle = BorderStyle.FixedSingle;
            TxtLastName.Font = new Font("Impact", 30F, FontStyle.Regular, GraphicsUnit.Point);
            TxtLastName.Location = new Point(22, 132);
            TxtLastName.Name = "TxtLastName";
            TxtLastName.Size = new Size(459, 56);
            TxtLastName.TabIndex = 1;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.BackColor = SystemColors.Control;
            label8.Location = new Point(0, 301);
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
            TxtFirstName.Location = new Point(22, 41);
            TxtFirstName.Name = "TxtFirstName";
            TxtFirstName.Size = new Size(459, 56);
            TxtFirstName.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(3, 100);
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
            label2.Location = new Point(3, 9);
            label2.Name = "label2";
            label2.Size = new Size(121, 29);
            label2.TabIndex = 27;
            label2.Text = "First Name:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.BackColor = SystemColors.Control;
            label7.Location = new Point(3, 194);
            label7.Name = "label7";
            label7.Size = new Size(89, 29);
            label7.TabIndex = 29;
            label7.Text = "Gender:";
            // 
            // EditAccountForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(525, 687);
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
        private TextBox TxtLastName;
        private Label label8;
        private TextBox TxtFirstName;
        private Label label4;
        private Label label2;
        private Label label7;
        private DateTimePicker DOBCalendar;
        private RadioButton RBTNOther;
        private RadioButton RBTNFemale;
        private RadioButton RBTNMale;
        private RadioButton RBTNPreferNotToSay;
    }
}