﻿// <auto-generated />
using Firma.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Firma.Data.Migrations
{
    [DbContext(typeof(AlmondContext))]
    [Migration("20230426184728_M8_Page_Photo_down")]
    partial class M8_Page_Photo_down
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Firma.Data.Data.CMS.Cat", b =>
                {
                    b.Property<int>("KotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KotId"), 1L, 1);

                    b.Property<decimal>("Cena")
                        .HasColumnType("money");

                    b.Property<string>("FotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Kolor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Rasa")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("KotId");

                    b.ToTable("Cat");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.CatTree", b =>
                {
                    b.Property<int>("DrapakId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrapakId"), 1L, 1);

                    b.Property<decimal>("Cena")
                        .HasColumnType("money");

                    b.Property<string>("FotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Kolor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.HasKey("DrapakId");

                    b.ToTable("CatTree");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.News", b =>
                {
                    b.Property<int>("IdAktualnosci")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAktualnosci"), 1L, 1);

                    b.Property<string>("LinkTytul")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdAktualnosci");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.Page", b =>
                {
                    b.Property<int>("IdStrony")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStrony"), 1L, 1);

                    b.Property<string>("FotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("FotoUrlDown")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("LinkTytul")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdStrony");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.Params", b =>
                {
                    b.Property<int>("IdParametr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdParametr"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("IdParametr");

                    b.ToTable("Params");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.Test", b =>
                {
                    b.Property<int>("IdTest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTest"), 1L, 1);

                    b.Property<string>("LinkTytul")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdTest");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("Firma.Data.Data.Sklep.Drapak", b =>
                {
                    b.Property<int>("DrapakId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrapakId"), 1L, 1);

                    b.Property<decimal>("Cena")
                        .HasColumnType("money");

                    b.Property<int>("DrapakRodzajId")
                        .HasColumnType("int");

                    b.Property<string>("FotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Kolor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.HasKey("DrapakId");

                    b.HasIndex("DrapakRodzajId");

                    b.ToTable("Drapak");
                });

            modelBuilder.Entity("Firma.Data.Data.Sklep.DrapakRodzaj", b =>
                {
                    b.Property<int>("DrapakRodzajId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrapakRodzajId"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.HasKey("DrapakRodzajId");

                    b.ToTable("DrapakRodzaj");
                });

            modelBuilder.Entity("Firma.Data.Data.Sklep.Kot", b =>
                {
                    b.Property<int>("KotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KotId"), 1L, 1);

                    b.Property<decimal>("Cena")
                        .HasColumnType("money");

                    b.Property<string>("FotoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Kolor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("KotRodzajId")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Rasa")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("KotId");

                    b.HasIndex("KotRodzajId");

                    b.ToTable("Kot");
                });

            modelBuilder.Entity("Firma.Data.Data.Sklep.KotRodzaj", b =>
                {
                    b.Property<int>("KotRodzajId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KotRodzajId"), 1L, 1);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.HasKey("KotRodzajId");

                    b.ToTable("KotRodzaj");
                });

            modelBuilder.Entity("Firma.Data.Data.Sklep.Drapak", b =>
                {
                    b.HasOne("Firma.Data.Data.Sklep.DrapakRodzaj", "DrapakRodzaj")
                        .WithMany("Drapaks")
                        .HasForeignKey("DrapakRodzajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrapakRodzaj");
                });

            modelBuilder.Entity("Firma.Data.Data.Sklep.Kot", b =>
                {
                    b.HasOne("Firma.Data.Data.Sklep.KotRodzaj", "KotRodzaj")
                        .WithMany("Kots")
                        .HasForeignKey("KotRodzajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KotRodzaj");
                });

            modelBuilder.Entity("Firma.Data.Data.Sklep.DrapakRodzaj", b =>
                {
                    b.Navigation("Drapaks");
                });

            modelBuilder.Entity("Firma.Data.Data.Sklep.KotRodzaj", b =>
                {
                    b.Navigation("Kots");
                });
#pragma warning restore 612, 618
        }
    }
}
