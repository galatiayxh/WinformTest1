namespace 无限分级
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvUnlimited = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增同级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增下一级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改类别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvUnlimited
            // 
            this.tvUnlimited.ContextMenuStrip = this.contextMenuStrip1;
            this.tvUnlimited.Location = new System.Drawing.Point(266, 12);
            this.tvUnlimited.Name = "tvUnlimited";
            this.tvUnlimited.Size = new System.Drawing.Size(243, 384);
            this.tvUnlimited.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增同级ToolStripMenuItem,
            this.新增下一级ToolStripMenuItem,
            this.删除类别ToolStripMenuItem,
            this.修改类别ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 92);
            // 
            // 新增同级ToolStripMenuItem
            // 
            this.新增同级ToolStripMenuItem.Name = "新增同级ToolStripMenuItem";
            this.新增同级ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.新增同级ToolStripMenuItem.Text = "新增同级";
            this.新增同级ToolStripMenuItem.Click += new System.EventHandler(this.新增同级ToolStripMenuItem_Click);
            // 
            // 新增下一级ToolStripMenuItem
            // 
            this.新增下一级ToolStripMenuItem.Name = "新增下一级ToolStripMenuItem";
            this.新增下一级ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.新增下一级ToolStripMenuItem.Text = "新增下一级";
            this.新增下一级ToolStripMenuItem.Click += new System.EventHandler(this.新增下一级ToolStripMenuItem_Click);
            // 
            // 删除类别ToolStripMenuItem
            // 
            this.删除类别ToolStripMenuItem.Name = "删除类别ToolStripMenuItem";
            this.删除类别ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除类别ToolStripMenuItem.Text = "删除类别";
            // 
            // 修改类别ToolStripMenuItem
            // 
            this.修改类别ToolStripMenuItem.Name = "修改类别ToolStripMenuItem";
            this.修改类别ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.修改类别ToolStripMenuItem.Text = "修改类别";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tvUnlimited);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvUnlimited;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增同级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增下一级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除类别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改类别ToolStripMenuItem;
    }
}

