namespace Live_Console
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panlApps = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numAppNums = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnChangeNums = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAppNums)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panlApps);
            this.groupBox1.Location = new System.Drawing.Point(33, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 397);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "启动项：";
            // 
            // panlApps
            // 
            this.panlApps.AutoScroll = true;
            this.panlApps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panlApps.Location = new System.Drawing.Point(3, 19);
            this.panlApps.Name = "panlApps";
            this.panlApps.Size = new System.Drawing.Size(821, 375);
            this.panlApps.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "数量：";
            // 
            // numAppNums
            // 
            this.numAppNums.Location = new System.Drawing.Point(85, 20);
            this.numAppNums.Name = "numAppNums";
            this.numAppNums.Size = new System.Drawing.Size(120, 23);
            this.numAppNums.TabIndex = 6;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(785, 22);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "立即启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnChangeNums
            // 
            this.btnChangeNums.Location = new System.Drawing.Point(218, 19);
            this.btnChangeNums.Name = "btnChangeNums";
            this.btnChangeNums.Size = new System.Drawing.Size(75, 23);
            this.btnChangeNums.TabIndex = 9;
            this.btnChangeNums.Text = "变更数量";
            this.btnChangeNums.UseVisualStyleBackColor = true;
            this.btnChangeNums.Click += new System.EventHandler(this.btnChangeNums_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存配置";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 451);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnChangeNums);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.numAppNums);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bilibili";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAppNums)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GroupBox groupBox1;
        private Label label1;
        private NumericUpDown numAppNums;
        private Button btnStart;
        private Panel panlApps;
        private Button btnChangeNums;
        private Button btnSave;
    }
}