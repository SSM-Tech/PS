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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            ButtonEdit = new Button();
            button1 = new Button();
            dgvDTR = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDTR).BeginInit();
            SuspendLayout();
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
            ButtonEdit.Click += ButtonEdit_Click;
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
            // dgvDTR
            // 
            dgvDTR.AllowUserToAddRows = false;
            dgvDTR.AllowUserToDeleteRows = false;
            dgvDTR.AllowUserToResizeColumns = false;
            dgvDTR.AllowUserToResizeRows = false;
            dgvDTR.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDTR.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDTR.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDTR.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDTR.Location = new Point(12, 12);
            dgvDTR.MultiSelect = false;
            dgvDTR.Name = "dgvDTR";
            dgvDTR.ReadOnly = true;
            dgvDTR.RowHeadersVisible = false;
            dgvDTR.RowTemplate.Height = 25;
            dgvDTR.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDTR.Size = new Size(1232, 593);
            dgvDTR.TabIndex = 6;
            dgvDTR.TabStop = false;
            dgvDTR.CellToolTipTextNeeded += dgvDTR_CellToolTipTextNeeded;
            dgvDTR.ColumnHeaderMouseClick += dgvDTR_ColumnHeaderMouseClick;
            dgvDTR.ColumnHeaderMouseDoubleClick += dgvDTR_ColumnHeaderMouseDoubleClick;
            dgvDTR.RowPrePaint += dgvDTR_RowPrePaint;
            // 
            // DTRForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1256, 660);
            Controls.Add(dgvDTR);
            Controls.Add(button1);
            Controls.Add(ButtonEdit);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "DTRForm";
            StartPosition = FormStartPosition.WindowsDefaultBounds;
            Text = "DTRForm";
            ((System.ComponentModel.ISupportInitialize)dgvDTR).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button ButtonEdit;
        private Button button1;
        private DataGridView dgvDTR;
    }
}