using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace NET.Tools.MarkupExtensions
{
    [MarkupExtensionReturnType(typeof(double))]
    public sealed class CalculateExtension : MarkupExtension
    {
        public double ValueA { get; set; }
        public double ValueB { get; set; }
        public double ValueC { get; set; }
        public double ValueD { get; set; }
        public double ValueE { get; set; }
        public double ValueF { get; set; }
        public double ValueG { get; set; }
        public double ValueH { get; set; }
        public double ValueI { get; set; }
        public double ValueJ { get; set; }
        public double ValueK { get; set; }
        public double ValueL { get; set; }
        public double ValueM { get; set; }
        public double ValueN { get; set; }
        public double ValueO { get; set; }
        public double ValueP { get; set; }
        public double ValueQ { get; set; }
        public double ValueR { get; set; }
        public double ValueS { get; set; }
        public double ValueT { get; set; }
        public double ValueU { get; set; }
        public double ValueV { get; set; }
        public double ValueW { get; set; }
        public double ValueX { get; set; }
        public double ValueY { get; set; }
        public double ValueZ { get; set; }

        [ConstructorArgument("formula")]
        public String Formula { get; set; }

        public CalculateExtension(string formula)
        {
            Formula = formula;
        }

        public CalculateExtension()
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            IDictionary<String, double> valueList = new Dictionary<string, double>();
            for (char i = 'A'; i<='Z'; i++)
            {
                valueList.Add(i+"", (double)GetType().GetProperty("Value" + i).GetValue(this, null));
            }
            return Formula.ParseCalculationString(valueList);
        }
    }
}
