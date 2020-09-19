﻿// <auto-generated />
using Libr.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Libr.Migrations.Cart
{
    [DbContext(typeof(CartContext))]
    [Migration("20200919145403_Cart")]
    partial class Cart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Libr.Data.Models.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IDBook")
                        .HasColumnType("integer");

                    b.Property<string>("NameBook")
                        .HasColumnType("text");

                    b.Property<int>("count")
                        .HasColumnType("integer");

                    b.Property<int>("idBook")
                        .HasColumnType("integer");

                    b.Property<string>("ip")
                        .HasColumnType("text");

                    b.Property<string>("login")
                        .HasColumnType("text");

                    b.Property<int>("priceBook")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Carts");
                });
#pragma warning restore 612, 618
        }
    }
}
