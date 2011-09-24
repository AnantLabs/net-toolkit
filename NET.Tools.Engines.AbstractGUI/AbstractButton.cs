using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup abstractgui
    /// @{

    /// <summary>
    /// Represent the basic for an abstract button
    /// </summary>
    /// <typeparam name="StyleType"></typeparam>
    public abstract class AbstractButton<StyleType> : AbstractComponent, IAbstractButton
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

        public AbstractButton()
            : base()
        {
            IsDefault = false;
            IsCancel = false;
        }

        #region IAbstractButton Member

        public bool IsDefault
        {
            get;
            set;
        }

        public bool IsCancel
        {
            get;
            set;
        }

        #endregion
    }

    /// @}
}
