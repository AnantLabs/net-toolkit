using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Controls;

namespace NET.Tools.WPF
{
    public interface IImageItem
    {
        object Content { get; set; }
        ImageSource Icon { get; set; }
        Orientation Orientation { get; set; }
    }
}
