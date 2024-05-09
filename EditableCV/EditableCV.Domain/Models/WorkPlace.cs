using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EditableCV.Domain.Models
{
    public record WorkPlace
    {
        public WorkPlace() { }
        public WorkPlace(WorkPlace place)
        {
            Id = place.Id;
            CompanyName = place.CompanyName;
            Position = place.Position;
            Experience = place.Experience;
            StartWorkingDate = place.StartWorkingDate;
            EndWorkingDate = place.EndWorkingDate;
        }
        [Key]
        public int Id { get; init; }
        [Required]
        [MaxLength(250)]
        public string CompanyName { get; init; }
        [Required]
        [MaxLength(250)]
        public string Position { get; init; }
        public string Experience { get; init; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime StartWorkingDate { get; init; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime EndWorkingDate { get; init; }
        [NotMapped]
        public bool IsValid
        {
            get
            {
                bool isValid = true;
                if (CompanyName == null || CompanyName == string.Empty)
                {
                    isValid = false;
                }
                if (Position == null || Position == string.Empty)
                {
                    isValid = false;
                }
                if (DateTime.MinValue.CompareTo(StartWorkingDate) == 0)
                {
                    isValid = false;
                }
                if (DateTime.MinValue.CompareTo(EndWorkingDate) == 0)
                {
                    isValid = false;
                }
                if (EndWorkingDate.CompareTo(StartWorkingDate) < 0)
                {
                    isValid = false;
                }
                return isValid;
            }
        }
    }
}
