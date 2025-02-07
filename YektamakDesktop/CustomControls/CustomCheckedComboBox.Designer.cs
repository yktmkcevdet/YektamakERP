namespace YektamakDesktop.CustomControls
{
    partial class CustomCheckedComboBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomCheckedComboBox));
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.panelDropDownButton = new System.Windows.Forms.Panel();
            this.textBox = new YektamakDesktop.CustomControls.CustomTextBox();
            this.SuspendLayout();
            // 
            // checkedListBox
            // 
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Location = new System.Drawing.Point(2, 30);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(250, 202);
            this.checkedListBox.TabIndex = 2;
            this.checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_ItemCheck);
            // 
            // panelDropDownButton
            // 
            this.panelDropDownButton.BackColor = System.Drawing.Color.Transparent;
            this.panelDropDownButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelDropDownButton.BackgroundImage")));
            this.panelDropDownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDropDownButton.Location = new System.Drawing.Point(224, 3);
            this.panelDropDownButton.Name = "panelDropDownButton";
            this.panelDropDownButton.Padding = new System.Windows.Forms.Padding(2);
            this.panelDropDownButton.Size = new System.Drawing.Size(25, 25);
            this.panelDropDownButton.TabIndex = 3;
            this.panelDropDownButton.Click += new System.EventHandler(this.panelDropDownButton_Click);
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.Window;
            this.textBox.BorderColor = System.Drawing.Color.Silver;
            this.textBox.BorderFocusColor = System.Drawing.Color.HotPink;
            this.textBox.BorderRadius = 10;
            this.textBox.BorderSize = 3;
            this.textBox.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox.ForeColor = System.Drawing.Color.DimGray;
            this.textBox.Location = new System.Drawing.Point(3, 0);
            this.textBox.Multiline = false;
            this.textBox.Name = "textBox";
            this.textBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.textBox.PasswordChar = false;
            this.textBox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.textBox.PlaceholderText = "";
            this.textBox.Size = new System.Drawing.Size(250, 32);
            this.textBox.TabIndex = 4;
            this.textBox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox.TextCustom = "";
            this.textBox.UnderlinedStyle = false;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.Key_Up += new System.Windows.Forms.KeyEventHandler(this.textBox_Key_Up);
            this.textBox.CustomEnter += new System.EventHandler(this.textBox_CustomEnter);
            this.textBox.CustomLeave += new System.EventHandler(this.textBox_CustomLeave);
            this.textBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // CustomCheckedComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panelDropDownButton);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.textBox);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CustomCheckedComboBox";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(254, 233);
            this.Load += new System.EventHandler(this.CustomCheckedComboBox_Load);
            this.FontChanged += new System.EventHandler(this.CustomCheckedComboBox_FontChanged);
            this.Leave += new System.EventHandler(this.CustomCheckedComboBox_Leave);
            this.MouseLeave += new System.EventHandler(this.CustomCheckedComboBox_MouseLeave);
            this.Resize += new System.EventHandler(this.CustomCheckedComboBox_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Panel panelDropDownButton;
        private CustomTextBox textBox;
    }
}
