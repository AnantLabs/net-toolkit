using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Represent a console container object
    /// 
    /// <remarks>Note that the height for this objects is not fixed default</remarks>
    /// </summary>
    public abstract class CMDContainer : CMDComponent
    {
        public override int Height { get; set; }

        /// <summary>
        /// Contains the list of all children elements
        /// </summary>
        public IList<CMDElement> ElementList { get; private set; }

        public CMDContainer()
        {
            Height = 2;
            ElementList = new List<CMDElement>();
        }
    }
}
