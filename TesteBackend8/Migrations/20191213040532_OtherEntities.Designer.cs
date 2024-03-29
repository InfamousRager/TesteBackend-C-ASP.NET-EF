﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteBackend8.Models;

namespace TesteBackend8.Migrations
{
    [DbContext(typeof(TesteBackend8Context))]
    [Migration("20191213040532_OtherEntities")]
    partial class OtherEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TesteBackend8.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<double>("Nota1");

                    b.Property<double>("Nota2");

                    b.Property<double>("Nota3");

                    b.Property<double>("Nota4");

                    b.Property<int?>("TurmaId");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("TesteBackend8.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("TesteBackend8.Models.Aluno", b =>
                {
                    b.HasOne("TesteBackend8.Models.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId");
                });
#pragma warning restore 612, 618
        }
    }
}
