﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using balasolu.web.contexts;

namespace balasolu.web.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20211007040052__00-00-32_07-10-2021")]
    partial class _000032_07102021
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.10");

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

                    b.ToTable("RoleClaims");
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

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("balasolu.models.abstractions.Account", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasDiscriminator<int>("AccountType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.abstractions.Item", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("Ethereal")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ItemQuality")
                        .HasColumnType("int");

                    b.Property<int>("ItemRarity")
                        .HasColumnType("int");

                    b.Property<int>("ItemType")
                        .HasColumnType("int");

                    b.Property<int>("MaxSockets")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<bool>("Perfect")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Socketed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Sockets")
                        .HasColumnType("int");

                    b.Property<bool>("Unidentified")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Upped")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasDiscriminator<int>("ItemType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.web.models.abstractions.Post", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ItemFTId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ItemISOId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PostType")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ItemFTId");

                    b.HasIndex("ItemISOId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasDiscriminator<int>("PostType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.web.models.abstractions.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Roles");

                    b.HasDiscriminator<int>("RoleType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.web.models.abstractions.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<ulong?>("AccountId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("PC")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("PlayStation")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("Switch")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<bool>("Xbox")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("UserType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.DefaultAccount", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Account");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.DiscordAccount", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Account");

                    b.Property<string>("Avatar")
                        .HasColumnType("longtext");

                    b.Property<bool>("Bot")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Discriminator")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Flags")
                        .HasColumnType("longtext");

                    b.Property<string>("Locale")
                        .HasColumnType("longtext");

                    b.Property<bool>("MFA_Enabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Premium_Type")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.Property<bool>("Verified")
                        .HasColumnType("tinyint(1)");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("balasolu.models.ArmorItem", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Item");

                    b.Property<int>("ItemArmorBase")
                        .HasColumnType("int");

                    b.Property<int>("ItemArmorType")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("balasolu.models.DefaultItem", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Item");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.OtherItem", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Item");

                    b.Property<int>("ItemOtherBase")
                        .HasColumnType("int");

                    b.Property<int>("ItemOtherType")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("balasolu.models.WeaponItem", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Item");

                    b.Property<int>("ItemWeaponBase")
                        .HasColumnType("int");

                    b.Property<int>("ItemWeaponType")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("balasolu.web.models.DefaultPost", b =>
                {
                    b.HasBaseType("balasolu.web.models.abstractions.Post");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.web.models.DefaultRole", b =>
                {
                    b.HasBaseType("balasolu.web.models.abstractions.Role");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.web.models.DefaultUser", b =>
                {
                    b.HasBaseType("balasolu.web.models.abstractions.User");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("balasolu.web.models.abstractions.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("balasolu.web.models.abstractions.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("balasolu.web.models.abstractions.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("balasolu.web.models.abstractions.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("balasolu.web.models.abstractions.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("balasolu.web.models.abstractions.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("balasolu.web.models.abstractions.Post", b =>
                {
                    b.HasOne("balasolu.models.abstractions.Item", "ItemFT")
                        .WithMany()
                        .HasForeignKey("ItemFTId");

                    b.HasOne("balasolu.models.abstractions.Item", "ItemISO")
                        .WithMany()
                        .HasForeignKey("ItemISOId");

                    b.HasOne("balasolu.web.models.abstractions.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("ItemFT");

                    b.Navigation("ItemISO");

                    b.Navigation("User");
                });

            modelBuilder.Entity("balasolu.web.models.abstractions.User", b =>
                {
                    b.HasOne("balasolu.models.abstractions.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}