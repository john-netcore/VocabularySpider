using Xunit;
using Xunit.Abstractions;
using VocabularySpider.Italian;
using VocabularySpider.French;
using VocabularySpider.Spanish;
using VocabularySpider.Classes;
using VocabularySpider.Tests.DataAttributes;

namespace VocabularySpider.Tests
{
    public class ReversoContextVerbConjugationsShould
    {
        private readonly ITestOutputHelper output;

        public ReversoContextVerbConjugationsShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        //TODO: Remove when finished with tests.
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
            var actual = ReversoContextVerbConjugations.GetVerbTense_Infinitive("italian", "mangiare");
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

        [Theory]
        [ItalianSimpleConjugationVerbTensesDataAttribute]
        public void RetrieveItalianSimpleConjugations(string verbTenseName)
        {
            var conjugations = ReversoContextItalianVerbConjugations.GetVerbTenseConjugations("mangiare", verbTenseName);

            Assert.All(conjugations, c => Assert.IsType<SimpleConjugation>(c));
            Assert.All(conjugations, c => Assert.NotNull(((SimpleConjugation)c).Pronoun));
            Assert.All(conjugations, c => Assert.NotNull(c.Verb));
        }

        [Theory]
        [ItalianCompoundConjugationVerbTensesData]
        public void RetrieveItalianCompoundConjugations(string verbTenseName)
        {
            var conjugations = ReversoContextItalianVerbConjugations.GetVerbTenseConjugations("mangiare", verbTenseName);

            foreach (var conjugation in conjugations)
            {
                var comConj = (CompoundConjugation)conjugation;
                output.WriteLine(comConj.Pronoun + " " + comConj.AuxiliaryVerb + " " + comConj.Verb);
            }

            Assert.All(conjugations, c => Assert.IsType<CompoundConjugation>(c));
            Assert.All(conjugations, c => Assert.NotNull(((CompoundConjugation)c).Pronoun));
            Assert.All(conjugations, c => Assert.NotNull(c.Verb));
        }
    }
}