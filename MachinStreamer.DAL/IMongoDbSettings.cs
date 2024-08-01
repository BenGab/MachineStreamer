namespace MachinStreamer.DAL
{
    public interface IMongoDbSettings
    {
        public string ConnectionString { get; set; } 
        public string DataBasename { get; set; }
    }
}
