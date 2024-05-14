using EditableCV.Dal;
using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EditableCV_backend.Data
{
    internal class ResumeContext : DbContext, IResumeContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options) {}

        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<StoredFile> Files { get; set; }
        public DbSet<CommonInfo> CommonInfos { get; set; }
        public DbSet<EducationalInstitution> EducationalInstitutions { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
    }
}
