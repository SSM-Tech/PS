namespace Payroll_System
{
    partial class PaySlipForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaySlipForm));
            dgvPayslip = new DataGridView();
            btnRefresh = new Button();
            btnView = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPayslip).BeginInit();
            SuspendLayout();
            // 
            // dgvPayslip
            // 
            dgvPayslip.AllowUserToAddRows = false;
            dgvPayslip.AllowUserToDeleteRows = false;
            dgvPayslip.AllowUserToResizeColumns = false;
            dgvPayslip.AllowUserToResizeRows = false;
            dgvPayslip.BackgroundColor = SystemColors.Control;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPayslip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPayslip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPayslip.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPayslip.Location = new Point(12, 12);
            dgvPayslip.Name = "dgvPayslip";
            dgvPayslip.ReadOnly = true;
            dgvPayslip.RowHeadersVisible = false;
            dgvPayslip.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvPayslip.RowTemplate.Height = 25;
            dgvPayslip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayslip.Size = new Size(1232, 593);
            dgvPayslip.TabIndex = 0;
            dgvPayslip.CellClick += dgvPayslip_CellClick;
            dgvPayslip.CellFormatting += dgvPayslip_CellFormatting;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.None;
            btnRefresh.Location = new Point(1024, 611);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(220, 37);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnView
            // 
            btnView.Anchor = AnchorStyles.None;
            btnView.Location = new Point(798, 611);
            btnView.Name = "btnView";
            btnView.Size = new Size(220, 37);
            btnView.TabIndex = 6;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // PaySlipForm
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(178, 190, 195);
            ClientSize = new Size(1256, 660);
            Controls.Add(btnView);
            Controls.Add(btnRefresh);
            Controls.Add(dgvPayslip);
            Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "PaySlipForm";
            Text = "PaySlipForm";
            ((System.ComponentModel.ISupportInitialize)dgvPayslip).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPayslip;
        private Button btnRefresh;
        private Button btnView;
    }
}