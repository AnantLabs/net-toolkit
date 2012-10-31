using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Graphics3D;

namespace NET.Tools.Engines.Graphics3D
{
    public interface IMeshImplementor : IImplementor
    {
        Mesh CreateBoxMesh(float width, float height, float depth);
        Mesh CreateCylinderMesh(float radius1, float radius2, float length, int slices, int stacks);
    }
}
