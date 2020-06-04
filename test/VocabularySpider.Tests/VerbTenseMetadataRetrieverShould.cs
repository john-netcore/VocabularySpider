using Xunit;
using Xunit.Abstractions;
using VocabularySpider.VerbsMetadata;
using System.Linq;
using System.Collections.Generic;

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
        public void RetrieveItalianConjugationsForMood_Indicativo()
        {
            int expectedVerbTenseMoodCount = 8;
            var sut = new VerbTenseMetadataRetriever("italian", "essere");

            var verbTenseConjugations = sut.RetrieveVerbTenseMoodCollection("Indicativo");

            foreach (var conjugation in verbTenseConjugations)
            {
                output.WriteLine(conjugation);
            }

            Assert.Equal(expectedVerbTenseMoodCount, verbTenseConjugations.Count());
        }

        [Fact]
        public void RetrieveItalianConjugationsForMood_Congiuntivo()
        {
            int expectedVerbTenseMoodCount = 4;
            var sut = new VerbTenseMetadataRetriever("italian", "essere");

            var verbTenseConjugations = sut.RetrieveVerbTenseMoodCollection("Congiuntivo");

            foreach (var conjugation in verbTenseConjugations)
            {
                output.WriteLine(conjugation);
            }

            Assert.Equal(expectedVerbTenseMoodCount, verbTenseConjugations.Count());
        }

        [Fact]
        public void RetrieveItalianConjugationsForMood_Condizionale()
        {
            int expectedVerbTenseMoodCount = 2;
            var sut = new VerbTenseMetadataRetriever("italian", "essere");

            var verbTenseConjugations = sut.RetrieveVerbTenseMoodCollection("Condizionale");

            foreach (var conjugation in verbTenseConjugations)
            {
                output.WriteLine(conjugation);
            }

            Assert.Equal(expectedVerbTenseMoodCount, verbTenseConjugations.Count());
        }

        [Fact]
        public void RetrieveItalianConjugationsForMood_Imperativo()
        {
            int expectedVerbTenseMoodCount = 1;
            var sut = new VerbTenseMetadataRetriever("italian", "essere");

            var verbTenseConjugations = sut.RetrieveVerbTenseMoodCollection("Imperativo");

            foreach (var conjugation in verbTenseConjugations)
            {
                output.WriteLine(conjugation);
            }

            Assert.Equal(expectedVerbTenseMoodCount, verbTenseConjugations.Count());
        }

        [Fact]
        public void RetrieveItalianConjugationsForMood_Gerundio()
        {
            int expectedVerbTenseMoodCount = 2;
            var sut = new VerbTenseMetadataRetriever("italian", "essere");

            var verbTenseConjugations = sut.RetrieveVerbTenseMoodCollection("Gerundio");

            foreach (var conjugation in verbTenseConjugations)
            {
                output.WriteLine(conjugation);
            }

            Assert.Equal(expectedVerbTenseMoodCount, verbTenseConjugations.Count());
        }

        [Fact]
        public void RetrieveItalianConjugationsForMood_Infinito()
        {
            int expectedVerbTenseMoodCount = 1;
            var sut = new VerbTenseMetadataRetriever("italian", "essere");

            var verbTenseConjugations = sut.RetrieveVerbTenseMoodCollection("Infinito");

            foreach (var conjugation in verbTenseConjugations)
            {
                output.WriteLine(conjugation);
            }

            Assert.Equal(expectedVerbTenseMoodCount, verbTenseConjugations.Count());
        }

        [Fact]
        public void RetrieveItalianConjugationsForMood_Participio()
        {
            int expectedVerbTenseMoodCount = 2;
            var sut = new VerbTenseMetadataRetriever("italian", "essere");

            var verbTenseConjugations = sut.RetrieveVerbTenseMoodCollection("Participio");

            foreach (var conjugation in verbTenseConjugations)
            {
                output.WriteLine(conjugation);
            }

            Assert.Equal(expectedVerbTenseMoodCount, verbTenseConjugations.Count());
        }

        [Theory]
        [CommonVerbsIndexesData]
        public void RetrieveAllCommonItalianVerbsConjugationsForMood_Congiuntivo(string index)
        {
            //Given
            var commonVerbs = new ReversoContextCommonVerbs("italian");

            output.WriteLine("Retrieving verb names.");
            IEnumerable<string> verbNames = commonVerbs.RetrieveVerbNameFromIndex(index);
            output.WriteLine("Verb names retrieved.");

            List<string> conjugations = new List<string>();

            //When

            foreach (var verbName in verbNames)
            {
                var verbTensemetadataRetriever = new VerbTenseMetadataRetriever("italian", verbName);
                output.WriteLine($"Retrieving verb {verbName} conjugations.");
                var conjugationsCol = verbTensemetadataRetriever.RetrieveHtmlConjugationsForVerbMood("Congiuntivo");
                output.WriteLine($"Conjugations for verb {verbName} retrieved.");
                conjugations.AddRange(conjugationsCol);
            }

            output.WriteLine($"Asserting conjugations...");
            //Then
            Assert.All(conjugations, conjugation => Assert.Contains("particletxt", conjugation));
        }
    }
}