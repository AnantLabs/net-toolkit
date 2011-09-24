using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup abstractgui
    /// @{

    /// <summary>
    /// Represent a abstract frame button
    /// </summary>
    /// <typeparam name="StyleType">Type for the style</typeparam>
    public abstract class AbstractFrameButton<StyleType> : AbstractButton<StyleType>
    {
        /// <summary>
        /// <b>This property returns always false. The setter is not supported</b>
        /// </summary>
        public override bool IsFocusable
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public AbstractFrameButton()
            : base()
        {
        }
    }

    /// @}
}
