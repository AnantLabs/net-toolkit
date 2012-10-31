using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace NET.Tools
{
    /// <summary>
    /// A manager for plugin systems
    /// </summary>
    public sealed class MultiPluginManager : PluginManager
    {
        public List<Type> TypeList { get; private set; }

        public MultiPluginManager(SearchType type)
            : base(type)
        {
            TypeList = new List<Type>();
        }

        public MultiPluginManager(string path, SearchType type)
            : base(path, type)
        {
        }

        public T[] GetInstancesOfType<T>(params object[] parameters)
        {
            return this.GetInstances<T>(parameters);
        }

        public Dictionary<Type, object[]> GetAllInstances(Dictionary<Type, object[]> parameterMap)
        {
            Dictionary<Type, object[]> res = new Dictionary<Type, object[]>();

            foreach (Type type in TypeList)
            {
                if (parameterMap.ContainsKey(type))
                    res.Add(type, this.GetInstances(type, parameterMap[type]));
                else
                    res.Add(type, this.GetInstances(type, new object[] { }));
            }

            return res;
        }
    }
}
