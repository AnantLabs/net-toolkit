using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace NET.Tools.Engines.Graphics3D
{
    public static class ViewportManager
    {
        private static Dictionary<String, Viewport> viewports = new Dictionary<String, Viewport>();

        public static Viewport GetViewport(String key)
        {
            return viewports[key];
        }

        public static Viewport CreateViewport(String key, ViewportCreator creator) 
        {
            Viewport vp = creator.Create();
            SetViewport(key, vp);

            return vp;
        }

        private static void SetViewport(String key, Viewport vp)
        {
            if (viewports.ContainsKey(key))
            {
                viewports[key] = vp;
            }
            else
            {
                viewports.Add(key, vp);
            }
        }

        public static bool ContainsViewport(String key)
        {
            return viewports.ContainsKey(key);
        }

        public static void RemoveViewport(String key)
        {
            viewports.Remove(key);
        }

        public static int CountOfViewports { get { return viewports.Count; } }

        internal static IEnumerable Iterator
        {
            get
            {
                return viewports.Values;
            }
        }
    }
}
