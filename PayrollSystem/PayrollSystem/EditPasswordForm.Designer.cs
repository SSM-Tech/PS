namespace PayrollSystem
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OldPassTextBox = new System.Windows.Forms.TextBox();
            this.NewPassTextBox = new System.Windows.Forms.TextBox();
            this.ConfNewPassTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OldPasswordPlaceHolder = new System.Windows.Forms.Label();
            this.NewPasswordPlaceHolder = new System.Windows.Forms.Label();
            this.ConfirmNewPasswordPlaceHolder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Old Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Confirm New Password:";
            // 
            // OldPassTextBox
            // 
            this.OldPassTextBox.Location = new System.Drawing.Point(257, 64);
            this.OldPassTextBox.Name = "OldPassTextBox";
            this.OldPassTextBox.Size = new System.Drawing.Size(264, 37);
            this.OldPassTextBox.TabIndex = 5;
            this.OldPassTextBox.UseSystemPasswordChar = true;
            this.OldPassTextBox.Enter += new System.EventHandler(this.OldPassTextBoxt_Enter);
            this.OldPassTextBox.Leave += new System.EventHandler(this.OldPassTextBoxt_Leave);
            // 
            // NewPassTextBox
            // 
            this.NewPassTextBox.Location = new System.Drawing.Point(257, 107);
            this.NewPassTextBox.Name = "NewPassTextBox";
            this.NewPassTextBox.Size = new System.Drawing.Size(264, 37);
            this.NewPassTextBox.TabIndex = 6;
            this.NewPassTextBox.UseSystemPasswordChar = true;
            this.NewPassTextBox.Enter += new System.EventHandler(this.NewPassTextBox_Enter);
            this.NewPassTextBox.Leave += new System.EventHandler(this.NewPassTextBox_Leave);
            // 
            // ConfNewPassTextBox
            // 
            this.ConfNewPassTextBox.Location = new System.Drawing.Point(257, 150);
            this.ConfNewPassTextBox.Name = "ConfNewPassTextBox";
            this.ConfNewPassTextBox.Size = new System.Drawing.Size(264, 37);
            this.ConfNewPassTextBox.TabIndex = 7;
            this.ConfNewPassTextBox.UseSystemPasswordChar = true;
            this.ConfNewPassTextBox.Enter += new System.EventHandler(this.ConfNewPassTextBox_Enter);
            this.ConfNewPassTextBox.Leave += new System.EventHandler(this.ConfNewPassTextBox_Leave);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(12, 200);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(239, 37);
            this.ConfirmButton.TabIndex = 8;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            this.ConfirmButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfirmButton_KeyDown);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(257, 200);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(264, 37);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OldPasswordPlaceHolder
            // 
            this.OldPasswordPlaceHolder.AutoSize = true;
            this.OldPasswordPlaceHolder.BackColor = System.Drawing.Color.White;
            this.OldPasswordPlaceHolder.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OldPasswordPlaceHolder.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.OldPasswordPlaceHolder.Location = new System.Drawing.Point(267, 67);
            this.OldPasswordPlaceHolder.Name = "OldPasswordPlaceHolder";
            this.OldPasswordPlaceHolder.Size = new System.Drawing.Size(142, 29);
            this.OldPasswordPlaceHolder.TabIndex = 12;
            this.OldPasswordPlaceHolder.Text = "Old Password";
            // 
            // NewPasswordPlaceHolder
            // 
            this.NewPasswordPlaceHolder.AutoSize = true;
            this.NewPasswordPlaceHolder.BackColor = System.Drawing.Color.White;
            this.NewPasswordPlaceHolder.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NewPasswordPlaceHolder.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.NewPasswordPlaceHolder.Location = new System.Drawing.Point(267, 110);
            this.NewPasswordPlaceHolder.Name = "NewPasswordPlaceHolder";
            this.NewPasswordPlaceHolder.Size = new System.Drawing.Size(151, 29);
            this.NewPasswordPlaceHolder.TabIndex = 13;
            this.NewPasswordPlaceHolder.Text = "New Password";
            // 
            // ConfirmNewPasswordPlaceHolder
            // 
            this.ConfirmNewPasswordPlaceHolder.AutoSize = true;
            this.ConfirmNewPasswordPlaceHolder.BackColor = System.Drawing.Color.White;
            this.ConfirmNewPasswordPlaceHolder.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConfirmNewPasswordPlaceHolder.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.ConfirmNewPasswordPlaceHolder.Location = new System.Drawing.Point(267, 153);
            this.ConfirmNewPasswordPlaceHolder.Name = "ConfirmNewPasswordPlaceHolder";
            this.ConfirmNewPasswordPlaceHolder.Size = new System.Drawing.Size(234, 29);
            this.ConfirmNewPasswordPlaceHolder.TabIndex = 14;
            this.ConfirmNewPasswordPlaceHolder.Text = "Confirm New Password";
            // 
            // EditPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(533, 249);
            this.Controls.Add(this.ConfirmNewPasswordPlaceHolder);
            this.Controls.Add(this.NewPasswordPlaceHolder);
            this.Controls.Add(this.OldPasswordPlaceHolder);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.ConfNewPassTextBox);
            this.Controls.Add(this.NewPassTextBox);
            this.Controls.Add(this.OldPassTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "EditPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditAccountForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox OldPassTextBox;
        private TextBox NewPassTextBox;
        private TextBox ConfNewPassTextBox;
        private Button ConfirmButton;
        private Button CancelButton;
        private Label OldPasswordPlaceHolder;
        private Label NewPasswordPlaceHolder;
        private Label ConfirmNewPasswordPlaceHolder;
    }
}