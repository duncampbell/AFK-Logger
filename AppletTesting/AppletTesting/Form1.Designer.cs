﻿namespace AppletTesting
{
    partial class Form1
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
            this.btnETA1 = new System.Windows.Forms.Button();
            this.btnETA2 = new System.Windows.Forms.Button();
            this.btnETA3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnETA1
            // 
            this.btnETA1.Location = new System.Drawing.Point(13, 13);
            this.btnETA1.Name = "btnETA1";
            this.btnETA1.Size = new System.Drawing.Size(75, 23);
            this.btnETA1.TabIndex = 0;
            this.btnETA1.Text = "ETA 1";
            this.btnETA1.UseVisualStyleBackColor = true;
            this.btnETA1.Click += new System.EventHandler(this.btnETA1_Click);
            // 
            // btnETA2
            // 
            this.btnETA2.Location = new System.Drawing.Point(95, 12);
            this.btnETA2.Name = "btnETA2";
            this.btnETA2.Size = new System.Drawing.Size(75, 23);
            this.btnETA2.TabIndex = 1;
            this.btnETA2.Text = "ETA 2";
            this.btnETA2.UseVisualStyleBackColor = true;
            this.btnETA2.Click += new System.EventHandler(this.btnETA2_Click);
            // 
            // btnETA3
            // 
            this.btnETA3.Location = new System.Drawing.Point(177, 13);
            this.btnETA3.Name = "btnETA3";
            this.btnETA3.Size = new System.Drawing.Size(75, 23);
            this.btnETA3.TabIndex = 2;
            this.btnETA3.Text = "ETA 3";
            this.btnETA3.UseVisualStyleBackColor = true;
            this.btnETA3.Click += new System.EventHandler(this.btnETA3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 47);
            this.Controls.Add(this.btnETA3);
            this.Controls.Add(this.btnETA2);
            this.Controls.Add(this.btnETA1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnETA1;
        private System.Windows.Forms.Button btnETA2;
        private System.Windows.Forms.Button btnETA3;
    }
}
