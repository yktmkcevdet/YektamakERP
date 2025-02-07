namespace YektamakDesktop.CustomControls
{
    partial class CustomComboListBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomComboListBox));
            listBox = new System.Windows.Forms.ListBox();
            panelDropDownButton = new System.Windows.Forms.Panel();
            textBox = new CustomTextBox();
            SuspendLayout();
            // 
            // listBox
            // 
            listBox.FormattingEnabled = true;
            listBox.HorizontalScrollbar = true;
            listBox.ItemHeight = 15;
            listBox.Location = new System.Drawing.Point(2, 28);
            listBox.Name = "listBox";
            listBox.Size = new System.Drawing.Size(247, 199);
            listBox.TabIndex = 2;
            listBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
            listBox.Enter += listBox_Enter;
            listBox.Leave += listBox_Leave;
            listBox.MouseLeave += listBox_MouseLeave;
            // 
            // panelDropDownButton
            // 
            panelDropDownButton.BackColor = System.Drawing.Color.Transparent;
            panelDropDownButton.BackgroundImage = (System.Drawing.Image)resources.GetObject("panelDropDownButton.BackgroundImage");
            panelDropDownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panelDropDownButton.Location = new System.Drawing.Point(219, 3);
            panelDropDownButton.Name = "panelDropDownButton";
            panelDropDownButton.Padding = new System.Windows.Forms.Padding(2);
            panelDropDownButton.Size = new System.Drawing.Size(25, 27);
            panelDropDownButton.TabIndex = 3;
            panelDropDownButton.Click += panelDropDownButton_Click;
            panelDropDownButton.Enter += panelDropDownButton_Enter;
            panelDropDownButton.Leave += panelDropDownButton_Leave;
            // 
            // textBox
            // 
            textBox.BackColor = System.Drawing.Color.White;
            textBox.BorderColor = System.Drawing.Color.Silver;
            textBox.BorderFocusColor = System.Drawing.Color.HotPink;
            textBox.BorderRadius = 5;
            textBox.BorderSize = 2;
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
            textBox.Size = new System.Drawing.Size(223, 32);
            textBox.TabIndex = 4;
            textBox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            textBox.TextCustom = "";
            textBox.UnderlinedStyle = false;
            textBox.TextChanged += textBox_TextChanged;
            textBox.Key_Up += textBox_Key_Up;
            // 
            // CustomComboListBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            Controls.Add(panelDropDownButton);
            Controls.Add(textBox);
            Controls.Add(listBox);
            Margin = new System.Windows.Forms.Padding(1);
            Name = "CustomComboListBox";
            Padding = new System.Windows.Forms.Padding(1);
            Size = new System.Drawing.Size(251, 228);
            Load += CustomCheckedComboBox_Load;
            FontChanged += CustomCheckedComboBox_FontChanged;
            Leave += CustomCheckedComboBox_Leave;
            MouseLeave += CustomCheckedComboBox_MouseLeave;
            Resize += CustomCheckedComboBox_Resize;
            ResumeLayout(false);
        }

        #endregion
        //private System.Windows.Forms.CheckedListBox listBox;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Panel panelDropDownButton;
        public CustomTextBox textBox;
    }
}
