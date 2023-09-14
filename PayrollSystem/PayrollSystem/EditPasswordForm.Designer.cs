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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPasswordForm));
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            OldPassTextBox = new TextBox();
            NewPassTextBox = new TextBox();
            ConfNewPassTextBox = new TextBox();
            ConfirmButton = new Button();
            CancelButton = new Button();
            OldPasswordPlaceHolder = new Label();
            NewPasswordPlaceHolder = new Label();
            ConfirmNewPasswordPlaceHolder = new Label();
            HideOldPasswordIcon = new PictureBox();
            ShowOldPasswordIcon = new PictureBox();
            HideNewPasswordIcon = new PictureBox();
            ShowNewPasswordIcon = new PictureBox();
            HideConNewPasswordIcon = new PictureBox();
            ShowConNewPasswordIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)HideOldPasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShowOldPasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HideNewPasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShowNewPasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HideConNewPasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShowConNewPasswordIcon).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(186, 29);
            label1.TabIndex = 0;
            label1.Text = "Change Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 67);
            label3.Name = "label3";
            label3.Size = new Size(147, 29);
            label3.TabIndex = 2;
            label3.Text = "Old Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 110);
            label2.Name = "label2";
            label2.Size = new Size(156, 29);
            label2.TabIndex = 3;
            label2.Text = "New Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 153);
            label4.Name = "label4";
            label4.Size = new Size(239, 29);
            label4.TabIndex = 4;
            label4.Text = "Confirm New Password:";
            // 
            // OldPassTextBox
            // 
            OldPassTextBox.Location = new Point(257, 64);
            OldPassTextBox.MaxLength = 16;
            OldPassTextBox.Name = "OldPassTextBox";
            OldPassTextBox.Size = new Size(304, 37);
            OldPassTextBox.TabIndex = 5;
            OldPassTextBox.UseSystemPasswordChar = true;
            OldPassTextBox.Enter += OldPassTextBoxt_Enter;
            OldPassTextBox.Leave += OldPassTextBoxt_Leave;
            // 
            // NewPassTextBox
            // 
            NewPassTextBox.Location = new Point(257, 107);
            NewPassTextBox.MaxLength = 16;
            NewPassTextBox.Name = "NewPassTextBox";
            NewPassTextBox.Size = new Size(304, 37);
            NewPassTextBox.TabIndex = 6;
            NewPassTextBox.UseSystemPasswordChar = true;
            NewPassTextBox.Enter += NewPassTextBox_Enter;
            NewPassTextBox.Leave += NewPassTextBox_Leave;
            // 
            // ConfNewPassTextBox
            // 
            ConfNewPassTextBox.Location = new Point(257, 150);
            ConfNewPassTextBox.MaxLength = 16;
            ConfNewPassTextBox.Name = "ConfNewPassTextBox";
            ConfNewPassTextBox.Size = new Size(304, 37);
            ConfNewPassTextBox.TabIndex = 7;
            ConfNewPassTextBox.UseSystemPasswordChar = true;
            ConfNewPassTextBox.Enter += ConfNewPassTextBox_Enter;
            ConfNewPassTextBox.Leave += ConfNewPassTextBox_Leave;
            // 
            // ConfirmButton
            // 
            ConfirmButton.Location = new Point(12, 200);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(239, 37);
            ConfirmButton.TabIndex = 8;
            ConfirmButton.Text = "Confirm";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            ConfirmButton.KeyDown += ConfirmButton_KeyDown;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(257, 200);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(264, 37);
            CancelButton.TabIndex = 9;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // OldPasswordPlaceHolder
            // 
            OldPasswordPlaceHolder.AutoSize = true;
            OldPasswordPlaceHolder.BackColor = Color.White;
            OldPasswordPlaceHolder.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            OldPasswordPlaceHolder.ForeColor = SystemColors.ActiveBorder;
            OldPasswordPlaceHolder.Location = new Point(267, 67);
            OldPasswordPlaceHolder.Name = "OldPasswordPlaceHolder";
            OldPasswordPlaceHolder.Size = new Size(142, 29);
            OldPasswordPlaceHolder.TabIndex = 12;
            OldPasswordPlaceHolder.Text = "Old Password";
            OldPasswordPlaceHolder.Click += OldPasswordPlaceHolder_Click;
            // 
            // NewPasswordPlaceHolder
            // 
            NewPasswordPlaceHolder.AutoSize = true;
            NewPasswordPlaceHolder.BackColor = Color.White;
            NewPasswordPlaceHolder.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            NewPasswordPlaceHolder.ForeColor = SystemColors.ActiveBorder;
            NewPasswordPlaceHolder.Location = new Point(267, 110);
            NewPasswordPlaceHolder.Name = "NewPasswordPlaceHolder";
            NewPasswordPlaceHolder.Size = new Size(151, 29);
            NewPasswordPlaceHolder.TabIndex = 13;
            NewPasswordPlaceHolder.Text = "New Password";
            NewPasswordPlaceHolder.Click += NewPasswordPlaceHolder_Click;
            // 
            // ConfirmNewPasswordPlaceHolder
            // 
            ConfirmNewPasswordPlaceHolder.AutoSize = true;
            ConfirmNewPasswordPlaceHolder.BackColor = Color.White;
            ConfirmNewPasswordPlaceHolder.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            ConfirmNewPasswordPlaceHolder.ForeColor = SystemColors.ActiveBorder;
            ConfirmNewPasswordPlaceHolder.Location = new Point(267, 153);
            ConfirmNewPasswordPlaceHolder.Name = "ConfirmNewPasswordPlaceHolder";
            ConfirmNewPasswordPlaceHolder.Size = new Size(234, 29);
            ConfirmNewPasswordPlaceHolder.TabIndex = 14;
            ConfirmNewPasswordPlaceHolder.Text = "Confirm New Password";
            ConfirmNewPasswordPlaceHolder.Click += ConfirmNewPasswordPlaceHolder_Click;
            // 
            // HideOldPasswordIcon
            // 
            HideOldPasswordIcon.BackColor = SystemColors.Window;
            HideOldPasswordIcon.Image = (Image)resources.GetObject("HideOldPasswordIcon.Image");
            HideOldPasswordIcon.Location = new Point(526, 67);
            HideOldPasswordIcon.Name = "HideOldPasswordIcon";
            HideOldPasswordIcon.Size = new Size(25, 25);
            HideOldPasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            HideOldPasswordIcon.TabIndex = 17;
            HideOldPasswordIcon.TabStop = false;
            HideOldPasswordIcon.Click += HideOldPasswordIcon_Click;
            // 
            // ShowOldPasswordIcon
            // 
            ShowOldPasswordIcon.BackColor = SystemColors.Window;
            ShowOldPasswordIcon.Image = Properties.Resources.showPasswordIcon;
            ShowOldPasswordIcon.Location = new Point(526, 67);
            ShowOldPasswordIcon.Name = "ShowOldPasswordIcon";
            ShowOldPasswordIcon.Size = new Size(25, 25);
            ShowOldPasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            ShowOldPasswordIcon.TabIndex = 16;
            ShowOldPasswordIcon.TabStop = false;
            ShowOldPasswordIcon.Visible = false;
            ShowOldPasswordIcon.Click += ShowOldPasswordIcon_Click;
            // 
            // HideNewPasswordIcon
            // 
            HideNewPasswordIcon.BackColor = SystemColors.Window;
            HideNewPasswordIcon.Image = (Image)resources.GetObject("HideNewPasswordIcon.Image");
            HideNewPasswordIcon.Location = new Point(526, 110);
            HideNewPasswordIcon.Name = "HideNewPasswordIcon";
            HideNewPasswordIcon.Size = new Size(25, 25);
            HideNewPasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            HideNewPasswordIcon.TabIndex = 19;
            HideNewPasswordIcon.TabStop = false;
            HideNewPasswordIcon.Click += HideNewPasswordIcon_Click;
            // 
            // ShowNewPasswordIcon
            // 
            ShowNewPasswordIcon.BackColor = SystemColors.Window;
            ShowNewPasswordIcon.Image = Properties.Resources.showPasswordIcon;
            ShowNewPasswordIcon.Location = new Point(526, 110);
            ShowNewPasswordIcon.Name = "ShowNewPasswordIcon";
            ShowNewPasswordIcon.Size = new Size(25, 25);
            ShowNewPasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            ShowNewPasswordIcon.TabIndex = 18;
            ShowNewPasswordIcon.TabStop = false;
            ShowNewPasswordIcon.Visible = false;
            ShowNewPasswordIcon.Click += ShowNewPasswordIcon_Click;
            // 
            // HideConNewPasswordIcon
            // 
            HideConNewPasswordIcon.BackColor = SystemColors.Window;
            HideConNewPasswordIcon.Image = (Image)resources.GetObject("HideConNewPasswordIcon.Image");
            HideConNewPasswordIcon.Location = new Point(526, 157);
            HideConNewPasswordIcon.Name = "HideConNewPasswordIcon";
            HideConNewPasswordIcon.Size = new Size(25, 25);
            HideConNewPasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            HideConNewPasswordIcon.TabIndex = 21;
            HideConNewPasswordIcon.TabStop = false;
            HideConNewPasswordIcon.Click += HideConNewPasswordIcon_Click;
            // 
            // ShowConNewPasswordIcon
            // 
            ShowConNewPasswordIcon.BackColor = SystemColors.Window;
            ShowConNewPasswordIcon.Image = Properties.Resources.showPasswordIcon;
            ShowConNewPasswordIcon.Location = new Point(526, 157);
            ShowConNewPasswordIcon.Name = "ShowConNewPasswordIcon";
            ShowConNewPasswordIcon.Size = new Size(25, 25);
            ShowConNewPasswordIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            ShowConNewPasswordIcon.TabIndex = 20;
            ShowConNewPasswordIcon.TabStop = false;
            ShowConNewPasswordIcon.Visible = false;
            ShowConNewPasswordIcon.Click += ShowConNewPasswordIcon_Click;
            // 
            // EditPasswordForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(573, 249);
            Controls.Add(HideConNewPasswordIcon);
            Controls.Add(ShowConNewPasswordIcon);
            Controls.Add(HideNewPasswordIcon);
            Controls.Add(ShowNewPasswordIcon);
            Controls.Add(HideOldPasswordIcon);
            Controls.Add(ShowOldPasswordIcon);
            Controls.Add(ConfirmNewPasswordPlaceHolder);
            Controls.Add(NewPasswordPlaceHolder);
            Controls.Add(OldPasswordPlaceHolder);
            Controls.Add(CancelButton);
            Controls.Add(ConfirmButton);
            Controls.Add(ConfNewPassTextBox);
            Controls.Add(NewPassTextBox);
            Controls.Add(OldPassTextBox);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "EditPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditAccountForm";
            ((System.ComponentModel.ISupportInitialize)HideOldPasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShowOldPasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)HideNewPasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShowNewPasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)HideConNewPasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShowConNewPasswordIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private PictureBox HideOldPasswordIcon;
        private PictureBox ShowOldPasswordIcon;
        private PictureBox HideNewPasswordIcon;
        private PictureBox ShowNewPasswordIcon;
        private PictureBox HideConNewPasswordIcon;
        private PictureBox ShowConNewPasswordIcon;
    }
}