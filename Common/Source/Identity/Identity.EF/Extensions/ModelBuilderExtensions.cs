using Common.Identity.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace Common.Identity.EF.Extensions;

public static class ModelBuilderExtensions
{
    public static ModelBuilder AddIdentity(this ModelBuilder modelBuilder)
    {
        return modelBuilder
            .AddRefreshTokens();
    }

    private static ModelBuilder AddRefreshTokens(this ModelBuilder modelBuilder)
    {
        var entityTypeBuilder = modelBuilder.Entity<RefreshToken>().ToTable("RefreshTokens".ToLowerInvariant());

        entityTypeBuilder.HasKey(e => e.Id);

        entityTypeBuilder
            .HasIndex(e => e.HashedToken)
            .IsUnique();

        entityTypeBuilder
            .Property(e => e.Id)!
            .ConfigureAggregateId();

        entityTypeBuilder
            .Property(e => e.HashedToken)
            .HasMaxLength(1_000);

        entityTypeBuilder
            .Property(e => e.UserId)!
            .ConfigureAggregateId();

        return modelBuilder;
    }
}