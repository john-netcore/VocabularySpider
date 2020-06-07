using System.Collections.Generic;

namespace VocabularySpider.BL
{
    public class Verb
    {

        public Verb(string verbName, Language language)
        {
            VerbName = verbName;
            Language = language;
        }

        public string VerbName { get; set; }
        public Language Language { get; private set; }
        public Dictionary<string, VerbTense> VerbTenses { get; set; } = new Dictionary<string, VerbTense>();
    }
}