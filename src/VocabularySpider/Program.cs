using System.Collections.Generic;
using System.IO;
using VocabularySpider.Classes;

namespace VocabularySpider
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] indexes = File.ReadAllLines("./data/commonVerbIndexes.txt");

            IEnumerable<string> italianVerbNames = RetrieveVerbNames("italian", indexes);

            System.Console.WriteLine("Finished");
        }

        static IEnumerable<string> RetrieveVerbNames(string language, string[] indexes)
        {
            List<string> verbNames = new List<string>();
            foreach (var index in indexes)
            {
                IEnumerable<(string VerbName, string ConjugationPath)> verbsInfo = ReversoContextCommonVerbs.RetrieveVerbsFromIndex("italian", index);
                foreach (var verbInfo in verbsInfo)
                {
                    verbNames.Add(verbInfo.VerbName);
                }
            }

            return verbNames;
        }

        static IEnumerable<Verb> RetrieveVerbsWithVerbTenseConjugations(string language, IEnumerable<string> verbNames)
        {
            List<Verb> verbs = new List<Verb>();

            foreach (var verbName in verbNames)
            {
                var verb = ReversoContextVerbConjugations.GetVerbWithTenses(language, verbName);
                verbs.Add(verb);
            }

            return verbs;
        }
    }
}
