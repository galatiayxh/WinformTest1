namespace 自定义控件
{
    partial class DoctorData
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSearchContent = new System.Windows.Forms.TextBox();
            this.dgvDoctorData = new System.Windows.Forms.DataGridView();
            this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorData)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchContent
            // 
            this.txtSearchContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchContent.Location = new System.Drawing.Point(0, 0);
            this.txtSearchContent.Name = "txtSearchContent";
            this.txtSearchContent.Size = new System.Drawing.Size(333, 21);
            this.txtSearchContent.TabIndex = 0;
            this.txtSearchContent.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearchContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchContent_KeyDown);
            // 
            // dgvDoctorData
            // 
            this.dgvDoctorData.AllowUserToResizeRows = false;
            this.dgvDoctorData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoctorData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctorData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnName,
            this.clnCode});
            this.dgvDoctorData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoctorData.Location = new System.Drawing.Point(0, 21);
            this.dgvDoctorData.Name = "dgvDoctorData";
            this.dgvDoctorData.RowHeadersVisible = false;
            this.dgvDoctorData.RowTemplate.Height = 23;
            this.dgvDoctorData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoctorData.Size = new System.Drawing.Size(333, 188);
            this.dgvDoctorData.TabIndex = 1;
            this.dgvDoctorData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoctorData_CellDoubleClick);
            this.dgvDoctorData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDoctorData_KeyDown);
            this.dgvDoctorData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvDoctorData_KeyPress);
            // 
            // clnName
            // 
            this.clnName.DataPropertyName = "Name";
            this.clnName.HeaderText = "医生";
            this.clnName.Name = "clnName";
            this.clnName.ReadOnly = true;
            // 
            // clnCode
            // 
            this.clnCode.DataPropertyName = "Code";
            this.clnCode.HeaderText = "编码";
            this.clnCode.Name = "clnCode";
            this.clnCode.ReadOnly = true;
            // 
            // DoctorData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDoctorData);
            this.Controls.Add(this.txtSearchContent);
            this.Name = "DoctorData";
            this.Size = new System.Drawing.Size(333, 209);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctorData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchContent;
        private System.Windows.Forms.DataGridView dgvDoctorData;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCode;
    }
}
