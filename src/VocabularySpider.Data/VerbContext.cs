using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using VocabularySpider.BL;

namespace VocabularySpider.Data
{
    public class VerbContext : DbContext
    {
        public DbSet<Verb> Verbs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(GetConnectionString());
        }

        private static string GetConnectionString()
        {
            var jsonString = File.ReadAllText("./data/secrets.json");
            var myObj = JObject.Parse(jsonString);
            var connString = myObj.SelectToken("connectionString").Value<string>();
            System.Console.WriteLine(connString);
            return connString;
        }
    }
}
