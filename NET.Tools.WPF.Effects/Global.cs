using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.WPF
{
    public static class Global
    {
        public static Uri GetPackageUri(String path)
        {
            return new Uri(@"pack://application:,,, /NET.Tools.WPF.Effects;component/" + path);
        }
    }
}
