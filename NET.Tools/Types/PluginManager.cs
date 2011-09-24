using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace NET.Tools
{
    /// <summary>
    /// Represent an abstract class for all plugin manager
    /// </summary>
    public abstract class PluginManager
    {
        public List<Assembly> AssemblyList { get; private set; }
        public SearchType SearchType { get; set; }

        public PluginManager(SearchType type)
        {
            AssemblyList = new List<Assembly>();
            SearchType = type;
        }

        public PluginManager(String path, SearchType type)
            : this(type)
        {
            foreach (FileInfo fi in new DirectoryInfo(path).GetFiles("*.dll"))
                AssemblyList.Add(Assembly.LoadFrom(fi.FullName));
        }

        protected T[] GetInstances<T>(object[] parameters)
        {
            List<T> instances = new List<T>();
            object[] list = GetInstances(typeof(T), parameters);

            foreach (object obj in list)
                instances.Add((T)obj);

            return instances.ToArray();
        }

        protected object[] GetInstances(Type t, object[] parameters)
        {
            List<object> instances = new List<object>();

            foreach (Assembly asm in AssemblyList)
            {
                foreach (Type type in asm.GetTypes())
                {
                    switch (SearchType)
                    {
                        case SearchType.Direct:
                            if (type.Equals(t))
                                instances.Add(Activator.CreateInstance(t, parameters));
                            break;
                        case SearchType.DirectBase:
                            if (type.BaseType.Equals(t))
                                instances.Add(Activator.CreateInstance(t, parameters));
                            break;
                        case SearchType.AnyBase:
                            if (CheckBaseTypes(type, t))
                                instances.Add(Activator.CreateInstance(t, parameters));
                            break;
                        case SearchType.AnyInterface:
                            if (CheckInterfaces(type, t))
                                instances.Add(Activator.CreateInstance(t, parameters));
                            break;
                        default:
                            throw new NotImplementedException();
                    }                    
                }
            }

            return instances.ToArray();
        }

        private bool CheckBaseTypes(Type type, Type search)
        {
            Type current = type;
            while (current != null)
            {
                if (current.BaseType != null)
                    if (current.BaseType.Equals(search))
                        return true;

                current = current.BaseType;
            }

            return false;
        }

        private bool CheckInterfaces(Type type, Type search)
        {
            Type current = type;
            while (current != null)
            {
                foreach (Type interf in current.GetInterfaces())
                    if (interf.Equals(search))
                        return true;

                current = current.BaseType;
            }

            return false;
        }
    }

    /// \addtogroup enums
    /// @{

    /// <summary>
    /// Enumeration for all search types for the plugin manager
    /// </summary>
    public enum SearchType
    {
        /// <summary>
        /// Search given type direct
        /// <example>
        /// If you set type to Stream, it search type Stream
        /// </example>
        /// </summary>
        Direct,
        /// <summary>
        /// Search given type as direct base of any type
        /// <example>
        /// If you set type to Stream, it search for example MemoryStream, FileStream, ect.
        /// </example>
        /// </summary>
        DirectBase,
        /// <summary>
        /// Search given type as any base of any type
        /// <example>
        /// If you set UIElement, it search for example Button, Window, Panel etc.
        /// </example>
        /// </summary>
        AnyBase,
        /// <summary>
        /// Search given type as any interface of any type
        /// <example>
        /// If you set IDispose, it search for example Stream, Frame, Window ect.
        /// </example>
        /// </summary>
        AnyInterface
    }

    /// @}
}
