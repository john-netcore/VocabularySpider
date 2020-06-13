using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace VocabularySpider.Tests.DataAttributes
{
    public class ItalianSimpleConjugationVerbTensesDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Indicativo Presente" };
            yield return new object[] { "Indicativo Imperfetto" };
            yield return new object[] { "Indicativo Passato remoto" };
            yield return new object[] { "Indicativo Futuro semplice" };
            yield return new object[] { "Congiuntivo Presente" };
            yield return new object[] { "Congiuntivo Imperfetto" };
            yield return new object[] { "Condizionale Presente" };
        }
    }
}