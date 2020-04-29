namespace ChistesAPIRest.Models
{
    public class ChistesDatabaseSettings : IChistesDatabaseSettings
    {
        public string ChistesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IChistesDatabaseSettings
    {
        string ChistesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}