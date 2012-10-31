using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace NET.Tools.Engines.Internationalization
{
    internal class LanguageDocument
    {
        public IDictionary<String, String> TextList {get; private set;}

        public LanguageDocument(FileInfo file)
        {
            TextList = new Dictionary<String, String>();

            try
            {
                XDocument doc = XDocument.Load(file.FullName);

                foreach (XElement node in doc.Root.Elements())
                {
                    TextList.Add(node.Attribute("key").Value, node.Value);
                }
            }
            catch (Exception e)
            {
                throw new LanguageDocumentException("Unable to load languages from xml: " + file.FullName, e);
            }
        }
    }
}
