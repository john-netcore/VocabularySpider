namespace VocabularySpider
{
    class Program
    {
        static void Main(string[] args)
        {
            var englishPopularVerbs = new ReversoContextPopularVerbs("italian");

            foreach (var value in englishPopularVerbs.PopularVerbs)
            {
                System.Console.WriteLine(value);
            }

            foreach (var value in englishPopularVerbs.PopularVerbsConjugationUrls)
            {
                System.Console.WriteLine(value);
            }
        }
    }
}
