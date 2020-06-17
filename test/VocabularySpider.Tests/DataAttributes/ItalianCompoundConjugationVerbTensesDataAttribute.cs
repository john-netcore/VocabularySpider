using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace VocabularySpider.Tests.DataAttributes
{
    public class ItalianCompoundConjugationVerbTensesDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Indicativo Passato prossimo" };
            yield return new object[] { "Indicativo Trapassato prossimo" };
            yield return new object[] { "Indicativo Trapassato remoto" };
            yield return new object[] { "Indicativo Futuro anteriore" };
            yield return new object[] { "Condizionale Passato" };
            yield return new object[] { "Congiuntivo Passato" };
            yield return new object[] { "Congiuntivo Trapassato" };
            yield return new object[] { "Gerundio Passato" };
        }
    }
}