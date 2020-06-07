namespace VocabularySpider.BL
{
    public class VerbTense
    {
        public VerbTense(string tenseName)
        {
            TenseName = tenseName;
        }

        public string TenseName { get; private set; }
    }
}