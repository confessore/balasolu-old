using balasolu.cartitems;
using balasolu.models.abstractions;
using balasolu.models.addresses;
using balasolu.models.authors;
using balasolu.models.booths;
using balasolu.models.carts;
using balasolu.models.contacts;
using balasolu.models.entries;
using balasolu.models.enums;
using balasolu.models.feeds;
using balasolu.models.phones;
using balasolu.models.products;
using balasolu.models.roles;
using balasolu.models.tokens;
using balasolu.models.users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace balasolu.contexts
{
    public class DefaultDbContext : IdentityDbContext<User, Role, string>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
            : base(options) { }

        new public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Token>? Tokens { get; set; }
        public virtual DbSet<Contact>? Contacts { get; set; }
        public virtual DbSet<Address>? Addresses { get; set; }
        public virtual DbSet<Phone>? Phones { get; set; }
        public virtual DbSet<Booth>? Booths { get; set; }
        public virtual DbSet<Product>? Products { get; set; }
        public virtual DbSet<Cart>? Carts { get; set; }
        public virtual DbSet<CartItem>? CartItems { get; set; }
        public virtual DbSet<Author>? Authors { get; set; }
        public virtual DbSet<Entry>? Entries { get; set; }
        public virtual DbSet<Feed>? Feeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var keysProperties = modelBuilder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x!.Properties);

            foreach (var property in keysProperties)
                property.ValueGenerated = ValueGenerated.OnAdd;


            modelBuilder.Entity<IdentityRoleClaim<string>>()
                .ToTable("RoleClaims");

            modelBuilder.Entity<Role>()
                .ToTable("Roles")
                .HasDiscriminator<RoleType>(nameof(RoleType))
                .HasValue<DefaultRole>(RoleType.Default)
                .IsComplete();

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaims");

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogins");

            modelBuilder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles");

            modelBuilder.Entity<IdentityUserToken<string>>()
                .ToTable("UserTokens");

            modelBuilder.Entity<Token>()
                .ToTable("Tokens")
                .HasDiscriminator<TokenType>(nameof(TokenType))
                .HasValue<DefaultToken>(TokenType.Default)
                .HasValue<AuthenticationToken>(TokenType.Authentication)
                .HasValue<RefreshToken>(TokenType.Refresh)
                .IsComplete();

            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasDiscriminator<UserType>(nameof(UserType))
                .HasValue<DefaultUser>(UserType.Default)
                .HasValue<VendorUser>(UserType.Vendor)
                .IsComplete();

            modelBuilder.Entity<Address>()
                .ToTable("Addresses")
                .HasDiscriminator<AddressType>(nameof(AddressType))
                .HasValue<DefaultAddress>(AddressType.Default)
                .HasValue<BillingAddress>(AddressType.Billing)
                .HasValue<ShippingAddress>(AddressType.Shipping)
                .IsComplete();

            modelBuilder.Entity<Contact>()
                .ToTable("Contacts")
                .HasDiscriminator<ContactType>(nameof(ContactType))
                .HasValue<DefaultContact>(ContactType.Default)
                .IsComplete();

            modelBuilder.Entity<Phone>()
                .ToTable("Phones")
                .HasDiscriminator<PhoneType>(nameof(PhoneType))
                .HasValue<DefaultPhone>(PhoneType.Default)
                .IsComplete();

            modelBuilder.Entity<Booth>()
                .ToTable("Booths")
                .HasDiscriminator<BoothType>(nameof(BoothType))
                .HasValue<DefaultBooth>(BoothType.Default)
                .IsComplete();

            modelBuilder.Entity<Product>()
                .ToTable("Products")
                .HasDiscriminator<ProductType>(nameof(ProductType))
                .HasValue<DefaultProduct>(ProductType.Default)
                .HasValue<DigitalProduct>(ProductType.Digital)
                .HasValue<PhysicalProduct>(ProductType.Physical)
                .HasValue<ServiceProduct>(ProductType.Service)
                .HasValue<SubscriptionProduct>(ProductType.Subscription)
                .HasValue<AffiliateProduct>(ProductType.Affiliate)
                .IsComplete();

            modelBuilder.Entity<Cart>()
                .ToTable("Carts")
                .HasDiscriminator<CartType>(nameof(CartType))
                .HasValue<DefaultCart>(CartType.Default)
                .IsComplete();

            modelBuilder.Entity<CartItem>()
                .ToTable("CartItems")
                .HasDiscriminator<CartItemType>(nameof(CartItemType))
                .HasValue<DefaultCartItem>(CartItemType.Default)
                .HasValue<DigitalCartItem>(CartItemType.Digital)
                .HasValue<PhysicalCartItem>(CartItemType.Physical)
                .HasValue<ServiceCartItem>(CartItemType.Service)
                .HasValue<SubscriptionCartItem>(CartItemType.Subscription)
                .HasValue<AffiliateCartItem>(CartItemType.Affiliate)
                .IsComplete();

            modelBuilder.Entity<Author>()
                .ToTable("Authors")
                .HasDiscriminator<AuthorType>(nameof(AuthorType))
                .HasValue<DefaultAuthor>(AuthorType.Default)
                .HasValue<TwitterAuthor>(AuthorType.Twitter)
                .IsComplete();

            modelBuilder.Entity<Entry>()
                .ToTable("Entries")
                .HasDiscriminator<EntryType>(nameof(EntryType))
                .HasValue<DefaultEntry>(EntryType.Default)
                .HasValue<TwitterEntry>(EntryType.Twitter)
                .IsComplete();

            modelBuilder.Entity<Feed>()
                .ToTable("Feeds")
                .HasDiscriminator<FeedType>(nameof(FeedType))
                .HasValue<DefaultFeed>(FeedType.Default)
                .HasValue<TwitterFeed>(FeedType.Twitter)
                .IsComplete();
        }
    }
}
