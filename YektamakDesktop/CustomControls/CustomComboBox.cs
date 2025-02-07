using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Design;

namespace YektamakDesktop.CustomControls
{
    [DefaultEvent("OnSelectedIndexChanged")]
    public class CustomComboBox:UserControl
    {
        //Fields
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(230, 228, 245);
        private Color listTextColor = Color.DimGray;
        private Color borderColor = Color.MediumSlateBlue;
        private int borderSize = 1;

        //Items
        private ComboBox cmbList;
        private Label lblText;
        private Button btnIcon;


        public new Color BackColor { get => backColor; set { backColor = value; lblText.BackColor = backColor;btnIcon.BackColor = backColor; } }
        public Color IconColor { get => iconColor; set { iconColor = value; btnIcon.Invalidate();/*Redraw icon*/ } }
        public Color ListBackColor { get => listBackColor; set { listBackColor = value;cmbList.BackColor = listBackColor; } }
        public Color ListTextColor { get => listTextColor; set { listTextColor = value; cmbList.ForeColor = listTextColor; } }
        public Color BorderColor { get => borderColor; set { borderColor = value; base.BackColor = borderColor; } }
        public int BorderSize { get => borderSize; 
            set 
            { 
                borderSize = value; 
                this.Padding = new Padding(BorderSize);
                AdjustComboBoxDimensions();
            }
        }
        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                lblText.ForeColor = value;
            }
        }
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                lblText.Font = value;
                cmbList.Font = value;
                //Bu kontrolün Font özelliğini hem label hem combobox listesinde geçerli olacak şekilde ayarladık
                //İstenirse bu iki alt kontrolün font özellikleri ayrı ayrı da ayarlanabilirdi
            }
        }
        public string Texts
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }
        public ComboBoxStyle DropDownStyle
        {
            get { return cmbList.DropDownStyle; }
            set
            {
                if(cmbList.DropDownStyle != ComboBoxStyle.Simple)
                cmbList.DropDownStyle = value;
            }
        }

        //Data

        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]        
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items
        {
            get
            {
                return cmbList.Items;
            }
        }

        
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get
            {
                return cmbList.DataSource;
            }
            set
            {
                cmbList.DataSource = value;
            }
        }


        [DefaultValue(AutoCompleteMode.None)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                return cmbList.AutoCompleteMode;
            }
            set
            {
                cmbList.AutoCompleteMode = value;
            }
        }

        [DefaultValue(AutoCompleteSource.None)]        
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return cmbList.AutoCompleteSource;
            }
            set
            {
                cmbList.AutoCompleteSource = value;
            }
        }        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]        
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get
            {
                return cmbList.AutoCompleteCustomSource;
            }
            set
            {
                cmbList.AutoCompleteCustomSource = value;
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]        
        public int SelectedIndex
        {
            get
            {
                return cmbList.SelectedIndex;
            }
            set
            {
                cmbList.SelectedIndex = value;
            }
        }
        
        [Browsable(false)]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]        
        public object SelectedItem
        {
            get
            {
                return cmbList.SelectedItem;
            }
            set
            {
                cmbList.SelectedItem = value;
            }
        }



        //Events
        public event EventHandler OnSelectedIndexChanged;//Default event

        //Constructor
        public CustomComboBox()
        {
            cmbList= new ComboBox();
            lblText= new Label();
            btnIcon= new Button();
            this.SuspendLayout();

            //ComboBox: Dropdown list
            cmbList.BackColor= listBackColor;
            cmbList.Font = new Font(this.Font.Name, 10f);
            cmbList.ForeColor = listTextColor;
            cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);//Default event
            cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);//Refresh text

            //Button
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize= 0;
            btnIcon.BackColor= backColor;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click);//Open dropdown list
            btnIcon.Paint += new PaintEventHandler(Icon_Paint);//Draw icon

            //Label : Text
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.MiddleLeft;
            lblText.Padding = new Padding(8, 0, 0, 0);
            lblText.Font = new Font(this.Font.Name, 10f);
            lblText.Click += new EventHandler(Surface_Click);//Select combo box
            lblText.MouseEnter += new EventHandler(Surface_MouseEnter);
            lblText.MouseLeave += new EventHandler(Surface_MouseLeave);

            //User Control
            this.Controls.Add(lblText);//2
            this.Controls.Add(btnIcon);//1
            this.Controls.Add(cmbList);//0

            this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.ForeColor = Color.DimGray;
            this.Padding = new Padding(borderSize);//Border Size
            base.BackColor = borderColor;//Border Color
            this.ResumeLayout();
            AdjustComboBoxDimensions();
        }

        

        //Private methods
        private void AdjustComboBoxDimensions()
        {
            cmbList.Width = lblText.Width;//label genişliği ile aynı genişlikte
            cmbList.Location = new Point()
            {
                X = this.Width - this.Padding.Right - cmbList.Width,//cmbList'in en sol noktası
                Y = lblText.Bottom - cmbList.Height//Burayı anlamadım ama açılır liste tam label'ın altında konumlanıyor
            };
        }

        //Event methods
        private void Surface_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
            //Select combo box
            cmbList.Select();
            if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
                cmbList.DroppedDown = true;//Open dropdown list
        }

        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            //Fields
            int iconWidth = 14;
            int iconHeight = 6;
            var rectIcon = new Rectangle((btnIcon.Width - iconWidth) / 2, (btnIcon.Height - iconHeight) / 2, iconWidth, iconHeight);
            Graphics graph = e.Graphics;

            //Draw arrow down icon
            using(GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(iconColor, 2))
            {
                graph.SmoothingMode= SmoothingMode.AntiAlias;
                path.AddLine(rectIcon.X,rectIcon.Y,rectIcon.X+(iconWidth/2),rectIcon.Bottom);
                path.AddLine(rectIcon.X + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                graph.DrawPath(pen, path);
            }
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            //Open dropdown list
            cmbList.Select();
            cmbList.DroppedDown = true;
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            //Refresh text
            lblText.Text = cmbList.Text;
        }
        //Default event
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {//Combobox SelectedIndexChanged event'i olduğunda bizim OnSelectedIndexChanged event'ini de tetikliyoruz
            if (OnSelectedIndexChanged != null)
                OnSelectedIndexChanged.Invoke(sender, e);
            //Refresh text
            lblText.Text = cmbList.Text;
        }

        private void Surface_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void Surface_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        //Overridden methods
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimensions();
        }
    }
}
