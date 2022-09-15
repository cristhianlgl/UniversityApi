namespace ApiOpenUniversity.Models
{
    public class JwtSettings
    {
        public bool ValidateIssuerSigninKey { get; set; }
        public string IssuerSigninKey { get; set; } = string.Empty;

        public bool ValidateIssuer { get; set; }
        public string? ValidIssuer { get; set; }

        public bool ValidateAudience { get; set; }
        public string? ValidAudience { get; set; }

        public bool RequerieExpirationTime { get; set; }
        public bool ValidateLifeTime { get; set; } = true;

    }
}
