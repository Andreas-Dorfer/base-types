using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApp.UserAggregate;

namespace TestApp.Data.Infrastructure;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName)
            .HasMaxLength(FirstName.MaxLength)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(LastName.MaxLength)
            .IsRequired();

        builder.Property(x => x.BirthDate);
    }
}