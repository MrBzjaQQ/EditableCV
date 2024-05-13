namespace EditableCV.Services.CommonInfoDto
{
    public sealed record CommonInfoReadDto
    {
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public string PatronymicName { get; init; } = string.Empty;
        public int Age { get; init; }
        public string? PhotoUrl { get; init; }
    }
}

