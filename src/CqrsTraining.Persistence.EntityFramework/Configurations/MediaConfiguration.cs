using CqrsTraining.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CqrsTraining.Persistence.EntityFramework.Configurations
{
    internal class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.ToTable("Media");

            builder.HasKey(e => e.MediaId);

            builder.HasOne(e => e.User)
                .WithMany();
        }
    }
}
