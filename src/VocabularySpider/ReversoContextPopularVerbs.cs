using System.Collections.Generic;
using System;
using HtmlAgilityPack;
using System.Linq;

namespace VocabularySpider
{
    public class ReversoContextPopularVerbs : ReversoContext
    {
        private readonly string url = "https://conjugator.reverso.net/conjugation-{0}.html";
        private readonly HtmlWeb web;
        private readonly string xpath = "//*[@id=\"ch_ExtrasVerbs\"]/div/ol/li/a";

        public ReversoContextPopularVerbs(string language)
        {
            Language = language;
            this.url = string.Format(url, language);
            this.web = new HtmlWeb();
        }

        public IEnumerable<string> RetrieveVerbs()
        {
            var htmlDoc = web.Load(url);
            var linkNodes = htmlDoc.DocumentNode.SelectNodes(xpath);

            return linkNodes.Select(n => n.InnerText.Trim());
        }

        public IEnumerable<string> RetrieveVerbTensesUrls()
        {
            var htmlDoc = web.Load(url);
            var linkNodes = htmlDoc.DocumentNode.SelectNodes(xpath);

            return linkNodes.Select(n => n.Attributes["href"].Value);
        }
    }
}