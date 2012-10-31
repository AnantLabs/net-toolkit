using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Effects;

namespace NET.Tools.WPF
{
    public abstract class ChangableEffect : PixelShaderEffectBase
    {
        #region Static Members

        private static readonly DependencyProperty IsChangedProperty =
            DependencyProperty.Register(
                    "IsChanged",
                    typeof(float),
                    typeof(ChangableEffect),
                    new UIPropertyMetadata(0f, PixelShaderConstantCallback(0)));

        #endregion

        public ChangableEffect(PixelShader shader)
            : base(shader)
        {
            IsChanged = 0f;

            UpdateShaderValue(IsChangedProperty);
        }

        public float IsChanged
        {
            get { return (float)GetValue(IsChangedProperty); }
            set { SetValue(IsChangedProperty, value); }
        }
    }
}
