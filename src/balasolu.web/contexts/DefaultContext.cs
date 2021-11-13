using balasolu.models;
using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.web.models;
using balasolu.web.models.abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace balasolu.web.contexts
{
    class DefaultContext : IdentityDbContext<User, Role, string>
    {
        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options) { }

        public virtual DbSet<Account>? Accounts { get; set; }
        public virtual DbSet<Item>? Items { get; set; }
        public virtual DbSet<Post>? Posts { get; set; }
        public virtual DbSet<Item>? BaseItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var keysProperties = modelBuilder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x.Properties);
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

            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasDiscriminator<UserType>(nameof(UserType))
                .HasValue<DefaultUser>(UserType.Default)
                .IsComplete();

            modelBuilder.Entity<Account>()
                .ToTable("Accounts")
                .HasDiscriminator<AccountType>(nameof(AccountType))
                .HasValue<DefaultAccount>(AccountType.Default)
                .HasValue<DiscordAccount>(AccountType.Discord)
                .IsComplete();

            modelBuilder.Entity<Item>()
                .ToTable("Items")
                .HasDiscriminator<ItemType>(nameof(ItemType))
                .HasValue<DefaultItem>(ItemType.Default)
                .HasValue<ArmorItem>(ItemType.Armor)
                .HasValue<WeaponItem>(ItemType.Weapon)
                .HasValue<OtherItem>(ItemType.Other)
                .IsComplete();

            modelBuilder.Entity<Post>()
                .ToTable("Posts")
                .HasDiscriminator<PostType>(nameof(PostType))
                .HasValue<DefaultPost>(PostType.Default)
                .IsComplete();
        }
    }
}
