using System.Collections.Generic;
using HtmlAgilityPack;
using VocabularySpider.BL;

namespace VocabularySpider
{
    public class ReversoContextItalianVerbConjugations : ReversoContextVerbConjugations
    {
        private readonly string urlTemplate = "https://conjugator.reverso.net/conjugation-italian-verb-{0}.html";
        // private readonly string xPathVerbMoodTemplate = "//*[starts-with(@mobile-title, '{0}')]/ul";
        // private readonly string xPathVerbTenseTemplate = "//*[@mobile-title='{0}']/ul";
        private readonly HashSet<string> CompoundTenses = new HashSet<string> {
            "indicativo passato prossimo",
            "indicativo trapassato prossimo",
            "indicativo trapassato remoto",
            "indicativo futuro anteriore",
            "congiuntivo passato",
            "congiuntivo trapassato",
            "condizionale passato",
        };


        public ReversoContextItalianVerbConjugations() : base()
        {
        }

        private VerbTense GetVerbTenseType(string verbTenseName)
        {
            if (CompoundTenses.Contains(verbTenseName.ToLower()))
            {
                return new VerbCompoundTense(verbTenseName);
            }

            return null;
        }

        public IEnumerable<VerbTense> RetrieveConjugations(string verb)
        {
            List<VerbTense> verbTenses = new List<VerbTense>();
            var url = string.Format(urlTemplate, verb);
            var nodes = GetVerbTenseNodes(url);

            foreach (var verbTenseNode in nodes)
            {
                var verbTenseName = verbTenseNode.Attributes["mobile-title"].Value;

            }

            return verbTenses;
        }
        // public IEnumerable<string> RetrieveHtmlConjugationsForVerbMood(string verbMood)
        // {
        //     var ulNode = document.DocumentNode.SelectNodes(string.Format(xPathVerbMoodTemplate, verbMood));
        //     return ulNode.Descendants("li").Select(li => li.InnerHtml);
        // }
    }
}