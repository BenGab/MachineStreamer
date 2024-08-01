using MachinStreamer.DAL.Models;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MachinStreamer.DAL.Repositories
{
    public class MachineDataRepository : IMachineDataRepository
    {
        private readonly IMongoCollection<MachineData> _collection;

        public MachineDataRepository(MongoDbContext conext)
        {
            _collection = conext.MachineCollection;       
        }

        public  ICollection<MachineData> GetAll(Expression<Func<MachineData, bool>> filter)
        {
            var result = _collection.AsQueryable().Where(filter);
            return result.ToList();
        }

        public Task InsertAsync(MachineData machineData)
        {
            return _collection.InsertOneAsync(machineData);
        }
    }
}
