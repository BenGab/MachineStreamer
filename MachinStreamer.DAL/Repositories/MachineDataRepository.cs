using MachinStreamer.DAL.Models;
using MongoDB.Driver;

namespace MachinStreamer.DAL.Repositories
{
    public class MachineDataRepository : IMachineDataRepository
    {
        private readonly IMongoCollection<MachineData> _collection;

        public MachineDataRepository(MongoDbContext conext)
        {
            _collection = conext.MachineCollection;       
        }

        public async Task<ICollection<MachineData>> GetAllAsync(FilterDefinition<MachineData> filter)
        {
            var result = await  _collection.FindAsync(filter);
            return await result.ToListAsync();
        }

        public Task InsertAsync(MachineData machineData)
        {
            return _collection.InsertOneAsync(machineData);
        }
    }
}
