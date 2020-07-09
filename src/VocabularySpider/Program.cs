using System;
using System.Collections.Generic;
using System.IO;
using AutoMapper;
using VocabularySpider.Classes;
using VocabularySpider.Data;

namespace VocabularySpider
{
    public class Program
    {
        private static HashSet<string> languages = new HashSet<string> { "italian", "spanish", "french" };
        private static MapperConfiguration mapperConfig;
        private static VerbContext context = new VerbContext();

        static void Main(string[] args)
        {
            if (args == null || args.Length < 1 || !languages.Contains(args[0].Trim().ToLower()))
            {
                System.Console.WriteLine("You must give the language as an argument (italian, spanish, french)");
                return;
            }

            var language = args[0].Trim().ToLower();

            System.Console.WriteLine(language);

            Configure();

            var verbs = RetrieveVerbs(language);
            IEnumerable<BL.Verb> mappedverbs = MapVerbs(verbs);

            System.Console.WriteLine("Finished");
        }

        public static void Configure()
        {
            // Initialize the mapper
            mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Verb, BL.Verb>()
                    .ForMember(dest => dest.Infinitive, opt => opt.MapFrom(src => src.VerbName));
                cfg.CreateMap<VerbTense, BL.VerbTense>()
                    .ForMember(dest => dest.TenseName, opt => opt.MapFrom(src => src.VerbTenseName));
                cfg.CreateMap<Conjugation, BL.Conjugation>()
                    .ForMember(dest => dest.InflictedVerb, opt => opt.MapFrom(src => src.Verb))
                    .Include<SimpleConjugation, BL.SimpleConjugation>()
                    .Include<CompoundConjugation, BL.CompoundConjugation>();
                cfg.CreateMap<SimpleConjugation, BL.SimpleConjugation>();
                cfg.CreateMap<CompoundConjugation, BL.CompoundConjugation>();
            });
        }

        static IEnumerable<Verb> RetrieveVerbs(string language)
        {
            string[] indexes = File.ReadAllLines("./data/commonVerbIndexes.txt");

            System.Console.WriteLine("Retrieving {0} common verb names...", language);
            var verbNames = ReversoContextCommonVerbs.RetrieveVerbsFromIndexes(language, indexes);

            System.Console.WriteLine("Retrieving {0} common verbs with conjugations", language);
            var verbs = ReversoContextVerbConjugations.GetVerbsWithTenses(language, verbNames);

            return verbs;
        }

        public static IEnumerable<BL.Verb> MapVerbs(IEnumerable<Verb> verbs)
        {
            var mapper = new Mapper(mapperConfig);
            return mapper.Map<IEnumerable<Verb>, IEnumerable<BL.Verb>>(verbs);
        }
    }
}
