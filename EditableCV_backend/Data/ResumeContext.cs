using EditableCV_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace EditableCV_backend.Data
{
    public class ResumeContext : DbContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options) {}

        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<CommonInfo> CommonInfos { get; set; }
        public DbSet<EducationalInstitution> EducationalInstitutions { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
    }
}
