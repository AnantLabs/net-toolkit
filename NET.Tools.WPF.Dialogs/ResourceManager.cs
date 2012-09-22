using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace NET.Tools.WPF
{
    internal static class ResourceManager
    {
        public static BitmapImage IMAGE_ERROR { get { return new BitmapImage(new Uri(@"pack://application:,,,/Net.Tools.WPF.Dialogs;component/Resources/Images/ERROR.ico")); } }
        public static BitmapImage IMAGE_INFO { get { return new BitmapImage(new Uri(@"pack://application:,,,/Net.Tools.WPF.Dialogs;component/Resources/Images/INFO.ico")); } }
        public static BitmapImage IMAGE_OK { get { return new BitmapImage(new Uri(@"pack://application:,,,/Net.Tools.WPF.Dialogs;component/Resources/Images/OK.ico")); } }
        public static BitmapImage IMAGE_QUESTION { get { return new BitmapImage(new Uri(@"pack://application:,,,/Net.Tools.WPF.Dialogs;component/Resources/Images/QUESTION.ico")); } }
        public static BitmapImage IMAGE_WARN { get { return new BitmapImage(new Uri(@"pack://application:,,,/Net.Tools.WPF.Dialogs;component/Resources/Images/WARN.ico")); } }
    }
}
