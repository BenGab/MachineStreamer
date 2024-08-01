using MachinStreamer.DAL.Models;
using MongoDB.Driver;

namespace MachinStreamer.DAL
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _dataBase;

        public MongoDbContext(IMongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            _dataBase = client.GetDatabase(mongoDbSettings.DataBasename);
        }

        public IMongoCollection<MachineData> MachineCollection => _dataBase.GetCollection<MachineData>("MachineData");
    }
}