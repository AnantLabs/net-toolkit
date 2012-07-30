using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.AbstractGUI
{
    /// \addtogroup extensions
    /// @{

    public interface IStyleGroup
    {
        IStyle ButtonStyle { get; set; }
        IStyle WindowStyle { get; set; }
    }

    public abstract class StyleGroup : IStyleGroup
    {
        public IStyle ButtonStyle { get; set; }
        public IStyle WindowStyle { get; set; }

        protected StyleGroup(IStyle buttonStyle, IStyle windowStyle)
        {
            ButtonStyle = buttonStyle;
            WindowStyle = windowStyle;
        }
    }

    public sealed class StyleManager : IStyleGroup
    {
        private static StyleManager instance = null;
        public static StyleManager Instance
        {
            get { return instance ?? (instance = new StyleManager()); }
        }

        public IStyle ButtonStyle { get; set; }
        public IStyle WindowStyle { get; set; }

        public void SetStyleGroup(StyleGroup styleGroup)
        {
            ButtonStyle = styleGroup.ButtonStyle;
            WindowStyle = styleGroup.WindowStyle;
        }
    }

    /// @}\
}
