using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Special addon for IList<GraphicsNode>
    /// </summary>
    public static class AddOnListIGraphicsNode
    {
        /// <summary>
        /// Find the first Node with the given name
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="name">Name to search</param>
        /// <returns>The first node with the given name or NULL if no node was found</returns>
        public static GraphicsNode FindFirst(this IList<GraphicsNode> lst, String name)
        {
            foreach (GraphicsNode node in lst)
                if (node.Name.Equals(name))
                    return node;

            return null;
        }
    }

    /// @}
}
