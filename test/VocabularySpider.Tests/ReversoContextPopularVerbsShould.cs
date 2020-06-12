using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using VocabularySpider.Tests.DataAttributes;

namespace VocabularySpider.Tests
{
    public class ReversoContextPopularVerbsShould
    {
        private readonly ITestOutputHelper output;

        public ReversoContextPopularVerbsShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        private void printContent(IEnumerable<string> content)
        {
            foreach (var value in content)
            {
                output.WriteLine(value);
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
        public void RetrieveAllVerbs(string language, int expectedVerbCount)
        {
            var sut = new ReversoContextPopularVerbs(language);

            var popularVerbs = sut.RetrieveVerbs();
            printContent(popularVerbs);

            Assert.Equal(expectedVerbCount, popularVerbs.Count());
        }

        [Theory]
        [PopularVerbsData]
        public void RetrieveAllVerbTensesUrls(string language, int expectedVerbCount)
        {
            var sut = new ReversoContextPopularVerbs(language);

            var verbTensesUrls = sut.RetrieveVerbTensesUrls();
            printContent(verbTensesUrls);

            Assert.Equal(expectedVerbCount, verbTensesUrls.Count());
        }
    }
}
