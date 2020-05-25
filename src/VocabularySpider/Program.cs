namespace VocabularySpider
{
    class Program
    {
        static void Main(string[] args)
        {
            var englishPopularVerbs = new ReversoContextPopularVerbs("italian");

            foreach (var value in englishPopularVerbs.RetrieveVerbs())
            {
                System.Console.WriteLine(value);
            }

            foreach (var value in englishPopularVerbs.RetrieveVerbTensesUrls())
            {
                System.Console.WriteLine(value);
            }
        }
    }
}
