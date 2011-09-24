using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Imaging;

namespace NET.Tools.OS
{
    /// <summary>
    /// \defgroup enums Enumerations
    /// \addtogroup enums
    /// @{
    /// </summary>
    public enum WallpaperStyle
    {
        Tiled = 0,
        Centered = 1,
        Streched = 2
    }

    public enum RotateDesktopMode : int
    {
        None = 0,
        Rotate90 = 1,
        Rotate180 = 2,
        Rotate270 = 3
    }

    public enum ChangeSettingsResult : int
    {
        Successful = User32.DISP_CHANGE_SUCCESSFUL,
        Restart = User32.DISP_CHANGE_RESTART,
        Failed = User32.DISP_CHANGE_FAILED
    }

    public enum ChangeSettingsMode : int
    {
        UpdateRegistry = User32.CDS_UPDATEREGISTRY,
        Test = User32.CDS_TEST,
        Fullscreen = User32.CDS_FULLSCREEN
    }
    /// @}

    /// <summary>
    /// \addtogroup dlltools
    /// @{
    /// </summary>
    public static class DesktopTools
    {
        private const int WP_UPDATEWALLPAPER = 20;
        private const int WP_UPDATEINI = 0x01;
        private const int WP_SENDINICHANGE = 0x02;

        static DesktopTools()
        {
            DisplayScreen.Init();
        }

        public static void ResetResolution()
        {
            DisplayScreen.ResetSettings();
        }

        public static void SetWallpaper(string path, WallpaperStyle style)
        {
            if (!path.ToLower().EndsWith(".bmp"))
            {
                if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Wallpapers"))
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Wallpapers");

                Image.FromFile(path).Save(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Wallpapers\\" +
                    new FileInfo(path).GetNameWithoutExtension() + ".bmp", ImageFormat.Bmp);

                path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Wallpapers\\" +
                    new FileInfo(path).GetNameWithoutExtension() + ".bmp";
            }

            if (File.Exists(path))
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);

                key.SetValue(@"WallpaperStyle", ((int)style).ToString());
                key.SetValue(@"TileWallpaper", 0);

                User32.SystemParametersInfo(WP_UPDATEWALLPAPER, 0, path, WP_UPDATEINI | WP_SENDINICHANGE);
            }
        }

        public static void SetWallpaper(Stream stream, WallpaperStyle style)
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Wallpapers"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Wallpapers");

            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Wallpapers\\" +
                Path.GetRandomFileName() + ".bmp";

            Image.FromStream(stream).Save(path);

            if (File.Exists(path))
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);

                key.SetValue(@"WallpaperStyle", ((int)style).ToString());
                key.SetValue(@"TileWallpaper", 0);

                User32.SystemParametersInfo(WP_UPDATEWALLPAPER, 0, path, WP_UPDATEINI | WP_SENDINICHANGE);
            }
        }

        public static void SetWallpaper(Image img, WallpaperStyle style)
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Wallpapers"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Wallpapers");

            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Wallpapers\\" +
                Path.GetRandomFileName() + ".bmp";

            img.Save(path);

            if (File.Exists(path))
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);

                key.SetValue(@"WallpaperStyle", ((int)style).ToString());
                key.SetValue(@"TileWallpaper", 0);

                User32.SystemParametersInfo(WP_UPDATEWALLPAPER, 0, path, WP_UPDATEINI | WP_SENDINICHANGE);
            }
        }

        public static ChangeSettingsResult ChangeResolutionPermanently(int width, int height, RotateDesktopMode rotMode)
        {
            DisplayScreen screen = new DisplayScreen();
            screen.ScreenWidth = width;
            screen.ScreenHeight = height;
            screen.ScreenRotation = rotMode;
            return screen.UpdateSettingsInRegistry();
        }

        public static ChangeSettingsResult ChangeResolutionPermanently(int width, int height)
        {
            return ChangeResolutionPermanently(width, height, RotateDesktopMode.None);
        }

        public static ChangeSettingsResult ChangeResolutionPermanently(RotateDesktopMode rotMode)
        {
            DisplayScreen screen = new DisplayScreen();
            screen.ScreenRotation = rotMode;
            return screen.UpdateSettingsInRegistry();
        }

        public static ChangeSettingsResult ChangeResolutionTemporary(int width, int height, RotateDesktopMode rotMode)
        {
            DisplayScreen screen = new DisplayScreen();
            screen.ScreenWidth = width;
            screen.ScreenHeight = height;
            screen.ScreenRotation = rotMode;
            return screen.UpdateSettingsToFullscreen();
        }

        public static ChangeSettingsResult ChangeResolutionTemporary(int width, int height)
        {
            return ChangeResolutionTemporary(width, height, RotateDesktopMode.None);
        }
    }
    /// @}
}
