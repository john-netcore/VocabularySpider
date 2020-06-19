using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace VocabularySpider.Tests.DataAttributes
{
    public class FrenchSimpleConjugationVerbTensesDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Indicatif Présent" };
            yield return new object[] { "Indicatif Imparfait" };
            yield return new object[] { "Indicatif Futur" };
            yield return new object[] { "Indicatif Passé simple" };
            yield return new object[] { "Subjonctif Présent" };
            yield return new object[] { "Subjonctif Imparfait" };
            yield return new object[] { "Conditionnel Présent" };
            yield return new object[] { "Participe Présent" };
            yield return new object[] { "Participe Passé" };
            yield return new object[] { "Impératif Présent" };
            yield return new object[] { "Infinitif Présent" };
        }
    }
}