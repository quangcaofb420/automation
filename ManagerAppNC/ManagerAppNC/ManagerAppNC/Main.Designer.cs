﻿
using ManagerAppNC.DI;
using System.Drawing;

namespace ManagerAppNC
{
    partial class Main
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
            this.fbAccListComponent1 = new ManagerAppNC.Components.FBAccListComponent();
            this.pnMain = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnRunAll = new System.Windows.Forms.Button();
            this.dgvFBAction = new System.Windows.Forms.DataGridView();
            this.pnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFBAction)).BeginInit();
            this.SuspendLayout();
            // 
            // fbAccListComponent1
            // 
            this.fbAccListComponent1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fbAccListComponent1.Location = new System.Drawing.Point(1358, 82);
            this.fbAccListComponent1.Name = "fbAccListComponent1";
            this.fbAccListComponent1.Padding = new System.Windows.Forms.Padding(10);
            this.fbAccListComponent1.Size = new System.Drawing.Size(542, 314);
            this.fbAccListComponent1.TabIndex = 0;
            // 
            // pnMain
            // 
            this.pnMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnMain.AutoScroll = true;
            this.pnMain.Controls.Add(this.btnRun);
            this.pnMain.Controls.Add(this.btnRunAll);
            this.pnMain.Controls.Add(this.dgvFBAction);
            this.pnMain.Controls.Add(this.fbAccListComponent1);
            this.pnMain.Location = new System.Drawing.Point(12, 12);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1900, 1031);
            this.pnMain.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(338, 0);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(149, 29);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnRunAll
            // 
            this.btnRunAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunAll.BackColor = System.Drawing.Color.Red;
            this.btnRunAll.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRunAll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRunAll.Location = new System.Drawing.Point(1751, 0);
            this.btnRunAll.Name = "btnRunAll";
            this.btnRunAll.Size = new System.Drawing.Size(149, 76);
            this.btnRunAll.TabIndex = 2;
            this.btnRunAll.Text = "RUN ALL";
            this.btnRunAll.UseVisualStyleBackColor = false;
            this.btnRunAll.Click += new System.EventHandler(this.btnRunAll_Click);
            // 
            // dgvFBAction
            // 
            this.dgvFBAction.AllowUserToAddRows = false;
            this.dgvFBAction.AllowUserToDeleteRows = false;
            this.dgvFBAction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFBAction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFBAction.Enabled = false;
            this.dgvFBAction.Location = new System.Drawing.Point(0, 0);
            this.dgvFBAction.MultiSelect = false;
            this.dgvFBAction.Name = "dgvFBAction";
            this.dgvFBAction.RowHeadersWidth = 51;
            this.dgvFBAction.RowTemplate.Height = 29;
            this.dgvFBAction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFBAction.Size = new System.Drawing.Size(332, 295);
            this.dgvFBAction.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.pnMain);
            this.Name = "Main";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFBAction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.FBAccListComponent fbAccListComponent1;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.DataGridView dgvFBAction;
        private System.Windows.Forms.Button btnRunAll;
        private System.Windows.Forms.Button btnRun;
    }
}

