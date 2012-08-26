using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Markup;
using System.Xaml;

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
    public sealed class LanguageExtension : MarkupExtension
    {
        private const String ILLEGAL_KEY = "#IllegalKey#";
        private const String NOT_FOUND = "#NotFound#";

        [ConstructorArgument("key")]
        public String Key { get; set; }

        public LanguageExtension(String key)
        {
            Key = key;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrEmpty(Key))
                return ILLEGAL_KEY;
   
            return GetString(Key, GetResourceManager(serviceProvider));
        }

        /// <summary>
        /// Gets the string to the given key with the current ui culture
        /// </summary>
        /// <param name="key">key to search string</param>
        /// <param name="rm">resource manager to use</param>
        /// <returns></returns>
        private String GetString(String key, ResourceManager rm)
        {
            if (rm == null)
            {
                return key;
            }

            String str = rm.GetString(key, CultureInfo.CurrentUICulture);
            if (String.IsNullOrEmpty(str))
                return NOT_FOUND;

            return str;
        }

        private ResourceManager GetResourceManager(IServiceProvider serviceProvider)
        {
            var rootObjectProvider = serviceProvider.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;
            var root = rootObjectProvider.RootObject;

            try
            {
                Assembly executingAssembly = root.GetType().Assembly;
                object[] array = executingAssembly.GetCustomAttributes(typeof(LanguageResourceAttribute), true);
                if (array.Length <= 0)
                    throw new InvalidOperationException("Cannot find Language Extension Attribute in assembly: " +
                                                        executingAssembly.GetName());
                if (array.Length > 1)
                    throw new InvalidOperationException(
                        "Find more than one Language Extension Attribute in assembly: " + executingAssembly.GetName());

                LanguageResourceAttribute attr = (LanguageResourceAttribute)array[0];

                return new ResourceManager(attr.LanguageResourceName, executingAssembly);
            }
            catch (Exception)
            {
                if (new DependencyObject().IsDesignMode())
                {
                    return null;
                }

                throw;
            }
        }
    }
}
