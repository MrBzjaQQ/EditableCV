using System.ComponentModel.DataAnnotations;

namespace EditableCV.Services.WorkPlaceDto
{
    public class WorkPlaceCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string CompanyName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Position { get; set; }
        public string Experience { get; set; }
        [Required]
        public DateTime StartWorkingDate { get; set; }
        [Required]
        public DateTime EndWorkingDate { get; set; }
    }
}
