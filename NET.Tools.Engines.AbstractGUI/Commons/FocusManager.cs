using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    internal static class FocusManager
    {
        private static AbstractComponent focusateComponent = null;

        /// <summary>
        /// Set focus to given object
        /// </summary>
        /// <param name="comp"></param>
        /// <returns>TRUE if focus was changed</returns>
        public static bool SetFocus(AbstractComponent comp)
        {
            if (!comp.IsFocusable)
                return false;

            //Reset the focus of the active component
            focusateComponent.ResetFocus();
            //Set the new focusate component
            focusateComponent = comp;
            //Set the focus to the given component
            focusateComponent.SetFocus();
            return true;
        }

        /// <summary>
        /// Get active focusate object
        /// </summary>
        /// <returns></returns>
        public static AbstractComponent GetFocus()
        {
            return focusateComponent;
        }
    }
}
