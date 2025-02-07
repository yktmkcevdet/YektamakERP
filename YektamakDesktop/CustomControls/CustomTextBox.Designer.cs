namespace YektamakDesktop.CustomControls
{
    partial class CustomTextBox
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
            textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            textBox.Location = new System.Drawing.Point(7, 5);
            textBox.Margin = new System.Windows.Forms.Padding(0);
            textBox.Name = "textBox";
            textBox.Size = new System.Drawing.Size(236, 17);
            textBox.TabIndex = 0;
            textBox.Click += textBox_Click;
            textBox.TextChanged += textBox_TextChanged;
            textBox.Enter += textBox1_Enter;
            textBox.KeyPress += textBox1_KeyPress;
            textBox.KeyUp += textBox1_KeyUp;
            textBox.KeyDown += textBox1_KeyDown;
            textBox.Leave += textBox1_Leave;
            textBox.LostFocus += textBox_LostFocus;
            textBox.MouseLeave += textBox_MouseLeave;
            // 
            // CustomTextBox
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.SystemColors.Window;
            Controls.Add(textBox);
            Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.DimGray;
            Name = "CustomTextBox";
            Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            Size = new System.Drawing.Size(250, 27);
            Enter += CustomTextBox_Enter;
            Leave += CustomTextBox_Leave;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.TextBox textBox;
    }
}
