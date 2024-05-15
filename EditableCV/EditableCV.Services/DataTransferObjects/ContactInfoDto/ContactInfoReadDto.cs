﻿namespace EditableCV.Services.ContactInfoDto;

public sealed record ContactInfoReadDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Value { get; init; } = string.Empty;
}
