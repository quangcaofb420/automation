
namespace ScriptDesigner.CustomControl
{
    partial class UCSenarior
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
            this.tblScript = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tblScript
            // 
            this.tblScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblScript.AutoSize = true;
            this.tblScript.BackColor = System.Drawing.SystemColors.Control;
            this.tblScript.ColumnCount = 1;
            this.tblScript.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblScript.Location = new System.Drawing.Point(0, 0);
            this.tblScript.Name = "tblScript";
            this.tblScript.RowCount = 1;
            this.tblScript.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblScript.Size = new System.Drawing.Size(702, 513);
            this.tblScript.TabIndex = 0;
            // 
            // UCSenarior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tblScript);
            this.Name = "UCSenarior";
            this.Size = new System.Drawing.Size(702, 513);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblScript;
    }
}
