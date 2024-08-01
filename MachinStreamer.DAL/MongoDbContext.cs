using MachinStreamer.DAL.Models;
using MongoDB.Driver;
using System.Text;

namespace MachinStreamer.DAL
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _dataBase;

        public MongoDbContext(IMongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(Encoding.UTF8.GetString(Convert.FromBase64String(mongoDbSettings.ConnectionString)));
            _dataBase = client.GetDatabase(mongoDbSettings.DataBasename);
        }

        public IMongoCollection<MachineData> MachineCollection => _dataBase.GetCollection<MachineData>("MachineData");
    }
}