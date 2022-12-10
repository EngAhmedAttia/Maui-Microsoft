﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApi.Data;

#nullable disable

namespace ToDoApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221210033427_initialmigration")]
    partial class initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("ToDoApi.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ToDoName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ToDoes");
                });
#pragma warning restore 612, 618
        }
    }
}