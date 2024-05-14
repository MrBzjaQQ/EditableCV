using EditableCV.Domain.Models;
using EditableCV.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EditableCV.Dal;
public interface IResumeContext: IDbContext
{
    DbSet<WorkPlace> WorkPlaces { get; }
    DbSet<Domain.Models.StoredFile> Files { get; }
    DbSet<CommonInfo> CommonInfos { get; }
    DbSet<EducationalInstitution> EducationalInstitutions { get; }
    DbSet<Skill> Skills { get; }
    DbSet<ContactInfo> ContactInfos { get; }
}
