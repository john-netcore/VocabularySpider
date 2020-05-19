using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

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

        [Fact]
        public void ThrowArgumentExcpetionIfLanguageNotAvailable()
        {
            var unexistingLanguage = "jfslfkjs";

            Assert.Throws<ArgumentException>(() => new ReversoContextCommonVerbs(unexistingLanguage));
        }

        [Fact]
        public void ThrowArgumentExcpetionIfLanguageIsNull()
        {
            string unexistingLanguage = null;

            Assert.Throws<ArgumentException>(() => new ReversoContextCommonVerbs(unexistingLanguage));
        }

        [Fact]
        public void RetrieveSameLanguageAsLanguageArgument()
        {
            var expectedLanguage = "french";
            var sut = new ReversoContextCommonVerbs(expectedLanguage);

            Assert.Equal(expectedLanguage, sut.Language);
        }

        [Theory]
        [CommonVerbsData]
        public void ShouldRetrieveAllVerbsFromGivenIndex(string language, string index, int expectedVerbCount)
        {
            var sut = new ReversoContextCommonVerbs(language);

            IEnumerable<string> verbs = sut.RetrieveVerbsFromIndex(index);
            int actualCount = verbs.Count();

            output.WriteLine($"Language: {language}, Index: {index}, Expected: {expectedVerbCount}, Actual: {actualCount}");

            Assert.Equal(expectedVerbCount, actualCount);
        }
    }
}