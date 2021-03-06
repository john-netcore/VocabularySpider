using Xunit;
using Xunit.Abstractions;
using VocabularySpider.VerbsMetadata;
using System.Linq;
using System.Collections.Generic;
using VocabularySpider.Tests.DataAttributes;

namespace VocabularySpider.Tests
{
    public class VerbTenseMetadataRetrieverShould
    {
        private readonly ITestOutputHelper output;

        public VerbTenseMetadataRetrieverShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void RetrieveItalianVerbTenseNames()
        {
            var sut = new VerbTenseMetadataRetriever("italian", "essere");

            var verbTenseNamesCol = sut.RetrieveVerbTenseTypes();

            foreach (var verbTense in verbTenseNamesCol)
            {
                output.WriteLine(verbTense);
            }

            Assert.NotNull(verbTenseNamesCol);
        }

        [Fact]
        public void RetrieveSpanishVerbTenseNames()
        {
            var sut = new VerbTenseMetadataRetriever("spanish", "ser");

            var verbTenseNamesCol = sut.RetrieveVerbTenseTypes();

            foreach (var verbTense in verbTenseNamesCol)
            {
                output.WriteLine(verbTense);
            }

            Assert.NotNull(verbTenseNamesCol);
        }

        [Fact]
        public void RetrieveFrenchVerbTenseNames()
        {
            var sut = new VerbTenseMetadataRetriever("french", "avoir");

            var verbTenseNamesCol = sut.RetrieveVerbTenseTypes();

            foreach (var verbTense in verbTenseNamesCol)
            {
                output.WriteLine(verbTense);
            }

            Assert.NotNull(verbTenseNamesCol);
        }

        [Fact]
        public void RetrieveFrenchSimpleVerbTenseNames()
        {
            var sut = new VerbTenseMetadataRetriever("french", "avoir");

            var verbTenseNamesCol = sut.RetrieveSimpleVerbTenseTypes();

            foreach (var verbTense in verbTenseNamesCol)
            {
                output.WriteLine(verbTense);
            }

            Assert.NotNull(verbTenseNamesCol);
        }

        [Fact]
        public void RetrieveFrenchCompoundVerbTenseNames()
        {
            var sut = new VerbTenseMetadataRetriever("french", "avoir");

            var verbTenseNamesCol = sut.RetrieveCompoundVerbTenseTypes();

            foreach (var verbTense in verbTenseNamesCol)
            {
                output.WriteLine(verbTense);
            }

            Assert.NotNull(verbTenseNamesCol);
        }

        [Theory]
        [VerbTenseData]
        public void RetrieveVerbTensesForVerbTenseMood(string language, string verb, string verbTenseMood, int expectedVerbTenseMoodCount)
        {
            var sut = new VerbTenseMetadataRetriever(language, verb);

            var verbTenseConjugations = sut.RetrieveVerbTenseMoodCollection(verbTenseMood);

            Assert.Equal(expectedVerbTenseMoodCount, verbTenseConjugations.Count());
        }

        [Theory]
        [CommonVerbsIndexesData]
        public void RetrieveAllCommonItalianVerbsConjugationsForMood_Congiuntivo(string index)
        {
            //Given
            output.WriteLine("Retrieving verb names.");
            IEnumerable<(string VerbName, string ConjugationPath)> verbs = ReversoContextCommonVerbs.RetrieveVerbsFromIndex("italian", index);
            output.WriteLine("Verb names retrieved.");

            List<string> conjugations = new List<string>();

            //When

            foreach (var verbContent in verbs)
            {
                var verbTensemetadataRetriever = new VerbTenseMetadataRetriever("italian", verbContent.VerbName);
                output.WriteLine($"Retrieving verb {verbContent.VerbName} conjugations.");
                var conjugationsCol = verbTensemetadataRetriever.RetrieveHtmlConjugationsForVerbMood("Congiuntivo");
                output.WriteLine($"Conjugations for verb {verbContent.VerbName} retrieved.");
                conjugations.AddRange(conjugationsCol);
            }

            output.WriteLine($"Asserting conjugations...");
            //Then
            Assert.All(conjugations, conjugation => Assert.Contains("particletxt", conjugation));
        }
    }
}