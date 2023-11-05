﻿namespace PS.Server
{
    partial class ServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            txtStatus = new Label();
            label1 = new Label();
            btnRefresh = new Button();
            btnExit = new Button();
            btnMinimize = new Button();
            btnStop = new Button();
            btnStart = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // txtStatus
            // 
            txtStatus.AutoSize = true;
            txtStatus.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point);
            txtStatus.Location = new Point(181, 11);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(245, 34);
            txtStatus.TabIndex = 15;
            txtStatus.Text = "Running/Terminated";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(16, 11);
            label1.Name = "label1";
            label1.Size = new Size(171, 34);
            label1.TabIndex = 14;
            label1.Text = "Server Status:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Yellow;
            btnRefresh.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefresh.Location = new Point(312, 491);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(140, 40);
            btnRefresh.TabIndex = 13;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Red;
            btnExit.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.Location = new Point(839, 491);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(140, 40);
            btnExit.TabIndex = 12;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.Yellow;
            btnMinimize.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnMinimize.Location = new Point(691, 491);
            btnMinimize.Margin = new Padding(4, 5, 4, 5);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(140, 40);
            btnMinimize.TabIndex = 11;
            btnMinimize.Text = "Minimize";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.Red;
            btnStop.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnStop.Location = new Point(164, 491);
            btnStop.Margin = new Padding(4, 5, 4, 5);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(140, 40);
            btnStop.TabIndex = 10;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Lime;
            btnStart.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Location = new Point(16, 491);
            btnStart.Margin = new Padding(4, 5, 4, 5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(140, 40);
            btnStart.TabIndex = 9;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ActiveCaptionText;
            richTextBox1.Font = new Font("Microsoft Sans Serif", 11.95F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.ForeColor = SystemColors.Info;
            richTextBox1.Location = new Point(16, 50);
            richTextBox1.Margin = new Padding(4, 5, 4, 5);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(963, 431);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(994, 543);
            Controls.Add(txtStatus);
            Controls.Add(label1);
            Controls.Add(btnRefresh);
            Controls.Add(btnExit);
            Controls.Add(btnMinimize);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(richTextBox1);
            Font = new Font("Impact", 15F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "ServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtStatus;
        private Label label1;
        private Button btnRefresh;
        private Button btnExit;
        private Button btnMinimize;
        private Button btnStop;
        private Button btnStart;
        private RichTextBox richTextBox1;
    }
}