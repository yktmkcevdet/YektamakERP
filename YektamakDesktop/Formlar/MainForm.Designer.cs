namespace YektamakDesktop.Formlar
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            pnlLeftMenu = new System.Windows.Forms.Panel();
            treeMenu = new System.Windows.Forms.TreeView();
            pnlTopMenu = new System.Windows.Forms.Panel();
            flowTopMenu = new System.Windows.Forms.FlowLayoutPanel();
            tabMain = new System.Windows.Forms.TabControl();
            btnToggleMenu = new System.Windows.Forms.Button();
            btnTabs = new System.Windows.Forms.Button();
            tabContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            pnlLeftMenu.SuspendLayout();
            pnlTopMenu.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pnlLeftMenu, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlTopMenu, 1, 1);
            tableLayoutPanel1.Controls.Add(tabMain, 1, 0);
            tableLayoutPanel1.Controls.Add(btnToggleMenu, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1162, 727);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlLeftMenu
            // 
            pnlLeftMenu.Controls.Add(treeMenu);
            pnlLeftMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlLeftMenu.Location = new System.Drawing.Point(3, 3);
            pnlLeftMenu.Name = "pnlLeftMenu";
            pnlLeftMenu.Size = new System.Drawing.Size(194, 691);
            pnlLeftMenu.TabIndex = 0;
            // 
            // treeMenu
            // 
            treeMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            treeMenu.Location = new System.Drawing.Point(0, 0);
            treeMenu.Name = "treeMenu";
            treeMenu.Size = new System.Drawing.Size(194, 691);
            treeMenu.TabIndex = 0;
            treeMenu.MouseEnter += treeMenu_MouseEnter;
            treeMenu.MouseLeave += treeMenu_MouseLeave;
            // 
            // pnlTopMenu
            // 
            pnlTopMenu.Controls.Add(flowTopMenu);
            pnlTopMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlTopMenu.Location = new System.Drawing.Point(203, 700);
            pnlTopMenu.Name = "pnlTopMenu";
            pnlTopMenu.Size = new System.Drawing.Size(956, 24);
            pnlTopMenu.TabIndex = 1;
            // 
            // flowTopMenu
            // 
            flowTopMenu.AutoScroll = true;
            flowTopMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            flowTopMenu.Location = new System.Drawing.Point(0, 0);
            flowTopMenu.Name = "flowTopMenu";
            flowTopMenu.Size = new System.Drawing.Size(956, 24);
            flowTopMenu.TabIndex = 0;
            flowTopMenu.WrapContents = false;
            // 
            // tabMain
            // 
            tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tabMain.Location = new System.Drawing.Point(203, 3);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new System.Drawing.Size(956, 691);
            tabMain.TabIndex = 2;
            // 
            // btnToggleMenu
            // 
            btnToggleMenu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnToggleMenu.Location = new System.Drawing.Point(171, 700);
            btnToggleMenu.Name = "btnToggleMenu";
            btnToggleMenu.Size = new System.Drawing.Size(26, 23);
            btnToggleMenu.TabIndex = 1;
            btnToggleMenu.Text = "☰";
            btnToggleMenu.UseVisualStyleBackColor = true;
            btnToggleMenu.Click += btnToggleMenu_Click;
            // 
            // btnTabs
            // 
            btnTabs.Location = new System.Drawing.Point(3, 3);
            btnTabs.Name = "btnTabs";
            btnTabs.Size = new System.Drawing.Size(108, 23);
            btnTabs.TabIndex = 3;
            btnTabs.Text = "Açık Sekmeler";
            btnTabs.UseVisualStyleBackColor = true;
            // 
            // tabContextMenu
            // 
            tabContextMenu.Name = "tabContextMenu";
            tabContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1162, 727);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            pnlLeftMenu.ResumeLayout(false);
            pnlTopMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlLeftMenu;
        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.FlowLayoutPanel flowTopMenu;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.ContextMenuStrip tabContextMenu;
        private System.Windows.Forms.Button btnTabs;
        private System.Windows.Forms.TreeView treeMenu;
        private System.Windows.Forms.Button btnToggleMenu;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}