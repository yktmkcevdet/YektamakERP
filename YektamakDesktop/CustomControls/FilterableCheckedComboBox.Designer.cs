using System.Windows.Forms;

namespace YektamakDesktop.CustomControls
{
    partial class FilterableCheckedComboBox
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private CustomDropDown dropDown;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBox = new TextBox();
            host = new CheckedListBox();
            dropDown = new CustomDropDown();
            dropDown.SuspendLayout();
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
            // host
            // 
            host.AccessibleName = "host";
            host.BorderStyle = BorderStyle.None;
            host.CheckOnClick = true;
            host.Location = new System.Drawing.Point(0, 0);
            host.Name = "host";
            host.Size = new System.Drawing.Size(120, 96);
            host.TabIndex = 0;
            // 
            // dropDown
            // 
            dropDown.InnerPadding = new Padding(4);
            dropDown.Items.AddRange(new ToolStripItem[] { host });
            dropDown.LayoutStyle = ToolStripLayoutStyle.Flow;
            dropDown.Name = "dropDown";
            dropDown.Size = new System.Drawing.Size(2, 4);
            // 
            // host
            // 
            host.Name = "host";
            host.Size = new System.Drawing.Size(120, 96);
            // 
            // FilterableCheckedComboBox
            // 
            Controls.Add(textBox);
            Name = "FilterableCheckedComboBox";
            Padding = new Padding(5);
            Size = new System.Drawing.Size(200, 30);
            dropDown.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        private CheckedListBox host;
        private ToolStripControlHost host;
    }
}
