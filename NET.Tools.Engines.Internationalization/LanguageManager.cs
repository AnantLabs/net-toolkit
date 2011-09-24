using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;

namespace NET.Tools.Engines.Internationalization
{
    /// <summary>
    /// Represent the abstract class for all language managers
    /// </summary>
    public abstract class LanguageManager
    {
        /// <summary>
        /// Get a string value from language file with the current ui culture
        /// </summary>
        /// <param name="key">Key of string</param>
        /// <param name="culture">Culture for searching key for language</param>
        /// <returns></returns>
        public abstract String GetString(String key, CultureInfo culture);
        public String GetString(String key)
        {
            return GetString(key, Thread.CurrentThread.CurrentUICulture);
        }

        public abstract IList<CultureInfo> InstalledCultures { get; }

        public LanguageManager()
        {
        }
    }
}
