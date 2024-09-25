﻿// <auto-generated />
using System;
using DynamicObject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DynamicObject.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240924101737_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DynamicObject.Domain.Model.DynamicObjectModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ObjectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjectType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DynamicObjectModels");
                });

            modelBuilder.Entity("DynamicObject.Domain.Model.ObjectData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ObjectFieldId")
                        .HasColumnType("int");

                    b.Property<string>("ObjectValues")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ObjectFieldId");

                    b.ToTable("ObjectDatas");
                });

            modelBuilder.Entity("DynamicObject.Domain.Model.ObjectField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("DynamicObjectModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<string>("ObjectType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObjectdName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DynamicObjectModelId");

                    b.ToTable("ObjectFields");
                });

            modelBuilder.Entity("DynamicObject.Domain.Model.ObjectData", b =>
                {
                    b.HasOne("DynamicObject.Domain.Model.ObjectField", null)
                        .WithMany("ObjectDatas")
                        .HasForeignKey("ObjectFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DynamicObject.Domain.Model.ObjectField", b =>
                {
                    b.HasOne("DynamicObject.Domain.Model.DynamicObjectModel", null)
                        .WithMany("ObjectFields")
                        .HasForeignKey("DynamicObjectModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DynamicObject.Domain.Model.DynamicObjectModel", b =>
                {
                    b.Navigation("ObjectFields");
                });

            modelBuilder.Entity("DynamicObject.Domain.Model.ObjectField", b =>
                {
                    b.Navigation("ObjectDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
