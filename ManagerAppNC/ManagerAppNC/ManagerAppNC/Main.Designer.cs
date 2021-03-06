
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
            this.SuspendLayout();
            // 
            // fbAccListComponent1
            // 
            this.fbAccListComponent1.Location = new System.Drawing.Point(12, 12);
            this.fbAccListComponent1.Name = "fbAccListComponent1";
            this.fbAccListComponent1.Padding = new System.Windows.Forms.Padding(10);
            this.fbAccListComponent1.Size = new System.Drawing.Size(499, 299);
            this.fbAccListComponent1.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.fbAccListComponent1);
            this.Name = "Main";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Components.FBAccListComponent fbAccListComponent1;
    }
}

