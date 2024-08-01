namespace MachinStreamer.DAL
{
    public class MongoDBSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set ; }
        public string DataBasename { get ; set ; }
    }
}
