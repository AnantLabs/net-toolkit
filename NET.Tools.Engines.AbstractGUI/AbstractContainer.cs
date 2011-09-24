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
    /// Represent the basic for all container objects
    /// </summary>
    public abstract class AbstractContainer : AbstractComponent, IAbstractContainer
    {
        #region IAbstractContainer Member

        public IList<AbstractComponent> Children
        {
            get;
            private set;
        }

        #endregion

        public AbstractContainer()
            : base()
        {
            Children = new List<AbstractComponent>();
        }

        internal override void Draw(Point origin)
        {
            base.Draw(origin);

            foreach (AbstractComponent comp in Children)
                comp.Draw(Location + new Size(1, 1));
        }

        internal override bool HandleMouseInput(System.Windows.Forms.MouseEventArgs e)
        {
            foreach (AbstractComponent child in Children)
            {
                if (child.HandleMouseInput(e))
                    return true;
            }

            return base.HandleMouseInput(e);
        }
    }

    /// @}
}
