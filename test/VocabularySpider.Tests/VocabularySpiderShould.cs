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
            var mappedVerb = Program.MapVerbs(new List<Verb> { verb }).FirstOrDefault();
            var tensePassatoProssimo = mappedVerb.VerbTenses
                                    .FirstOrDefault(vt => vt.TenseName == "Indicativo Passato prossimo");
            var firstConjugation = (BL.CompoundConjugation)tensePassatoProssimo.Conjugations.FirstOrDefault();
            var lastConjugation = (BL.CompoundConjugation)tensePassatoProssimo.Conjugations.LastOrDefault();

            //Then
            Assert.Equal("io", firstConjugation.Pronoun);
            Assert.Equal("ho", firstConjugation.AuxiliaryVerb);
            Assert.Equal("vissuto", firstConjugation.InflictedVerb);

            Assert.Equal("loro", lastConjugation.Pronoun);
            Assert.Equal("sono", lastConjugation.AuxiliaryVerb);
            Assert.Equal("vissute", lastConjugation.InflictedVerb);
        }

        [Fact]
        public void TestName()
        {
            //Given
            var verb = ReversoContextVerbConjugations.GetVerbWithTenses("italian", "vivere");
            Program.Configure();
            var mappedVerbs = Program.MapVerbs(new List<Verb> { verb });
            //When
            var count = Program.AddVerbs(mappedVerbs);
            //Then
            Assert.True(count > 0);
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