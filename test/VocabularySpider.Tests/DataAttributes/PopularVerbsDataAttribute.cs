using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace VocabularySpider.Tests.DataAttributes
{
    public class PopularVerbsDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "spanish", 30 };
            yield return new object[] { "italian", 30 };
            yield return new object[] { "french", 30 };
            yield return new object[] { "english", 30 };
        }
    }
}