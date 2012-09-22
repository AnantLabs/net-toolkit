using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    public class ANDMultiCondition : MultiCondition
    {
        public ANDMultiCondition(params ICondition[] list)
            : base(LinkType.AND, list)
        {
        }

        public ANDMultiCondition()
            : this(new ICondition[] { })
        {            
        }
    }
}
