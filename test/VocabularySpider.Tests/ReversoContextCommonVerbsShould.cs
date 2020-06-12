using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using VocabularySpider.Tests.DataAttributes;

namespace VocabularySpider.Tests
{
    public class ReversoContextCommonVerbsShould
    {
        private readonly ITestOutputHelper output;

        public ReversoContextCommonVerbsShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        private void printCommonVerbs(IEnumerable<string> popularVerbs)
        {
            foreach (var verb in popularVerbs)
            {
                output.WriteLine(verb);
            }
        }

        [Theory]
        [CommonVerbsData]
        public void ShouldRetrieveAllVerbsFromGivenIndex(string language, string index, int expectedVerbCount)
        {
            IEnumerable<(string VerbName, string ConjugationPath)> verbs = ReversoContextCommonVerbs.RetrieveVerbsFromIndex(language, index);
            int actualCount = verbs.Count();

            foreach (var verbContent in verbs)
            {

                output.WriteLine(verbContent.VerbName + "   " + verbContent.ConjugationPath);
            }

            output.WriteLine($"Language: {language}, Index: {index}, Expected: {expectedVerbCount}, Actual: {actualCount}");

            Assert.Equal(expectedVerbCount, actualCount);
        }
    }
}