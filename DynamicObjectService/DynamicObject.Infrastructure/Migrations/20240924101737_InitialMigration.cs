using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicObject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DynamicObjectModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicObjectModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DynamicObjectModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectdName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectFields_DynamicObjectModels_DynamicObjectModelId",
                        column: x => x.DynamicObjectModelId,
                        principalTable: "DynamicObjectModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectFieldId = table.Column<int>(type: "int", nullable: false),
                    ObjectValues = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectDatas_ObjectFields_ObjectFieldId",
                        column: x => x.ObjectFieldId,
                        principalTable: "ObjectFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectDatas_ObjectFieldId",
                table: "ObjectDatas",
                column: "ObjectFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectFields_DynamicObjectModelId",
                table: "ObjectFields",
                column: "DynamicObjectModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectDatas");

            migrationBuilder.DropTable(
                name: "ObjectFields");

            migrationBuilder.DropTable(
                name: "DynamicObjectModels");
        }
    }
}
