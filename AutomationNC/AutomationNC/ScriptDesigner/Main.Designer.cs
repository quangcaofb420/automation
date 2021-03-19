
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
            this.dgvSenarior = new System.Windows.Forms.DataGridView();
            this.dgvMappingControls = new System.Windows.Forms.DataGridView();
            this.btnSaveMappingControl = new System.Windows.Forms.Button();
            this.btnSaveSenarior = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSenarior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMappingControls)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSenarior
            // 
            this.dgvSenarior.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSenarior.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSenarior.Location = new System.Drawing.Point(12, 12);
            this.dgvSenarior.Name = "dgvSenarior";
            this.dgvSenarior.RowHeadersWidth = 51;
            this.dgvSenarior.RowTemplate.Height = 29;
            this.dgvSenarior.Size = new System.Drawing.Size(398, 435);
            this.dgvSenarior.TabIndex = 0;
            // 
            // dgvMappingControls
            // 
            this.dgvMappingControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMappingControls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMappingControls.Location = new System.Drawing.Point(416, 12);
            this.dgvMappingControls.Name = "dgvMappingControls";
            this.dgvMappingControls.RowHeadersWidth = 51;
            this.dgvMappingControls.RowTemplate.Height = 29;
            this.dgvMappingControls.Size = new System.Drawing.Size(531, 435);
            this.dgvMappingControls.TabIndex = 1;
           // 
            // btnSaveMappingControl
            // 
            this.btnSaveMappingControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMappingControl.Location = new System.Drawing.Point(751, 453);
            this.btnSaveMappingControl.Name = "btnSaveMappingControl";
            this.btnSaveMappingControl.Size = new System.Drawing.Size(196, 29);
            this.btnSaveMappingControl.TabIndex = 2;
            this.btnSaveMappingControl.Text = "Update Mapping Controls";
            this.btnSaveMappingControl.UseVisualStyleBackColor = true;
            this.btnSaveMappingControl.Click += new System.EventHandler(this.btnSaveMappingControl_Click);
            // 
            // btnSaveSenarior
            // 
            this.btnSaveSenarior.Location = new System.Drawing.Point(316, 453);
            this.btnSaveSenarior.Name = "btnSaveSenarior";
            this.btnSaveSenarior.Size = new System.Drawing.Size(94, 29);
            this.btnSaveSenarior.TabIndex = 3;
            this.btnSaveSenarior.Text = "button1";
            this.btnSaveSenarior.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 494);
            this.Controls.Add(this.btnSaveSenarior);
            this.Controls.Add(this.btnSaveMappingControl);
            this.Controls.Add(this.dgvMappingControls);
            this.Controls.Add(this.dgvSenarior);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSenarior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMappingControls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSenarior;
        private System.Windows.Forms.DataGridView dgvMappingControls;
        private System.Windows.Forms.Button btnSaveMappingControl;
        private System.Windows.Forms.Button btnSaveSenarior;
    }
}

