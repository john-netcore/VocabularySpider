using Xunit;
using Xunit.Abstractions;
using VocabularySpider.Italian;
using VocabularySpider.French;
using VocabularySpider.Spanish;

namespace VocabularySpider.Tests
{
    public class ReversoContextVerbConjugationsShould
    {
        private readonly ITestOutputHelper output;

        public ReversoContextVerbConjugationsShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test()
        {
            //Arrange
            var expected = "essere";
            //Act
            var actual = ReversoContextItalianVerbConjugations.GetVerbTense_Infinitive("essere");
            output.WriteLine(actual);
            //Assert
            Assert.Equal(expected, actual, ignoreCase: true);
        }

        [Fact]
        public void RetrieveItalianVerbTense_Infinitive()
        {
            //Arrange
            var expected = "mangiare";
            //Act
            var actual = ReversoContextItalianVerbConjugations.GetVerbTense_Infinitive("mangiare");
            //Assert
            Assert.Equal(expected, actual, ignoreCase: true);
        }

        [Fact]
        public void RetrieveFrenchVerbTense_Infinitive()
        {
            //Arrange
            var expected = "&#234;tre";
            //Act
            var actual = ReversoContextFrenchVerbConjugations.GetVerbTense_Infinitive("être");
            //Assert
            Assert.Equal(expected, actual, ignoreCase: true);
        }

        [Fact]
        public void RetrieveSpanishVerbTense_Infinitive()
        {
            //Arrange
            var expected = "rega&#241;ar";
            //Act
            var actual = ReversoContextSpanishVerbConjugations.GetVerbTense_Infinitive("regañar");
            //Assert
            Assert.Equal(expected, actual, ignoreCase: true);
        }

        // [Fact]
        // public void AddVerbTenseNamesToVerbTenseObject()
        // {
        //     //Arrange
        //     var relativeUrl = "conjugation-french-verb-avoir.html";
        //     var infinitive = "avoir";
        //     var verb = new Verb(infinitive, relativeUrl);
        //     var sut = new ReversoContextVerbConjugations();

        //     //Act
        //     sut.RetrieveAndAddVerbTenses(verb);
        //     VerbTense actual;
        //     verb.VerbTenses.TryGetValue("Indicatif Présent", out actual);

        //     //Assert
        //     Assert.NotNull(actual);
        // }

        // [Fact]
        // public void AddVerbTensesToVerb()
        // {
        //     //Arrange
        //     var relativeUrl = "conjugation-french-verb-avoir.html";
        //     var infinitive = "avoir";
        //     var verb = new Verb(infinitive, relativeUrl);
        //     var sut = new ReversoContextVerbConjugations();

        //     //Act
        //     sut.RetrieveAndAddVerbTenses(verb);
        //     VerbTense actual;
        //     verb.VerbTenses.TryGetValue("Indicatif Présent", out actual);

        //     foreach (var conjugation in actual.Conjugations)
        //     {
        //         output.WriteLine($"Subject pronoun: {conjugation.SubjectPronoun}, Conjugation: {conjugation.Conjugation}");
        //     }

        //     //Assert
        //     Assert.NotNull(actual);
        // }
    }
}