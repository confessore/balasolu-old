﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using balasolu.contexts;

#nullable disable

namespace balasolu.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20220607221537_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("balasolu.models.abstractions.Address", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AddressType")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("ContactId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("Line1")
                        .HasColumnType("longtext");

                    b.Property<string>("Line2")
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Addresses", (string)null);

                    b.HasDiscriminator<int>("AddressType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.abstractions.Author", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AuthorType")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Uri")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Authors", (string)null);

                    b.HasDiscriminator<int>("AuthorType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.abstractions.Booth", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("BoothType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSource")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Summary")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Booths", (string)null);

                    b.HasDiscriminator<int>("BoothType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.abstractions.Cart", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CartType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carts", (string)null);

                    b.HasDiscriminator<int>("CartType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.abstractions.CartItem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CartId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CartItemType")
                        .HasColumnType("int");

                    b.Property<string>("ProductId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems", (string)null);

                    b.HasDiscriminator<int>("CartItemType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.abstractions.Contact", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Contacts", (string)null);

                    b.HasDiscriminator<int>("ContactType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.abstractions.Entry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Content")
                        .HasColumnType("longtext");

                    b.Property<int>("EntryType")
                        .HasColumnType("int");

                    b.Property<string>("FeedId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Summary")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("FeedId");

                    b.ToTable("Entries", (string)null);

                    b.HasDiscriminator<int>("EntryType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.abstractions.Feed", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("FeedType")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Fetched")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTimeOffset>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Feeds", (string)null);

                    b.HasDiscriminator<int>("FeedType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.abstractions.Phone", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AreaCode")
                        .HasColumnType("int");

                    b.Property<string>("ContactId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CountryCode")
                        .HasColumnType("int");

                    b.Property<int>("Discriminator")
                        .HasColumnType("int");

                    b.Property<int>("PhoneType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Phones", (string)null);

                    b.HasDiscriminator<int>("PhoneType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.abstractions.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BoothId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageSource")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BoothId");

                    b.ToTable("Products", (string)null);

                    b.HasDiscriminator<int>("ProductType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.abstractions.Role", b =>
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

                    b.ToTable("Roles", (string)null);

                    b.HasDiscriminator<int>("RoleType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.abstractions.Token", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<long>("Expiration")
                        .HasColumnType("bigint");

                    b.Property<string>("Hash")
                        .HasColumnType("longtext");

                    b.Property<int>("TokenType")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tokens", (string)null);

                    b.HasDiscriminator<int>("TokenType").IsComplete(true);
                });

            modelBuilder.Entity("balasolu.models.abstractions.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CartId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactId")
                        .HasColumnType("varchar(255)");

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

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ContactId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users", (string)null);

                    b.HasDiscriminator<int>("UserType").IsComplete(true);
                });

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

                    b.ToTable("RoleClaims", (string)null);
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

                    b.ToTable("UserClaims", (string)null);
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

                    b.ToTable("UserLogins", (string)null);
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

                    b.ToTable("UserRoles", (string)null);
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

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("balasolu.cartitems.AffiliateCartItem", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.CartItem");

                    b.HasDiscriminator().HasValue(5);
                });

            modelBuilder.Entity("balasolu.cartitems.DefaultCartItem", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.CartItem");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.cartitems.DigitalCartItem", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.CartItem");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("balasolu.cartitems.PhysicalCartItem", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.CartItem");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("balasolu.cartitems.ServiceCartItem", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.CartItem");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("balasolu.cartitems.SubscriptionCartItem", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.CartItem");

                    b.HasDiscriminator().HasValue(4);
                });

            modelBuilder.Entity("balasolu.models.addresses.BillingAddress", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Address");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("balasolu.models.addresses.DefaultAddress", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Address");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.addresses.ShippingAddress", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Address");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("balasolu.models.authors.DefaultAuthor", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Author");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.authors.TwitterAuthor", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Author");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("balasolu.models.booths.DefaultBooth", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Booth");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.carts.DefaultCart", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Cart");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.contacts.DefaultContact", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Contact");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.entries.DefaultEntry", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Entry");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.entries.TwitterEntry", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Entry");

                    b.Property<string>("AuthorId")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("balasolu.models.feeds.DefaultFeed", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Feed");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.feeds.TwitterFeed", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Feed");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("balasolu.models.phones.DefaultPhone", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Phone");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.products.AffiliateProduct", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Product");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue(5);
                });

            modelBuilder.Entity("balasolu.models.products.DefaultProduct", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Product");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.products.DigitalProduct", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Product");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("balasolu.models.products.PhysicalProduct", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Product");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("balasolu.models.products.ServiceProduct", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Product");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("balasolu.models.products.SubscriptionProduct", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Product");

                    b.HasDiscriminator().HasValue(4);
                });

            modelBuilder.Entity("balasolu.models.roles.DefaultRole", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Role");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.tokens.AuthenticationToken", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Token");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("balasolu.models.tokens.DefaultToken", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Token");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.tokens.RefreshToken", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.Token");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("balasolu.models.users.DefaultUser", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.User");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("balasolu.models.users.VendorUser", b =>
                {
                    b.HasBaseType("balasolu.models.abstractions.User");

                    b.Property<string>("BoothId")
                        .HasColumnType("varchar(255)");

                    b.HasIndex("BoothId");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("balasolu.models.abstractions.Address", b =>
                {
                    b.HasOne("balasolu.models.abstractions.Contact", null)
                        .WithMany("Addresses")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("balasolu.models.abstractions.CartItem", b =>
                {
                    b.HasOne("balasolu.models.abstractions.Cart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("CartId");

                    b.HasOne("balasolu.models.abstractions.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("balasolu.models.abstractions.Entry", b =>
                {
                    b.HasOne("balasolu.models.abstractions.Feed", null)
                        .WithMany("Entries")
                        .HasForeignKey("FeedId");
                });

            modelBuilder.Entity("balasolu.models.abstractions.Phone", b =>
                {
                    b.HasOne("balasolu.models.abstractions.Contact", null)
                        .WithMany("Phones")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("balasolu.models.abstractions.Product", b =>
                {
                    b.HasOne("balasolu.models.abstractions.Booth", null)
                        .WithMany("Products")
                        .HasForeignKey("BoothId");
                });

            modelBuilder.Entity("balasolu.models.abstractions.Token", b =>
                {
                    b.HasOne("balasolu.models.abstractions.User", null)
                        .WithMany("Tokens")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("balasolu.models.abstractions.User", b =>
                {
                    b.HasOne("balasolu.models.abstractions.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");

                    b.HasOne("balasolu.models.abstractions.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.Navigation("Cart");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("balasolu.models.abstractions.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("balasolu.models.abstractions.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("balasolu.models.abstractions.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("balasolu.models.abstractions.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("balasolu.models.abstractions.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("balasolu.models.abstractions.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("balasolu.models.users.VendorUser", b =>
                {
                    b.HasOne("balasolu.models.abstractions.Booth", "Booth")
                        .WithMany()
                        .HasForeignKey("BoothId");

                    b.Navigation("Booth");
                });

            modelBuilder.Entity("balasolu.models.abstractions.Booth", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("balasolu.models.abstractions.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("balasolu.models.abstractions.Contact", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Phones");
                });

            modelBuilder.Entity("balasolu.models.abstractions.Feed", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("balasolu.models.abstractions.User", b =>
                {
                    b.Navigation("Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
