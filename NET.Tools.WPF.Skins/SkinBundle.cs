using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace NET.Tools.WPF.Skins
{
    /// <summary>
    /// Represent a skin bundle for a WPF skin. In this bundle are defined all styles and xaml-paths.
    /// Additional it descripes needed colors, brushes and icons for Dialogs.
    /// </summary>
    public class SkinBundle
    {
        /// <summary>
        /// Create a skin bundle
        /// </summary>
        /// <param name="xamlPath">Path to the finnaly xaml-file</param>
        /// <param name="windowKey">Key for the window style template</param>
        /// <param name="errIcon">Error icon</param>
        /// <param name="infoIcon">Info icon</param>
        /// <param name="okIcon">OK icon</param>
        /// <param name="questIcon">Qestion icon</param>
        /// <param name="warnIcon">Warning icon</param>
        public SkinBundle(Uri xamlPath, String windowKey,
            ImageSource errIcon, ImageSource infoIcon, ImageSource okIcon,
            ImageSource questIcon, ImageSource warnIcon) 
        {
            XAMLSkinPath = xamlPath;
            WindowTemplateKey = windowKey;

            ErrorIcon = errIcon;
            InfoIcon = infoIcon;
            OKIcon = okIcon;
            QuestionIcon = questIcon;
            WarnIcon = warnIcon;
        }

        /// <summary>
        /// Create a skin bundle
        /// </summary>
        /// <param name="xamlPath">Path to the finnaly xaml-file</param>
        /// <param name="windowKey">Key for the window style template</param>
        public SkinBundle(Uri xamlPath, String windowKey)
            : this(xamlPath, windowKey, null, null, null, null, null)
        {
        }

        /// <summary>
        /// Path to the finnaly xaml-file
        /// </summary>
        public Uri XAMLSkinPath { get; private set; }
        /// <summary>
        /// Key for the window style template
        /// </summary>
        public String WindowTemplateKey { get; private set; }

        /// <summary>
        /// Error icon for this bundle or null to use the defualt in dialogs
        /// </summary>
        public ImageSource ErrorIcon { get; private set; }
        /// <summary>
        /// Info icon for this bundle or null to use the defualt in dialogs
        /// </summary>
        public ImageSource InfoIcon { get; private set; }
        /// <summary>
        /// OK icon for this bundle or null to use the defualt in dialogs
        /// </summary>
        public ImageSource OKIcon { get; private set; }
        /// <summary>
        /// Question icon for this bundle or null to use the defualt in dialogs
        /// </summary>
        public ImageSource QuestionIcon { get; private set; }
        /// <summary>
        /// Warn icon for this bundle or null to use the defualt in dialogs
        /// </summary>
        public ImageSource WarnIcon { get; private set; }

        /// <summary>
        /// Set the skin bundle to this window
        /// </summary>
        /// <param name="win">The window to set the style template and add the 
        /// xaml-file as merged resource</param>
        public void SetBundle(Window win)
        {
            ResourceDictionary dic = new ResourceDictionary
                {
                    Source = this.XAMLSkinPath
                };

            win.Resources.MergedDictionaries.Add(dic);
            win.Style = (Style)win.Resources[this.WindowTemplateKey];
        }
    }
}
