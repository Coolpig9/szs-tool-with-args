namespace SZS_Tool {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {;
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openSZSDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveSZSDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // openZIPDialog
            // 
            //this.openZIPDialog.Filter = "ZIP Archives|*.zip|All Files|*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);

            this.label1.Size = new System.Drawing.Size(0, 0);
            
            // 
            // openSZSDialog
            // 
            this.openSZSDialog.Filter = "SZS Files|*.szs|All Files|*.*";
            // 
            // saveSZSDialog
            // 
            this.saveSZSDialog.Filter = "SZS Files|*.szs|All Files|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SZS Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openSZSDialog;
        private System.Windows.Forms.SaveFileDialog saveSZSDialog;
    }
}

