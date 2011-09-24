using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup abstractgui
    /// @{

    /// <summary>
    /// Represent the basic for a dialog
    /// 
    /// A dialog:
    /// - is modal
    /// - have only a close button
    /// - is not resizeable
    /// - have default buttons (ok, cancel)
    /// </summary>
    public abstract class AbstractDialog<StyleType> : AbstractFrame, IAbstractDialog
    {
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

        public AbstractDialog()
            : base()
        {
            WindowStateChanged += new System.ComponentModel.CancelEventHandler(AbstractDialog_WindowStateChanged);
        }

        private void AbstractDialog_WindowStateChanged(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (WindowState != WindowState.Normal)
                e.Cancel = true;
        }
    }

    /// @}
}
