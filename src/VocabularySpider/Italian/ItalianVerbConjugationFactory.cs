using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using VocabularySpider.Classes;

namespace VocabularySpider.Italian
{
    public static class ItalianVerbConjugationFactory
    {
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

        public static Conjugation CreateConjugation(string verbTenseName, IEnumerable<HtmlNode> iNodes)
        {
            if (SimpleTenses.Contains(verbTenseName))
            {
                return CreateSimpleTenseConjugation(iNodes);
            }
            else if (CompoundTenses.Contains(verbTenseName))
            {
                return CreateCompoundTenseConjugation(iNodes);
            }
            else if (verbTenseName == "Imperativo Presente")
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