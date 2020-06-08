using HtmlAgilityPack;

namespace VocabularySpider.Italian
{
    public static class ReversoContextItalianVerbConjugations
    {
        private static readonly HtmlWeb web;
        private static readonly string urlTemplate = "https://conjugator.reverso.net/conjugation-italian-verb-{0}.html";
        private static readonly string xPathVerbTenseTemplate = "//*[@mobile-title='{0}']";

        static ReversoContextItalianVerbConjugations()
        {
            web = new HtmlWeb();
        }

        public static string GetVerbTense_Infinitive(string verbName)
        {
            var infinitiveXpath = "//*[@id='ch_lblVerb']";
            var url = string.Format(urlTemplate, verbName);
            var htmlDoc = web.Load(url);

            return htmlDoc.DocumentNode.SelectSingleNode(infinitiveXpath).InnerText;
        }

    }
}