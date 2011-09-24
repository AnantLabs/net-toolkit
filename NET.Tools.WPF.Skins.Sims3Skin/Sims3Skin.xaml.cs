using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Media;

namespace NET.Tools.WPF.Skins
{
    public static class Sims3Skin
    {
        public static SkinBundle SkinBundle_Style1
        {
            get
            {
                return new SkinBundle(
                    new Uri(@"pack://application:,,,/NET.Tools.WPF.Skins.Sims3Skin;component/Sims3Skin.xaml"),
                    "Sims3Window1");
            }
        }

        public static SkinBundle SkinBundle_Style2
        {
            get
            {
                return new SkinBundle(
                    new Uri(@"pack://application:,,,/NET.Tools.WPF.Skins.Sims3Skin;component/Sims3Skin.xaml"),
                    "Sims3Window2");
            }
        }

        public static SkinBundle SkinBundle_Style3
        {
            get
            {
                return new SkinBundle(
                    new Uri(@"pack://application:,,,/NET.Tools.WPF.Skins.Sims3Skin;component/Sims3Skin.xaml"),
                    "Sims3Window3");
            }
        }

        public static SkinBundle SkinBundle_Random
        {
            get
            {
                return new SkinBundle(
                    new Uri(@"pack://application:,,,/NET.Tools.WPF.Skins.Sims3Skin;component/Sims3Skin.xaml"),
                    "Sims3Window" + ((new Random().Next() % 3) + 1).ToString());
            }
        }
    }
}
