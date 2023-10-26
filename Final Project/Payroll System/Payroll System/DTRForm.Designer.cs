namespace Payroll_System
{
    partial class DTRForm
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
            dataGridView1 = new DataGridView();
            ButtonEdit = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1232, 593);
            dataGridView1.TabIndex = 0;
            // 
            // ButtonEdit
            // 
            ButtonEdit.Anchor = AnchorStyles.None;
            ButtonEdit.Location = new Point(798, 611);
            ButtonEdit.Name = "ButtonEdit";
            ButtonEdit.Size = new Size(220, 37);
            ButtonEdit.TabIndex = 4;
            ButtonEdit.Text = "Refresh";
            ButtonEdit.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(1024, 611);
            button1.Name = "button1";
            button1.Size = new Size(220, 37);
            button1.TabIndex = 5;
            button1.Text = "Report";
            button1.UseVisualStyleBackColor = true;
            // 
            // DTRForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 660);
            Controls.Add(button1);
            Controls.Add(ButtonEdit);
            Controls.Add(dataGridView1);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "DTRForm";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "DTRForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button ButtonEdit;
        private Button button1;
    }
}