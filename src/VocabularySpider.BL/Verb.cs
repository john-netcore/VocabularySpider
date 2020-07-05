using System.Collections.Generic;

namespace VocabularySpider.BL
{
    public class Verb
    {

        public Verb(string infinitive, string language)
        {
            Infinitive = infinitive;
            Language = language;
        }

        public Verb() { }

        public int Id { get; set; }
        public string Infinitive { get; set; }
        public string Language { get; private set; }
        public IList<VerbTense> VerbTenses { get; set; }
    }
}