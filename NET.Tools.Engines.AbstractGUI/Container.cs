using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup extensions
    /// @{

    public abstract class Container : Component
    {
        public List<Component> ChildComponentList { get; private set; }

        protected Container()
        {
            ChildComponentList = new List<Component>();
        }

        protected sealed override void OnPaint()
        {
            InternalPaint();
            foreach (Component component in ChildComponentList)
            {
                component.Paint();
            }
        }

        protected sealed override void OnRepaint()
        {
            InternalRepaint();
            foreach (Component component in ChildComponentList)
            {
                component.Repaint();
            }
        }

        public override bool IsFocusable
        {
            get { return false; }
            set { throw new NotSupportedException(); }
        }

        protected abstract void InternalPaint();
        protected abstract void InternalRepaint();
    }

    /// @}
}
