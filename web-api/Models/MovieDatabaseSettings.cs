namespace WebAPI.Models
{
    public class MovieDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string MovieCollectionName { get; set; }
    }
}