
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
            this.cbbFBActionType = new System.Windows.Forms.ComboBox();
            this.tblScript = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMappingControls)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMappingControls
            // 
            this.dgvMappingControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMappingControls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMappingControls.Location = new System.Drawing.Point(653, 47);
            this.dgvMappingControls.Name = "dgvMappingControls";
            this.dgvMappingControls.RowHeadersWidth = 51;
            this.dgvMappingControls.RowTemplate.Height = 29;
            this.dgvMappingControls.Size = new System.Drawing.Size(531, 455);
            this.dgvMappingControls.TabIndex = 1;
            // 
            // btnSaveMappingControl
            // 
            this.btnSaveMappingControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMappingControl.Location = new System.Drawing.Point(988, 508);
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
            this.btnSaveSenarior.Location = new System.Drawing.Point(531, 508);
            this.btnSaveSenarior.Name = "btnSaveSenarior";
            this.btnSaveSenarior.Size = new System.Drawing.Size(116, 29);
            this.btnSaveSenarior.TabIndex = 3;
            this.btnSaveSenarior.Text = "Save Senarior";
            this.btnSaveSenarior.UseVisualStyleBackColor = true;
            this.btnSaveSenarior.Click += new System.EventHandler(this.btnSaveSenarior_Click);
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
            // tblScript
            // 
            this.tblScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblScript.AutoScroll = true;
            this.tblScript.ColumnCount = 1;
            this.tblScript.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblScript.Location = new System.Drawing.Point(13, 48);
            this.tblScript.Name = "tblScript";
            this.tblScript.RowCount = 1;
            this.tblScript.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblScript.Size = new System.Drawing.Size(634, 454);
            this.tblScript.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 549);
            this.Controls.Add(this.tblScript);
            this.Controls.Add(this.cbbFBActionType);
            this.Controls.Add(this.btnSaveSenarior);
            this.Controls.Add(this.btnSaveMappingControl);
            this.Controls.Add(this.dgvMappingControls);
            this.Name = "Main";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMappingControls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMappingControls;
        private System.Windows.Forms.Button btnSaveMappingControl;
        private System.Windows.Forms.Button btnSaveSenarior;
        private System.Windows.Forms.ComboBox cbbFBActionType;
        private System.Windows.Forms.TableLayoutPanel tblScript;
    }
}

