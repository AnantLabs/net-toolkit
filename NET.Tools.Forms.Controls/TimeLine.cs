//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using System.Drawing.Drawing2D;
//
//
//using System.Drawing.Design;

//namespace NET.Tools.Forms
//{
//    [ToolboxItemFilter("NET Tools")]
//    public partial class TimeLine : UserControl
//    {
//        private const int TIMELINE_HEIGHT = 25;
//        private const int TIMELINE_TICKER = 10;
//        private const int TIMELINE_NORMALTICKHEIGHT = 5;
//        private const int TIMELINE_LONGTICKHEIGHT = 10;

//        [Browsable(true)]
//        [Category("Appearance")]
//        [Description("Sets the brush from the timeline header")]
//        [Editor(typeof(UIBrushEditor), typeof(UITypeEditor))]
//        public Brush TimeLineHeaderBrush { get; set; }
//        [Browsable(true)]
//        [Category("Appearance")]
//        [Description("Sets the text brush from the timeline header")]
//        [Editor(typeof(UIBrushEditor), typeof(UITypeEditor))]
//        public Brush TimeLineHeaderTextBrush { get; set; }
//        [Browsable(true)]
//        [Category("Appearance")]
//        [Description("Sets the ticker color from the timeline header")]
//        public Color TimeLineHeaderTickColor { get; set; }
//        [Browsable(true)]
//        [Category("Appearance")]
//        [Description("Sets the background color from the timeline")]
//        public new Color BackColor
//        {
//            get { return pnlMain.BackColor; }
//            set { pnlMain.BackColor = value; }
//        }


//        [Browsable(true)]
//        [Category("Appearance")]
//        [Description("Sets the length of timeline")]
//        [DefaultValue(100)]
//        public int Seconds
//        {
//            get { return pnlMain.Width / 10; }
//            set { pnlMain.Width = value * 10; }
//        }

//        public TimeLine()
//        {
//            InitializeComponent();
//            DoubleBuffered = true;
//            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
//            MouseWheel += (s, e) =>
//            {
//                int delta = (e.Delta / 120) * 3;

                
//            };

//            TimeLineHeaderBrush = new LinearGradientBrush(
//                new Point(0, 0), new Point(0, TIMELINE_HEIGHT),
//                SystemColors.ActiveCaption, SystemColors.GradientActiveCaption);
//            TimeLineHeaderTextBrush = new SolidBrush(SystemColors.ActiveCaptionText);
//            TimeLineHeaderTickColor = SystemColors.ActiveCaptionText;
//            BackColor = SystemColors.AppWorkspace;
//        }

//        protected void PaintTimeLine(Graphics g)
//        {
//            g.SetClip(new Rectangle(
//                this.HorizontalScroll.Value, this.VerticalScroll.Value, 
//                this.Width, this.Height));

//            g.FillRectangle(TimeLineHeaderBrush, 0, 0, pnlMain.Width, TIMELINE_HEIGHT + 1);

//            for (int i = 0; i < pnlMain.Width / TIMELINE_TICKER + 1; i++)
//            {
//                if (i % 5 == 0)
//                {
//                    g.DrawLine(TimeLineHeaderTickColor.ToPen(),
//                        i * TIMELINE_TICKER, 
//                        TIMELINE_HEIGHT,
//                        i * TIMELINE_TICKER, 
//                        TIMELINE_HEIGHT - TIMELINE_LONGTICKHEIGHT);
//                    g.DrawString(i.ToString(), this.Font, TimeLineHeaderTextBrush,
//                        i * TIMELINE_TICKER - g.MeasureString(i.ToString(), this.Font).Width / 2, 
//                        0);
//                }
//                else
//                {
//                    g.DrawLine(TimeLineHeaderTickColor.ToPen(),
//                        i * TIMELINE_TICKER, 
//                        TIMELINE_HEIGHT,
//                        i * TIMELINE_TICKER, 
//                        TIMELINE_HEIGHT - TIMELINE_NORMALTICKHEIGHT);
//                }
//            }

//            g.ResetClip();
//        }

//        private void scroller_Scroll(object sender, ScrollEventArgs e)
//        {
//            Refresh();
//        }

//        private void pnlMain_Paint(object sender, PaintEventArgs e)
//        {
//            PaintTimeLine(e.Graphics);
//        }
//    }
//}
