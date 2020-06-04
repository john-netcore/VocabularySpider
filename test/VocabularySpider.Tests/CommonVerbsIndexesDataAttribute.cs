using System.Collections.Generic;
using System.Reflection;
using Xunit.Sdk;

namespace VocabularySpider.Tests
{
    public class CommonVerbsIndexesDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "1-250" };
            yield return new object[] { "251-500" };
            yield return new object[] { "501-750" };
            yield return new object[] { "751-1000" };
            yield return new object[] { "1001-1250" };
            yield return new object[] { "1251-1500" };
            yield return new object[] { "1501-1750" };
            yield return new object[] { "1751-2000" };
        }
    }
}