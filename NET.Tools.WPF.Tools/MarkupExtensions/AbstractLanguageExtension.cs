using System;
using System.Windows.Markup;

namespace NET.Tools
{
    /// <summary>
    /// Abstract class for implementation of a internationality in wpf
    /// 
    /// <example>
    /// This example shows you to use this markup extension:
    /// <code>
    /// public class LanguageExtension : AbstractLanguageExtension
    /// {
    ///     protected override String GetString(String key)
    ///     {
    ///         return MyLanguageManager.GetString(key);
    ///     }
    /// }
    /// // XAML:
    /// ...Content="{tools:Language ExampleText1}"...
    /// </code>
    /// </example>
    /// </summary>
    [MarkupExtensionReturnType(typeof(String))]
    public abstract class AbstractLanguageExtension : MarkupExtension
    {
        private const String NOTFOUND = "#StringNotFound#";

        [ConstructorArgument("key")]
        public String Key { get; set; }

        public AbstractLanguageExtension(String key)
        {
            Key = key;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrEmpty(Key))
                return NOTFOUND;

            return GetString(Key) ?? NOTFOUND;
        }

        /// <summary>
        /// Gets the string to the given key with the current ui culture
        /// </summary>
        /// <param name="key">key to search string</param>
        /// <returns></returns>
        protected abstract String GetString(String key);
    }
}
