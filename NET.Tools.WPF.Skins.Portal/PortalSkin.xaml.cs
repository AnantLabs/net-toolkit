﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace NET.Tools.WPF.Skins
{
    public static class PortalSkin
    {
        public static SkinBundle SkinBundle
        {
            get
            {
                return new SkinBundle(
                  new Uri(@"pack://application:,,,/NET.Tools.WPF.Skins.PortalSkin;component/PortalSkin.xaml"),
                  "PortalWindow", Brushes.Black, Brushes.Black, Colors.LightYellow, Colors.Yellow);
            }
        }
    }
}