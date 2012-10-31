using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Threading;

namespace NET.Tools
{
    internal static class TextManager
    {
        private static ResourceManager rm = new ResourceManager(
            typeof(TextManager).Namespace + ".Text", typeof(TextManager).Assembly);

        private static String GetString(String key)
        {
            return rm.GetString(key, Thread.CurrentThread.CurrentUICulture);
        }

        public static class MDI
        {
            public static String Close { get { return GetString("MDI.Close"); } }
            public static String CloseAll { get { return GetString("MDI.CloseAll"); } }
            public static String CloseOthers { get { return GetString("MDI.CloseOthers"); } }
            public static String LayoutText { get { return GetString("MDI.Layout"); } }
            public static String Window { get { return GetString("MDI.Window"); } }

            public static class Layout
            {
                public static String TileHorizontal { get { return GetString("MDI.Layout.TileHorizontal"); } }
                public static String TileVertical { get { return GetString("MDI.Layout.TileVertical"); } }
                public static String Overlapping { get { return GetString("MDI.Layout.Overlapping"); } }
            }
        }
    }
}
