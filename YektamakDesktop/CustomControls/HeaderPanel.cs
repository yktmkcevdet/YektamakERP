using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace YektamakDesktop.CustomControls
{
    public partial class HeaderPanel : UserControl
    {
        Form parentForm;
        [Browsable(true)]
        [Description("Help Buton")]
        [Category("Yektamak Custom Controls")]
        [DefaultValue(false)]
        public bool IsHelp { get; set; }

        [Browsable(true)]
        [Description("Minimize Buton")]
        [Category("Yektamak Custom Controls")]
        [DefaultValue(true)]
        public bool IsMinimize { get; set; } = true;
        [Browsable(true)]
        [Description("Close Buton")]
        [Category("Yektamak Custom Controls")]
        [DefaultValue(true)]
        public bool IsClose { get; set; } = true;
        public HeaderPanel()
        {
            InitializeComponent();
            btnHelp.Visible = IsHelp;
            btnMinimize.Visible = IsMinimize;
            btnClose.Visible = IsClose;
        }

        #region mouseDrag
        bool mouseDown;
        private Point offset;

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            parentForm = this.FindForm();
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreepPos = PointToScreen(e.Location);
                parentForm.Location = new Point(currentScreepPos.X - offset.X, currentScreepPos.Y - offset.Y);
            }
        }
        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        #endregion mouseDrag



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue("")]
        [Description("Üst başlık metni")]
        [Browsable(true)]
        public string Baslik
        {
            get => lblHdr.Text;
            set
            {
                lblHdr.Text = value;
                if (this.DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    Invalidate();
            }
        }
        private void roundedButton4_Click(object sender, EventArgs e)
        {
            parentForm = this.FindForm();
            if (parentForm is Form form)
            {
                form.Close();
                form.Dispose();
                form = null;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            parentForm = this.FindForm();
            parentForm.WindowState = FormWindowState.Minimized;
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            parentForm = this.FindForm();
            parentForm.WindowState= parentForm.WindowState == FormWindowState.Maximized 
                ? FormWindowState.Normal 
                : FormWindowState.Maximized;
        }
    }
}
