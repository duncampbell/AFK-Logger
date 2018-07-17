namespace AFKApplet
{
    partial class AFKAppletForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFKAppletForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnETA1 = new System.Windows.Forms.Button();
            this.chkVM = new System.Windows.Forms.CheckBox();
            this.btnETA2 = new System.Windows.Forms.Button();
            this.btnETA3 = new System.Windows.Forms.Button();
            this.txtETA3 = new System.Windows.Forms.TextBox();
            this.txtETA2 = new System.Windows.Forms.TextBox();
            this.txtETA1 = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnAddDevice);
            this.splitContainer1.Panel1.Controls.Add(this.btnSet);
            this.splitContainer1.Panel1.Controls.Add(this.btnETA1);
            this.splitContainer1.Panel1.Controls.Add(this.chkVM);
            this.splitContainer1.Panel1.Controls.Add(this.btnETA2);
            this.splitContainer1.Panel1.Controls.Add(this.btnETA3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtETA3);
            this.splitContainer1.Panel2.Controls.Add(this.txtETA2);
            this.splitContainer1.Panel2.Controls.Add(this.txtETA1);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(271, 140);
            this.splitContainer1.SplitterDistance = 70;
            this.splitContainer1.TabIndex = 7;
            this.splitContainer1.TabStop = false;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Location = new System.Drawing.Point(12, 41);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(75, 23);
            this.btnAddDevice.TabIndex = 10;
            this.btnAddDevice.Text = "Add Device";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(205, 41);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(46, 23);
            this.btnSet.TabIndex = 12;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnETA1
            // 
            this.btnETA1.Location = new System.Drawing.Point(12, 12);
            this.btnETA1.Name = "btnETA1";
            this.btnETA1.Size = new System.Drawing.Size(75, 23);
            this.btnETA1.TabIndex = 7;
            this.btnETA1.Text = "ETA 1";
            this.btnETA1.UseVisualStyleBackColor = true;
            this.btnETA1.Click += new System.EventHandler(this.allETABtn_Click);
            // 
            // chkVM
            // 
            this.chkVM.AutoSize = true;
            this.chkVM.Location = new System.Drawing.Point(94, 45);
            this.chkVM.Name = "chkVM";
            this.chkVM.Size = new System.Drawing.Size(105, 17);
            this.chkVM.TabIndex = 11;
            this.chkVM.Text = "Virtual Machine?";
            this.chkVM.UseVisualStyleBackColor = true;
            // 
            // btnETA2
            // 
            this.btnETA2.Location = new System.Drawing.Point(94, 11);
            this.btnETA2.Name = "btnETA2";
            this.btnETA2.Size = new System.Drawing.Size(75, 23);
            this.btnETA2.TabIndex = 8;
            this.btnETA2.Text = "ETA 2";
            this.btnETA2.UseVisualStyleBackColor = true;
            this.btnETA2.Click += new System.EventHandler(this.allETABtn_Click);
            // 
            // btnETA3
            // 
            this.btnETA3.Location = new System.Drawing.Point(176, 12);
            this.btnETA3.Name = "btnETA3";
            this.btnETA3.Size = new System.Drawing.Size(75, 23);
            this.btnETA3.TabIndex = 9;
            this.btnETA3.Text = "ETA 3";
            this.btnETA3.UseVisualStyleBackColor = true;
            this.btnETA3.Click += new System.EventHandler(this.allETABtn_Click);
            // 
            // txtETA3
            // 
            this.txtETA3.Location = new System.Drawing.Point(176, 18);
            this.txtETA3.Name = "txtETA3";
            this.txtETA3.Size = new System.Drawing.Size(75, 20);
            this.txtETA3.TabIndex = 15;
            // 
            // txtETA2
            // 
            this.txtETA2.Location = new System.Drawing.Point(94, 18);
            this.txtETA2.Name = "txtETA2";
            this.txtETA2.Size = new System.Drawing.Size(75, 20);
            this.txtETA2.TabIndex = 14;
            // 
            // txtETA1
            // 
            this.txtETA1.Location = new System.Drawing.Point(12, 18);
            this.txtETA1.Name = "txtETA1";
            this.txtETA1.Size = new System.Drawing.Size(74, 20);
            this.txtETA1.TabIndex = 13;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Application minimised to system tray. Double click to open.";
            this.notifyIcon1.BalloonTipTitle = "AFKLogger Applet";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "AFKLogger Applet";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.toolStripMenuItem1.Text = "Open Webpage";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(131, 22);
            this.toolStripMenuItem2.Text = "Restart";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // AFKAppletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 71);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AFKAppletForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AFK Applet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AFKAppletForm_FormClosing);
            this.Resize += new System.EventHandler(this.AFKApplet_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnETA1;
        private System.Windows.Forms.CheckBox chkVM;
        private System.Windows.Forms.Button btnETA2;
        private System.Windows.Forms.Button btnETA3;
        private System.Windows.Forms.TextBox txtETA3;
        private System.Windows.Forms.TextBox txtETA2;
        private System.Windows.Forms.TextBox txtETA1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

