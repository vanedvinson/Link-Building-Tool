﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using LinkBuildingTool.Core.Persistence;

#nullable disable

namespace LinkBuildingTool.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    [Migration("20221109214709_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<string>("PrioUrl")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("385786b8-c5f4-4f2a-b6ba-b168702a71db"),
                            Name = "client 1"
                        },
                        new
                        {
                            Id = new Guid("8c44ca32-beef-4aa2-a24c-ac3161ac8133"),
                            Name = "client 2"
                        });
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.ClientDomain", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Metrics")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Theme")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("WebmasterId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("WebmasterId");

                    b.ToTable("Domains");

                    b.HasData(
                        new
                        {
                            Id = new Guid("326ffb9d-411e-4007-81b1-504a9d865948"),
                            Name = "domain 1",
                            Theme = " theme 1"
                        },
                        new
                        {
                            Id = new Guid("42f6e765-0015-43eb-8dc2-ba7483d9bcc4"),
                            Name = "domain 2",
                            Theme = " theme 2"
                        });
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.ClientType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ClientTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ccf5a932-76c3-4180-b1dd-def2a906fb4a"),
                            Amount = 2m,
                            Name = "Anzahl"
                        },
                        new
                        {
                            Id = new Guid("f13ef1bf-1ec2-4def-992a-97768dde32c7"),
                            Amount = 200m,
                            Name = "Budget"
                        });
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.Link", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal?>("ContentPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("InclExclText")
                        .HasColumnType("longtext");

                    b.Property<string>("LinkBuilderId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("PriceNetto")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TimeInterval")
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LinkBuilderId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.LinkAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("LinkAttributes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b92d0bb-eb16-4195-b668-413253754499"),
                            Name = "follow"
                        },
                        new
                        {
                            Id = new Guid("b39a791a-134b-47c3-91dc-3555394ceb42"),
                            Name = "nofollow"
                        });
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.LinkType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("LinkTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("08c36374-dbd4-4e21-a169-9b7f7e948198"),
                            Name = "editorial"
                        },
                        new
                        {
                            Id = new Guid("3fde1f12-aa91-4379-aeeb-a14302d79961"),
                            Name = "community"
                        },
                        new
                        {
                            Id = new Guid("22a2749a-6cb8-43c6-a6af-8af864189a28"),
                            Name = "directory"
                        });
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "9a2817b4-8181-437b-afea-ee1daff707b4",
                            ConcurrencyStamp = "a8c7a051-5a33-480b-a7cd-6f37d1df2f69",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "488b094c-65cf-43b7-a8e6-d2be36286c6a",
                            ConcurrencyStamp = "602db514-9079-4fa6-9d8b-0582b7ce2b66",
                            Name = "Linkbuilder",
                            NormalizedName = "LINKBUILDER"
                        });
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int?>("Group")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6756f803-4a8a-4b45-94d3-dba14257b70c"),
                            Group = 1,
                            Name = "Vorschlag"
                        },
                        new
                        {
                            Id = new Guid("657cafe5-c6c7-4fff-bed2-6d464ea11256"),
                            Group = 2,
                            Name = "1. Kontakt"
                        },
                        new
                        {
                            Id = new Guid("163a46e9-d6f8-400e-952b-33312d84436b"),
                            Group = 2,
                            Name = "2. Kontakt"
                        },
                        new
                        {
                            Id = new Guid("edb059b4-9ed3-4325-9379-f6a30accabc5"),
                            Group = 2,
                            Name = "3. Kontakt"
                        },
                        new
                        {
                            Id = new Guid("9d445f49-37eb-44ce-9a47-2b56d3ef6fa5"),
                            Group = 2,
                            Name = "Verhandlung"
                        },
                        new
                        {
                            Id = new Guid("73b39209-667e-40b5-9b5b-e013060f79de"),
                            Group = 3,
                            Name = "Zusage"
                        },
                        new
                        {
                            Id = new Guid("28e9a232-df45-4c49-a77b-0e29ce04b2eb"),
                            Group = 3,
                            Name = "WM Schreibt"
                        },
                        new
                        {
                            Id = new Guid("41ac3192-3560-43b5-8b6f-f949618685cd"),
                            Group = 3,
                            Name = "Text bestellt"
                        },
                        new
                        {
                            Id = new Guid("2d32f656-cfea-4601-9566-7aacb4722666"),
                            Group = 3,
                            Name = "Text verschickt"
                        },
                        new
                        {
                            Id = new Guid("4e4c54d1-a9f2-404e-94c0-6f1e1f89a5d0"),
                            Group = 3,
                            Name = "Änderung"
                        },
                        new
                        {
                            Id = new Guid("03931800-53b6-48e3-997b-f596d604f3de"),
                            Group = 3,
                            Name = "Live"
                        });
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AnchorText")
                        .HasColumnType("longtext");

                    b.Property<bool?>("Approve")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("ApprovePrice")
                        .HasColumnType("tinyint(1)");

                    b.Property<double?>("BudgetAmount")
                        .HasColumnType("double");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("DomainId")
                        .HasColumnType("char(36)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("IsFinished")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastEdited")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LinkAmount")
                        .HasColumnType("int");

                    b.Property<Guid?>("LinkAttributeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LinkTarget")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("LinkTypeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<double?>("Price")
                        .HasColumnType("double");

                    b.Property<DateTime?>("Published")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ReasonForFinished")
                        .HasColumnType("longtext");

                    b.Property<int?>("StatusGroup")
                        .HasColumnType("int");

                    b.Property<Guid?>("StatusId")
                        .HasColumnType("char(36)");

                    b.Property<string>("TextLink")
                        .HasColumnType("longtext");

                    b.Property<string>("Theme")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("DomainId");

                    b.HasIndex("LinkAttributeId");

                    b.HasIndex("LinkTypeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Education")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("EmailConfirmationToken")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsEmployee")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Language")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("LongTerm")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordResetToken")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<string>("Profession")
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("ShortTerm")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "f05fccf7-dac0-4f24-9c54-92208e06fb01",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "11f3faf4-d8c2-4bcb-b9f4-25abf5ac6761",
                            CreatedAt = new DateTime(2022, 11, 9, 22, 47, 8, 729, DateTimeKind.Local).AddTicks(8245),
                            Email = "benjamin@an-digital.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            IsEmployee = false,
                            IsWorking = false,
                            LastName = "Admin",
                            LockoutEnabled = false,
                            LongTerm = false,
                            NormalizedEmail = "BENJAMIN@AN-DIGITAL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEOpwHaChjunhb8nP43BTPCw00i02dKTokT+U6/gXTrRe8iXrOJ1l+d+WOY8tKKVQFg==",
                            PhoneNumber = "0600103693",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            ShortTerm = false,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2022, 11, 9, 21, 47, 8, 729, DateTimeKind.Utc).AddTicks(8173),
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "584290a6-6e87-43bf-bde1-626c5d993e85",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a3384936-e6e9-4a7b-9dc9-43a2f32ba106",
                            CreatedAt = new DateTime(2022, 11, 9, 22, 47, 8, 729, DateTimeKind.Local).AddTicks(8336),
                            Email = "milan@an-digital.com",
                            EmailConfirmed = true,
                            FirstName = "Linkbuilder",
                            IsEmployee = false,
                            IsWorking = false,
                            LastName = "Lb",
                            LockoutEnabled = false,
                            LongTerm = false,
                            NormalizedEmail = "MILAN@AN-DIGITAL.COM",
                            NormalizedUserName = "LINKBUILDER",
                            PasswordHash = "AQAAAAEAACcQAAAAEJUncN0JfpOBDJ35LE8hWrP030dk/B2fqg65gyAZOzzcffJA/0JRjBeAd0FS8EbGIA==",
                            PhoneNumber = "0600103693",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            ShortTerm = false,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2022, 11, 9, 21, 47, 8, 729, DateTimeKind.Utc).AddTicks(8300),
                            UserName = "linkbuilder"
                        },
                        new
                        {
                            Id = "c6ada4f0-bdf8-4e34-aa73-05a189e76103",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "21f3bbd9-5777-4891-8bf4-5d74b1efa6a1",
                            CreatedAt = new DateTime(2022, 11, 9, 22, 47, 8, 729, DateTimeKind.Local).AddTicks(8361),
                            Email = "e.kovacevic102@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Linkbuilder2",
                            IsEmployee = false,
                            IsWorking = false,
                            LastName = "Lb2",
                            LockoutEnabled = false,
                            LongTerm = false,
                            NormalizedEmail = "E.KOVACEVIC102@GMAIL.COM",
                            NormalizedUserName = "LINKBUILDER2",
                            PasswordHash = "AQAAAAEAACcQAAAAELMSxKVHl9p1yqIDDsXlpdhOF/dNRqEDGXT/URfx8Owrc4xhmh9xHoBX/wGfPu0b5w==",
                            PhoneNumber = "0600103693",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3de18460-825a-4360-b3cd-6cff1c92bd13",
                            ShortTerm = false,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2022, 11, 9, 21, 47, 8, 729, DateTimeKind.Utc).AddTicks(8344),
                            UserName = "linkbuilder2"
                        });
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.UserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "f05fccf7-dac0-4f24-9c54-92208e06fb01",
                            RoleId = "9a2817b4-8181-437b-afea-ee1daff707b4"
                        },
                        new
                        {
                            UserId = "584290a6-6e87-43bf-bde1-626c5d993e85",
                            RoleId = "488b094c-65cf-43b7-a8e6-d2be36286c6a"
                        },
                        new
                        {
                            UserId = "c6ada4f0-bdf8-4e34-aa73-05a189e76103",
                            RoleId = "488b094c-65cf-43b7-a8e6-d2be36286c6a"
                        });
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.Webmaster", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Note")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<string>("SocialMediaUrl")
                        .HasColumnType("longtext");

                    b.Property<bool?>("Title")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Webmasters");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b5b985c9-5612-43e2-b92e-a3c93b0ef477"),
                            Email = "webm",
                            Lastname = "web 1",
                            Name = "webmaster 1",
                            Note = "good",
                            Phone = "123",
                            SocialMediaUrl = "https://google.com"
                        },
                        new
                        {
                            Id = new Guid("5582f8c6-ff31-4710-9076-99ef832e4b66"),
                            Email = "webm",
                            Lastname = "web 2",
                            Name = "webmaster 2",
                            Note = "good",
                            Phone = "123",
                            SocialMediaUrl = "https://google.com"
                        },
                        new
                        {
                            Id = new Guid("40eb95a8-b88d-448d-816f-0d100d9d2feb"),
                            Email = "webm",
                            Lastname = "web 3",
                            Name = "webmaster 3",
                            Note = "good",
                            Phone = "123",
                            SocialMediaUrl = "https://google.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.Client", b =>
                {
                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.ClientType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.ClientDomain", b =>
                {
                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.Webmaster", "Webmaster")
                        .WithMany()
                        .HasForeignKey("WebmasterId");

                    b.Navigation("Webmaster");
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.Link", b =>
                {
                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.User", "LinkBuilder")
                        .WithMany()
                        .HasForeignKey("LinkBuilderId");

                    b.Navigation("LinkBuilder");
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.Todo", b =>
                {
                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.ClientDomain", "Domain")
                        .WithMany()
                        .HasForeignKey("DomainId");

                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.LinkAttribute", "LinkAttribute")
                        .WithMany()
                        .HasForeignKey("LinkAttributeId");

                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.LinkType", "LinkType")
                        .WithMany()
                        .HasForeignKey("LinkTypeId");

                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Client");

                    b.Navigation("Domain");

                    b.Navigation("LinkAttribute");

                    b.Navigation("LinkType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.Role", "Role")
                        .WithMany("Roles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LinkBuildingTool.Core.Domain.Entities.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.Role", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("LinkBuildingTool.Core.Domain.Entities.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}