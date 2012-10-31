using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NET.Tools.WPF;
using NET.Tools.WPF.Skins;



namespace NET.Tools.Demo
{
    /// <summary>
    /// Interaktionslogik für ComponentsWin.xaml
    /// </summary>
    public partial class ComponentsWin : Window
    {
        public ComponentsWin()
        {
            InitializeComponent();
            fm.ExceptionIsThrown += (s, e) =>
            {
                ErrorDialogEx.ShowDialog("Error", e.AdditionalMessage, e.ThrownException,
                    NimbusSkin.SkinBundle);
            };
        }
    }
}
