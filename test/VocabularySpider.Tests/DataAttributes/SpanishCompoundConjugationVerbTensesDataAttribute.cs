using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace VocabularySpider.Tests.DataAttributes
{
    public class SpanishCompoundConjugationVerbTensesDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Indicativo Pretérito perfecto compuesto" };
            yield return new object[] { "Indicativo Pretérito pluscuamperfecto" };
            yield return new object[] { "Indicativo Pretérito anterior" };
            yield return new object[] { "Indicativo Futuro perfecto" };
            yield return new object[] { "Indicativo Condicional perfecto" };
            yield return new object[] { "Subjuntivo Pretérito pluscuamperfecto" };
            yield return new object[] { "Subjuntivo Futuro perfecto" };
            yield return new object[] { "Subjuntivo Pretérito pluscuamperfecto (2)" };
            yield return new object[] { "Subjuntivo Pretérito perfecto" };
            yield return new object[] { "Gerundio compuesto " }; //Ends with a trailing whitespace in the html document.
            yield return new object[] { "Infinitivo compuesto " }; //Ends with a trailing whitespace in the html document.
        }
    }
}