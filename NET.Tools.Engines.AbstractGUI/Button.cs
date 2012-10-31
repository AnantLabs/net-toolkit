using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Represent a button in the abstract GUI framework
    /// </summary>
    public sealed class Button : Component
    {
        public event EventHandler Click;

        public Button()
        {
            InputHandler.MouseClick += new MouseEventHandler(InputHandler_MouseClick);
        }

        private void InputHandler_MouseClick(object sender, MouseEventArgs e)
        {
            if (Bounds.IsPointInRect(e.Position) && e.MouseButton != MouseButton.None)
            {
                Style.OnClick(this);
                if (Click != null)
                {
                    Click(this, new EventArgs());
                }
            }
        }

        protected override void OnPaint()
        {
            Style.Paint(this);
        }

        protected override void OnRepaint()
        {
            Style.Repaint(this);
        }
    }

    /// @}
}
