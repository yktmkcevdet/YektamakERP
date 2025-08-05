using System.Drawing;

namespace YektamakDesktop
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            panelState = new System.Windows.Forms.Panel();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            lblOturumSuresi = new System.Windows.Forms.ToolStripStatusLabel();
            lblKullanici = new System.Windows.Forms.Label();
            panelAnaMenu = new System.Windows.Forms.Panel();
            panelMenu = new System.Windows.Forms.Panel();
            panelExit = new System.Windows.Forms.Panel();
            panelHandle = new System.Windows.Forms.Panel();
            headerPanel1 = new YektamakDesktop.CustomControls.HeaderPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panelState.SuspendLayout();
            statusStrip1.SuspendLayout();
            panelHandle.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel1.CausesValidation = false;
            tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panelHandle, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.940594F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.0594F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1149, 710);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.1356077F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.8643951F));
            tableLayoutPanel2.Controls.Add(panelState, 1, 1);
            tableLayoutPanel2.Controls.Add(panelAnaMenu, 0, 0);
            tableLayoutPanel2.Controls.Add(panelMenu, 1, 0);
            tableLayoutPanel2.Controls.Add(panelExit, 0, 1);
            tableLayoutPanel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            tableLayoutPanel2.Location = new Point(6, 50);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            tableLayoutPanel2.Size = new Size(1137, 654);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panelState
            // 
            panelState.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelState.Controls.Add(statusStrip1);
            panelState.Controls.Add(lblKullanici);
            panelState.Location = new Point(172, 609);
            panelState.Margin = new System.Windows.Forms.Padding(0);
            panelState.Name = "panelState";
            panelState.Size = new Size(965, 45);
            panelState.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblOturumSuresi });
            statusStrip1.Location = new Point(820, 20);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(144, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblOturumSuresi
            // 
            lblOturumSuresi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblOturumSuresi.ForeColor = Color.IndianRed;
            lblOturumSuresi.Name = "lblOturumSuresi";
            lblOturumSuresi.Size = new Size(127, 17);
            lblOturumSuresi.Text = "toolStripStatusLabel1";
            // 
            // lblKullanici
            // 
            lblKullanici.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblKullanici.ForeColor = Color.IndianRed;
            lblKullanici.Location = new Point(820, 2);
            lblKullanici.Name = "lblKullanici";
            lblKullanici.Size = new Size(142, 15);
            lblKullanici.TabIndex = 2;
            lblKullanici.Text = "label1";
            lblKullanici.TextAlign = ContentAlignment.TopRight;
            lblKullanici.Click += lblKullanici_Click;
            // 
            // panelAnaMenu
            // 
            panelAnaMenu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelAnaMenu.BackColor = Color.SteelBlue;
            panelAnaMenu.Location = new Point(0, 0);
            panelAnaMenu.Margin = new System.Windows.Forms.Padding(0);
            panelAnaMenu.Name = "panelAnaMenu";
            panelAnaMenu.Size = new Size(172, 609);
            panelAnaMenu.TabIndex = 0;
            // 
            // panelMenu
            // 
            panelMenu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelMenu.Location = new Point(172, 0);
            panelMenu.Margin = new System.Windows.Forms.Padding(0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(965, 609);
            panelMenu.TabIndex = 1;
            // 
            // panelExit
            // 
            panelExit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelExit.BackColor = Color.DodgerBlue;
            panelExit.Location = new Point(0, 609);
            panelExit.Margin = new System.Windows.Forms.Padding(0);
            panelExit.Name = "panelExit";
            panelExit.Size = new Size(172, 45);
            panelExit.TabIndex = 3;
            // 
            // panelHandle
            // 
            panelHandle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panelHandle.BackColor = Color.White;
            panelHandle.Controls.Add(headerPanel1);
            panelHandle.Location = new Point(4, 4);
            panelHandle.Margin = new System.Windows.Forms.Padding(1);
            panelHandle.Name = "panelHandle";
            panelHandle.Size = new Size(1141, 39);
            panelHandle.TabIndex = 1;
            panelHandle.MouseDown += panelHeader_MouseDown;
            panelHandle.MouseMove += panelHeader_MouseMove;
            panelHandle.MouseUp += panelHeader_MouseUp;
            // 
            // headerPanel1
            // 
            headerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            headerPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            headerPanel1.BackColor = Color.Firebrick;
            headerPanel1.Baslik = "Yektamak ERP Uygulaması";
            headerPanel1.Location = new Point(1, 1);
            headerPanel1.Margin = new System.Windows.Forms.Padding(1);
            headerPanel1.Name = "headerPanel1";
            headerPanel1.Padding = new System.Windows.Forms.Padding(1);
            headerPanel1.Size = new Size(1138, 32);
            headerPanel1.TabIndex = 0;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1149, 710);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Name = "MainWindow";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Ana Menü";
            Load += AnaSayfa_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panelState.ResumeLayout(false);
            panelState.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panelHandle.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelHandle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelAnaMenu;
        private System.Windows.Forms.Panel panelMenu;
        private CustomControls.HeaderPanel headerPanel1;
        private System.Windows.Forms.Panel panelState;
        private System.Windows.Forms.Panel panelExit;
        private System.Windows.Forms.Label lblKullanici;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblOturumSuresi;
    }
}