using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using VocabularySpider.Classes;

namespace VocabularySpider.Italian
{
    public static class ReversoContextItalianVerbConjugations
    {
        private static readonly HtmlWeb web;
        private static readonly string urlTemplate = "https://conjugator.reverso.net/conjugation-italian-verb-{0}.html";
        private static readonly string xPathVerbTenseTemplate = "//*[@mobile-title='{0}']/ul";


        static ReversoContextItalianVerbConjugations()
        {
            web = new HtmlWeb();
        }

        private static HtmlDocument LoadHtmlDocument(string verbName)
        {
            var url = string.Format(urlTemplate, verbName);
            var htmlDoc = web.Load(url);
            return htmlDoc;
        }

        public static string GetVerbTense_Infinitive(string verbName)
        {
            var infinitiveXpath = "//*[@id='ch_lblVerb']";
            var htmlDoc = LoadHtmlDocument(verbName);

            return htmlDoc.DocumentNode.SelectSingleNode(infinitiveXpath).InnerText;
        }

        public static IEnumerable<Conjugation> GetVerbTenseConjugations(string verbName, string verbTenseName)
        {
            var conjugations = new List<Conjugation>();
            var htmlDoc = LoadHtmlDocument(verbName);
            var ulNode = htmlDoc.DocumentNode.SelectNodes(string.Format(xPathVerbTenseTemplate, verbTenseName));

            foreach (var liNode in ulNode.Descendants("li"))
            {
                var iNodes = liNode.Descendants("i");
                var conjugation = ItalianVerbConjugationFactory.CreateConjugation(verbTenseName, iNodes);
                conjugations.Add(conjugation);
            }

            return conjugations;
        }
    }
}