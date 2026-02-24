using System.Windows.Forms;

namespace YektamakDesktop.CustomControls
{
    partial class FilterableCheckedComboBox
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.ToolStripDropDown dropDown;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBox = new TextBox();
            checkedListBox = new CheckedListBox();
            dropDown = new ToolStripDropDown();
            SuspendLayout();
            // 
            // textBox
            // 
            textBox.BorderStyle = BorderStyle.None;
            textBox.Dock = DockStyle.Fill;
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Name = "textBox";
            textBox.Size = new System.Drawing.Size(190, 16);
            textBox.TabIndex = 1;
            // 
            // checkedListBox
            // 
            checkedListBox.AllowDrop = true;
            checkedListBox.BorderStyle = BorderStyle.None;
            checkedListBox.CheckOnClick = true;
            checkedListBox.Location = new System.Drawing.Point(0, 0);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new System.Drawing.Size(120, 96);
            checkedListBox.TabIndex = 0;
            // 
            // dropDown
            // 
            dropDown.LayoutStyle = ToolStripLayoutStyle.Flow;
            dropDown.Name = "dropDown";
            dropDown.Padding = new Padding(0);
            dropDown.Size = new System.Drawing.Size(0, 0);
            // 
            // FilterableCheckedComboBox
            // 
            Controls.Add(textBox);
            Name = "FilterableCheckedComboBox";
            Padding = new Padding(5);
            Size = new System.Drawing.Size(200, 30);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
