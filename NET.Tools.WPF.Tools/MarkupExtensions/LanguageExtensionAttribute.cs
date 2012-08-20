using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    public sealed class LanguageExtensionAttribute : Attribute
    {
        public String LanguageResourceName { get; private set; }

        public LanguageExtensionAttribute(string languageResourceName)
        {
            LanguageResourceName = languageResourceName;
        }
    }
}
