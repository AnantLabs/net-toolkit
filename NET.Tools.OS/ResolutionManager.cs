using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace NET.Tools.OS
{
    /// \addtogroup dlltools
    /// @{

    /// <summary>
    /// Manager  that gets all supported resolutions.
    /// For fast screen resolution changing use DesktopTools
    /// </summary>
    /// <seealso cref="DesktopTools"/>
    public static class ResolutionManager
    {
        /// <summary>
        /// Gets all supported screenresolutions
        /// </summary>
        public static List<DisplayScreen> ResolutionList
        {
            get
            {
                List<DisplayScreen> result = new List<DisplayScreen>();
                int i = 0;
                do
                {
                    DisplayScreen res = new DisplayScreen();
                    if (res.Fill(++i))
                    {
                        if (!result.Contains(res))
                            result.Add(res);
                    }
                    else
                        break;
                } while (true);

                result.Sort((obj1, obj2) =>
                {
                    if (obj1.Equals(obj2))
                        return 0;

                    if (obj1.ScreenHeight < obj2.ScreenHeight)
                        if (obj1.ScreenWidth < obj2.ScreenWidth)
                            return -1;
                        else
                            return 1;
                    else
                        return 1;
                });
                return result;
            }
        }
    }

    /// \}

    /// <summary>
    /// A Screen Resolution Wrapper-Class
    /// </summary>
    public class DisplayScreen
    {
        #region Static

        private static DisplayScreen oldSettings;

        static DisplayScreen()
        {
            oldSettings = new DisplayScreen();
        }

        public static void ResetSettings()
        {
            oldSettings.UpdateSettingsInRegistry();
        }

        //For DesktopTools to save the resolution before the application was started
        internal static void Init()
        {
        }

        #endregion

        // The Win32 DevMode
        private DevMode _devMode;


        /// <summary>
        /// Create a display screen object with the current settings
        /// </summary>
        public DisplayScreen()
        {
            _devMode = new DevMode();
            _devMode.dmDeviceName = new String(new char[32]);
            _devMode.dmFormName = new String(new char[32]);
            _devMode.dmSize = (short)Marshal.SizeOf(_devMode);

            if (0 == User32.EnumDisplaySettings(null, User32.ENUM_CURRENT_SETTINGS, ref _devMode))
                throw new SystemException("Cannot load current display settings!");
        }

        /// <summary>
        /// Create a display screen object with the given settings. 
        /// If a setting is not given it will be used the current setting
        /// </summary>
        /// <param name="width">Screen width</param>
        /// <param name="height">Screen height</param>
        /// <param name="frequency">Screen frequency</param>
        /// <param name="color">Screen color mode</param>
        /// <param name="mode">Screen rotation mode</param>
        public DisplayScreen(int width, int height, int frequency, short color, RotateDesktopMode mode)
            : this()
        {
            Initialize(width, height, frequency, color, mode);
        }

        /// <summary>
        /// Create a display screen object with the given settings. 
        /// If a setting is not given it will be used the current setting
        /// </summary>
        /// <param name="width">Screen width</param>
        /// <param name="height">Screen height</param>
        /// <param name="frequency">Screen frequency</param>
        /// <param name="color">Screen color mode</param>
        public DisplayScreen(int width, int height, int frequency, short color)
            : this()
        {
            Initialize(width, height, frequency, color, null);
        }

        /// <summary>
        /// Create a display screen object with the given settings. 
        /// If a setting is not given it will be used the current setting
        /// </summary>
        /// <param name="width">Screen width</param>
        /// <param name="height">Screen height</param>
        /// <param name="color">Screen color mode</param>
        /// <param name="mode">Screen rotation mode</param>
        public DisplayScreen(int width, int height, short color, RotateDesktopMode mode)
            : this()
        {
            Initialize(width, height, null, color, mode);
        }

        /// <summary>
        /// Create a display screen object with the given settings. 
        /// If a setting is not given it will be used the current setting
        /// </summary>
        /// <param name="width">Screen width</param>
        /// <param name="height">Screen height</param>
        /// <param name="mode">Screen rotation mode</param>
        public DisplayScreen(int width, int height, RotateDesktopMode mode)
            : this()
        {
            Initialize(width, height, null, null, mode);
        }

        /// <summary>
        /// Create a display screen object with the given settings. 
        /// If a setting is not given it will be used the current setting
        /// </summary>
        /// <param name="width">Screen width</param>
        /// <param name="height">Screen height</param>
        public DisplayScreen(int width, int height)
            : this()
        {
            Initialize(width, height, null, null, null);
        }

        /// <summary>
        /// Create a display screen object with the given settings. 
        /// If a setting is not given it will be used the current setting
        /// </summary>
        /// <param name="width">Screen width</param>
        /// <param name="height">Screen height</param>
        /// <param name="color">Screen color mode</param>
        public DisplayScreen(int width, int height, short color)
            : this()
        {
            Initialize(width, height, null, color, null);
        }

        private void Initialize(int? width, int? height, int? frequency, short? color, RotateDesktopMode? mode)
        {
            if (height.HasValue)
                ScreenHeight = height.Value;
            if (width.HasValue)
                ScreenWidth = width.Value;
            if (mode.HasValue)
                ScreenRotation = mode.Value;
            if (frequency.HasValue)
                ScreenFrequency = frequency.Value;
            if (color.HasValue)
                ScreenColor = color.Value;
        }

        internal bool Fill(int mode)
        {

            int res = User32.EnumDisplaySettings(null, mode, ref _devMode);
            if (res == 0)
                return false;

            return true;

        }

        /// <summary>
        /// Update the settings on computer permanently (registry)
        /// </summary>
        public ChangeSettingsResult UpdateSettingsInRegistry()
        {
            int res = User32.ChangeDisplaySettings(ref _devMode, User32.CDS_TEST);
            if (res == User32.DISP_CHANGE_FAILED)
                return ChangeSettingsResult.Failed;

            res = User32.ChangeDisplaySettings(ref _devMode, User32.CDS_UPDATEREGISTRY);
            return (ChangeSettingsResult)res;
        }

        /// <summary>
        /// Update the settings on computer temporary (fullscreen)
        /// </summary>
        public ChangeSettingsResult UpdateSettingsToFullscreen()
        {
            int res = User32.ChangeDisplaySettings(ref _devMode, User32.CDS_TEST);
            if (res == User32.DISP_CHANGE_FAILED)
                return ChangeSettingsResult.Failed;

            res = User32.ChangeDisplaySettings(ref _devMode, User32.CDS_FULLSCREEN);
            return (ChangeSettingsResult)res;
        }

        /// <summary>
        /// Gets or sets the screen width
        /// </summary>
        public int ScreenWidth
        {
            get
            {
                return _devMode.dmPelsWidth;
            }
            set
            {
                _devMode.dmPelsWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the screen height
        /// </summary>
        public int ScreenHeight
        {
            get
            {
                return _devMode.dmPelsHeight;
            }
            set
            {
                _devMode.dmPelsHeight = value;
            }
        }

        /// <summary>
        /// Gets or sets the screen rotation
        /// </summary>
        public RotateDesktopMode ScreenRotation
        {
            get
            {
                return (RotateDesktopMode)_devMode.dmDisplayOrientation;
            }
            set
            {
                _devMode.dmDisplayOrientation = (int)value;
            }
        }

        /// <summary>
        /// Gets or sets the screen frequency
        /// </summary>
        public int ScreenFrequency
        {
            get
            {
                return _devMode.dmDisplayFrequency;
            }
            set
            {
                _devMode.dmDisplayFrequency = value;
            }
        }

        /// <summary>
        /// Gets or sets the sxcreen color mode
        /// </summary>
        public short ScreenColor
        {
            get
            {
                return _devMode.dmColor;
            }
            set
            {
                _devMode.dmColor = value;
            }
        }

        /// <summary>
        /// Display as String
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return _devMode.dmPelsWidth + " x " + _devMode.dmPelsHeight + " @ " + _devMode.dmDisplayFrequency;
        }

        /// <summary>
        /// Hashcode
        /// </summary>
        /// <returns>Hashcode</returns>
        public override int GetHashCode()
        {
            return
                _devMode.dmPelsWidth.GetHashCode() +
                _devMode.dmPelsHeight.GetHashCode();
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is DisplayScreen))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            DisplayScreen res = obj as DisplayScreen;

            return
                _devMode.dmPelsWidth.Equals(res._devMode.dmPelsWidth) &&
                _devMode.dmPelsHeight.Equals(res._devMode.dmPelsHeight) &&
                _devMode.dmDisplayFrequency.Equals(res._devMode.dmDisplayFrequency);
        }
    }
}
