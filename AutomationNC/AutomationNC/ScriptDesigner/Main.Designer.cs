﻿
namespace ScriptDesigner
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
            this.dgvMappingControls = new System.Windows.Forms.DataGridView();
            this.btnSaveMappingControl = new System.Windows.Forms.Button();
            this.btnSaveSenarior = new System.Windows.Forms.Button();
            this.ucSenarior = new ScriptDesigner.CustomControl.UCSenarior();
            this.dgvFBActions = new System.Windows.Forms.DataGridView();
            this.btnSaveFBActions = new System.Windows.Forms.Button();
            this.btnLoadDBAction = new System.Windows.Forms.Button();
            this.txtActionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddFBAction = new System.Windows.Forms.Button();
            this.btnDeleteFBAction = new System.Windows.Forms.Button();
            this.btnEunSenarior = new System.Windows.Forms.Button();
            this.cbbFBActionHandleTYpe = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMappingControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFBActions)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMappingControls
            // 
            this.dgvMappingControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvMappingControls.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMappingControls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMappingControls.Location = new System.Drawing.Point(13, 258);
            this.dgvMappingControls.Name = "dgvMappingControls";
            this.dgvMappingControls.RowHeadersWidth = 51;
            this.dgvMappingControls.RowTemplate.Height = 29;
            this.dgvMappingControls.Size = new System.Drawing.Size(392, 451);
            this.dgvMappingControls.TabIndex = 1;
            // 
            // btnSaveMappingControl
            // 
            this.btnSaveMappingControl.Location = new System.Drawing.Point(13, 223);
            this.btnSaveMappingControl.Name = "btnSaveMappingControl";
            this.btnSaveMappingControl.Size = new System.Drawing.Size(196, 29);
            this.btnSaveMappingControl.TabIndex = 2;
            this.btnSaveMappingControl.Text = "Update Mapping Controls";
            this.btnSaveMappingControl.UseVisualStyleBackColor = true;
            this.btnSaveMappingControl.Click += new System.EventHandler(this.btnSaveMappingControl_Click);
            // 
            // btnSaveSenarior
            // 
            this.btnSaveSenarior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSenarior.Location = new System.Drawing.Point(814, 12);
            this.btnSaveSenarior.Name = "btnSaveSenarior";
            this.btnSaveSenarior.Size = new System.Drawing.Size(116, 29);
            this.btnSaveSenarior.TabIndex = 3;
            this.btnSaveSenarior.Text = "Save Senarior";
            this.btnSaveSenarior.UseVisualStyleBackColor = true;
            this.btnSaveSenarior.Click += new System.EventHandler(this.btnSaveSenarior_Click);
            // 
            // ucSenarior
            // 
            this.ucSenarior.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSenarior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucSenarior.Location = new System.Drawing.Point(424, 47);
            this.ucSenarior.Name = "ucSenarior";
            this.ucSenarior.Size = new System.Drawing.Size(570, 662);
            this.ucSenarior.TabIndex = 5;
            // 
            // dgvFBActions
            // 
            this.dgvFBActions.AllowUserToAddRows = false;
            this.dgvFBActions.AllowUserToDeleteRows = false;
            this.dgvFBActions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFBActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFBActions.Location = new System.Drawing.Point(13, 13);
            this.dgvFBActions.MultiSelect = false;
            this.dgvFBActions.Name = "dgvFBActions";
            this.dgvFBActions.ReadOnly = true;
            this.dgvFBActions.RowHeadersWidth = 51;
            this.dgvFBActions.RowTemplate.Height = 29;
            this.dgvFBActions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFBActions.Size = new System.Drawing.Size(328, 135);
            this.dgvFBActions.TabIndex = 6;
            // 
            // btnSaveFBActions
            // 
            this.btnSaveFBActions.Location = new System.Drawing.Point(347, 118);
            this.btnSaveFBActions.Name = "btnSaveFBActions";
            this.btnSaveFBActions.Size = new System.Drawing.Size(58, 29);
            this.btnSaveFBActions.TabIndex = 7;
            this.btnSaveFBActions.Text = "Save";
            this.btnSaveFBActions.UseVisualStyleBackColor = true;
            this.btnSaveFBActions.Click += new System.EventHandler(this.btnSaveFBActions_Click);
            // 
            // btnLoadDBAction
            // 
            this.btnLoadDBAction.Location = new System.Drawing.Point(347, 12);
            this.btnLoadDBAction.Name = "btnLoadDBAction";
            this.btnLoadDBAction.Size = new System.Drawing.Size(58, 29);
            this.btnLoadDBAction.TabIndex = 8;
            this.btnLoadDBAction.Text = "Load";
            this.btnLoadDBAction.UseVisualStyleBackColor = true;
            this.btnLoadDBAction.Click += new System.EventHandler(this.btnLoadDBAction_Click);
            // 
            // txtActionName
            // 
            this.txtActionName.Location = new System.Drawing.Point(68, 156);
            this.txtActionName.Name = "txtActionName";
            this.txtActionName.Size = new System.Drawing.Size(100, 27);
            this.txtActionName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Action";
            // 
            // btnAddFBAction
            // 
            this.btnAddFBAction.Location = new System.Drawing.Point(347, 156);
            this.btnAddFBAction.Name = "btnAddFBAction";
            this.btnAddFBAction.Size = new System.Drawing.Size(58, 29);
            this.btnAddFBAction.TabIndex = 11;
            this.btnAddFBAction.Text = "Add";
            this.btnAddFBAction.UseVisualStyleBackColor = true;
            this.btnAddFBAction.Click += new System.EventHandler(this.btnAddFBAction_Click);
            // 
            // btnDeleteFBAction
            // 
            this.btnDeleteFBAction.BackColor = System.Drawing.Color.Red;
            this.btnDeleteFBAction.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDeleteFBAction.Location = new System.Drawing.Point(347, 67);
            this.btnDeleteFBAction.Name = "btnDeleteFBAction";
            this.btnDeleteFBAction.Size = new System.Drawing.Size(58, 29);
            this.btnDeleteFBAction.TabIndex = 12;
            this.btnDeleteFBAction.Text = "DEL";
            this.btnDeleteFBAction.UseVisualStyleBackColor = false;
            this.btnDeleteFBAction.Click += new System.EventHandler(this.btnDeleteFBAction_Click);
            // 
            // btnEunSenarior
            // 
            this.btnEunSenarior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEunSenarior.Location = new System.Drawing.Point(936, 12);
            this.btnEunSenarior.Name = "btnEunSenarior";
            this.btnEunSenarior.Size = new System.Drawing.Size(58, 29);
            this.btnEunSenarior.TabIndex = 13;
            this.btnEunSenarior.Text = "Run";
            this.btnEunSenarior.UseVisualStyleBackColor = true;
            this.btnEunSenarior.Click += new System.EventHandler(this.btnEunSenarior_Click);
            // 
            // cbbFBActionHandleTYpe
            // 
            this.cbbFBActionHandleTYpe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFBActionHandleTYpe.FormattingEnabled = true;
            this.cbbFBActionHandleTYpe.Location = new System.Drawing.Point(174, 156);
            this.cbbFBActionHandleTYpe.Name = "cbbFBActionHandleTYpe";
            this.cbbFBActionHandleTYpe.Size = new System.Drawing.Size(167, 28);
            this.cbbFBActionHandleTYpe.TabIndex = 14;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.cbbFBActionHandleTYpe);
            this.Controls.Add(this.btnEunSenarior);
            this.Controls.Add(this.btnDeleteFBAction);
            this.Controls.Add(this.btnAddFBAction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtActionName);
            this.Controls.Add(this.btnLoadDBAction);
            this.Controls.Add(this.btnSaveFBActions);
            this.Controls.Add(this.dgvFBActions);
            this.Controls.Add(this.ucSenarior);
            this.Controls.Add(this.btnSaveSenarior);
            this.Controls.Add(this.btnSaveMappingControl);
            this.Controls.Add(this.dgvMappingControls);
            this.Name = "Main";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMappingControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFBActions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMappingControls;
        private System.Windows.Forms.Button btnSaveMappingControl;
        private System.Windows.Forms.Button btnSaveSenarior;
        private CustomControl.UCSenarior ucSenarior;
        private System.Windows.Forms.DataGridView dgvFBActions;
        private System.Windows.Forms.Button btnSaveFBActions;
        private System.Windows.Forms.Button btnLoadDBAction;
        private System.Windows.Forms.TextBox txtActionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddFBAction;
        private System.Windows.Forms.Button btnDeleteFBAction;
        private System.Windows.Forms.Button btnEunSenarior;
        private System.Windows.Forms.ComboBox cbbFBActionHandleTYpe;
    }
}

