using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using VocabularySpider.Tests.DataAttributes;
using System.Diagnostics;
using System;

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
        public void RetrieveAllVerbNamesInParallel()
        {
            //Arrange
            var indexes = new string[] {
                "1-250",
                "251-500",
                "501-750",
                "751-1000",
                "1001-1250",
                "1251-1500",
                "1501-1750",
                "1751-2000"
            };
            int expectedCount = 2000;
            var stopWatch = new Stopwatch();

            //Act
            stopWatch.Start();
            IEnumerable<string> verbNames = ReversoContextCommonVerbs.RetrieveVerbsFromIndexes("italian", indexes);
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            output.WriteLine("RunTime " + elapsedTime);

            //Assert
            Assert.Equal(expectedCount, verbNames.Count());
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