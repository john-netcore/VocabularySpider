using System.Linq;
using HtmlAgilityPack;
using VocabularySpider.BL;

namespace VocabularySpider
{
    public class ReversoContextVerbConjugations
    {
        protected readonly string xPath = "//*[@mobile-title]";
        protected readonly HtmlWeb web;

        public ReversoContextVerbConjugations()
        {
            web = new HtmlWeb();
        }

        protected HtmlNodeCollection GetVerbTenseNodes(string verbTensesUrl)
        {
            var htmlDoc = web.Load(verbTensesUrl);
            return htmlDoc.DocumentNode.SelectNodes(xPath);
        }
    }
}