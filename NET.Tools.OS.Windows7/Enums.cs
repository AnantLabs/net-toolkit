using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.OS
{
    /// \addtogroup enums
    /// @{

    /// <summary>
    /// Progressbar style in taskbar
    /// </summary>
    public enum TaskbarProgressBarStyle
    {
        /// <summary>
        /// No progress to show
        /// </summary>
        NoProgress = 0,
        /// <summary>
        /// Indeterminate (endless)
        /// </summary>
        Indeterminate = 0x1,
        /// <summary>
        /// Normal progress style (green)
        /// </summary>
        Normal = 0x2,
        /// <summary>
        /// Error progress style (red)
        /// </summary>
        Error = 0x4,
        /// <summary>
        /// Paused progress style (yellow)
        /// </summary>
        Paused = 0x8
    }

    public enum TabBehavior
    {
        None = 0x0,
        UseAppThumbnailAlways = 0x1,
        UseAppThumbnailWhenActive = 0x2,
        UseAppPeekAlways = 0x4,
        UseAppPeekWhenActive = 0x8
    }

    internal enum ThumbButtonMask
    {
        Bitmap = 0x1,
        Icon = 0x2,
        Tooltip = 0x4,
        THB_FLAGS = 0x8
    }

    [Flags]
    internal enum ThumbButtonOptions
    {
        Enabled = 0x00000000,
        Disabled = 0x00000001,
        DismissOnClick = 0x00000002,
        NoBackground = 0x00000004,
        Hidden = 0x00000008,
        NonInteractive = 0x00000010
    }

    /// @}
}
