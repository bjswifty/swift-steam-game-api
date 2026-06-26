using Microsoft.EntityFrameworkCore;
using SwiftSteamGameApi.Models;
using SwiftSteamGameApi.Models.Related;

namespace SwiftSteamGameApi.Data;

public class GameLibraryDbContext : DbContext
{
    public GameLibraryDbContext(DbContextOptions<GameLibraryDbContext> options)
        : base(options)
    {
    }

    public DbSet<GameRecord> GameRecords => Set<GameRecord>();

    public DbSet<GameDetails> GameDetails => Set<GameDetails>();

    public DbSet<PersonalTracking> PersonalTrackings => Set<PersonalTracking>();

    public DbSet<GameReview> GameReviews => Set<GameReview>();

    public DbSet<GameGenre> GameGenres => Set<GameGenre>();

    public DbSet<GameTag> GameTags => Set<GameTag>();

    public DbSet<GameScreenshot> GameScreenshots => Set<GameScreenshot>();

    public DbSet<GameAchievement> GameAchievements => Set<GameAchievement>();

    public DbSet<GameCategory> GameCategories => Set<GameCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureGameRecord(modelBuilder);
        ConfigureGameDetails(modelBuilder);
        ConfigurePersonalTracking(modelBuilder);
        ConfigureGameReview(modelBuilder);
        ConfigureLookupCollections(modelBuilder);
        ConfigureRelatedEntities(modelBuilder);
    }

    private static void ConfigureGameRecord(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameRecord>(entity =>
        {
            entity.HasKey(gameRecord => gameRecord.Id);

            entity.Property(gameRecord => gameRecord.Status)
                .HasConversion<string>()
                .HasMaxLength(50);

            entity.Property(gameRecord => gameRecord.Priority)
                .HasConversion<string>()
                .HasMaxLength(50);

            entity.HasOne(gameRecord => gameRecord.Details)
                .WithOne(details => details.GameRecord)
                .HasForeignKey<GameDetails>(details => details.GameRecordId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(gameRecord => gameRecord.Tracking)
                .WithOne(tracking => tracking.GameRecord)
                .HasForeignKey<PersonalTracking>(tracking => tracking.GameRecordId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(gameRecord => gameRecord.Review)
                .WithOne(review => review.GameRecord)
                .HasForeignKey<GameReview>(review => review.GameRecordId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void ConfigureGameDetails(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameDetails>(entity =>
        {
            entity.HasKey(details => details.Id);

            entity.HasIndex(details => details.GameRecordId)
                .IsUnique();

            entity.Property(details => details.Platform)
                .HasConversion<string>()
                .HasMaxLength(50);

            entity.HasMany(details => details.Genres)
                .WithOne(genre => genre.GameDetails)
                .HasForeignKey(genre => genre.GameDetailsId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void ConfigurePersonalTracking(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonalTracking>(entity =>
        {
            entity.HasKey(tracking => tracking.Id);

            entity.HasIndex(tracking => tracking.GameRecordId)
                .IsUnique();

            entity.Property(tracking => tracking.HoursPlayed)
                .HasPrecision(8, 2);
        });
    }

    private static void ConfigureGameReview(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameReview>(entity =>
        {
            entity.HasKey(review => review.Id);

            entity.HasIndex(review => review.GameRecordId)
                .IsUnique();

            entity.Property(review => review.PersonalRating)
                .HasPrecision(3, 1);
        });
    }

    private static void ConfigureLookupCollections(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameGenre>(entity =>
        {
            entity.HasKey(genre => genre.Id);

            entity.HasOne(genre => genre.GameRecord)
                .WithMany()
                .HasForeignKey(genre => genre.GameRecordId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<GameTag>(entity =>
        {
            entity.HasKey(tag => tag.Id);

            entity.HasOne(tag => tag.GameRecord)
                .WithMany(gameRecord => gameRecord.Tags)
                .HasForeignKey(tag => tag.GameRecordId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void ConfigureRelatedEntities(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameScreenshot>(entity =>
        {
            entity.HasKey(screenshot => screenshot.Id);

            entity.HasOne(screenshot => screenshot.GameRecord)
                .WithMany(gameRecord => gameRecord.Screenshots)
                .HasForeignKey(screenshot => screenshot.GameRecordId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<GameAchievement>(entity =>
        {
            entity.HasKey(achievement => achievement.Id);

            entity.HasOne(achievement => achievement.GameRecord)
                .WithMany(gameRecord => gameRecord.Achievements)
                .HasForeignKey(achievement => achievement.GameRecordId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<GameCategory>(entity =>
        {
            entity.HasKey(category => category.Id);

            entity.HasOne(category => category.GameRecord)
                .WithMany(gameRecord => gameRecord.Categories)
                .HasForeignKey(category => category.GameRecordId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
