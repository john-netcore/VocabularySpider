using System.Collections.Generic;
using System;
using HtmlAgilityPack;
using System.Linq;

namespace VocabularySpider
{
    public class ReversoContextPopularVerbs
    {
        private readonly string url = "https://conjugator.reverso.net/conjugation-{0}.html";
        private readonly HtmlWeb web;
        private readonly string xpath = "//*[@id=\"ch_ExtrasVerbs\"]/div/ol/li/a";
        private HtmlNodeCollection linkNodes;
        private static HashSet<string> AvailableLanguages { get; } = new HashSet<string> {
            "english",
            "spanish",
            "italian"
        };

        public IEnumerable<string> PopularVerbs => linkNodes.Select(l => l.InnerText.Trim());

        public IEnumerable<string> PopularVerbsConjugationUrls => linkNodes.Select(l => l.Attributes["href"].Value);

        public ReversoContextPopularVerbs(string language)
        {
            if (!AvailableLanguages.Contains(language.ToLower()))
            {
                throw new ArgumentException("Language is not available");
            }
            this.url = string.Format(url, language);
            this.web = new HtmlWeb();

            RetrievePopularVerbs();
        }

        private void RetrievePopularVerbs()
        {
            var htmlDoc = web.Load(url);
            linkNodes = htmlDoc.DocumentNode.SelectNodes(xpath);
        }

        public override string ToString()
        {
            string temp = "";

            foreach (var link in linkNodes)
            {
                temp += link.ToString() + "\n";
            }

            return temp;
        }
    }
}