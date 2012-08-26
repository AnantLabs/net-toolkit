using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    public sealed class LanguageResourceAttribute : Attribute
    {
        public String LanguageResourceName { get; private set; }

        public LanguageResourceAttribute(string languageResourceName)
        {
            LanguageResourceName = languageResourceName;
        }
    }
}
