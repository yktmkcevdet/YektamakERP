namespace YektamakDesktop.Formlar
{
    partial class UpdateVersion
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            progressBar1 = new System.Windows.Forms.ProgressBar();
            lblStatus = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(52, 67);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(519, 23);
            progressBar1.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(52, 26);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(38, 15);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "label1";
            // 
            // UpdateVersion
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(643, 120);
            Controls.Add(lblStatus);
            Controls.Add(progressBar1);
            Name = "UpdateVersion";
            Text = "UpdateVersion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblStatus;
    }
}