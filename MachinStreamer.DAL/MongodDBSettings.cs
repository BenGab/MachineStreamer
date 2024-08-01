namespace MachinStreamer.DAL
{
    public class MongodDBSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set ; }
        public string DataBasename { get ; set ; }
    }
}
