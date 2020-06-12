using System.Collections.Generic;

namespace VocabularySpider.Classes
{
    public class VerbTense
    {
        public string VerbTenseName { get; set; }
        public List<Conjugation> Conjugations { get; set; }
    }
}