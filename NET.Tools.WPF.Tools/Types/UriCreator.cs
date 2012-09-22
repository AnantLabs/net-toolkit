using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// Class to build uris
    /// </summary>
    public static class UriCreator
    {
        /// <summary>
        /// Create an uri from modul and path:
        /// <example>
        /// Uri uri = CreateUri("MyModul", "Resources/myImage.png");
        /// ... build this uri ...
        /// Uri uri = new Uri(@"pack://application:,,,/MyModul;component/Resources/myImage.png");
        /// </example>
        /// </summary>
        /// <param name="modul">Modul to load from</param>
        /// <param name="path">Path to the file in the modul</param>
        /// <returns>A correct uri</returns>
        public static Uri CreateUri(String modul, String path)
        {
            return new Uri(CreateUriString(modul, path));
        }

        /// <summary>
        /// Create an uri string from modul and path:
        /// <example>
        /// String uri = CreateUriString("MyModul", "Resources/myImage.png");
        /// ... build this uri ...
        /// String uri = @"pack://application:,,,/MyModul;component/Resources/myImage.png";
        /// </example>
        /// </summary>
        /// <param name="modul">Modul to load from</param>
        /// <param name="path">Path to the file in the modul</param>
        /// <returns>A correct uri string</returns>
        public static String CreateUriString(String modul, String path)
        {
            return @"pack://application:,,,/" + modul + ";component/" + path;
        }
    }
}
