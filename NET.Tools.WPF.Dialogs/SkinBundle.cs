using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace NET.Tools.WPF.Dialogs
{
    /// <summary>
    /// Represent a skin bundle for a WPF skin
    /// </summary>
    public class SkinBundle
    {
        /// <summary>
        /// Create a skin bundle
        /// </summary>
        /// <param name="xamlPath">Path to the finnaly xaml-file</param>
        /// <param name="windowKey">Key for the window style template</param>
        public SkinBundle(Uri xamlPath, String windowKey) 
        {
            XAMLSkinPath = xamlPath;
            WindowTemplateKey = windowKey;
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
        /// Set the skin bundle to this window
        /// </summary>
        /// <param name="win">The window to set the style template and add the 
        /// xaml-file as merged resource</param>
        public void SetBundle(Window win)
        {
            ResourceDictionary dic = new ResourceDictionary();
            dic.Source = this.XAMLSkinPath;

            win.Resources.MergedDictionaries.Add(dic);
            win.Style = (Style)win.Resources[this.WindowTemplateKey];
        }
    }
}
