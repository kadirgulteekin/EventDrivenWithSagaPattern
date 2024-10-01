using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicObject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Reflection1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectDatas_ObjectFields_ObjectFieldId",
                table: "ObjectDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectFields_DynamicObjectModels_DynamicObjectModelId",
                table: "ObjectFields");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetail_Products_ProductId",
                table: "ProductDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage");

            migrationBuilder.DropTable(
                name: "DynamicObjectModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetail",
                table: "ProductDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObjectFields",
                table: "ObjectFields");

            migrationBuilder.DropIndex(
                name: "IX_ObjectFields_DynamicObjectModelId",
                table: "ObjectFields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObjectDatas",
                table: "ObjectDatas");

            migrationBuilder.RenameTable(
                name: "ProductImage",
                newName: "ProductImages");

            migrationBuilder.RenameTable(
                name: "ProductDetail",
                newName: "ProductDetails");

            migrationBuilder.RenameTable(
                name: "ObjectFields",
                newName: "ObjectField");

            migrationBuilder.RenameTable(
                name: "ObjectDatas",
                newName: "ObjectData");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetail_ProductId",
                table: "ProductDetails",
                newName: "IX_ProductDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ObjectDatas_ObjectFieldId",
                table: "ObjectData",
                newName: "IX_ObjectData_ObjectFieldId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObjectField",
                table: "ObjectField",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObjectData",
                table: "ObjectData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectData_ObjectField_ObjectFieldId",
                table: "ObjectData",
                column: "ObjectFieldId",
                principalTable: "ObjectField",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Products_ProductId",
                table: "ProductDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectData_ObjectField_ObjectFieldId",
                table: "ObjectData");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Products_ProductId",
                table: "ProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductDetails",
                table: "ProductDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObjectField",
                table: "ObjectField");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObjectData",
                table: "ObjectData");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImage");

            migrationBuilder.RenameTable(
                name: "ProductDetails",
                newName: "ProductDetail");

            migrationBuilder.RenameTable(
                name: "ObjectField",
                newName: "ObjectFields");

            migrationBuilder.RenameTable(
                name: "ObjectData",
                newName: "ObjectDatas");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImage",
                newName: "IX_ProductImage_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetail",
                newName: "IX_ProductDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ObjectData_ObjectFieldId",
                table: "ObjectDatas",
                newName: "IX_ObjectDatas_ObjectFieldId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductDetail",
                table: "ProductDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObjectFields",
                table: "ObjectFields",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObjectDatas",
                table: "ObjectDatas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DynamicObjectModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ObjectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicObjectModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectFields_DynamicObjectModelId",
                table: "ObjectFields",
                column: "DynamicObjectModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectDatas_ObjectFields_ObjectFieldId",
                table: "ObjectDatas",
                column: "ObjectFieldId",
                principalTable: "ObjectFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectFields_DynamicObjectModels_DynamicObjectModelId",
                table: "ObjectFields",
                column: "DynamicObjectModelId",
                principalTable: "DynamicObjectModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetail_Products_ProductId",
                table: "ProductDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Products_ProductId",
                table: "ProductImage",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
