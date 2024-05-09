﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EditableCV.Domain.Models
{
    public record EducationalInstitution
    {
        public EducationalInstitution() { }
        public EducationalInstitution(EducationalInstitution inst)
        {
            Id = inst.Id;
            Institution = inst.Institution;
            Faculty = inst.Faculty;
            StartDate = inst.StartDate;
            EndDate = inst.EndDate;
            Progress = inst.Progress;
        }
        [Key]
        public int Id { get; init; }
        [Required]
        public string Institution { get; init; }
        public string Faculty { get; init; }
        [Required]
        public DateTime StartDate { get; init; }
        [Required]
        public DateTime EndDate { get; init; }
        public string Progress { get; init; }
        [NotMapped]
        public bool IsValid
        {
            get
            {
                bool isValid = true;
                if (Institution == null || Institution == string.Empty)
                {
                    isValid = false;
                }
                if (DateTime.MinValue.CompareTo(StartDate) == 0)
                {
                    isValid = false;
                }
                if (DateTime.MinValue.CompareTo(EndDate) == 0)
                {
                    isValid = false;
                }
                if (EndDate.CompareTo(StartDate) < 0)
                {
                    isValid = false;
                }
                return isValid;
            }
        }
    }
}