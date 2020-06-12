using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace VocabularySpider.Tests.DataAttributes
{
    public class VerbTenseDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "italian", "essere", "Indicativo", 8 };
            yield return new object[] { "italian", "essere", "Congiuntivo", 4 };
            yield return new object[] { "italian", "essere", "Condizionale", 2 };
            yield return new object[] { "italian", "essere", "Imperativo", 1 };
            yield return new object[] { "italian", "essere", "Gerundio", 2 };
            yield return new object[] { "italian", "essere", "Infinito", 1 };
            yield return new object[] { "italian", "essere", "Participio", 2 };

            yield return new object[] { "spanish", "ser", "Indicativo", 10 };
            yield return new object[] { "spanish", "ser", "Imperativo", 1 };
            yield return new object[] { "spanish", "ser", "Subjuntivo", 8 };
            yield return new object[] { "spanish", "ser", "Gerundio", 2 };
            yield return new object[] { "spanish", "ser", "Infinitivo", 2 };
            yield return new object[] { "spanish", "ser", "Participio", 1 };

            yield return new object[] { "french", "être", "Indicatif", 8 };
            yield return new object[] { "french", "être", "Subjonctif", 4 };
            yield return new object[] { "french", "être", "Conditionnel", 3 };
            yield return new object[] { "french", "être", "Participe", 3 };
            yield return new object[] { "french", "être", "Impératif", 2 };
            yield return new object[] { "french", "être", "Infinitif", 2 };
        }
    }
}