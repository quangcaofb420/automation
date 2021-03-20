
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
            this.cbbFBActionType = new System.Windows.Forms.ComboBox();
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
            this.dgvSenarior.Location = new System.Drawing.Point(12, 47);
            this.dgvSenarior.Name = "dgvSenarior";
            this.dgvSenarior.RowHeadersWidth = 51;
            this.dgvSenarior.RowTemplate.Height = 29;
            this.dgvSenarior.Size = new System.Drawing.Size(348, 482);
            this.dgvSenarior.TabIndex = 0;
            // 
            // dgvMappingControls
            // 
            this.dgvMappingControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMappingControls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMappingControls.Location = new System.Drawing.Point(366, 47);
            this.dgvMappingControls.Name = "dgvMappingControls";
            this.dgvMappingControls.RowHeadersWidth = 51;
            this.dgvMappingControls.RowTemplate.Height = 29;
            this.dgvMappingControls.Size = new System.Drawing.Size(531, 482);
            this.dgvMappingControls.TabIndex = 1;
            // 
            // btnSaveMappingControl
            // 
            this.btnSaveMappingControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMappingControl.Location = new System.Drawing.Point(701, 535);
            this.btnSaveMappingControl.Name = "btnSaveMappingControl";
            this.btnSaveMappingControl.Size = new System.Drawing.Size(196, 29);
            this.btnSaveMappingControl.TabIndex = 2;
            this.btnSaveMappingControl.Text = "Update Mapping Controls";
            this.btnSaveMappingControl.UseVisualStyleBackColor = true;
            this.btnSaveMappingControl.Click += new System.EventHandler(this.btnSaveMappingControl_Click);
            // 
            // btnSaveSenarior
            // 
            this.btnSaveSenarior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSenarior.Location = new System.Drawing.Point(266, 535);
            this.btnSaveSenarior.Name = "btnSaveSenarior";
            this.btnSaveSenarior.Size = new System.Drawing.Size(94, 29);
            this.btnSaveSenarior.TabIndex = 3;
            this.btnSaveSenarior.Text = "button1";
            this.btnSaveSenarior.UseVisualStyleBackColor = true;
            // 
            // cbbFBActionType
            // 
            this.cbbFBActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFBActionType.FormattingEnabled = true;
            this.cbbFBActionType.Items.AddRange(new object[] {
            "View Livestream",
            "Auto Create Post / Like"});
            this.cbbFBActionType.Location = new System.Drawing.Point(13, 13);
            this.cbbFBActionType.Name = "cbbFBActionType";
            this.cbbFBActionType.Size = new System.Drawing.Size(160, 28);
            this.cbbFBActionType.TabIndex = 4;
            this.cbbFBActionType.SelectedIndexChanged += new System.EventHandler(this.cbbFBActionType_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 576);
            this.Controls.Add(this.cbbFBActionType);
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
        private System.Windows.Forms.ComboBox cbbFBActionType;
    }
}

