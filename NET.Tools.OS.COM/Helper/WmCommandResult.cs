using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Forms;

namespace NET.Tools.OS
{
    /// <summary>
    /// Represent a wmCommand result from this message
    /// </summary>
    public sealed class WmCommandResult
    {
        #region Static

        internal static bool IsCommandMessage(Message msg)
        {
            return msg.Msg == COMConstants.COMCommands.WmCommand;
        }

        #endregion

        public MouseAction MouseAction { get; private set; }
        public uint ID { get; private set; }

        internal WmCommandResult(Message msg)
        {
            if (msg.Msg != COMConstants.COMCommands.WmCommand)
                throw new ArgumentException("Cannot interpret this message: Not a WmCommand!");

            switch ((short)(msg.WParam.ToInt64() >> 16))
            {
                case COMConstants.COMInput.COMMouse.Clicked:
                    MouseAction = MouseAction.Clicked;
                    break;
            }

            ID = (uint)((short)msg.WParam.ToInt32());
        }
    }

    public enum MouseAction
    {
        Clicked = COMConstants.COMInput.COMMouse.Clicked
    }
}
