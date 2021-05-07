
namespace ScriptDesigner.CustomControl
{
    partial class UCScriptItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnAction = new System.Windows.Forms.Button();
            this.cbbControl = new System.Windows.Forms.ComboBox();
            this.cbbAction = new System.Windows.Forms.ComboBox();
            this.cmtAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.Controls.Add(this.btnAction);
            this.panelMain.Controls.Add(this.cbbControl);
            this.panelMain.Controls.Add(this.cbbAction);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1024, 28);
            this.panelMain.TabIndex = 2;
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.BackColor = System.Drawing.Color.Red;
            this.btnAction.Location = new System.Drawing.Point(994, -2);
            this.btnAction.MaximumSize = new System.Drawing.Size(50, 50);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(30, 30);
            this.btnAction.TabIndex = 3;
            this.btnAction.UseVisualStyleBackColor = false;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // cbbControl
            // 
            this.cbbControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbControl.FormattingEnabled = true;
            this.cbbControl.Location = new System.Drawing.Point(206, 0);
            this.cbbControl.Name = "cbbControl";
            this.cbbControl.Size = new System.Drawing.Size(208, 28);
            this.cbbControl.TabIndex = 1;
            this.cbbControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbControl_KeyDown);
            // 
            // cbbAction
            // 
            this.cbbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAction.FormattingEnabled = true;
            this.cbbAction.Location = new System.Drawing.Point(0, 0);
            this.cbbAction.Name = "cbbAction";
            this.cbbAction.Size = new System.Drawing.Size(191, 28);
            this.cbbAction.TabIndex = 0;
            this.cbbAction.SelectedIndexChanged += new System.EventHandler(this.cbbAction_SelectedIndexChanged);
            // 
            // cmtAction
            // 
            this.cmtAction.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmtAction.Name = "cmtAction";
            this.cmtAction.Size = new System.Drawing.Size(61, 4);
            this.cmtAction.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmtAction_ItemClicked);
            // 
            // UCScriptItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelMain);
            this.Name = "UCScriptItem";
            this.Size = new System.Drawing.Size(1024, 28);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ComboBox cbbAction;
        private System.Windows.Forms.ComboBox cbbControl;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.ContextMenuStrip cmtAction;
    }
}
