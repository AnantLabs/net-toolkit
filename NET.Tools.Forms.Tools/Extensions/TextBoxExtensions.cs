using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class TextBoxExtensions
    {
        /// <summary>
        /// Add a validator and change all incorrect inputs
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="validator">The validator function</param>
        public static void AddInputValidator(this TextBox textBox, Func<String, bool> validator)
        {
            textBox.KeyDown += (s, e) =>
            {
                if (!validator(textBox.Text))
                    e.SuppressKeyPress = true;
            };
        }

        /// <summary>
        /// Add a validator and mark the box with a colored border if the  content is incorrect
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="validator">The validator function</param>
        /// <param name="errColor">Color for error</param>
        public static void AddMarkValidator(this TextBox textBox, Func<String, bool> validator, Color errColor)
        {
            textBox.TextChanged += (s, e) =>
            {
                if (!validator(textBox.Text))
                    textBox.BackColor = errColor;
                else
                    textBox.BackColor = SystemColors.Window;
            };
        }

        /// <summary>
        /// Add a validator and mark the box with a colored border if the  content is incorrect
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="validator">The validator function</param>
        public static void AddMarkValidator(this TextBox textBox, Func<String, bool> validator)
        {
            AddMarkValidator(textBox, validator, Color.Red);
        }
    }
    /// @}
}
