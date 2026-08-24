namespace Shared.Models.Auth
{
    public class RegisterResponseDto
    {
        public bool Success { get; set; }
        public RegisterError Error { get; set; } = RegisterError.None;
    }
}
