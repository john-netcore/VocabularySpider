using System.Collections.Generic;

namespace VocabularySpider
{
    public class Verb
    {

        public Verb(string infinitive) : this(infinitive, null)
        {
        }

        public Verb(string infinitive, string conjugationRelativeUrl)
        {
            Infinitive = infinitive;
            ConjugationRelativeUrl = conjugationRelativeUrl;
        }
        public string Infinitive { get; set; }

        public string ConjugationRelativeUrl { get; set; }

        public Dictionary<string, VerbTense> VerbTenses { get; set; } = new Dictionary<string, VerbTense>();
    }
}