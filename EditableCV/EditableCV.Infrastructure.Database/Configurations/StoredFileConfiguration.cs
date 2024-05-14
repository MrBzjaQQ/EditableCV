using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EditableCV.Infrastructure.Database.Configurations;
internal sealed class StoredFileConfiguration : IEntityTypeConfiguration<StoredFile>
{
    public void Configure(EntityTypeBuilder<StoredFile> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.FileName).IsUnique();
    }
}
