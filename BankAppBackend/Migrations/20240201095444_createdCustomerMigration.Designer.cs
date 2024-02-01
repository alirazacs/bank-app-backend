﻿// <auto-generated />
using System;
using BankAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankAppBackend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240201095444_createdCustomerMigration")]
    partial class createdCustomerMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BankAppBackend.Models.Applicant", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("TellerId")
                        .HasColumnType("bigint");

                    b.Property<int>("accountStatus")
                        .HasColumnType("int");

                    b.Property<int>("accountType")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("dob")
                        .HasColumnType("date");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TellerId");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("BankAppBackend.Models.Customer", b =>
                {
                    b.Property<long>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CustomerId"));

                    b.Property<long>("ApplicantId")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("ApplicantId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BankAppBackend.Models.Teller", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tellers");
                });

            modelBuilder.Entity("BankAppBackend.Models.Applicant", b =>
                {
                    b.HasOne("BankAppBackend.Models.Teller", "Teller")
                        .WithMany("Applicants")
                        .HasForeignKey("TellerId");

                    b.Navigation("Teller");
                });

            modelBuilder.Entity("BankAppBackend.Models.Customer", b =>
                {
                    b.HasOne("BankAppBackend.Models.Applicant", "Applicant")
                        .WithOne("customer")
                        .HasForeignKey("BankAppBackend.Models.Customer", "ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("BankAppBackend.Models.Applicant", b =>
                {
                    b.Navigation("customer");
                });

            modelBuilder.Entity("BankAppBackend.Models.Teller", b =>
                {
                    b.Navigation("Applicants");
                });
#pragma warning restore 612, 618
        }
    }
}
