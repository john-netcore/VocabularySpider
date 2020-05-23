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
    }
}