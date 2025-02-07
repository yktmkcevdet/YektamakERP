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
            panelHandle = new System.Windows.Forms.Panel();
            panelHeader = new System.Windows.Forms.TableLayoutPanel();
            pictureBoxLogo = new System.Windows.Forms.PictureBox();
            labelHeader = new System.Windows.Forms.Label();
            buttomMinimize = new CustomControls.RoundedButton();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            panelAnaMenu = new System.Windows.Forms.Panel();
            panelMenu = new System.Windows.Forms.Panel();
            tableLayoutPanel1.SuspendLayout();
            panelHandle.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CausesValidation = false;
            tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panelHandle, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1149, 678);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panelHandle
            // 
            panelHandle.BackColor = System.Drawing.Color.White;
            panelHandle.Controls.Add(panelHeader);
            panelHandle.Location = new System.Drawing.Point(4, 4);
            panelHandle.Margin = new System.Windows.Forms.Padding(1);
            panelHandle.Name = "panelHandle";
            panelHandle.Size = new System.Drawing.Size(1141, 51);
            panelHandle.TabIndex = 1;
            panelHandle.MouseDown += panelHeader_MouseDown;
            panelHandle.MouseMove += panelHeader_MouseMove;
            panelHandle.MouseUp += panelHeader_MouseUp;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.DarkRed;
            panelHeader.ColumnCount = 4;
            panelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            panelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            panelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.52319F));
            panelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            panelHeader.Controls.Add(pictureBoxLogo, 0, 0);
            panelHeader.Controls.Add(labelHeader, 1, 0);
            panelHeader.Controls.Add(buttomMinimize, 3, 0);
            panelHeader.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            panelHeader.ForeColor = System.Drawing.Color.White;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.RowCount = 1;
            panelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            panelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            panelHeader.Size = new System.Drawing.Size(1141, 51);
            panelHeader.TabIndex = 0;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBoxLogo.Image = (System.Drawing.Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new System.Drawing.Point(3, 9);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new System.Drawing.Size(38, 32);
            pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // labelHeader
            // 
            labelHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.Location = new System.Drawing.Point(47, 15);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(107, 21);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Yektamak Erp";
            // 
            // buttomMinimize
            // 
            buttomMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttomMinimize.BackColor = System.Drawing.Color.DarkRed;
            buttomMinimize.BackgroundColor = System.Drawing.Color.DarkRed;
            buttomMinimize.BorderColor = System.Drawing.Color.LavenderBlush;
            buttomMinimize.BorderRadius = 10;
            buttomMinimize.BorderSize = 2;
            buttomMinimize.FlatAppearance.BorderSize = 0;
            buttomMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttomMinimize.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttomMinimize.ForeColor = System.Drawing.Color.White;
            buttomMinimize.Location = new System.Drawing.Point(1094, 7);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(7);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(40, 37);
            buttomMinimize.TabIndex = 99;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.1356077F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.8643951F));
            tableLayoutPanel2.Controls.Add(panelAnaMenu, 0, 0);
            tableLayoutPanel2.Controls.Add(panelMenu, 1, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            tableLayoutPanel2.Location = new System.Drawing.Point(6, 62);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new System.Drawing.Size(1137, 610);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panelAnaMenu
            // 
            panelAnaMenu.BackColor = System.Drawing.Color.Red;
            panelAnaMenu.Location = new System.Drawing.Point(3, 3);
            panelAnaMenu.Name = "panelAnaMenu";
            panelAnaMenu.Size = new System.Drawing.Size(166, 604);
            panelAnaMenu.TabIndex = 0;
            // 
            // panelMenu
            // 
            panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMenu.Location = new System.Drawing.Point(175, 3);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new System.Drawing.Size(959, 604);
            panelMenu.TabIndex = 1;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(1149, 678);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Name = "MainWindow";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form2";
            Load += AnaSayfa_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panelHandle.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelHandle;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TableLayoutPanel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedButton buttomMinimize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelAnaMenu;
        private System.Windows.Forms.Panel panelMenu;
    }
}