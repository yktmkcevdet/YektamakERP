namespace YektamakDesktop.CustomControls
{
    partial class CustomTextBoxSayisal
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
            textBox = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox.Location = new System.Drawing.Point(3, 4);
            textBox.Margin = new System.Windows.Forms.Padding(0);
            textBox.Name = "textBox";
            textBox.Size = new System.Drawing.Size(256, 15);
            textBox.TabIndex = 0;
            textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            textBox.Click += textBox_Click;
            textBox.TextChanged += textBox1_TextChanged;
            textBox.Enter += textBox1_Enter;
            textBox.KeyPress += textBox1_KeyPress;
            textBox.KeyUp += textBox1_KeyUp;
            textBox.Leave += textBox1_Leave;
            textBox.LostFocus += textBox_LostFocus;
            textBox.MouseLeave += textBox_MouseLeave;
            // 
            // CustomTextBoxSayisal
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.SystemColors.Window;
            Controls.Add(textBox);
            Font = new System.Drawing.Font("Segoe UI", 8F);
            ForeColor = System.Drawing.Color.DimGray;
            Margin = new System.Windows.Forms.Padding(1);
            Name = "CustomTextBoxSayisal";
            Padding = new System.Windows.Forms.Padding(3);
            Size = new System.Drawing.Size(262, 25);
            Enter += CustomTextBox_Enter;
            Leave += CustomTextBoxSayisal_Leave;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.TextBox textBox;
    }
}
