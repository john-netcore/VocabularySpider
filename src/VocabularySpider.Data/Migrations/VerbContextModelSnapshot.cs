﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VocabularySpider.Data;

namespace VocabularySpider.Data.Migrations
{
    [DbContext(typeof(VerbContext))]
    partial class VerbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VocabularySpider.BL.Conjugation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InflictedVerb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VerbTenseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VerbTenseId");

                    b.ToTable("Conjugations");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Conjugation");
                });

            modelBuilder.Entity("VocabularySpider.BL.Verb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Infinitive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Verbs");
                });

            modelBuilder.Entity("VocabularySpider.BL.VerbTense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VerbId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VerbId");

                    b.ToTable("VerbTenses");
                });

            modelBuilder.Entity("VocabularySpider.BL.SimpleConjugation", b =>
                {
                    b.HasBaseType("VocabularySpider.BL.Conjugation");

                    b.Property<string>("Pronoun")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("SimpleConjugation");
                });

            modelBuilder.Entity("VocabularySpider.BL.CompoundConjugation", b =>
                {
                    b.HasBaseType("VocabularySpider.BL.SimpleConjugation");

                    b.Property<string>("AuxiliaryVerb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("CompoundConjugation");
                });

            modelBuilder.Entity("VocabularySpider.BL.Conjugation", b =>
                {
                    b.HasOne("VocabularySpider.BL.VerbTense", null)
                        .WithMany("Conjugations")
                        .HasForeignKey("VerbTenseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VocabularySpider.BL.VerbTense", b =>
                {
                    b.HasOne("VocabularySpider.BL.Verb", null)
                        .WithMany("VerbTenses")
                        .HasForeignKey("VerbId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
