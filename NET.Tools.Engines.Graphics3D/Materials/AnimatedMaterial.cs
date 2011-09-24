using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// \addtogroup graphics3d
    /// @{

    /// <summary>
    /// Represent a material for animations
    /// </summary>
    public abstract class AnimatedMaterial : Material, IAnimation
    {
        private double position = 0;

        internal AnimatedMaterial(double length)
        {
            Length = length;
        }

        #region IAnimation Member

        public double Speed
        {
            get;
            set;
        }

        public double Position
        {
            get { return position; }
            set
            {
                if ((position < 0) || (position >= Length))
                    throw new ArgumentException("Position must be between 0 and " + Length + "!");

                position = value;
            }
        }

        public double Length
        {
            get;
            private set;
        }

        public bool IsRunning
        {
            get;
            private set;
        }

        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }

        public void Reset()
        {
            Position = 0;
        }

        #endregion

        /// <summary>
        /// Compute the animation
        /// 
        /// The position <b>is not computed</b> by this base class
        /// </summary>
        protected abstract void ComputeAnimation();

        internal override void SetMaterial(Graphics3D graphics)
        {
            ComputeAnimation();
            base.SetMaterial(graphics);
        }
    }

    /// @}
}
