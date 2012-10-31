using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Threading;
using log4net;

namespace NET.Tools.Engines.Internationalization
{
    /// <summary>
    /// Represent a language manager for external language files
    /// 
    /// You need:
    /// - Default.xml: Fallback if key is not found in culture list
    /// - de-DE.xml (e. g.): list for the culture 'de' (language german)
    /// - ...
    /// </summary>
    public sealed class ExternalLanguageManager : LanguageManager
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof (ExternalLanguageManager));

        private IDictionary<CultureInfo, LanguageDocument> textList;
        private LanguageDocument defaultText;

        public ExternalLanguageManager(DirectoryInfo target)
        {
			textList = new Dictionary<CultureInfo, LanguageDocument>();
		
            foreach (FileInfo fi in target.GetFiles("*.xml"))
            {
                if (fi.Name.ToLower() == "default.xml")
                    defaultText = new LanguageDocument(fi);
                else
                {
                    try
                    {
                        CultureInfo ci = new CultureInfo(fi.Name.ToLower().Replace(".xml", ""));
                        if (ci == null)
                            throw new ArgumentException("Unable to find language!");
                        textList.Add(ci, new LanguageDocument(fi));
                    }
                    catch (Exception e)
                    {
                        LOG.Warn("Cannot handle language '" + fi.Name.ToLower().Replace(".xml", ""), e);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the string from the key with the given culture info
        /// </summary>
        /// <param name="key">Key of string</param>
        /// <param name="culture">Culture info for String</param>
        /// <returns>Internationalized String</returns>
        public override string GetString(string key, CultureInfo culture)
        {
            if (!textList.ContainsKey(culture))
            {
                //Fallback to neutral culture
                if (!culture.IsNeutralCulture)
                    culture = new CultureInfo(culture.TwoLetterISOLanguageName);
            }
            if (textList.ContainsKey(culture))
                if (textList[culture].TextList.ContainsKey(key))
                    return textList[culture].TextList[key];

            if (defaultText.TextList.ContainsKey(key))
                return defaultText.TextList[key];

            return null;
        }

        /// <summary>
        /// Get all installed (all external files) cultures
        /// </summary>
        public override IList<CultureInfo> InstalledCultures
        {
            get
            {
                return textList.Keys.ToList();
            }
        }
    }
}
