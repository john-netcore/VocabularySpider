using System.Collections.Generic;
using System.IO;

namespace VocabularySpider
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] indexes = File.ReadAllLines("./data/commonVerbIndexes.txt");

            List<string> italianVerbNames = RetrieveVerbNames("italian", indexes);

            System.Console.WriteLine("Finished");
        }

        static List<string> RetrieveVerbNames(string language, string[] indexes)
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
    }
}
