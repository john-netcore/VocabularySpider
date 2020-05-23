using HtmlAgilityPack;

namespace VocabularySpider
{
    public class ReversoContextVerbConjugations
    {
        private readonly string urlTemplate = "https://conjugator.reverso.net/{0}.html";
        private readonly string xPath = "//*[@mobile-title]";
        private readonly HtmlWeb web;

        public Verb Verb { get; }


        public ReversoContextVerbConjugations(Verb verb)
        {
            Verb = verb;
            web = new HtmlWeb();
        }


    }
}