namespace YektamakDesktop.CustomControls
{
    partial class CustomTextBoxTarih
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
            textBox = new CustomTextBox();
            monthCalendar = new System.Windows.Forms.MonthCalendar();
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.BackColor = System.Drawing.Color.White;
            textBox.BorderColor = System.Drawing.Color.Silver;
            textBox.BorderFocusColor = System.Drawing.Color.HotPink;
            textBox.BorderSize = 1;
            textBox.Font = new System.Drawing.Font("Segoe UI", 8F);
            textBox.ForeColor = System.Drawing.Color.Black;
            textBox.Location = new System.Drawing.Point(0, 0);
            textBox.Margin = new System.Windows.Forms.Padding(1);
            textBox.Multiline = false;
            textBox.Name = "textBox";
            textBox.Padding = new System.Windows.Forms.Padding(3);
            textBox.PasswordChar = false;
            textBox.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBox.PlaceholderText = "";
            textBox.ReadOnly = false;
            textBox.SelectionStart = 0;
            textBox.Size = new System.Drawing.Size(91, 25);
            textBox.TabIndex = 7;
            textBox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            textBox.TextCustom = "";
            textBox.UnderlinedStyle = false;
            textBox.KeyPress += textBox_KeyPress_1;
            textBox.Click += textBox_Click;
            textBox.Leave += textBox_Leave;
            textBox.Enter += textBox_Enter;
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new System.Drawing.Point(2, 28);
            monthCalendar.Margin = new System.Windows.Forms.Padding(8);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 8;
            monthCalendar.DateSelected += monthCalendar_DateSelected;
            // 
            // CustomTextBoxTarih
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(monthCalendar);
            Controls.Add(textBox);
            Font = new System.Drawing.Font("Segoe UI", 8F);
            Margin = new System.Windows.Forms.Padding(1);
            Name = "CustomTextBoxTarih";
            Padding = new System.Windows.Forms.Padding(3);
            Size = new System.Drawing.Size(238, 191);
            ResumeLayout(false);
        }

        #endregion
        public CustomTextBox textBox;
        private System.Windows.Forms.MonthCalendar monthCalendar;
    }
}
