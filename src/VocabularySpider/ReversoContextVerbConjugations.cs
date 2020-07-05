using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VocabularySpider.Classes;

namespace VocabularySpider
{
    public class ReversoContextVerbConjugations
    {
        private static readonly string urlTemplate = "https://conjugator.reverso.net/conjugation-{0}-verb-{1}.html";
        protected static readonly string xPathAllVerbTenses = "//*[@mobile-title]";
        private static readonly string xPathVerbTenseTemplate = "//*[@mobile-title='{0}']/ul";
        // private readonly string xPathVerbMoodTemplate = "//*[starts-with(@mobile-title, '{0}')]";
        protected static readonly HtmlWeb web;
        private static Dictionary<string, HashSet<string>> SimpleTenses = new Dictionary<string, HashSet<string>>();
        private static Dictionary<string, HashSet<string>> CompoundTenses = new Dictionary<string, HashSet<string>>();

        static ReversoContextVerbConjugations()
        {
            web = new HtmlWeb();
            ReadAndParseVerbTenses();
        }

        private static void ReadAndParseVerbTenses()
        {
            using (StreamReader reader = new StreamReader("data/verbTenses.json"))
            {
                string json = reader.ReadToEnd();
                var jobject = JObject.Parse(json);

                PopulateVerbTenseTypes("italian", jobject);
                PopulateVerbTenseTypes("spanish", jobject);
                PopulateVerbTenseTypes("french", jobject);
            }
        }

        private static void PopulateVerbTenseTypes(string language, JObject jobject)
        {
            SimpleTenses.Add(language, new HashSet<string>());
            jobject["simpleTenses"][language].ToList().ForEach(t => SimpleTenses[language].Add((string)t));

            CompoundTenses.Add(language, new HashSet<string>());
            jobject["compoundTenses"][language].ToList().ForEach(t => CompoundTenses[language].Add((string)t));
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
                var conjugations = GetVerbTenseConjugations(language, verbTenseName, ulNode);
                var verbTense = new VerbTense(verbTenseName);
                verbTense.Conjugations = conjugations.ToList();
                verb.VerbTenses.Add(verbTense);
            }

            return verb;
        }

        public static List<Verb> GetVerbsWithTenses(string language, IEnumerable<string> verbNames)
        {
            var htmlDocsInfo = new ConcurrentBag<(string VerbName, HtmlDocument HtmlDoc)>();

            Parallel.ForEach(verbNames, (verbName) =>
            {
                var url = string.Format(urlTemplate, language, verbName);
                var htmlDoc = web.Load(url);

                System.Console.WriteLine("Html document for verb {0} retrieved.", verbName);
                htmlDocsInfo.Add((verbName, htmlDoc));
            });

            var verbs = new List<Verb>();

            foreach (var htmlDocInfo in htmlDocsInfo)
            {
                var verb = new Verb(htmlDocInfo.VerbName, language);
                var verbTenseDivNodes = htmlDocInfo.HtmlDoc.DocumentNode.SelectNodes(xPathAllVerbTenses);

                foreach (var verbTenseDivNode in verbTenseDivNodes)
                {
                    var verbTenseName = verbTenseDivNode.Attributes["mobile-title"].Value;
                    var ulNode = verbTenseDivNode.Descendants("ul").First();
                    var conjugations = GetVerbTenseConjugations(language, verbTenseName, ulNode);
                    var verbTense = new VerbTense(verbTenseName);
                    verbTense.Conjugations = conjugations.ToList();
                    verb.VerbTenses.Add(verbTense);
                }

                verbs.Add(verb);
            }

            return verbs;
        }

        private static IEnumerable<Conjugation> GetVerbTenseConjugations(string language, string verbTenseName, HtmlNode ulNode)
        {
            var conjugations = new List<Conjugation>();

            foreach (var liNode in ulNode.Descendants("li"))
            {
                var iNodes = liNode.Descendants("i");
                var conjugation = CreateConjugation(language, verbTenseName, iNodes);
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
                var conjugation = CreateConjugation(language, verbTenseName, iNodes);
                conjugations.Add(conjugation);
            }

            return conjugations;
        }
        private static Conjugation CreateConjugation(string language, string verbTenseName, IEnumerable<HtmlNode> iNodes)
        {
            if (SimpleTenses[language].Contains(verbTenseName))
            {
                return CreateSimpleTenseConjugation(iNodes);
            }
            else if (CompoundTenses[language].Contains(verbTenseName))
            {
                return CreateCompoundTenseConjugation(iNodes);
            }

            return null;
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
                else if (classAttributeValue == "verbtxt")
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