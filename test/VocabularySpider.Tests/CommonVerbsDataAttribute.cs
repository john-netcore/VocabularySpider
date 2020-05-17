using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace VocabularySpider.Tests
{
    public class CommonVerbsDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "spanish", 250 };
            yield return new object[] { "italian", 250 };
            yield return new object[] { "french", 250 };
            yield return new object[] { "english", 250 };
        }
    }
}