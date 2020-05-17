using System;

namespace VocabularySpider
{
    public class ReversoContextCommonVerbs : ReversoContext
    {
        private readonly string url = "https://conjugator.reverso.net/index-{0}-{1}.html";
        private readonly string path = "//*[@id=\"form1\"]/div[4]/div/div[1]/div[4]/ol/li/a";


        public ReversoContextCommonVerbs(string language)
        {
            Language = language;
        }
    }
}