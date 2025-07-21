using Models.Interface;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar.Genel
{
    partial class AnaVeriTanimlamaFormu<T> : Form, IForm where T : class, IBaseEntity, new()
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
            panelHeader = new System.Windows.Forms.Panel();
            buttonClose = new CustomControls.RoundedButton();
            buttomMinimize = new CustomControls.RoundedButton();
            roundedButton6 = new CustomControls.RoundedButton();
            btnClose = new CustomControls.RoundedButton();
            btnMinimize = new CustomControls.RoundedButton();
            roundedButton3 = new CustomControls.RoundedButton();
            bntHelp = new CustomControls.RoundedButton();
            labelHeader = new System.Windows.Forms.Label();
            roundedButton1 = new CustomControls.RoundedButton();
            roundedButton2 = new CustomControls.RoundedButton();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.Firebrick;
            panelHeader.Controls.Add(buttonClose);
            panelHeader.Controls.Add(buttomMinimize);
            panelHeader.Controls.Add(roundedButton6);
            panelHeader.Controls.Add(btnClose);
            panelHeader.Controls.Add(btnMinimize);
            panelHeader.Controls.Add(roundedButton3);
            panelHeader.Controls.Add(bntHelp);
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Controls.Add(roundedButton1);
            panelHeader.Controls.Add(roundedButton2);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(800, 32);
            panelHeader.TabIndex = 9;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonClose.BackColor = System.Drawing.Color.Firebrick;
            buttonClose.BackgroundColor = System.Drawing.Color.Firebrick;
            buttonClose.BorderColor = System.Drawing.Color.Firebrick;
            buttonClose.CornerRadius = 10;
            buttonClose.BorderSize = 2;
            buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttonClose.ForeColor = System.Drawing.Color.White;
            buttonClose.Location = new System.Drawing.Point(765, 3);
            buttonClose.Margin = new System.Windows.Forms.Padding(0);
            buttonClose.Name = "buttonClose";
            buttonClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttonClose.Size = new System.Drawing.Size(29, 27);
            buttonClose.TabIndex = 109;
            buttonClose.Text = "X";
            buttonClose.TextColor = System.Drawing.Color.White;
            buttonClose.UseVisualStyleBackColor = false;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttomMinimize
            // 
            buttomMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttomMinimize.BackColor = System.Drawing.Color.Firebrick;
            buttomMinimize.BackgroundColor = System.Drawing.Color.Firebrick;
            buttomMinimize.BorderColor = System.Drawing.Color.Firebrick;
            buttomMinimize.CornerRadius = 10;
            buttomMinimize.BorderSize = 2;
            buttomMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            buttomMinimize.FlatAppearance.BorderSize = 0;
            buttomMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttomMinimize.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            buttomMinimize.ForeColor = System.Drawing.Color.White;
            buttomMinimize.Location = new System.Drawing.Point(725, 3);
            buttomMinimize.Margin = new System.Windows.Forms.Padding(0);
            buttomMinimize.Name = "buttomMinimize";
            buttomMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            buttomMinimize.Size = new System.Drawing.Size(29, 27);
            buttomMinimize.TabIndex = 107;
            buttomMinimize.Text = "-";
            buttomMinimize.TextColor = System.Drawing.Color.White;
            buttomMinimize.UseVisualStyleBackColor = false;
            buttomMinimize.Click += buttomMinimize_Click;
            // 
            // roundedButton6
            // 
            roundedButton6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            roundedButton6.BackColor = System.Drawing.Color.Firebrick;
            roundedButton6.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton6.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton6.CornerRadius = 10;
            roundedButton6.BorderSize = 2;
            roundedButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            roundedButton6.FlatAppearance.BorderSize = 0;
            roundedButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton6.ForeColor = System.Drawing.Color.White;
            roundedButton6.Location = new System.Drawing.Point(685, 3);
            roundedButton6.Margin = new System.Windows.Forms.Padding(0);
            roundedButton6.Name = "roundedButton6";
            roundedButton6.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton6.Size = new System.Drawing.Size(29, 27);
            roundedButton6.TabIndex = 108;
            roundedButton6.Text = "?";
            roundedButton6.TextColor = System.Drawing.Color.White;
            roundedButton6.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnClose.BackColor = System.Drawing.Color.Firebrick;
            btnClose.BackgroundColor = System.Drawing.Color.Firebrick;
            btnClose.BorderColor = System.Drawing.Color.Firebrick;
            btnClose.CornerRadius = 10;
            btnClose.BorderSize = 2;
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Location = new System.Drawing.Point(1412, 2);
            btnClose.Margin = new System.Windows.Forms.Padding(0);
            btnClose.Name = "btnClose";
            btnClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            btnClose.Size = new System.Drawing.Size(29, 27);
            btnClose.TabIndex = 103;
            btnClose.Text = "X";
            btnClose.TextColor = System.Drawing.Color.White;
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnMinimize.BackColor = System.Drawing.Color.Firebrick;
            btnMinimize.BackgroundColor = System.Drawing.Color.Firebrick;
            btnMinimize.BorderColor = System.Drawing.Color.Firebrick;
            btnMinimize.CornerRadius = 10;
            btnMinimize.BorderSize = 2;
            btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMinimize.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnMinimize.ForeColor = System.Drawing.Color.White;
            btnMinimize.Location = new System.Drawing.Point(1372, 2);
            btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            btnMinimize.Size = new System.Drawing.Size(29, 27);
            btnMinimize.TabIndex = 101;
            btnMinimize.Text = "-";
            btnMinimize.TextColor = System.Drawing.Color.White;
            btnMinimize.UseVisualStyleBackColor = false;
            // 
            // roundedButton3
            // 
            roundedButton3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            roundedButton3.BackColor = System.Drawing.Color.Firebrick;
            roundedButton3.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton3.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton3.CornerRadius = 10;
            roundedButton3.BorderSize = 2;
            roundedButton3.FlatAppearance.BorderSize = 0;
            roundedButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton3.ForeColor = System.Drawing.Color.White;
            roundedButton3.Location = new System.Drawing.Point(2499, 1);
            roundedButton3.Margin = new System.Windows.Forms.Padding(0);
            roundedButton3.Name = "roundedButton3";
            roundedButton3.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton3.Size = new System.Drawing.Size(29, 27);
            roundedButton3.TabIndex = 100;
            roundedButton3.Text = "X";
            roundedButton3.TextColor = System.Drawing.Color.White;
            roundedButton3.UseVisualStyleBackColor = false;
            // 
            // bntHelp
            // 
            bntHelp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            bntHelp.BackColor = System.Drawing.Color.Firebrick;
            bntHelp.BackgroundColor = System.Drawing.Color.Firebrick;
            bntHelp.BorderColor = System.Drawing.Color.Firebrick;
            bntHelp.CornerRadius = 10;
            bntHelp.BorderSize = 2;
            bntHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            bntHelp.FlatAppearance.BorderSize = 0;
            bntHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            bntHelp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            bntHelp.ForeColor = System.Drawing.Color.White;
            bntHelp.Location = new System.Drawing.Point(1332, 2);
            bntHelp.Margin = new System.Windows.Forms.Padding(0);
            bntHelp.Name = "bntHelp";
            bntHelp.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            bntHelp.Size = new System.Drawing.Size(29, 27);
            bntHelp.TabIndex = 102;
            bntHelp.Text = "?";
            bntHelp.TextColor = System.Drawing.Color.White;
            bntHelp.UseVisualStyleBackColor = false;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelHeader.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            labelHeader.Location = new System.Drawing.Point(12, 6);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new System.Drawing.Size(110, 17);
            labelHeader.TabIndex = 1;
            labelHeader.Text = "Stok Kart Tanımı";
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            roundedButton1.BackColor = System.Drawing.Color.Firebrick;
            roundedButton1.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton1.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton1.CornerRadius = 10;
            roundedButton1.BorderSize = 2;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton1.ForeColor = System.Drawing.Color.White;
            roundedButton1.Location = new System.Drawing.Point(2459, 1);
            roundedButton1.Margin = new System.Windows.Forms.Padding(0);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton1.Size = new System.Drawing.Size(29, 27);
            roundedButton1.TabIndex = 98;
            roundedButton1.Text = "-";
            roundedButton1.TextColor = System.Drawing.Color.White;
            roundedButton1.UseVisualStyleBackColor = false;
            // 
            // roundedButton2
            // 
            roundedButton2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            roundedButton2.BackColor = System.Drawing.Color.Firebrick;
            roundedButton2.BackgroundColor = System.Drawing.Color.Firebrick;
            roundedButton2.BorderColor = System.Drawing.Color.Firebrick;
            roundedButton2.CornerRadius = 10;
            roundedButton2.BorderSize = 2;
            roundedButton2.FlatAppearance.BorderSize = 0;
            roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            roundedButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            roundedButton2.ForeColor = System.Drawing.Color.White;
            roundedButton2.Location = new System.Drawing.Point(2419, 1);
            roundedButton2.Margin = new System.Windows.Forms.Padding(0);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            roundedButton2.Size = new System.Drawing.Size(29, 27);
            roundedButton2.TabIndex = 99;
            roundedButton2.Text = "?";
            roundedButton2.TextColor = System.Drawing.Color.White;
            roundedButton2.UseVisualStyleBackColor = false;
            // 
            // AnaVeriTanimlamaFormu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(460, 450);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "AnaVeriTanimlamaFormu";
            Text = "AnaVeriTanimlamaFormu";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            StartPosition=FormStartPosition.CenterScreen;
            ResumeLayout(false);
            this.ControlBox = false;
            this.Text = "";
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private CustomControls.RoundedButton btnClose;
        private CustomControls.RoundedButton btnMinimize;
        private CustomControls.RoundedButton roundedButton3;
        private CustomControls.RoundedButton bntHelp;
        private System.Windows.Forms.Label labelHeader;
        private CustomControls.RoundedButton roundedButton1;
        private CustomControls.RoundedButton roundedButton2;
        private CustomControls.RoundedButton buttonClose;
        private CustomControls.RoundedButton buttomMinimize;
        private CustomControls.RoundedButton roundedButton6;
    }
}