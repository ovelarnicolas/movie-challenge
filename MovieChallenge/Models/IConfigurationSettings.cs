namespace MovieChallenge.Models
{
    public interface IConfigurationSettings
    {
        public string ConnectionURI { get; set; }
        public string DatabaseName { get; set; }
        public string JwtKey { get; set; }
    }
}
