using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Represent a console component
    /// 
    /// <remarks>Note that the height for this objects is fixed default</remarks>
    /// </summary>
    public abstract class CMDComponent : CMDElement
    {
        private bool mouseClicked = false;

        public bool HasFocus { get; set; }
        public bool IsFocusbale { get; set; }

        public String Text { get; set; }
        public Point Location { get; set; }
        /// <summary>
        /// Gets or sets the size of this component
        /// </summary>
        public Size Size
        {
            get { return new Size(Width, Height); }
            set { Width = value.Width; Height = value.Height; }
        }
        /// <summary>
        /// Gets or sets the width of this component
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Gets or sets the height of this component
        /// </summary>
        public virtual int Height { get { return 1; } set { throw new NotSupportedException(); } }

        public CMDComponent()
            : base()
        {
            CMDApplication.MouseEvent += new MouseEventHandler(CMDApplication_MouseEvent);
        }

        private void CMDApplication_MouseEvent(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //Check for borders
            if ((e.X >= Location.X) && (e.X <= Location.X + Width) &&
                (e.Y >= Location.Y) && (e.Y <= Location.Y + Height))
            {
                //Check for mouse drag move
                if (e.Button != MouseButtons.None)
                {
                    OnMouseDragMove(e);

                    if (!mouseClicked)
                    {
                        mouseClicked = true;
                        OnMouseDown(e);
                    }
                }
                //Check for mouse move
                else
                {
                    OnMouseMove(e);

                    if (mouseClicked)
                    {
                        mouseClicked = false;
                        OnMouseUp(e);
                        OnClick();
                    }
                }
            }
        }
    }
}
