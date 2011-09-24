using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.OS
{
    /// <summary>
    /// \addtogroup dlltools
    /// @{
    /// </summary>
    public static class MessageTools
    {
        public static void MessageBeep(MessageType type)
        {
            User32.MessageBeep((uint)type);
        }

        public static int MessageBox(int hwnd, String text, String caption, MessageType type)
        {
            return User32.MessageBox(hwnd, text, caption, (uint)type);
        }

        public static int MessageBox(String text, String caption, MessageType type)
        {
            return MessageBox(0, text, caption, type);
        }

        public static int MessageBox(String text, String caption)
        {
            return MessageBox(text, caption, MessageType.OK);
        }
    }
    /// @}

    /// <summary>
    /// \addtogroup enums
    /// @{
    /// </summary>
    public enum MessageType : uint
    {
        ERROR = User32.SOUND_ERROR,
        INFO = User32.SOUND_INFO,
        QUESTION = User32.SOUND_QUESTION,
        WARN = User32.SOUND_WARN,
        OK = User32.SOUND_OK
    }
    /// @}
}
