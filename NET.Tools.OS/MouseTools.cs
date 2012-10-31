using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NET.Tools.OS
{
    /// <summary>
    /// \addtogroup dlltools
    /// @{
    /// </summary>
    public static class MouseTools
    {
        /// <summary>
        /// Load a mouse cursor from a *.cur or *.ani file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Cursor LoadMouseCursor(String file)
        {
            return new Cursor(User32.LoadCursorFromFile(file));
        }

        /// <summary>
        /// Show the mouse cursor
        /// </summary>
        public static void ShowMouseCursor()
        {
            User32.ShowCursor(true);
        }

        /// <summary>
        /// Hide the mouse cursor
        /// </summary>
        public static void HideMouseCursor()
        {
            User32.ShowCursor(false);
        }

        /// <summary>
        /// Reset the mouse cursor area
        /// </summary>
        public static void ResetMouseCursorClipRect()
        {
            NativeRect rect = new NativeRect(0, 0, Screen.PrimaryScreen.Bounds.Right, Screen.PrimaryScreen.Bounds.Bottom);
            if (!User32.ClipCursor(ref rect))
                throw new ArgumentException("Cannot work with rect!");
        }

        /// <summary>
        /// Gets or sets area of mouse cursor
        /// </summary>
        public static Rectangle CursorArea
        {
            get
            {
                NativeRect rect = new NativeRect();
                if (!User32.GetClipCursor(out rect))
                    throw new InvalidOperationException("Cannot call GetClipCursor from user32.dll!");
                return rect;
            }
            set
            {
                NativeRect rect = value;
                if (!User32.ClipCursor(ref rect))
                    throw new ArgumentException("Cannot work with rect!");
            }
        }

        /// <summary>
        /// Set the given system cursor
        /// </summary>
        /// <param name="sysCursor">ID of system cursor</param>
        /// <param name="cursor">The new cursor image</param>
        public static void SetSystemCursor(SystemCursors sysCursor, Cursor cursor)
        {
            if (!User32.SetSystemCursor(cursor.Handle, (uint)sysCursor))
                throw new ArgumentException("There are a wrong argument!");
        }

        /// <summary>
        /// Gets or sets the mouse cursor position
        /// </summary>
        public static Point CursorPosition
        {
            get
            {
                NativePoint p = new NativePoint();
                if (!User32.GetCursorPos(out p))
                    throw new InvalidOperationException("Cannot call GetCursorPos from user32.dll!");
                return p;
            }
            set
            {
                if (!User32.SetCursorPos(value.X, value.Y))
                    throw new ArgumentException("Wrong arguments in function SetCursorPos from user32.dll!");
            }
        }
    }
    /// @}

    /// <summary>
    /// \addtogroup enums
    /// @{
    /// </summary>
    public enum SystemCursors : uint
    {
        AppStarting = 32650,
        Normal = 32512,
        Cross = 32515,
        Hand = 32649,
        Help = 32651,
        IBeam = 32513,
        No = 32648,
        SizeAll = 32646,
        SizeNESW = 32643,
        SizeNS = 32645,
        SizeNWSE = 32642,
        SizeWE = 32644,
        Up = 32516,
        Wait = 32514
    }
    /// @}
}
