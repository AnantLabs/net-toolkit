using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media;

namespace NET.Tools.WPF.Skins
{
    public static class NimbusSkin
    {
        public static SkinBundle SkinBundle
        {
            get
            {
                return new SkinBundle(
                    new Uri(@"pack://application:,,,/NET.Tools.WPF.Skins.NimbusSkin;component/NimbusSkin.xaml"),
                    "NimbusWindow", Brushes.Black, Brushes.Black, Colors.Silver, Colors.DarkGray);
            }
        }

    }
}
