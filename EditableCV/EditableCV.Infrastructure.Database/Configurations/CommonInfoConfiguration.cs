using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EditableCV.Infrastructure.Database.Configurations;
internal sealed class CommonInfoConfiguration : IEntityTypeConfiguration<CommonInfo>
{
    public void Configure(EntityTypeBuilder<CommonInfo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Photo).WithMany();
    }
}
