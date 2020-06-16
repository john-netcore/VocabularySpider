using System.Collections.Generic;

namespace VocabularySpider.Classes
{
    public class VerbTense
    {
        public string VerbTenseName { get; set; }
        public IList<Conjugation> Conjugations { get; set; }

        public VerbTense(string verbTenseName)
        {
            VerbTenseName = verbTenseName;
        }
    }
}