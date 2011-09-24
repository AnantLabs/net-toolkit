using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools.OS
{
    /// <summary>
    /// Helper class for message interpretation
    /// </summary>
    public static class MessageInterpreter
    {
        /// <summary>
        /// Try to interpret the message as wmCommand
        /// </summary>
        /// <param name="msg">The message to check</param>
        /// <returns>The wmCommandResult or null if it is not a wmCommand message</returns>
        public static WmCommandResult CheckWmCommand(Message msg)
        {
            if (!WmCommandResult.IsCommandMessage(msg))
                return null;

            return new WmCommandResult(msg);
        }
    }
}
