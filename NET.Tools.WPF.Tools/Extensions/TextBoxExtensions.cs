using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class TextBoxExtensions
    {
        private static Dictionary<TextBox, Brush> oldBrush = new Dictionary<TextBox,Brush>();

        /// <summary>
        /// Add a validator and change all incorrect inputs
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="validator">The validator function</param>
        /// <param name="additionalKeys">Additional keys to ignore</param>
        public static void AddInputValidator(this TextBox textBox, Func<String, bool> validator, params Key[] additionalKeys)
        {
            DataObject.AddPastingHandler(textBox,
                new DataObjectPastingEventHandler(
                    (s, e) =>
                    {
                        string lPastingText = e.DataObject.GetData(DataFormats.Text) as string;
                        if (!validator(lPastingText))
                            e.CancelCommand();
                    }));

            textBox.PreviewKeyDown += (s, e) =>
            {
                foreach(Key key in additionalKeys)
                    if (e.Key == key)
                    {
                        e.Handled = true;
                        break;
                    }
            };

            textBox.PreviewTextInput += (s, e) =>
            {
                String text = textBox.Text;
                text = text.Insert(textBox.SelectionStart, e.Text);

                if (!validator(text))
                    e.Handled = true;
            };
        }

        /// <summary>
        /// Add a validator and mark the box with a colored border if the  content is incorrect
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="validator">The validator function</param>
        /// <param name="errBrush">Brush for error</param>
        public static void AddMarkValidator(this TextBox textBox, Func<String, bool> validator, Brush errBrush)
        {
            if (!oldBrush.ContainsKey(textBox))
                oldBrush.Add(textBox, textBox.BorderBrush);
            else
                oldBrush[textBox] = textBox.BorderBrush;

            textBox.TextChanged += (s, e) =>
            {
                if (!validator(textBox.Text))
                    textBox.BorderBrush = errBrush;
                else
                    textBox.BorderBrush = oldBrush[textBox];
            };
        }

        /// <summary>
        /// Add a validator and mark the box with a colored border if the  content is incorrect
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="validator">The validator function</param>
        public static void AddMarkValidator(this TextBox textBox, Func<String, bool> validator)
        {
            AddMarkValidator(textBox, validator, Brushes.Red);
        }
    }
    /// @}
}
