using Xunit;
using Xunit.Abstractions;
using VocabularySpider.BL;

namespace VocabularySpider.Tests
{
    public class ReversoContextVerbConjugationsShould
    {
        private readonly ITestOutputHelper output;

        public ReversoContextVerbConjugationsShould(ITestOutputHelper output)
        {
            this.output = output;
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