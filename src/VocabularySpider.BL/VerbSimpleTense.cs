using System.Collections.Generic;

namespace VocabularySpider.BL
{
    public class VerbSimpleTense : VerbTense
    {
        public VerbSimpleTense(string tenseName) : base(tenseName)
        {
        }

        public List<(string SubjectPronoun, string Conjugation)> Conjugations
        {
            get;
            set;
        } = new List<(string SubjectPronoun, string Conjugation)>();

    }
}