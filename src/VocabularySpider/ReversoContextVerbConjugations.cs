using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using VocabularySpider.Classes;

namespace VocabularySpider
{
    //TODO: Remove this class if not able to create generic methods for all the conjugation retrievals.
    public class ReversoContextVerbConjugations
    {
        private static readonly string urlTemplate = "https://conjugator.reverso.net/conjugation-{0}-verb-{1}.html";
        protected static readonly string xPath = "//*[@mobile-title]";
        protected static readonly HtmlWeb web;

        static ReversoContextVerbConjugations()
        {
            web = new HtmlWeb();
        }

        protected HtmlNodeCollection GetVerbTenseNodes(string verbTensesUrl)
        {
            var htmlDoc = web.Load(verbTensesUrl);
            return htmlDoc.DocumentNode.SelectNodes(xPath);
        }

        public static string GetVerbTense_Infinitive(string language, string verbName)
        {
            var infinitiveXpath = "//*[@id='ch_lblVerb']";
            var url = string.Format(urlTemplate, language, verbName);
            var htmlDoc = web.Load(url);

            return htmlDoc.DocumentNode.SelectSingleNode(infinitiveXpath).InnerText;
        }

        public static Dictionary<string, VerbTense> GetVerbTenseConjugation(string language, string verbTenseName)
        {
            return null;
        }
    }
}