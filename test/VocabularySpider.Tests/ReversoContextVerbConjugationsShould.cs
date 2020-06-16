using Xunit;
using Xunit.Abstractions;
using VocabularySpider.Classes;
using VocabularySpider.Tests.DataAttributes;
using System.Collections.Generic;
using System.Linq;

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
            var actual = ReversoContextVerbConjugations.GetVerbTense_Infinitive("italian", "essere");
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
            var actual = ReversoContextVerbConjugations.GetVerbTense_Infinitive("french", "être");
            //Assert
            Assert.Equal(expected, actual, ignoreCase: true);
        }

        [Fact]
        public void RetrieveSpanishVerbTense_Infinitive()
        {
            //Arrange
            var expected = "rega&#241;ar";
            //Act
            var actual = ReversoContextVerbConjugations.GetVerbTense_Infinitive("spanish", "regañar");
            //Assert
            Assert.Equal(expected, actual, ignoreCase: true);
        }

        [Theory]
        [ItalianSimpleConjugationVerbTensesDataAttribute]
        public void RetrieveItalianSimpleConjugations(string verbTenseName)
        {
            var conjugations = ReversoContextVerbConjugations.GetVerbTenseConjugations("italian", "mangiare", verbTenseName);

            Assert.All(conjugations, c => Assert.IsType<SimpleConjugation>(c));
            Assert.All(conjugations, c => Assert.NotNull(((SimpleConjugation)c).Pronoun));
            Assert.All(conjugations, c => Assert.NotNull(c.Verb));
        }

        [Theory]
        [ItalianCompoundConjugationVerbTensesData]
        public void RetrieveItalianCompoundConjugations(string verbTenseName)
        {
            var conjugations = ReversoContextVerbConjugations.GetVerbTenseConjugations("italian", "mangiare", verbTenseName);

            Assert.All(conjugations, c => Assert.IsType<CompoundConjugation>(c));
            Assert.All(conjugations, c => Assert.NotNull(((CompoundConjugation)c).Pronoun));
            Assert.All(conjugations, c => Assert.NotNull(c.Verb));
        }

        [Fact]
        public void RetrieveItalianImperativeConjugations()
        {
            string[] expected = { "mangia", "mangi", "mangiamo", "mangiate", "mangino" };
            var conjugations = ReversoContextVerbConjugations.GetVerbTenseConjugations("italian", "mangiare", "Imperativo Presente");

            PrintConjugations(conjugations);

            Assert.All(conjugations, c => Assert.IsType<Conjugation>(c));
            Assert.Equal(conjugations.Select(c => c.Verb), expected);
        }

        [Fact]
        public void RetrieveItalianVerbWithVerbTenses()
        {
            var verb = ReversoContextVerbConjugations.GetVerbWithTenses("italian", "mangiare");

            foreach (var verbTense in verb.VerbTenses)
            {
                output.WriteLine(verbTense.VerbTenseName);
                PrintConjugations(verbTense.Conjugations);
                output.WriteLine("\n");
            }
        }

        private void PrintConjugations(IEnumerable<Conjugation> conjugations)
        {
            foreach (var conjugation in conjugations)
            {
                if (conjugation is SimpleConjugation)
                {
                    var simple = conjugation as SimpleConjugation;
                    output.WriteLine($"{simple.Pronoun} {simple.Verb}");
                }
                else if (conjugation is CompoundConjugation)
                {
                    var compound = conjugation as CompoundConjugation;
                    output.WriteLine($"{compound.Pronoun} {compound.AuxiliaryVerb} {compound.Verb}");
                }
                else
                {
                    output.WriteLine($"{conjugation.Verb}");
                }

            }
        }
    }
}