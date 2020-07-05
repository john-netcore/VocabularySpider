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
            string[] indexes = File.ReadAllLines("./data/commonVerbIndexes.txt");

            System.Console.WriteLine("Retrieving italian common verb names...");
            var italianVerbNames = ReversoContextCommonVerbs.RetrieveVerbsFromIndexes("italian", indexes);

            System.Console.WriteLine("Retrieving italian common verbs with conjugations");
            var italianVerbs = ReversoContextVerbConjugations.GetVerbsWithTenses("italian", italianVerbNames);

            System.Console.WriteLine("Mapping italian common verbs");

            System.Console.WriteLine("Finished");
        }
    }
}
