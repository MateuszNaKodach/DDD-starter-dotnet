﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCompany.Crm.Contacts.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyCompany.Crm.Contacts.Database.Migrations
{
    [DbContext(typeof(ContactsDbContext))]
    [Migration("20220831085231_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyCompany.Crm.Contacts.Companies.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Companies.CompanyGroup", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.HasKey("CompanyId", "GroupId");

                    b.ToTable("CompanyGroup");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Companies.CompanyTag", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.HasKey("CompanyId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("CompanyTag");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Groups.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Groups.GroupTag", b =>
                {
                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.HasKey("GroupId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("GroupTag");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Tags.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Companies.Company", b =>
                {
                    b.OwnsOne("MyCompany.Crm.Contacts.Companies.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .HasColumnType("text");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("text");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Companies");

                            b1.WithOwner("Company")
                                .HasForeignKey("CompanyId");

                            b1.Navigation("Company");
                        });

                    b.OwnsMany("MyCompany.Crm.Contacts.Companies.Phone", "Phones", b1 =>
                        {
                            b1.Property<string>("Number")
                                .HasColumnType("text");

                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("uuid");

                            b1.HasKey("Number");

                            b1.HasIndex("CompanyId");

                            b1.ToTable("Phone");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Phones");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Companies.CompanyGroup", b =>
                {
                    b.HasOne("MyCompany.Crm.Contacts.Companies.Company", "Company")
                        .WithMany("Groups")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCompany.Crm.Contacts.Groups.Group", "Group")
                        .WithMany("Companies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Companies.CompanyTag", b =>
                {
                    b.HasOne("MyCompany.Crm.Contacts.Companies.Company", "Company")
                        .WithMany("Tags")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCompany.Crm.Contacts.Tags.Tag", "Tag")
                        .WithMany("Companies")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Groups.GroupTag", b =>
                {
                    b.HasOne("MyCompany.Crm.Contacts.Groups.Group", "Group")
                        .WithMany("Tags")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCompany.Crm.Contacts.Tags.Tag", "Tag")
                        .WithMany("Groups")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Companies.Company", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Groups.Group", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("MyCompany.Crm.Contacts.Tags.Tag", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}