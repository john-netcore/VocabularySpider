﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using VocabularySpider.BL;

namespace VocabularySpider.Data
{
    public class VerbContext : DbContext
    {
        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information
                ).AddConsole();
            }
        );

        public DbSet<Verb> Verbs { get; set; }
        public DbSet<VerbTense> VerbTenses { get; set; }
        public DbSet<Conjugation> Conjugations { get; set; }
        public DbSet<SimpleConjugation> SimpleConjugations { get; set; }
        public DbSet<CompoundConjugation> CompoundConjugations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            System.Console.WriteLine("On configuring invoked...");
            builder
                .UseLoggerFactory(ConsoleLoggerFactory)
                .UseSqlServer(GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            System.Console.WriteLine("On model creating invoked...");
            builder.Entity<Verb>().Property(b => b.Language).IsRequired();
            builder.Entity<Verb>().Property(b => b.Infinitive).IsRequired();

            builder.Entity<VerbTense>().Property(b => b.TenseName).IsRequired();
            builder.Entity<VerbTense>().HasOne<Verb>().WithMany(v => v.VerbTenses).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Conjugation>().Property(b => b.InflictedVerb).IsRequired();
            builder.Entity<Conjugation>().HasOne<VerbTense>().WithMany(vt => vt.Conjugations).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SimpleConjugation>().Property(b => b.Pronoun).IsRequired();

            builder.Entity<CompoundConjugation>().Property(b => b.AuxiliaryVerb).IsRequired();
        }

        private static string GetConnectionString()
        {
            var jsonString = File.ReadAllText("./data/secrets.json");
            var myObj = JObject.Parse(jsonString);
            var connString = myObj.SelectToken("connectionString").Value<string>();
            System.Console.WriteLine("Using connectionstring: {0}", connString);
            return connString;
        }
    }
}
