using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SuikodenPSPTool
{
    public class TextProgressBar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams result = base.CreateParams;
                if (Environment.OSVersion.Platform == PlatformID.Win32NT
                    && Environment.OSVersion.Version.Major >= 6)
                {
                    result.ExStyle |= 0x02000000; // WS_EX_COMPOSITED 
                }

                return result;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x000F)
            {
                using (Graphics graphics = CreateGraphics())
                using (SolidBrush brush = new SolidBrush(ForeColor))
                {
                    SizeF textSize = graphics.MeasureString(Text, Font);
                    graphics.DrawString(Text, Font, brush, (Width - textSize.Width) / 2, (Height - textSize.Height) / 2);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Refresh();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                Refresh();
            }
        }
    }
}
