﻿namespace EditableCV.Domain.Models
{
    public record LandingDataModel
    {
        public CommonInfo? CommonInfo { get; init; } = new();
        public ContactInfo? ContactInfo { get; init; } = new();
        public IList<WorkPlace> WorkPlaces { get; init; } = Array.Empty<WorkPlace>();
        public IList<EducationalInstitution> Education { get; init; } = Array.Empty<EducationalInstitution>();
        public IList<Skill> Skills { get; init; } = Array.Empty<Skill>();
    }
}