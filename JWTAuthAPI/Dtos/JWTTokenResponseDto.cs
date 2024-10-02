namespace JWTAuthAPI.Dtos
{
    public class JWTTokenResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}