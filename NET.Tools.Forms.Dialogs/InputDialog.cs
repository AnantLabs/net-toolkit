using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NET.Tools.Forms
{
    /// \addtogroup dialogGroup
    /// @{

    /// <summary>
    /// Dialog for default input (supports validating)
    /// </summary>
    public partial class InputDialog : Form
    {
        #region Static Members

        #region Default

        public static String ShowDefaultDialog(String title, String msg, String text, bool password,
            Func<String, bool> validateFunc)
        {
            InputDialog dlg = new InputDialog();
            dlg.txtInput.Text = text;
            dlg.lblMessage.Text = msg;
            dlg.Text = title;
            if (password)
                dlg.txtInput.UseSystemPasswordChar = true;
            if (validateFunc != null)
                dlg.txtInput.TextChanged += (s, e) =>
                {
                    if (!validateFunc(dlg.txtInput.Text))
                        dlg.txtInput.Undo();
                };

            if (dlg.ShowDialog() == DialogResult.OK)
                return dlg.txtInput.Text;
            else
                return null;
        }

        public static String ShowDefaultDialog(String title, String msg, String text, bool password)
        {
            return ShowDefaultDialog(title, msg, text, password, null);
        }

        public static String ShowDefaultDialog(String title, String msg, String text)
        {
            return ShowDefaultDialog(title, msg, text, false);
        }

        public static String ShowDefaultDialog(String title, String msg)
        {
            return ShowDefaultDialog(title, msg, "");
        }

        #endregion        

        #region ComboBox Input

        public static String ShowComboBoxInputDialog(String title, String msg,
            IList<String> items, int selIndex)
        {
            InputDialog dlg = new InputDialog();
            dlg.txtInput.Visible = false;
            dlg.cmbInput.Visible = true;
            dlg.cmbInput.Items.AddRange(items.ToArray());
            dlg.cmbInput.DropDownStyle = ComboBoxStyle.DropDown;
            dlg.cmbInput.SelectedIndex = selIndex;
            dlg.lblMessage.Text = msg;
            dlg.Text = title;

            if (dlg.ShowDialog() == DialogResult.OK)
                return dlg.cmbInput.Text;
            else
                return null;
        }

        public static String ShowComboBoxInputDialog(String title, String msg,
            IList<String> items)
        {
            return ShowComboBoxInputDialog(title, msg, items, -1);
        }

        #endregion

        #region ComboBox Choice

        public static T ShowComboBoxChoiceDialog<T>(String title, String msg,
            IList<T> items, int selIndex)
        {
            if (selIndex < -1)
                throw new ArgumentOutOfRangeException("The selIndex must be between 0 and " + (items.Count - 1) + "!");

            InputDialog dlg = new InputDialog();
            dlg.txtInput.Visible = false;
            dlg.cmbInput.Visible = true;
            foreach (T obj in items)
                dlg.cmbInput.Items.Add(obj);
            dlg.cmbInput.DropDownStyle = ComboBoxStyle.DropDownList;
            dlg.cmbInput.SelectedIndex = selIndex;
            dlg.lblMessage.Text = msg;
            dlg.Text = title;

            if (dlg.ShowDialog() == DialogResult.OK)
                return (T)dlg.cmbInput.SelectedItem;
            else
                return default(T);
        }

        public static T ShowComboBoxChoiceDialog<T>(String title, String msg,
            IList<T> items)
        {
            return ShowComboBoxChoiceDialog<T>(title, msg, items, 0);
        }

        public static String ShowComboBoxChoiceDialog(String title, String msg,
            IList<String> items, int selIndex)
        {
            return ShowComboBoxChoiceDialog<String>(title, msg, items, selIndex);
        }

        public static String ShowComboBoxChoiceDialog(String title, String msg,
            IList<String> items)
        {
            return ShowComboBoxChoiceDialog<String>(title, msg, items);
        }

        #endregion

        #endregion

        private InputDialog()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;

            txtInput.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
    /// @}
}
