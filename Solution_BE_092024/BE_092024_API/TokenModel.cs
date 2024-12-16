namespace BE_092024_API
{
    public class TokenModel
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }

    public class TokenLogOutModel
    {
        public string? AccessToken { get; set; }
        public string DeviceID {  get; set; }
    }
}
