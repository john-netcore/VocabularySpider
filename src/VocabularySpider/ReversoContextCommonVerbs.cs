using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace VocabularySpider
{
    public class ReversoContextCommonVerbs : ReversoContext
    {
        private readonly string urlTemplate = "https://conjugator.reverso.net/index-{0}-{1}.html";
        private readonly string xpath = "//*[@id=\"form1\"]/div[4]/div/div[1]/div[4]/ol/li/a";
        private readonly HtmlWeb web;

        public ReversoContextCommonVerbs(string language)
        {
            Language = language;
            web = new HtmlWeb();
        }

        public IEnumerable<string> RetrieveVerbsFromIndex(string index)
        {
            var url = string.Format(urlTemplate, Language, index);
            var htmlDoc = web.Load(url);
            var commonVerbs = htmlDoc.DocumentNode.SelectNodes(xpath).Select(l => l.InnerText);

            return commonVerbs;
        }
    }
}