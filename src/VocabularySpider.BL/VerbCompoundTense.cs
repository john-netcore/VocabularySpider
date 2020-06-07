using System.Collections.Generic;

namespace VocabularySpider.BL
{
    public class VerbCompoundTense : VerbTense
    {
        public VerbCompoundTense(string tenseName) : base(tenseName)
        {
        }

        public List<(string SubjectPronoun, string Auxiliary, string Conjugation)> Conjugations
        {
            get;
            set;
        } = new List<(string SubjectPronoun, string Auxiliary, string Conjugation)>();
    }
}