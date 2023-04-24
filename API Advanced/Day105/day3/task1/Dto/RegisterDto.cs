namespace task1.Dto;

public record RegisterDto(string Name,string Email, string Pass , string Phone,string Position, string? Secret=null);
