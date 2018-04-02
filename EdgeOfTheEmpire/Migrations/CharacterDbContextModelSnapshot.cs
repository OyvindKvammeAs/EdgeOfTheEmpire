﻿// <auto-generated />
using EdgeOfTheEmpire.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EdgeOfTheEmpire.Migrations
{
    [DbContext(typeof(CharacterDbContext))]
    partial class CharacterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EdgeOfTheEmpire.Entities.CharacterBattleScarAdvance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharacterId");

                    b.Property<string>("Talent");

                    b.HasKey("Id");

                    b.ToTable("CharacterBattleScarAdvances");
                });

            modelBuilder.Entity("EdgeOfTheEmpire.Entities.CharacterSignatureAbility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharacterId");

                    b.Property<string>("SignatureAbility");

                    b.HasKey("Id");

                    b.ToTable("CharacterSignatureAbilities");
                });

            modelBuilder.Entity("EdgeOfTheEmpire.Entities.CharacterSignatureAbilityAdvance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharacterId");

                    b.Property<int>("Column");

                    b.Property<int>("Row");

                    b.Property<string>("SignatureAbility");

                    b.HasKey("Id");

                    b.ToTable("CharacterSignatureAbilityAdvances");
                });

            modelBuilder.Entity("EdgeOfTheEmpire.Entities.CharacterSkillAdvance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharacterId");

                    b.Property<int>("Rank");

                    b.Property<string>("Skill");

                    b.HasKey("Id");

                    b.ToTable("CharacterSkillAdvances");
                });

            modelBuilder.Entity("EdgeOfTheEmpire.Entities.CharacterSpecialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharacterId");

                    b.Property<string>("Specialization")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CharacterSpecializations");
                });

            modelBuilder.Entity("EdgeOfTheEmpire.Entities.CharacterSpecializationAdvance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CharacterId");

                    b.Property<int>("Column");

                    b.Property<int>("Row");

                    b.Property<string>("Specialization");

                    b.HasKey("Id");

                    b.ToTable("CharacterSpecializationAdvances");
                });

            modelBuilder.Entity("EdgeOfTheEmpire.Entities.InitialCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Agility");

                    b.Property<int>("Brawn");

                    b.Property<int>("Cunning");

                    b.Property<int>("Intelligence");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Player")
                        .IsRequired();

                    b.Property<int>("Presence");

                    b.Property<string>("Race")
                        .IsRequired();

                    b.Property<int>("Willpower");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
