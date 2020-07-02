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
            var italianVerbNames = RetrieveVerbNames("italian", indexes);

            System.Console.WriteLine("Retrieving italian common verbs with conjugations");
            var italianVerbs = RetrieveVerbsWithVerbTenseConjugations("italian", italianVerbNames);

            System.Console.WriteLine("Finished");
        }

        public static IEnumerable<string> RetrieveVerbNames(string language, string[] indexes)
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

        public static IEnumerable<Verb> RetrieveVerbsWithVerbTenseConjugations(string language, IEnumerable<string> verbNames)
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
