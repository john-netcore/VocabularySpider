using System.Collections.Generic;
using Xunit;
using VocabularySpider;
using System.Linq;
using Xunit.Abstractions;
using VocabularySpider.Classes;

namespace VocabularySpider.Tests
{
    public class VocabularySpiderShould
    {

        private readonly ITestOutputHelper output;
        public VocabularySpiderShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void MapVerbs()
        {
            //Given
            var verb = ReversoContextVerbConjugations.GetVerbWithTenses("italian", "vivere");

            //When
            Program.Configure();
            var mappedVerbs = Program.MapVerbs(new List<Verb> { verb });

            //Then
            Assert.Equal(1, mappedVerbs.Count());
        }

        private void PrintConjugations(IEnumerable<Conjugation> conjugations)
        {
            foreach (var conjugation in conjugations)
            {

                if (conjugation is CompoundConjugation)
                {
                    var compound = conjugation as CompoundConjugation;
                    output.WriteLine($"{compound.Pronoun} {compound.AuxiliaryVerb} {compound.Verb}");
                }
                else if (conjugation is SimpleConjugation)
                {
                    var simple = conjugation as SimpleConjugation;
                    output.WriteLine($"{simple.Pronoun} {simple.Verb}");
                }
                else
                {
                    output.WriteLine($"{conjugation.Verb}");
                }

            }
        }
    }
}