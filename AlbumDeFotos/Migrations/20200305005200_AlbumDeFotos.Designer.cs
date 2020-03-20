﻿// <auto-generated />
using System;
using AlbumDeFotos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlbumDeFotos.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200305005200_AlbumDeFotos")]
    partial class AlbumDeFotos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlbumDeFotos.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Fim");

                    b.Property<string>("FotoTopo")
                        .IsRequired();

                    b.Property<DateTime>("Inicio");

                    b.HasKey("AlbumId");

                    b.ToTable("Albuns");
                });

            modelBuilder.Entity("AlbumDeFotos.Models.Imagen", b =>
                {
                    b.Property<int>("ImagenId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumId");

                    b.Property<int>("AlbunId");

                    b.Property<string>("Link")
                        .IsRequired();

                    b.HasKey("ImagenId");

                    b.HasIndex("AlbumId");

                    b.ToTable("imagens");
                });

            modelBuilder.Entity("AlbumDeFotos.Models.Imagen", b =>
                {
                    b.HasOne("AlbumDeFotos.Models.Album", "Album")
                        .WithMany("Imagen")
                        .HasForeignKey("AlbumId");
                });
#pragma warning restore 612, 618
        }
    }
}
