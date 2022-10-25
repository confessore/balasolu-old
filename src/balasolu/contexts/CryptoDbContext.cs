using balasolu.models.abstractions;
using balasolu.models.enums;
using balasolu.models.observations;
using balasolu.models.progressions;
using balasolu.models.samples;
using balasolu.models.trends;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace balasolu.contexts
{
    public class CryptoDbContext : DbContext
    {
        public CryptoDbContext(DbContextOptions<CryptoDbContext> options)
            : base(options) { }

        public virtual DbSet<Trend>? Trends { get; set; }
        public virtual DbSet<Progression>? Progressions { get; set; }
        public virtual DbSet<Sample>? Samples { get; set; }
        public virtual DbSet<Observation>? Observations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var keysProperties = modelBuilder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x!.Properties);

            foreach (var property in keysProperties)
                property.ValueGenerated = ValueGenerated.OnAdd;

            modelBuilder.Entity<Trend>()
                .ToTable("Trends")
                .HasDiscriminator<TrendType>(nameof(TrendType))
                .HasValue<DefaultTrend>(TrendType.Default)
                .IsComplete();

            modelBuilder.Entity<Progression>()
                .ToTable("Progressions")
                .HasDiscriminator<ProgressionType>(nameof(ProgressionType))
                .HasValue<DefaultProgression>(ProgressionType.Default)
                .IsComplete();

            modelBuilder.Entity<Sample>()
                .ToTable("Samples")
                .HasDiscriminator<SampleType>(nameof(SampleType))
                .HasValue<DefaultSample>(SampleType.Default)
                .IsComplete();

            modelBuilder.Entity<Observation>()
                .ToTable("Observations")
                .HasDiscriminator<ObservationType>(nameof(ObservationType))
                .HasValue<DefaultObservation>(ObservationType.Default)
                .IsComplete();
        }
    }
}
