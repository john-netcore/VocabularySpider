using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;
using VocabularySpider.BL;

namespace VocabularySpider
{
    public static class ReversoContextCommonVerbs
    {
        private static readonly string rootUrl = "https://conjugator.reverso.net";
        private static readonly string urlTemplate = "https://conjugator.reverso.net/index-{0}-{1}.html";
        private static readonly string xpath = "//*[@id=\"form1\"]/div[4]/div/div[1]/div[4]/ol/li/a";
        private static readonly HtmlWeb web;

        static ReversoContextCommonVerbs()
        {
            web = new HtmlWeb();
        }

        public static IEnumerable<(string VerbName, string ConjugationPath)> RetrieveVerbsFromIndex(string language, string index)
        {
            var url = string.Format(urlTemplate, language, index);
            var htmlDoc = web.Load(url);
            var commonVerbs = htmlDoc.DocumentNode
                                    .SelectNodes(xpath)
                                    .Select(l =>
                                        (
                                            VerbName: l.InnerText,
                                            ConjugationPath: Path.Combine(rootUrl, l.Attributes["href"].Value)
                                        )
                                    );

            return commonVerbs;
        }
    }
}