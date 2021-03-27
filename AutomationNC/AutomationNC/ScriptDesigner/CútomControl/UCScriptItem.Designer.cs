
namespace ScriptDesigner.CútomControl
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.cbbControl = new System.Windows.Forms.ComboBox();
            this.cbbAction = new System.Windows.Forms.ComboBox();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.Controls.Add(this.cbbControl);
            this.panelMain.Controls.Add(this.cbbAction);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1024, 45);
            this.panelMain.TabIndex = 2;
            // 
            // cbbControl
            // 
            this.cbbControl.FormattingEnabled = true;
            this.cbbControl.Location = new System.Drawing.Point(205, 8);
            this.cbbControl.Name = "cbbControl";
            this.cbbControl.Size = new System.Drawing.Size(208, 28);
            this.cbbControl.TabIndex = 1;
            // 
            // cbbAction
            // 
            this.cbbAction.FormattingEnabled = true;
            this.cbbAction.Location = new System.Drawing.Point(8, 8);
            this.cbbAction.Name = "cbbAction";
            this.cbbAction.Size = new System.Drawing.Size(191, 28);
            this.cbbAction.TabIndex = 0;
            this.cbbAction.SelectedIndexChanged += new System.EventHandler(this.cbbAction_SelectedIndexChanged);
            // 
            // UCScriptItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelMain);
            this.Name = "UCScriptItem";
            this.Size = new System.Drawing.Size(1024, 45);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ComboBox cbbAction;
        private System.Windows.Forms.ComboBox cbbControl;
    }
}
