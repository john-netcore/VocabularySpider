using System;
using System.Collections.Generic;
using System.IO;
using VocabularySpider.Classes;

namespace VocabularySpider
{
    public class Program
    {
        static void Main(string[] args)
        {
            var italianVerbs = RetrieveVerbs("italian");
        }

        static IEnumerable<Verb> RetrieveVerbs(string language)
        {
            string[] indexes = File.ReadAllLines("./data/commonVerbIndexes.txt");

            System.Console.WriteLine("Retrieving {0} common verb names...", language);
            var verbNames = ReversoContextCommonVerbs.RetrieveVerbsFromIndexes(language, indexes);

            System.Console.WriteLine("Retrieving {0} common verbs with conjugations", language);
            var verbs = ReversoContextVerbConjugations.GetVerbsWithTenses(language, verbNames);

            System.Console.WriteLine("Finished");

            return verbs;
        }
    }
}
