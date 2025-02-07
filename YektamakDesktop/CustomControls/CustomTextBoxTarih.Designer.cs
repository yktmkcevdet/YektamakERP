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
            monthCalendar = new System.Windows.Forms.MonthCalendar();
            textBox = new CustomTextBox();
            SuspendLayout();
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new System.Drawing.Point(1, 30);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 5;
            monthCalendar.Visible = false;
            monthCalendar.DateSelected += monthCalendar_DateSelected;
            monthCalendar.Leave += monthCalendar_Leave;
            // 
            // textBox
            // 
            textBox.BackColor = System.Drawing.Color.White;
            textBox.BorderColor = System.Drawing.Color.Silver;
            textBox.BorderFocusColor = System.Drawing.Color.HotPink;
            textBox.BorderRadius = 5;
            textBox.BorderSize = 1;
            textBox.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox.ForeColor = System.Drawing.Color.Black;
            textBox.isPlaceHolder = false;
            textBox.Location = new System.Drawing.Point(0, 0);
            textBox.Multiline = false;
            textBox.Name = "textBox";
            textBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            textBox.PasswordChar = false;
            textBox.PlaceholderColor = System.Drawing.Color.DarkGray;
            textBox.PlaceholderText = "";
            textBox.ReadOnly = false;
            textBox.SelectionStart = 0;
            textBox.Size = new System.Drawing.Size(106, 32);
            textBox.TabIndex = 7;
            textBox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            textBox.TextCustom = "";
            textBox.UnderlinedStyle = false;
            textBox.KeyPress += textBox_KeyPress_1;
            textBox.Click += textBox_Click;
            textBox.Leave += textBox_Leave;
            textBox.Enter += textBox_Enter;
            // 
            // CustomTextBoxTarih
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(textBox);
            Controls.Add(monthCalendar);
            Margin = new System.Windows.Forms.Padding(1);
            Name = "CustomTextBoxTarih";
            Padding = new System.Windows.Forms.Padding(1);
            Size = new System.Drawing.Size(234, 191);
            Load += CustomTextBoxTarih_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private CustomTextBox textBox;
    }
}
