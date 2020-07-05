using Xunit;
using Xunit.Abstractions;
using VocabularySpider.Classes;
using VocabularySpider.Tests.DataAttributes;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System;

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
            var conjugations = ReversoContextVerbConjugations.GetVerbTenseConjugations("italian", "vivere", verbTenseName);

            Assert.All(conjugations, c => Assert.IsType<SimpleConjugation>(c));
            Assert.All(conjugations, c => Assert.NotNull(c.Verb));
        }

        [Theory]
        [ItalianCompoundConjugationVerbTensesData]
        public void RetrieveItalianCompoundConjugations(string verbTenseName)
        {
            var conjugations = ReversoContextVerbConjugations.GetVerbTenseConjugations("italian", "vivere", verbTenseName);
            PrintConjugations(conjugations);
            Assert.All(conjugations, c => Assert.IsType<CompoundConjugation>(c));
            Assert.All(conjugations, c => Assert.NotNull(((CompoundConjugation)c).AuxiliaryVerb));
            Assert.All(conjugations, c => Assert.NotNull(c.Verb));
        }

        [Fact]
        public void RetrieveItalianImperativeConjugations()
        {
            string[] expected = { "mangia", "mangi", "mangiamo", "mangiate", "mangino" };
            var conjugations = ReversoContextVerbConjugations.GetVerbTenseConjugations("italian", "mangiare", "Imperativo Presente");

            PrintConjugations(conjugations);

            Assert.All(conjugations, c => Assert.IsType<SimpleConjugation>(c));
            Assert.Equal(conjugations.Select(c => c.Verb), expected);
        }

        [Fact]
        public void RetrieveItalianVerbWithVerbTenses()
        {
            var expectedTenseCount = 20;

            var verb = ReversoContextVerbConjugations.GetVerbWithTenses("italian", "vivere");

            foreach (var verbTense in verb.VerbTenses)
            {
                output.WriteLine(verbTense.VerbTenseName);
                PrintConjugations(verbTense.Conjugations);
                output.WriteLine("\n");
            }

            Assert.Equal(expectedTenseCount, verb.VerbTenses.Count);
        }

        [Fact]
        public void RetrieveItalianFirst250CommonVerbsWithVerbTenses()
        {
            IEnumerable<(string VerbName, string ConjugationPath)> verbsInfo = ReversoContextCommonVerbs.RetrieveVerbsFromIndex("italian", "1-250");
            int actualCount = verbsInfo.Count();

            List<Verb> verbs = new List<Verb>();
            foreach (var verbInfo in verbsInfo)
            {
                var verb = ReversoContextVerbConjugations.GetVerbWithTenses("italian", verbInfo.VerbName);
                verbs.Add(verb);
            }

            Assert.Equal(verbs.Count, actualCount);
        }

        [Fact]
        public void TestName()
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
            IEnumerable<string> verbNames = ReversoContextCommonVerbs.RetrieveVerbsFromIndexes("italian", indexes);

            //Act
            stopWatch.Start();
            var verbs = ReversoContextVerbConjugations.GetVerbsWithTenses("italian", verbNames);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            output.WriteLine("RunTime " + elapsedTime);

            //Assert
            Assert.Equal(expectedCount, verbs.Count());
            Assert.Equal(20, verbs.First().VerbTenses.Count);
        }


        [Theory]
        [SpanishSimpleConjugationVerbTensesDataAttribute]
        public void RetrieveSpanishSimpleConjugations(string verbTenseName)
        {
            var conjugations = ReversoContextVerbConjugations.GetVerbTenseConjugations("spanish", "manejar", verbTenseName);

            PrintConjugations(conjugations);

            Assert.All(conjugations, c => Assert.IsType<SimpleConjugation>(c));
            Assert.All(conjugations, c => Assert.NotNull(c.Verb));
        }

        [Theory]
        [SpanishCompoundConjugationVerbTensesData]
        public void RetrieveSpanishCompoundConjugations(string verbTenseName)
        {
            var conjugations = ReversoContextVerbConjugations.GetVerbTenseConjugations("spanish", "manejar", verbTenseName);

            PrintConjugations(conjugations);

            Assert.All(conjugations, c => Assert.IsType<CompoundConjugation>(c));
            Assert.All(conjugations, c => Assert.NotNull(((CompoundConjugation)c).AuxiliaryVerb));
            Assert.All(conjugations, c => Assert.NotNull(c.Verb));
        }

        [Fact]
        public void RetrieveSpanishVerbWithVerbTenses()
        {
            var expectedTenseCount = 24;

            var verb = ReversoContextVerbConjugations.GetVerbWithTenses("spanish", "manejar");

            foreach (var verbTense in verb.VerbTenses)
            {
                output.WriteLine(verbTense.VerbTenseName);
                PrintConjugations(verbTense.Conjugations);
                output.WriteLine("\n");
            }

            Assert.Equal(expectedTenseCount, verb.VerbTenses.Count);
        }

        [Fact]
        public void RetrieveSpanishFirst250CommonVerbsWithVerbTenses()
        {
            IEnumerable<(string VerbName, string ConjugationPath)> verbsInfo = ReversoContextCommonVerbs.RetrieveVerbsFromIndex("spanish", "1-250");
            int actualCount = verbsInfo.Count();

            List<Verb> verbs = new List<Verb>();
            foreach (var verbInfo in verbsInfo)
            {
                var verb = ReversoContextVerbConjugations.GetVerbWithTenses("spanish", verbInfo.VerbName);
                verbs.Add(verb);
            }

            Assert.Equal(verbs.Count, actualCount);
        }

        [Theory]
        [FrenchSimpleConjugationVerbTensesDataAttribute]
        public void RetrieveFrenchSimpleConjugations(string verbTenseName)
        {
            var conjugations = ReversoContextVerbConjugations.GetVerbTenseConjugations("french", "regarder", verbTenseName);
            PrintConjugations(conjugations);

            Assert.All(conjugations, c => Assert.IsType<SimpleConjugation>(c));
            Assert.All(conjugations, c => Assert.NotNull(c.Verb));
        }

        [Theory]
        [FrenchCompoundConjugationVerbTensesDataAttribute]
        public void RetrieveFrenchCompoundConjugations(string verbTenseName)
        {
            var conjugations = ReversoContextVerbConjugations.GetVerbTenseConjugations("french", "regarder", verbTenseName);
            PrintConjugations(conjugations);

            Assert.All(conjugations, c => Assert.IsType<CompoundConjugation>(c));
            Assert.All(conjugations, c => Assert.NotNull(((CompoundConjugation)c).AuxiliaryVerb));
            Assert.All(conjugations, c => Assert.NotNull(c.Verb));
        }

        [Fact]
        public void RetrieveFrenchVerbWithVerbTenses()
        {
            var expectedTenseCount = 22;

            var verb = ReversoContextVerbConjugations.GetVerbWithTenses("french", "regarder");

            foreach (var verbTense in verb.VerbTenses)
            {
                output.WriteLine(verbTense.VerbTenseName);
                PrintConjugations(verbTense.Conjugations);
                output.WriteLine("\n");
            }

            Assert.Equal(expectedTenseCount, verb.VerbTenses.Count);
        }

        [Fact]
        public void RetrieveFrenchFirst250CommonVerbsWithVerbTenses()
        {
            IEnumerable<(string VerbName, string ConjugationPath)> verbsInfo = ReversoContextCommonVerbs.RetrieveVerbsFromIndex("french", "1-250");
            int actualCount = verbsInfo.Count();

            List<Verb> verbs = new List<Verb>();
            foreach (var verbInfo in verbsInfo)
            {
                var verb = ReversoContextVerbConjugations.GetVerbWithTenses("french", verbInfo.VerbName);
                verbs.Add(verb);
            }

            Assert.Equal(verbs.Count, actualCount);
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