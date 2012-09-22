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
using NET.Tools.WPF.Skins;


namespace NET.Tools.WPF
{
    /// \addtogroup dialogGroup
    /// @{

    /// <summary>
    /// Default input dialog for WPF (support validators)
    /// 
    /// Change the skin about the bundle parameter
    /// </summary>
    public partial class InputDialogEx : Window
    {
        #region Static

        #region Default

        private static String ShowDialog(String title, String msg, String text,
            MessageIcons icon, ImageSource image, SkinBundle bundle, Func<String, bool> validateFunc)
        {
            InputDialogEx dlg = new InputDialogEx();
            dlg.Title = title;
            dlg.txtInput.Text = text;
            if (validateFunc != null)
                dlg.txtInput.TextChanged += (s, e) =>
                {
                    if (!validateFunc(dlg.txtInput.Text))
                        dlg.txtInput.Undo();
                };
            dlg.lblMessage.Text = msg;
            dlg.imgIcon.Source = MessageIconHelper.GetIcon(icon, bundle);
            if (dlg.imgIcon.Source == null)
                if (image != null)
                    dlg.imgIcon.Source = image;

            if (bundle != null)
                bundle.SetBundle(dlg);

            /************************************************************/

            if (dlg.ShowDialog().GetValueOrDefault(false))
                return dlg.txtInput.Text;
            else
                return null;
        }

        public static String ShowDialog(String title, String msg, String text,
            MessageIcons icon, SkinBundle bundle, Func<String, bool> validateFunc)
        {
            return ShowDialog(title, msg, text, icon, null, bundle, validateFunc);
        }

        public static String ShowDialog(String title, String msg, String text,
            ImageSource image, SkinBundle bundle, Func<String, bool> validateFunc)
        {
            return ShowDialog(title, msg, text, MessageIcons.None, image, bundle, validateFunc);
        }

        public static String ShowDialog(String title, String msg, String text,
            MessageIcons icon, SkinBundle bundle)
        {
            return ShowDialog(title, msg, text, icon, null, bundle, null);
        }

        public static String ShowDialog(String title, String msg, String text,
            MessageIcons icon, Func<String, bool> validateFunc)
        {
            return ShowDialog(title, msg, text, icon, null, null, validateFunc);
        }

        public static String ShowDialog(String title, String msg, String text,
            MessageIcons icon)
        {
            return ShowDialog(title, msg, text, icon, null, null, null);
        }

        public static String ShowDialog(String title, String msg, String text,
            ImageSource image, SkinBundle bundle)
        {
            return ShowDialog(title, msg, text, MessageIcons.None, image, bundle, null);
        }

        public static String ShowDialog(String title, String msg, String text,
            ImageSource image, Func<String, bool> validateFunc)
        {
            return ShowDialog(title, msg, text, MessageIcons.None, image, null, validateFunc);
        }

        public static String ShowDialog(String title, String msg, String text,
            ImageSource image)
        {
            return ShowDialog(title, msg, text, MessageIcons.None, image, null, null);
        }

        public static String ShowDialog(String title, String msg, String text)
        {
            return ShowDialog(title, msg, text, MessageIcons.None);
        }

        public static String ShowDialog(String title, String msg)
        {
            return ShowDialog(title, msg, "");
        }

        #endregion

        #region Editable ComboBox

        public static String ShowComboBoxInputDialog(String title, String msg, ImageSource icon, int index, SkinBundle bundle, params String[] items)
        {
            if (index < -1)
                throw new ArgumentException("The index must be greater than -2!");

            InputDialogEx dlg = new InputDialogEx();
            dlg.Title = title;
            dlg.lblMessage.Text = msg;
            dlg.imgIcon.Source = icon;

            dlg.cmbInput.Visibility = Visibility.Visible;
            dlg.txtInput.Visibility = Visibility.Hidden;

            dlg.cmbInput.IsEditable = true;
            foreach (String str in items)
                dlg.cmbInput.Items.Add(str);
            dlg.cmbInput.SelectedIndex = index;

            if (bundle != null)
                bundle.SetBundle(dlg);

            if (dlg.ShowDialog().GetValueOrDefault(false))
                return dlg.cmbInput.Text;

            return null;
        }

        public static String ShowComboBoxInputDialog(String title, String msg, MessageIcons icon, int index, SkinBundle bundle, params String[] items)
        {
            return ShowComboBoxInputDialog(title, msg, MessageIconHelper.GetIcon(icon, bundle), 
                index, bundle, items);
        }

        public static String ShowComboBoxInputDialog(String title, String msg, MessageIcons icon, int index, params String[] items)
        {
            return ShowComboBoxInputDialog(title, msg, icon, index, null, items);
        }

        public static String ShowComboBoxInputDialog(String title, String msg, MessageIcons icon, SkinBundle bundle, params String[] items)
        {
            return ShowComboBoxInputDialog(title, msg, icon, -1, bundle, items);
        }

        public static String ShowComboBoxInputDialog(String title, String msg, MessageIcons icon, params String[] items)
        {
            return ShowComboBoxInputDialog(title, msg, icon, -1, items);
        }

        public static String ShowComboBoxInputDialog(String title, String msg, params String[] items)
        {
            return ShowComboBoxInputDialog(title, msg, MessageIcons.None, items);
        }

        #endregion

        #region Choice ComboBox

        public static T ShowComboBoxChoiceDialog<T>(String title, String msg, ImageSource icon, int index, SkinBundle bundle, params T[] items)
        {
            if (index < 0)
                throw new ArgumentException("The index must be greater than -1!");

            InputDialogEx dlg = new InputDialogEx();
            dlg.Title = title;
            dlg.lblMessage.Text = msg;
            dlg.imgIcon.Source = icon;

            dlg.cmbInput.Visibility = Visibility.Visible;
            dlg.txtInput.Visibility = Visibility.Hidden;

            dlg.cmbInput.IsEditable = false;
            foreach (T obj in items)
                dlg.cmbInput.Items.Add(obj);
            dlg.cmbInput.SelectedIndex = index;

            if (bundle != null)
                bundle.SetBundle(dlg);

            if (dlg.ShowDialog().GetValueOrDefault(false))
                return (T)dlg.cmbInput.SelectedItem;

            return default(T);
        }

        public static T ShowComboBoxChoiceDialog<T>(String title, String msg, MessageIcons icon, int index, SkinBundle bundle, params T[] items)
        {
            return ShowComboBoxChoiceDialog<T>(title, msg, MessageIconHelper.GetIcon(icon, bundle),
                index, bundle, items);
        }

        public static T gShowComboBoxChoiceDialog<T>(String title, String msg, MessageIcons icon, int index, params T[] items)
        {
            return ShowComboBoxChoiceDialog<T>(title, msg, icon, index, null, items);
        }

        public static T ShowComboBoxChoiceDialog<T>(String title, String msg, MessageIcons icon, SkinBundle bundle, params T[] items)
        {
            return ShowComboBoxChoiceDialog<T>(title, msg, icon, 0, bundle, items);
        }

        public static T ShowComboBoxChoiceDialog<T>(String title, String msg, MessageIcons icon, params T[] items)
        {
            return ShowComboBoxChoiceDialog<T>(title, msg, icon, 0, null, items);
        }

        public static T ShowComboBoxChoiceDialog<T>(String title, String msg, params T[] items)
        {
            return ShowComboBoxChoiceDialog<T>(title, msg, MessageIcons.None, items);
        }

        #endregion

        #endregion

        private InputDialogEx()
        {
            InitializeComponent();
            txtInput.Focus();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
    /// @}
}
