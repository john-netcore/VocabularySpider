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
        protected static readonly string xPathAllVerbTenses = "//*[@mobile-title]";
        private static readonly string xPathVerbTenseTemplate = "//*[@mobile-title='{0}']/ul";
        private readonly string xPathVerbMoodTemplate = "//*[starts-with(@mobile-title, '{0}')]";
        protected static readonly HtmlWeb web;
        private static HashSet<string> Tenses = new HashSet<string>{
            "Imperativo Presente",
            "Gerundio Presente",
            "Infinito Presente",
            "Participio Presente",
            "Participio Passato"
        };
        private static HashSet<string> SimpleTenses = new HashSet<string>{
            "Indicativo Presente",
            "Indicativo Imperfetto",
            "Indicativo Passato remoto",
            "Indicativo Futuro semplice",
            "Congiuntivo Presente",
            "Congiuntivo Imperfetto",
            "Condizionale Presente",
        };
        private static HashSet<string> CompoundTenses = new HashSet<string>{
            "Indicativo Passato prossimo",
            "Indicativo Trapassato prossimo",
            "Indicativo Trapassato remoto",
            "Indicativo Futuro anteriore",
            "Condizionale Passato",
            "Congiuntivo Passato",
            "Congiuntivo Trapassato",
        };

        static ReversoContextVerbConjugations()
        {
            web = new HtmlWeb();
        }

        private static HtmlDocument LoadHtmlDocument(string language, string verbName)
        {
            var url = string.Format(urlTemplate, language, verbName);
            var htmlDoc = web.Load(url);
            return htmlDoc;
        }

        public static string GetVerbTense_Infinitive(string language, string verbName)
        {
            var infinitiveXpath = "//*[@id='ch_lblVerb']";
            var htmlDoc = LoadHtmlDocument(language, verbName);

            return htmlDoc.DocumentNode.SelectSingleNode(infinitiveXpath).InnerText;
        }

        public static Verb GetVerbWithTenses(string language, string verbName)
        {
            var verb = new Verb(verbName, language);
            var htmlDoc = LoadHtmlDocument(language, verbName);
            var verbTenseDivNodes = htmlDoc.DocumentNode.SelectNodes(xPathAllVerbTenses);

            foreach (var verbTenseDivNode in verbTenseDivNodes)
            {
                var verbTenseName = verbTenseDivNode.Attributes["mobile-title"].Value;
                var ulNode = verbTenseDivNode.Descendants("ul").First();
                var conjugations = GetVerbTenseConjugations(verbTenseName, ulNode);
                var verbTense = new VerbTense(verbTenseName);
                verbTense.Conjugations = conjugations.ToList();
                verb.VerbTenses.Add(verbTense);
            }

            return verb;
        }

        private static IEnumerable<Conjugation> GetVerbTenseConjugations(string verbTenseName, HtmlNode ulNode)
        {
            var conjugations = new List<Conjugation>();

            foreach (var liNode in ulNode.Descendants("li"))
            {
                var iNodes = liNode.Descendants("i");
                var conjugation = CreateConjugation(verbTenseName, iNodes);
                if (conjugation != null)
                {
                    conjugations.Add(conjugation);
                }
            }

            return conjugations;
        }

        public static IEnumerable<Conjugation> GetVerbTenseConjugations(string language, string verbName, string verbTenseName)
        {
            var conjugations = new List<Conjugation>();
            var htmlDoc = LoadHtmlDocument(language, verbName);
            var ulNode = htmlDoc.DocumentNode.SelectNodes(string.Format(xPathVerbTenseTemplate, verbTenseName));

            foreach (var liNode in ulNode.Descendants("li"))
            {
                var iNodes = liNode.Descendants("i");
                var conjugation = CreateConjugation(verbTenseName, iNodes);
                conjugations.Add(conjugation);
            }

            return conjugations;
        }
        private static Conjugation CreateConjugation(string verbTenseName, IEnumerable<HtmlNode> iNodes)
        {
            if (SimpleTenses.Contains(verbTenseName))
            {
                return CreateSimpleTenseConjugation(iNodes);
            }
            else if (CompoundTenses.Contains(verbTenseName))
            {
                return CreateCompoundTenseConjugation(iNodes);
            }
            else if (Tenses.Contains(verbTenseName))
            {
                return CreateConjugation(iNodes);
            }

            return null;
        }

        private static Conjugation CreateConjugation(IEnumerable<HtmlNode> iNodes)
        {
            var conjugation = new Conjugation();
            var iNodeValue = iNodes.First().InnerText;
            conjugation.Verb = iNodeValue;

            return conjugation;
        }

        private static Conjugation CreateCompoundTenseConjugation(IEnumerable<HtmlNode> iNodes)
        {
            var conjugation = new CompoundConjugation();
            foreach (var iNode in iNodes)
            {
                var classAttributeValue = iNode.Attributes["class"].Value;
                var iNodeValue = iNode.InnerText.Trim();

                if (classAttributeValue == "graytxt")
                {
                    conjugation.Pronoun = iNodeValue;
                }
                else if (classAttributeValue == "auxgraytxt")
                {
                    conjugation.AuxiliaryVerb = iNodeValue;
                }
                else
                {
                    conjugation.Verb = iNodeValue;
                }
            }
            return conjugation;
        }

        private static Conjugation CreateSimpleTenseConjugation(IEnumerable<HtmlNode> iNodes)
        {
            var conjugation = new SimpleConjugation();
            foreach (var iNode in iNodes)
            {
                var classAttributeValue = iNode.Attributes["class"].Value;
                var iNodeValue = iNode.InnerText.Trim();

                if (classAttributeValue == "graytxt")
                {
                    conjugation.Pronoun = iNodeValue;
                }
                else
                {
                    conjugation.Verb = iNodeValue;
                }
            }
            return conjugation;
        }
    }
}