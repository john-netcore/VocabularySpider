using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace VocabularySpider.Tests.DataAttributes
{
    public class FrenchCompoundConjugationVerbTensesDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Indicatif Passé composé" };
            yield return new object[] { "Indicatif Plus-que-parfait" };
            yield return new object[] { "Indicatif Passé antérieur" };
            yield return new object[] { "Indicatif Futur antérieur" };
            yield return new object[] { "Subjonctif Plus-que-parfait" };
            yield return new object[] { "Subjonctif Passé" };
            yield return new object[] { "Conditionnel Passé première forme" };
            yield return new object[] { "Conditionnel Passé deuxième forme" };
            yield return new object[] { "Participe Passé composé" };
            yield return new object[] { "Impératif Passé" };
            yield return new object[] { "Infinitif Passé" };
        }
    }
}