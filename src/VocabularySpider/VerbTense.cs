using System.Collections.Generic;

namespace VocabularySpider
{
    public class VerbTense
    {
        public VerbTense(string tense)
        {
            Tense = tense;
        }

        public string Tense { get; private set; }

        public List<(string SubjectPronoun, string Conjugation)> Conjugations { get; set; } = new List<(string SubjectPronoun, string Conjugation)>();
    }
}