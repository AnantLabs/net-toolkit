using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup abstractgui
    /// @{

    /// <summary>
    /// Represent the basic for a desktop
    /// 
    /// This is the main object for all rendering in abstract gui
    /// </summary>
    public abstract class AbstractDesktop<StyleType> : AbstractComponent, IAbstractDesktop
    {

        #region IAbstractDesktop Member

        private IList<AbstractFrame> frameList;

        public void Paint()
        {
            Draw(new Point(0, 0));

            foreach (AbstractFrame frames in frameList)
                frames.Draw(new Point(0, 0));
        }

        #endregion

        public override IAbstractStyle Style
        {
            get
            {
                return base.Style;
            }
            set
            {
                if ((value is StyleType))
                    base.Style = value;
                else
                    throw new NotSupportedException("Only type '" + typeof(StyleType).Name + "' is allowed!");
            }
        }

        protected StyleType InternalStyle
        {
            get { return (StyleType)Style; }
        }

        public AbstractDesktop()
            : base()
        {
            frameList = new List<AbstractFrame>();
        }

        public void Show(AbstractFrame frame)
        {
            if (!frameList.Contains(frame))
                frameList.Add(frame);
            else
            {
                frameList.Remove(frame);
                frameList.Add(frame);
            }
        }

        public void Hide(AbstractFrame frame)
        {
            frameList.Remove(frame);
        }

        protected void HandleMouseInput(object sender, MouseEventArgs e)
        {
            for (int i = frameList.Count - 1; i >= 0; i--)
            {
                if (frameList[i].HandleMouseInput(e))
                    break;
            }
        }
    }

    /// @}
}
