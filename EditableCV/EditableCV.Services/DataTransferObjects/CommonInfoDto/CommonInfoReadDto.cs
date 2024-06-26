﻿namespace EditableCV.Services.CommonInfoDto;

public sealed record CommonInfoReadDto
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string? PatronymicName { get; init; }
    public int Age { get; init; }
    public string? PhotoUrl { get; init; }
    public decimal Salary { get; init; }
}

