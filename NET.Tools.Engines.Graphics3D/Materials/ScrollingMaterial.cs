using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NET.Tools.Engines.Mathematica;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent a scrolling material
    /// 
    /// The texture in  this material is scrolled 
    /// </summary>
    public sealed class ScrollingMaterial : SingleAnimatedTextureMaterial
    {
        private double translateX = 0, translateY = 0;

        /// <summary>
        /// Translation factor on the x axis
        /// </summary>
        public double FactorX { get; set; }
        /// <summary>
        /// Translation factor on the y axis
        /// </summary>
        public double FactorY { get; set; }

        internal ScrollingMaterial()
            : base(double.MaxValue)
        {
        }

        protected override void ComputeAnimation()
        {
            Position += Speed;

            translateX = Position * FactorX;
            translateY = Position * FactorY;
        }

        internal override void SetMaterial(Graphics3D graphics)
        {
            base.SetMaterial(graphics);

            foreach (Texture tex in textures)
                if (tex != null)
                    tex.Translation = new Vector2D(translateX, translateY);
        }

        internal override void UnsetMaterial(Graphics3D graphics)
        {
            base.UnsetMaterial(graphics);

            foreach (Texture tex in textures)
                if (tex != null)
                    tex.Translation = new Vector2D();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }

    /// @}
}
