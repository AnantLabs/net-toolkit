using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MS.Internal.PresentationFramework;

namespace NET.Tools.WPF
{
    /// <summary>
    /// Interaktionslogik für PageRotator.xaml
    /// </summary>
    public partial class PageRotator : UserControl
    {
        private int rotator = 0;

        public IList<Visual> Children { get; private set; }

        public int Rotator
        {
            get { return rotator; }
            set
            {
                if (value < 0 || value >= Children.Count)
                    throw new IndexOutOfRangeException("Rotator must be between 0 and " + (Children.Count - 1) + "!");

                UpdateGUI();
                rotator = value;
            }
        }

        public bool HasNext
        {
            get { return rotator < Children.Count - 1; }
        }

        public bool HasPrev
        {
            get { return rotator > 0; }
        }

        public bool IsFirstPage { get { return rotator == 0; } }
        public bool IsLastPage { get { return rotator == Children.Count - 1; } }

        public Visual SelectedChild { get { return Children[rotator]; } }

        public event DependencyPropertyChangedEventHandler Rotate;

        public PageRotator()
        {
            InitializeComponent();
            Children = new List<Visual>();
        }

        public bool NextPage()
        {
            if (HasNext)
            {
                rotator++;
                UpdateGUI();
                return true;
            }

            return false;
        }

        public bool PrevPage()
        {
            if (HasPrev)
            {
                rotator--;
                UpdateGUI();
                return true;
            }

            return false;
        }

        public void RefreshPage()
        {
            UpdateGUI();
        }

        private void UpdateGUI()
        {
            Content = Children[rotator];
        }
    }
}
