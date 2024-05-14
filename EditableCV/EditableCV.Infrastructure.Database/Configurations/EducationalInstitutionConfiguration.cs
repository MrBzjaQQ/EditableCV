using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EditableCV.Infrastructure.Database.Configurations;
internal sealed class EducationalInstitutionConfiguration : IEntityTypeConfiguration<EducationalInstitution>
{
    public void Configure(EntityTypeBuilder<EducationalInstitution> builder)
    {
        builder.HasKey(x => x.Id);
    }
}
