using System.Linq;
using HtmlAgilityPack;

namespace VocabularySpider
{
    public class ReversoContextVerbConjugations
    {
        private readonly string urlTemplate = "https://conjugator.reverso.net/{0}";
        private readonly string xPath = "//*[@mobile-title]";
        private readonly HtmlWeb web;

        public Verb Verb { get; }


        public ReversoContextVerbConjugations()
        {
            web = new HtmlWeb();
        }

        public void RetrieveAndAddVerbTenses(Verb verb)
        {
            var url = string.Format(urlTemplate, verb.ConjugationRelativeUrl);
            var htmlDoc = web.Load(url);
            var nodes = htmlDoc.DocumentNode.SelectNodes(xPath);

            foreach (var node in nodes)
            {
                var tenseName = node.Attributes["mobile-title"].Value;
                var verbTense = new VerbTense(tenseName);
                //TODO: Change logic to use specific Verbtense types.
                foreach (var listNode in node.Descendants("li"))
                {
                    var iNodes = listNode.Descendants("i");
                    var subjectPronoun = iNodes.ElementAt(0).InnerText;
                    var conjugation = iNodes.ElementAt(1).InnerText;
                    verbTense.Conjugations.Add((subjectPronoun, conjugation));
                }

                verb.VerbTenses[tenseName] = verbTense;
            }
        }
    }
}