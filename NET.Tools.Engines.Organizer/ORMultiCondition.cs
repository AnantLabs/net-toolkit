using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Organizer
{
    public class ORMultiCondition : MultiCondition
    {
        public ORMultiCondition(params ICondition[] list)
            : base(LinkType.AND, list)
        {
        }

        public ORMultiCondition()
            : this(new ICondition[] { })
        {            
        }
    }
}
