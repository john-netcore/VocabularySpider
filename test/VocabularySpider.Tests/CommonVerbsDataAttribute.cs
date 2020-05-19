using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace VocabularySpider.Tests
{
    public class CommonVerbsDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "spanish", "1-250", 250 };
            yield return new object[] { "spanish", "251-500", 250 };
            yield return new object[] { "spanish", "501-750", 250 };
            yield return new object[] { "spanish", "751-1000", 250 };
            yield return new object[] { "spanish", "1001-1250", 250 };
            yield return new object[] { "spanish", "1251-1500", 250 };
            yield return new object[] { "spanish", "1501-1750", 250 };
            yield return new object[] { "spanish", "1751-2000", 249 };

            yield return new object[] { "italian", "1-250", 250 };
            yield return new object[] { "italian", "251-500", 250 };
            yield return new object[] { "italian", "501-750", 250 };
            yield return new object[] { "italian", "751-1000", 250 };
            yield return new object[] { "italian", "1001-1250", 250 };
            yield return new object[] { "italian", "1251-1500", 250 };
            yield return new object[] { "italian", "1501-1750", 250 };
            yield return new object[] { "italian", "1751-2000", 250 };

            yield return new object[] { "french", "1-250", 250 };
            yield return new object[] { "french", "251-500", 250 };
            yield return new object[] { "french", "501-750", 250 };
            yield return new object[] { "french", "751-1000", 250 };
            yield return new object[] { "french", "1001-1250", 250 };
            yield return new object[] { "french", "1251-1500", 250 };
            yield return new object[] { "french", "1501-1750", 250 };
            yield return new object[] { "french", "1751-2000", 250 };

            yield return new object[] { "english", "1-250", 250 };
            yield return new object[] { "english", "251-500", 250 };
            yield return new object[] { "english", "501-750", 250 };
            yield return new object[] { "english", "751-1000", 250 };
            yield return new object[] { "english", "1001-1250", 250 };
            yield return new object[] { "english", "1251-1500", 250 };
            yield return new object[] { "english", "1501-1750", 250 };
            yield return new object[] { "english", "1751-2000", 250 };

        }
    }
}