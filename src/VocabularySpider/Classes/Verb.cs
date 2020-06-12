namespace VocabularySpider.Classes
{
    public class Verb
    {
        public Verb(string verbName, string language)
        {
            VerbName = verbName;
            Language = language;
        }

        public string VerbName { get; set; }
        public string Language { get; private set; }
    }
}