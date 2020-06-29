using System.Collections.Generic;

namespace VocabularySpider.BL
{
    public class VerbTense
    {
        public VerbTense(string tenseName)
        {
            TenseName = tenseName;
        }

        public int Id { get; set; }
        public string TenseName { get; private set; }
        public IList<Conjugation> Conjugations { get; set; }
    }
}