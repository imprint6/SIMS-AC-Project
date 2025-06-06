﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(SIMSContext))]
    partial class SIMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<bool?>("Blocked")
                        .HasColumnType("bit")
                        .HasColumnName("BLOCKED");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FIRSTNAME");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LASTNAME");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PASSWORD_HASH");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PASSWORD_SALT");

                    b.Property<int?>("Role")
                        .HasColumnType("int")
                        .HasColumnName("ROLE");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("USERNAME");

                    b.Property<string>("UserUUID")
                        .HasColumnType("VARCHAR(300)")
                        .HasColumnName("User_UUID");

                    b.HasKey("ID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("USERS");
                });

            modelBuilder.Entity("WebAPI.Models.LogEntry", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<int>("Level")
                        .HasColumnType("int")
                        .HasColumnName("LEVEL");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("MESSAGE");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2")
                        .HasColumnName("TIMESTAMP");

                    b.HasKey("ID");

                    b.ToTable("LOG_ENTRIES");
                });

            modelBuilder.Entity("WebAPI.Models.Ticket", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long?>("AssignedPersonID")
                        .HasColumnType("bigint")
                        .HasColumnName("ASSIGNEDPERSON_ID");

                    b.Property<string>("CVE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CVE");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATION_TIME");

                    b.Property<long?>("CreatorID")
                        .HasColumnType("bigint")
                        .HasColumnName("CREATOR_ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<string>("ReferenceID")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("REFERENCE_ID");

                    b.Property<byte>("Severity")
                        .HasColumnType("tinyint")
                        .HasColumnName("SEVERITY");

                    b.Property<int>("State")
                        .HasColumnType("int")
                        .HasColumnName("STATE");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("TITLE");

                    b.HasKey("ID");

                    b.HasIndex("AssignedPersonID");

                    b.HasIndex("CreatorID");

                    b.ToTable("TICKETS");
                });

            modelBuilder.Entity("WebAPI.Models.Ticket", b =>
                {
                    b.HasOne("User", "AssignedPerson")
                        .WithMany("AssignedTickets")
                        .HasForeignKey("AssignedPersonID");

                    b.HasOne("User", "Creator")
                        .WithMany("CreatedTickets")
                        .HasForeignKey("CreatorID");

                    b.Navigation("AssignedPerson");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("AssignedTickets");

                    b.Navigation("CreatedTickets");
                });
#pragma warning restore 612, 618
        }
    }
}
