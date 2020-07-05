using System;
using System.Collections.Generic;
using System.IO;
using AutoMapper;
using VocabularySpider.Classes;

namespace VocabularySpider
{
    public class Program
    {
        private static MapperConfiguration mapperConfig;

        static void Main(string[] args)
        {
            Configure();

            var italianVerbs = RetrieveVerbs("italian");
            IEnumerable<BL.Verb> mappedItalianVerbs = MapVerbs(italianVerbs);

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
