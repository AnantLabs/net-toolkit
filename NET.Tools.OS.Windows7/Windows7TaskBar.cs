using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools.OS
{
    internal static class Windows7TaskBar
    {
        private static ITaskbarList4 taskbar = null;

        static Windows7TaskBar()
        {
            try
            {
                Log.Info("Try to initialize Windows 7 Taskbar...");
                taskbar = (ITaskbarList4)new TaskbarList();
                taskbar.HrInit();
                Log.Info(">>> OK");
            }
            catch (Exception e)
            {
                taskbar = null;
                Log.Warn("WARN: Cannot create windows 7 taskbar:\n" + e.Message);
                Log.Info("Ignore commands for windows 7 taskbar!");
            }
        }

        public static bool IsInitialized
        {
            get { return taskbar != null; }
        }

        public static void SetProgressStyle(IntPtr hwnd, TaskbarProgressBarStyle style)
        {
            if (IsInitialized)
                taskbar.SetProgressState(hwnd, style);
        }

        public static void SetProgressValue(IntPtr hwnd, ulong value, ulong max)
        {
            if (IsInitialized)
                taskbar.SetProgressValue(hwnd, value, max);
        }

        public static void AddThumbnailButtons(IntPtr hwnd, params ThumbButton[] buttons)
        {
            if (IsInitialized)
            {
                HResult res = taskbar.ThumbBarAddButtons(hwnd, (uint)buttons.Length, buttons);
                if (res != HResult.Ok)
                    throw new COMException("Cannot add thumbnail button(s): " + res);
            }
        }

        public static void UpdateThumbnailButtons(IntPtr hwnd, params ThumbButton[] buttons)
        {
            if (IsInitialized)
            {
                HResult res = taskbar.ThumbBarUpdateButtons(hwnd, (uint)buttons.Length, buttons);
                if (res != HResult.Ok)
                    throw new COMException("Cannot update thumbnail button(s): " + res);
            }
        }

        public static void RegisterTab(IntPtr parent, IntPtr child)
        {
            if (IsInitialized)
                taskbar.RegisterTab(child, parent);
        }

        public static void UnregisterTab(IntPtr child)
        {
            if (IsInitialized)
                taskbar.UnregisterTab(child);
        }

        public static void SetTabProperties(IntPtr child, TabBehavior behavior)
        {
            if (IsInitialized)
                taskbar.SetTabProperties(child, behavior);
        }

        public static void SetTabOrder(IntPtr child, IntPtr insertBefore)
        {
            if (IsInitialized)
                taskbar.SetTabOrder(child, insertBefore);
        }

        public static void SetTabActive(IntPtr child, IntPtr insertBefore)
        {
            if (IsInitialized)
                taskbar.SetTabActive(child, insertBefore, 0);
        }

        public static void SetOverlayIcon(IntPtr hwnd, IntPtr icon, string description)
        {
            if (IsInitialized)
                taskbar.SetOverlayIcon(hwnd, icon, description);
        }

        public static void SetThumbnailClip(IntPtr hwnd, NativeRect? rect)
        {
            if (IsInitialized)
            {
                if (rect.HasValue)
                {
                    IntPtr rectPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(rect));
                    try
                    {
                        Marshal.StructureToPtr(rect, rectPtr, true);
                        taskbar.SetThumbnailClip(hwnd, rectPtr);
                    }
                    finally
                    {
                        Marshal.FreeCoTaskMem(rectPtr);
                    }
                }
                else
                    taskbar.SetThumbnailClip(hwnd, IntPtr.Zero);
            }
        }

        public static void SetThumbnailToolTip(IntPtr hwnd, string tooltip)
        {
            if (IsInitialized)
                taskbar.SetThumbnailTooltip(hwnd, tooltip);
        }
    }
}
