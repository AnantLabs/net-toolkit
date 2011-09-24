using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup abstractgui
    /// @{

    /// <summary>
    /// Represent the basic for a default abstract window
    /// 
    /// A window:
    /// - is not modal
    /// - have a close-, minimize- and maximize button
    /// - is resizeable
    /// - have no default buttons
    /// </summary>
    public abstract class AbstractWindow<StyleType> : AbstractFrame, IAbstractWindow
    {
        #region IAbstractWindow

        public virtual bool ShowMinimzeButton
        {
            get;
            set;
        }

        public virtual bool ShowMaximizeButton
        {
            get;
            set;
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

        /// <summary>
        /// Defines the bounds for the minimize button
        /// </summary>
        protected abstract Rectangle MinimizeButtonBounds { get; }
        /// <summary>
        /// Defines the bounds for the maximize button
        /// </summary>
        protected abstract Rectangle MaximizeButtonBounds { get; }
        /// <summary>
        /// Defines the maximum bounds of screen for maximize
        /// </summary>
        protected abstract Rectangle MaximumBounds { get; }

        public override Rectangle Bounds
        {
            get
            {
                if (WindowState == WindowState.Maximized)
                    return MaximumBounds;
                else
                    return base.Bounds;
            }
            set
            {
                if (WindowState == WindowState.Normal)
                    base.Bounds = value;
            }
        }

        public AbstractWindow()
            : base()
        {
            ShowMaximizeButton = true;
            ShowMinimzeButton = true;

            MouseUp += new System.Windows.Forms.MouseEventHandler(AbstractWindow_MouseUp);
        }

        private void AbstractWindow_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (MaximizeButtonBounds.IsPointInRect(e.Location))
                if (WindowState != WindowState.Maximized)
                    WindowState = WindowState.Maximized;
                else
                    WindowState = WindowState.Normal;
        }
    }

    /// @}
}
