using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace NET.Tools.Engines.Graphics3D
{
    public static class Graphics3DSystem
    {
        private static IDictionary<String, ILayerInformation> layerList = new Dictionary<String, ILayerInformation>();

        public static String CurrentDeviceType { get; private set; }
        internal static ILayerImplementor Implementors { get; private set; }
        public static Graphics3DConfiguration Configuration { get; private set; }

        static Graphics3DSystem()
        {
            CurrentDeviceType = null;
            FindLayers();
        }

        /// <summary>
        /// Initialize a graphics 3d system from a plugin. <b>Do not call initialize on the returned Graphics3DDevice! Already called by this method!</b>
        /// </summary>
        /// <param name="config">Configuration for Graphics 3D Engine</param>
        /// <param name="systemName">Name of the low layer system (e. g. Direct3D9, ...)</param>
        /// <returns>A Graphics3DDevice object. Represent an instance of the graphics 3d engine</returns>
        /// <exception cref="Graphics3DSystemNotFoundException">Is thrown if no system with the given system name was found</exception>
        public static Graphics3DDevice InitializeSystem(Graphics3DConfiguration config, String systemName)
        {
            if (!layerList.ContainsKey(systemName))
                throw new Graphics3DSystemNotFoundException("Cannot find system: " + systemName);

            Configuration = config;

            Implementors = layerList[systemName].LayerImplementor;
            Graphics3DDevice device = layerList[systemName].Device;
            device.Initialize(config);

            CurrentDeviceType = systemName;

            return device;
        }

        private static void FindLayers()
        {
            foreach (FileInfo file in new FileInfo(typeof(Graphics3DSystem).Assembly.Location).Directory.GetFiles("*.dll"))
            {
                Assembly asm = Assembly.LoadFrom(file.FullName);
                if (asm.Equals(typeof(Graphics3DSystem).Assembly))
                    continue;

                foreach (Type type in asm.GetTypes()) 
                {
                    foreach (Type interf in type.GetInterfaces())
                    {
                        if (interf.Equals(typeof(ILayerInformation)))
                        {
                            ILayerInformation info = (ILayerInformation)Activator.CreateInstance(type);
                            layerList.Add(info.SystemName, info);

                            break;
                        }
                    }
                }
            }
        }
    }
}
