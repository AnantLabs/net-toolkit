using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace NET.Tools.WPF.Skins
{
    public static class ArtSkin
    {
        public static SkinBundle SkinBundle
        {
            get
            {
                return new SkinBundle(
                    new Uri(@"pack://application:,,,/NET.Tools.WPF.Skins.ArtSkin;component/ArtSkin.xaml"),
                    "ArtWindow");
            }
        }
    }
}
