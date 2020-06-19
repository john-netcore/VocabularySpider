using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace VocabularySpider.VerbsMetadata
{
    public class VerbTenseMetadataRetriever
    {
        private string conjugationsUrl = "https://conjugator.reverso.net/conjugation-{0}-verb-{1}.html";
        private readonly string xPathConjugations = "//*[@mobile-title]";
        private readonly string xPathVerbMoodTemplate = "//*[starts-with(@mobile-title, '{0}')]";
        private readonly string xPathVerbTenseTemplate = "//*[@mobile-title='{0}']/ul";
        private readonly HtmlDocument document;

        public VerbTenseMetadataRetriever(string language, string verb)
        {
            conjugationsUrl = string.Format(conjugationsUrl, language, verb);
            var web = new HtmlWeb();
            document = web.Load(conjugationsUrl);
        }

        public IEnumerable<string> RetrieveVerbTenseTypes()
        {
            var nodes = document.DocumentNode.SelectNodes(xPathConjugations);
            return nodes.Select(n => n.Attributes["mobile-title"].Value);
        }

        public IEnumerable<string> RetrieveSimpleVerbTenseTypes()
        {
            var nodes = document.DocumentNode.SelectNodes(xPathConjugations);
            List<string> verbTenseNames = new List<string>();

            foreach (var node in nodes)
            {
                var iNode = node.Descendants("i").Where(i => i.Attributes["class"].Value == "auxgraytxt").FirstOrDefault();
                if (iNode == null)
                {
                    var name = node.Attributes["mobile-title"].Value;
                    verbTenseNames.Add(name);
                }
            }
            return verbTenseNames;
        }

        public IEnumerable<string> RetrieveCompoundVerbTenseTypes()
        {
            var nodes = document.DocumentNode.SelectNodes(xPathConjugations);
            List<string> verbTenseNames = new List<string>();

            foreach (var node in nodes)
            {
                var iNode = node.Descendants("i").Where(i => i.Attributes["class"].Value == "auxgraytxt").FirstOrDefault();
                if (iNode != null)
                {
                    var name = node.Attributes["mobile-title"].Value;
                    verbTenseNames.Add(name);
                }
            }
            return verbTenseNames;
        }

        public IEnumerable<string> RetrieveVerbTenseMoodCollection(string verbTenseMood)
        {
            var divNodes = document.DocumentNode.SelectNodes(string.Format(xPathVerbMoodTemplate, verbTenseMood));
            return divNodes.Select(dn => dn.OuterHtml);
        }

        public IEnumerable<string> RetrieveHtmlForVerbTenseConjugations(string verbTense)
        {

            var ulNode = document.DocumentNode.SelectNodes(string.Format(xPathVerbTenseTemplate, verbTense));
            return ulNode.Descendants("li").Select(li => li.InnerHtml);
        }

        public IEnumerable<string> RetrieveHtmlConjugationsForVerbMood(string verbMood)
        {
            var ulNode = document.DocumentNode.SelectNodes(string.Format(xPathVerbMoodTemplate + "/ul", verbMood));
            return ulNode.Descendants("li").Select(li => li.InnerHtml);
        }
    }
}