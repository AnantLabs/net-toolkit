using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;

namespace NET.Tools.Forms
{
    public class HighLightingRecord
    {
        public Regex RegularExpression { get; set; }
        public Color ForeColor { get; set; }
        public Color BackColor { get; set; }
        public FontStyle FontStyle { get; set; }

        public HighLightingRecord()
        {
        }

        public HighLightingRecord(Regex regex, Color fore, Color back, FontStyle style)
        {
            RegularExpression = regex;
            ForeColor = fore;
            BackColor = back;
            FontStyle = style;
        }
    }
}
