﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MountainGuide.Infrastructure.Data;

#nullable disable

namespace MountainGuide.Infrastructure.Data.Migrations
{
    [DbContext(typeof(MountainGuideDbContext))]
    [Migration("20220331062330_NewConfigurations")]
    partial class NewConfigurations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TouristAssociationId")
                        .HasColumnType("int");

                    b.Property<int?>("TouristBuildingId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TouristAssociationId");

                    b.HasIndex("TouristBuildingId");

                    b.HasIndex("UserId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.AssociationManager", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("TouristAssociationId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TouristAssociationId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("AssociationManagers");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.BuildingManager", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("TouristBuildingId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TouristBuildingId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("BuildingManagers");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TouristAssociationId")
                        .HasColumnType("int");

                    b.Property<int?>("TouristBuildingId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("TouristAssociationId");

                    b.HasIndex("TouristBuildingId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Coordinate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("LatitudeType")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("LatitudeValue")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("LongitudeType")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("LongitudeValue")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("MountainId")
                        .HasColumnType("int");

                    b.Property<int?>("PeakId")
                        .HasColumnType("int");

                    b.Property<int?>("TouristAssociationId")
                        .HasColumnType("int");

                    b.Property<int?>("TouristBuildingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MountainId");

                    b.HasIndex("PeakId");

                    b.HasIndex("TouristAssociationId");

                    b.HasIndex("TouristBuildingId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CommentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TouristAssociationId")
                        .HasColumnType("int");

                    b.Property<int?>("TouristBuildingId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("TouristAssociationId");

                    b.HasIndex("TouristBuildingId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Mountain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Mountains");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Peak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Altitude")
                        .HasColumnType("float");

                    b.Property<int?>("CoordinateId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MountainId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CoordinateId")
                        .IsUnique()
                        .HasFilter("[CoordinateId] IS NOT NULL");

                    b.HasIndex("MountainId");

                    b.ToTable("Peaks");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.TouristAssociation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoUrl")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("WebSiteUrl")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("TouristAssociations");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.TouristBuilding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Altitude")
                        .HasColumnType("float");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("CoordinateId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MountainId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("TouristAssociationId")
                        .HasColumnType("int");

                    b.Property<int>("TouristBuildingTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoordinateId")
                        .IsUnique();

                    b.HasIndex("MountainId");

                    b.HasIndex("TouristAssociationId");

                    b.HasIndex("TouristBuildingTypeId");

                    b.ToTable("TouristBuildings");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.TouristBuildingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TouristBuildingTypes");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Announcement", b =>
                {
                    b.HasOne("MountainGuide.Infrastructure.Data.Models.TouristAssociation", "TouristAssociation")
                        .WithMany("Announcements")
                        .HasForeignKey("TouristAssociationId");

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.TouristBuilding", "TouristBuilding")
                        .WithMany("Announcements")
                        .HasForeignKey("TouristBuildingId");

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.User", "User")
                        .WithMany("Announcements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TouristAssociation");

                    b.Navigation("TouristBuilding");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.AssociationManager", b =>
                {
                    b.HasOne("MountainGuide.Infrastructure.Data.Models.TouristAssociation", "TouristAssociation")
                        .WithOne()
                        .HasForeignKey("MountainGuide.Infrastructure.Data.Models.AssociationManager", "TouristAssociationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("MountainGuide.Infrastructure.Data.Models.AssociationManager", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TouristAssociation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.BuildingManager", b =>
                {
                    b.HasOne("MountainGuide.Infrastructure.Data.Models.TouristBuilding", "TouristBuilding")
                        .WithOne()
                        .HasForeignKey("MountainGuide.Infrastructure.Data.Models.BuildingManager", "TouristBuildingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("MountainGuide.Infrastructure.Data.Models.BuildingManager", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TouristBuilding");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Comment", b =>
                {
                    b.HasOne("MountainGuide.Infrastructure.Data.Models.Comment", null)
                        .WithMany("Comments")
                        .HasForeignKey("CommentId");

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.TouristAssociation", "TouristAssociation")
                        .WithMany("Comments")
                        .HasForeignKey("TouristAssociationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.TouristBuilding", "TouristBuilding")
                        .WithMany("Comments")
                        .HasForeignKey("TouristBuildingId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TouristAssociation");

                    b.Navigation("TouristBuilding");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Image", b =>
                {
                    b.HasOne("MountainGuide.Infrastructure.Data.Models.Mountain", "Mountain")
                        .WithMany("Images")
                        .HasForeignKey("MountainId");

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.Peak", "Peak")
                        .WithMany("Images")
                        .HasForeignKey("PeakId");

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.TouristAssociation", "TouristAssociation")
                        .WithMany("Images")
                        .HasForeignKey("TouristAssociationId");

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.TouristBuilding", "TouristBuilding")
                        .WithMany("Images")
                        .HasForeignKey("TouristBuildingId");

                    b.Navigation("Mountain");

                    b.Navigation("Peak");

                    b.Navigation("TouristAssociation");

                    b.Navigation("TouristBuilding");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Like", b =>
                {
                    b.HasOne("MountainGuide.Infrastructure.Data.Models.Comment", "Comment")
                        .WithMany("Likes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.TouristAssociation", "TouristAssociation")
                        .WithMany("Likes")
                        .HasForeignKey("TouristAssociationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.TouristBuilding", "TouristBuilding")
                        .WithMany("Likes")
                        .HasForeignKey("TouristBuildingId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("TouristAssociation");

                    b.Navigation("TouristBuilding");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Peak", b =>
                {
                    b.HasOne("MountainGuide.Infrastructure.Data.Models.Coordinate", "Coordinate")
                        .WithOne()
                        .HasForeignKey("MountainGuide.Infrastructure.Data.Models.Peak", "CoordinateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.Mountain", "Mountain")
                        .WithMany("Peaks")
                        .HasForeignKey("MountainId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Coordinate");

                    b.Navigation("Mountain");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.TouristBuilding", b =>
                {
                    b.HasOne("MountainGuide.Infrastructure.Data.Models.Coordinate", "Coordinate")
                        .WithOne()
                        .HasForeignKey("MountainGuide.Infrastructure.Data.Models.TouristBuilding", "CoordinateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.Mountain", "Mountain")
                        .WithMany("TouristBuildings")
                        .HasForeignKey("MountainId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.TouristAssociation", "TouristAssociation")
                        .WithMany("TouristBuildings")
                        .HasForeignKey("TouristAssociationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MountainGuide.Infrastructure.Data.Models.TouristBuildingType", "TouristBuildingType")
                        .WithMany("TouristBuildings")
                        .HasForeignKey("TouristBuildingTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Coordinate");

                    b.Navigation("Mountain");

                    b.Navigation("TouristAssociation");

                    b.Navigation("TouristBuildingType");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Comment", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Mountain", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Peaks");

                    b.Navigation("TouristBuildings");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.Peak", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.TouristAssociation", b =>
                {
                    b.Navigation("Announcements");

                    b.Navigation("Comments");

                    b.Navigation("Images");

                    b.Navigation("Likes");

                    b.Navigation("TouristBuildings");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.TouristBuilding", b =>
                {
                    b.Navigation("Announcements");

                    b.Navigation("Comments");

                    b.Navigation("Images");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.TouristBuildingType", b =>
                {
                    b.Navigation("TouristBuildings");
                });

            modelBuilder.Entity("MountainGuide.Infrastructure.Data.Models.User", b =>
                {
                    b.Navigation("Announcements");

                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
