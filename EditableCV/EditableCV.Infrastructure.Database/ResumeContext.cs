using EditableCV.Dal;
using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EditableCV_backend.Data
{
    internal class ResumeContext : DbContext, IResumeContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options) {}

        public DbSet<WorkPlace> WorkPlaces { get; init; }
        public DbSet<StoredFile> Files { get; init; }
        public DbSet<CommonInfo> CommonInfos { get; init; }
        public DbSet<EducationalInstitution> EducationalInstitutions { get; init; }
        public DbSet<Skill> Skills { get; init; }
        public DbSet<ContactInfo> ContactInfos { get; init; }
        public DbSet<Project> Projects { get; init; }
    }
}
