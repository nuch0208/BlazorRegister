namespace JWTAuthAPI.Data.Entities
{
    public class UserRefreshToken
    {
        public int Id {get; set;}
        public int UserId {get; set;}
        public string Token {get; set;}
        public DateTime ExpirationDate {get; set;}
    }
}