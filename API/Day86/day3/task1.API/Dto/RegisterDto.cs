namespace task1.API.Dto;

public record RegisterDto (string Name, string Email, string Pass, string Phone, string Position, string? Secret = null);
