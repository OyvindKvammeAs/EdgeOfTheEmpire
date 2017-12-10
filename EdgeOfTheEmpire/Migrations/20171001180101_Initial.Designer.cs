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
    [Migration("20171001180101_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EdgeOfTheEmpire.Models.CharacterSignatureAbilityAdvance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Column");

                    b.Property<int>("Row");

                    b.Property<string>("SignatureAbility");

                    b.HasKey("Id");

                    b.ToTable("CharacterSignatureAbilityAdvances");
                });

            modelBuilder.Entity("EdgeOfTheEmpire.Models.CharacterSkillAdvance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Skill");

                    b.HasKey("Id");

                    b.ToTable("CharacterSkillAdvances");
                });

            modelBuilder.Entity("EdgeOfTheEmpire.Models.CharacterSpecializationAdvance", b =>
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

            modelBuilder.Entity("EdgeOfTheEmpire.Models.InitialCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Agility");

                    b.Property<int>("Brawn");

                    b.Property<int>("Cunning");

                    b.Property<int>("Intelligence");

                    b.Property<string>("Name");

                    b.Property<string>("Player");

                    b.Property<int>("Presence");

                    b.Property<string>("Race");

                    b.Property<int>("Willpower");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
