using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace NET.Tools.Engines.Internationalization
{
    /// <summary>
    /// Gets language strings from resources 
    /// </summary>
    public sealed class ResourceLanguageManager : LanguageManager
    {
        private ResourceManager rm;

        public ResourceLanguageManager(String namesp, Assembly asm, String resName)
            : base()
        {
            rm = new ResourceManager(namesp + "." + resName, asm);
        }

        public ResourceLanguageManager(String namesp, Type type, String resName)
            : this(namesp, type.Assembly, resName)
        {
        }

        public ResourceLanguageManager(Type type, String resName)
            : this(type.Namespace, type.Assembly, resName)
        {
        }

        /// <summary>
        /// Name is "Language"
        /// </summary>
        /// <param name="type"></param>
        public ResourceLanguageManager(Type type)
            : this(type, "Language")
        {
        }

        public override string GetString(string key, CultureInfo culture)
        {
            return rm.GetString(key, culture);
        }

        public override IList<CultureInfo> InstalledCultures
        {
            get
            {
                IList<CultureInfo> res = new List<CultureInfo>();

                foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
                {
                    try
                    {
                        if (rm.GetResourceSet(ci, true, true) != null)
                            res.Add(ci);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                return res;
            }
        }
    }
}
