﻿// <auto-generated />
using System;
using ARTiculateDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ARTiculateDataAccessLibrary.Migrations
{
    [DbContext(typeof(ArtistContext))]
    [Migration("20210210131326_addedPropDurationToVernisageClass")]
    partial class addedPropDurationToVernisageClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.ArtItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("Depth")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Open")
                        .HasColumnType("bit");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("ArtItems");
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.ArtItem_Tag", b =>
                {
                    b.Property<int>("ArtItemId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("ArtItemId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ArtItem_Tags");
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Emailadress")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Firstname")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Lastname")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Phonenumber")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Artist_Exhibition", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("ExhibitionId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId", "ExhibitionId");

                    b.HasIndex("ExhibitionId");

                    b.ToTable("Artist_Exhibitions");
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Artist_Tag", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("Artist_Tags");
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Artist_Vernisage", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<int>("VernisageId")
                        .HasColumnType("int");

                    b.HasKey("ArtistId", "VernisageId");

                    b.HasIndex("VernisageId");

                    b.ToTable("Artist_Vernisages");
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Exhibition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<bool>("Open")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Exhibitions");
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Exhibition_ArtItem", b =>
                {
                    b.Property<int>("ExhibitionId")
                        .HasColumnType("int");

                    b.Property<int>("ArtItemId")
                        .HasColumnType("int");

                    b.HasKey("ExhibitionId", "ArtItemId");

                    b.HasIndex("ArtItemId");

                    b.ToTable("Exhibition_ArtItems");
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Exhibition_Tag", b =>
                {
                    b.Property<int>("ExhibitionId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("ExhibitionId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("Exhibition_Tags");
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Link", b =>
                {
                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("Facebook")
                        .HasColumnType("varchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("FlickR")
                        .HasColumnType("varchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("Instagram")
                        .HasColumnType("varchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("Linkedin")
                        .HasColumnType("varchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("Optional")
                        .HasColumnType("varchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("Patreon")
                        .HasColumnType("varchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("Pinterest")
                        .HasColumnType("varchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("Website")
                        .HasColumnType("varchar(1500)")
                        .HasMaxLength(1500);

                    b.HasKey("ArtistId");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TagName")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Vernisage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<double>("Duration")
                        .HasColumnType("float");

                    b.Property<int>("ExhibitionId")
                        .HasColumnType("int");

                    b.Property<string>("LiveLink")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<bool>("Open")
                        .HasColumnType("bit");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ExhibitionId");

                    b.ToTable("Vernisages");
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Vernisage_Tag", b =>
                {
                    b.Property<int>("VernisageId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("VernisageId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("Vernisage_Tags");
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.ArtItem", b =>
                {
                    b.HasOne("ARTiculateDataAccessLibrary.Models.Artist", "Artist")
                        .WithMany("ArtItems")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.ArtItem_Tag", b =>
                {
                    b.HasOne("ARTiculateDataAccessLibrary.Models.ArtItem", "ArtItem")
                        .WithMany("ArtItem_Tags")
                        .HasForeignKey("ArtItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARTiculateDataAccessLibrary.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Artist_Exhibition", b =>
                {
                    b.HasOne("ARTiculateDataAccessLibrary.Models.Artist", "Artist")
                        .WithMany("Artist_Exhibitions")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARTiculateDataAccessLibrary.Models.Exhibition", "Exhibition")
                        .WithMany("Artist_Exhibitions")
                        .HasForeignKey("ExhibitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Artist_Tag", b =>
                {
                    b.HasOne("ARTiculateDataAccessLibrary.Models.Artist", "Artist")
                        .WithMany("Artist_Tags")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARTiculateDataAccessLibrary.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Artist_Vernisage", b =>
                {
                    b.HasOne("ARTiculateDataAccessLibrary.Models.Artist", "Artist")
                        .WithMany("Artist_Vernisages")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARTiculateDataAccessLibrary.Models.Vernisage", "Vernisage")
                        .WithMany("Artist_Vernisages")
                        .HasForeignKey("VernisageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Exhibition_ArtItem", b =>
                {
                    b.HasOne("ARTiculateDataAccessLibrary.Models.ArtItem", "ArtItems")
                        .WithMany("Exhibition_ArtItems")
                        .HasForeignKey("ArtItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARTiculateDataAccessLibrary.Models.Exhibition", "Exhibitions")
                        .WithMany("Exhibition_ArtItem")
                        .HasForeignKey("ExhibitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Exhibition_Tag", b =>
                {
                    b.HasOne("ARTiculateDataAccessLibrary.Models.Exhibition", "Exhibition")
                        .WithMany("Exhibition_Tags")
                        .HasForeignKey("ExhibitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARTiculateDataAccessLibrary.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Link", b =>
                {
                    b.HasOne("ARTiculateDataAccessLibrary.Models.Artist", "Artist")
                        .WithOne("Link")
                        .HasForeignKey("ARTiculateDataAccessLibrary.Models.Link", "ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Vernisage", b =>
                {
                    b.HasOne("ARTiculateDataAccessLibrary.Models.Exhibition", "Exhibition")
                        .WithMany()
                        .HasForeignKey("ExhibitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ARTiculateDataAccessLibrary.Models.Vernisage_Tag", b =>
                {
                    b.HasOne("ARTiculateDataAccessLibrary.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ARTiculateDataAccessLibrary.Models.Vernisage", "Vernisage")
                        .WithMany("Vernisage_Tags")
                        .HasForeignKey("VernisageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
