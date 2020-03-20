﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlbumDeFotos.Migrations
{
    public partial class AlbumDeFotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albuns",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Destino = table.Column<string>(maxLength: 50, nullable: false),
                    FotoTopo = table.Column<string>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albuns", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "imagens",
                columns: table => new
                {
                    ImagenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Link = table.Column<string>(nullable: false),
                    AlbunId = table.Column<int>(nullable: false),
                    AlbumId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagens", x => x.ImagenId);
                    table.ForeignKey(
                        name: "FK_imagens_Albuns_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albuns",
                        principalColumn: "AlbumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_imagens_AlbumId",
                table: "imagens",
                column: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imagens");

            migrationBuilder.DropTable(
                name: "Albuns");
        }
    }
}
