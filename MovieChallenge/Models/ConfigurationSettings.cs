namespace MovieChallenge.Models
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string JwtKey { get; set; } = null!;
    }
}
