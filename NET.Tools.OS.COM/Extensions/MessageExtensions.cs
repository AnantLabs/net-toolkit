using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools.OS
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for Message
    /// </summary>
    public static class MessageExtensions
    {
        public static WmCommandResult CheckForWmCommand(this Message msg)
        {
            return MessageInterpreter.CheckWmCommand(msg);
        }
    }

    /// @}
}
