using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace VocabularySpider.Tests
{
    public class ReversoContextPopularVerbsShould
    {
        private readonly ITestOutputHelper output;

        public ReversoContextPopularVerbsShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        private void printPopularVerbs(IEnumerable<string> popularVerbs)
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

            Assert.Throws<ArgumentException>(() => new ReversoContextPopularVerbs(unexistingLanguage));
        }

        [Fact]
        public void ThrowArgumentExcpetionIfLanguageIsNull()
        {
            string unexistingLanguage = null;

            Assert.Throws<ArgumentException>(() => new ReversoContextPopularVerbs(unexistingLanguage));
        }

        [Theory]
        [PopularVerbsData]
        public void RetrieveAllPopularVerbs(string language, int expectedVerbCount)
        {
            var sut = new ReversoContextPopularVerbs(language);

            printPopularVerbs(sut.PopularVerbs);

            Assert.Equal(expectedVerbCount, sut.PopularVerbs.Count());
        }

    }
}
