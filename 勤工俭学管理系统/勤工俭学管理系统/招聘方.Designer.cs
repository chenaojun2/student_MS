namespace 勤工俭学管理系统
{
    partial class 招聘方
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.招聘管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发布信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人员管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工作聘用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工资发放ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.招聘管理ToolStripMenuItem,
            this.人员管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 招聘管理ToolStripMenuItem
            // 
            this.招聘管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.发布信息ToolStripMenuItem,
            this.修改信息ToolStripMenuItem});
            this.招聘管理ToolStripMenuItem.Name = "招聘管理ToolStripMenuItem";
            this.招聘管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.招聘管理ToolStripMenuItem.Text = "招聘管理";
            // 
            // 发布信息ToolStripMenuItem
            // 
            this.发布信息ToolStripMenuItem.Name = "发布信息ToolStripMenuItem";
            this.发布信息ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.发布信息ToolStripMenuItem.Text = "发布信息";
            this.发布信息ToolStripMenuItem.Click += new System.EventHandler(this.发布信息ToolStripMenuItem_Click);
            // 
            // 修改信息ToolStripMenuItem
            // 
            this.修改信息ToolStripMenuItem.Name = "修改信息ToolStripMenuItem";
            this.修改信息ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.修改信息ToolStripMenuItem.Text = "修改信息";
            this.修改信息ToolStripMenuItem.Click += new System.EventHandler(this.修改信息ToolStripMenuItem_Click);
            // 
            // 人员管理ToolStripMenuItem
            // 
            this.人员管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工作聘用ToolStripMenuItem,
            this.工资发放ToolStripMenuItem});
            this.人员管理ToolStripMenuItem.Name = "人员管理ToolStripMenuItem";
            this.人员管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.人员管理ToolStripMenuItem.Text = "人员管理";
            // 
            // 工作聘用ToolStripMenuItem
            // 
            this.工作聘用ToolStripMenuItem.Name = "工作聘用ToolStripMenuItem";
            this.工作聘用ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.工作聘用ToolStripMenuItem.Text = "工作聘用";
            this.工作聘用ToolStripMenuItem.Click += new System.EventHandler(this.工作聘用ToolStripMenuItem_Click);
            // 
            // 工资发放ToolStripMenuItem
            // 
            this.工资发放ToolStripMenuItem.Name = "工资发放ToolStripMenuItem";
            this.工资发放ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.工资发放ToolStripMenuItem.Text = "工资发放";
            this.工资发放ToolStripMenuItem.Click += new System.EventHandler(this.工资发放ToolStripMenuItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(635, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "签到";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "人员表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(59, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(651, 267);
            this.dataGridView1.TabIndex = 6;
            // 
            // 招聘方
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "招聘方";
            this.Text = "招聘方";
            this.Load += new System.EventHandler(this.招聘方_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 招聘管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发布信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人员管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工作聘用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工资发放ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}