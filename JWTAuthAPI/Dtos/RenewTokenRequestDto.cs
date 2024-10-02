namespace JWTAuthAPI.Dtos
{
    public class RenewTokenRequestDto
    {
        public int UserId {get; set;}
        public string RefreshToken {get; set;}
    }
}