using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EditableCV.Infrastructure.Database.Configurations;
internal sealed class WorkPlaceConfiguration : IEntityTypeConfiguration<WorkPlace>
{
    public void Configure(EntityTypeBuilder<WorkPlace> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CompanyName).HasMaxLength(250);
        builder.Property(x => x.Position).HasMaxLength(250);
    }
}
