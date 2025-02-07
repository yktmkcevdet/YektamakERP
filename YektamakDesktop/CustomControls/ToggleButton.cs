using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace YektamakDesktop.CustomControls
{
    public class ToggleButton:CheckBox
    {
        private Color onBackColor = Color.MediumSlateBlue;
        private Color onToggleColor = Color.WhiteSmoke;
        private Color offBackColor = Color.Gray;
        private Color offToggleColor = Color.Gainsboro;

        public Color OnBackColor { get => onBackColor; set { onBackColor = value;this.Invalidate(); } }
        public Color OnToggleColor { get => onToggleColor; set { onToggleColor = value; this.Invalidate(); } }
        public Color OffBackColor { get => offBackColor; set { offBackColor = value; this.Invalidate(); } }
        public Color OffToggleColor { get => offToggleColor; set { offToggleColor = value; this.Invalidate(); } }

        public ToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
        }


        private GraphicsPath GetFigurePath()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc=new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc=new Rectangle(this.Width-arcSize-2, 0, arcSize, arcSize);
            
            GraphicsPath path=new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize=this.Height- 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            if (this.Checked)//ON
            {
                //Draw the control surface
                pevent.Graphics.FillPath(new SolidBrush(OnBackColor), GetFigurePath());
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(OnToggleColor), new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else //OFF
            {
                //Draw the control surface
                pevent.Graphics.FillPath(new SolidBrush(OffBackColor), GetFigurePath());
                //Draw the toggle
                pevent.Graphics.FillEllipse(new SolidBrush(OffToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}