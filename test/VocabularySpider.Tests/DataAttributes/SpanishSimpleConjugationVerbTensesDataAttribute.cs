using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace VocabularySpider.Tests.DataAttributes
{
    public class SpanishSimpleConjugationVerbTensesDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "Indicativo Presente" };
            yield return new object[] { "Indicativo Futuro" };
            yield return new object[] { "Indicativo Pretérito imperfecto" };
            yield return new object[] { "Indicativo Condicional" };
            yield return new object[] { "Indicativo Pretérito perfecto simple" };
            yield return new object[] { "Imperativo " }; //Ends with a trailing whitespace in the html document.
            yield return new object[] { "Subjuntivo Presente" };
            yield return new object[] { "Subjuntivo Futuro" };
            yield return new object[] { "Subjuntivo Pretérito imperfecto" };
            yield return new object[] { "Subjuntivo Pretérito imperfecto (2)" };
            yield return new object[] { "Gerundio " }; //Ends with a trailing whitespace in the html document.
            yield return new object[] { "Infinitivo " }; //Ends with a trailing whitespace in the html document.
            yield return new object[] { "Participio Pasado" };
        }
    }
}