using System;
using System.Collections.Generic;

namespace VocabularySpider
{
    public class ReversoContext
    {
        protected static HashSet<string> AvailableLanguages { get; } = new HashSet<string> {
            "english",
            "spanish",
            "italian",
            "french"
        };

        private string language;

        public string Language
        {
            get { return language; }
            protected set
            {
                if (value == null || !AvailableLanguages.Contains(value.ToLower()))
                {
                    throw new ArgumentException("Language is not available");
                }
                language = value.ToLower();
            }
        }
    }
}