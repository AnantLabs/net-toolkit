using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;

namespace NET.Tools
{
    /// <summary>
    /// Represent a class to overwrite all default cursors
    /// </summary>
    public static class CustomDefaultCursors
    {
        /// <summary>
        /// Overwrite all default cursors while the application exists or <see cref="Dispose"/> is called.
        /// </summary>
        /// <param name="cursors">Cursor-Definition</param>
        public static void Initialize(IDictionary<CursorType, Cursor> cursors)
        {
            FieldInfo fieldInfo = typeof (Cursors).GetField("_stockCursors",
                                                            BindingFlags.GetField | BindingFlags.NonPublic |
                                                            BindingFlags.Static);
            Cursor[] cursorArray = (Cursor[]) fieldInfo.GetValue(null);

            foreach (CursorType cursorType in cursors.Keys)
            {
                cursorArray[(int) cursorType] = cursors[cursorType];
            }
        }

        /// <summary>
        /// Dispose the custom default cursors and reset the list to get the OS cursors
        /// </summary>
        public static void Dispose()
        {
            FieldInfo fieldInfo = typeof(Cursors).GetField("_stockCursors",
                                                            BindingFlags.GetField | BindingFlags.NonPublic |
                                                            BindingFlags.Static);
            Cursor[] cursorArray = (Cursor[])fieldInfo.GetValue(null);

            foreach (CursorType cursorType in Enum.GetValues(typeof(CursorType)))
            {
                cursorArray[(int) cursorType] = null;
            }
        }
    }
}
