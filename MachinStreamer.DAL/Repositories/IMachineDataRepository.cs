using MachinStreamer.DAL.Models;
using MongoDB.Driver;

namespace MachinStreamer.DAL.Repositories
{
    public interface IMachineDataRepository
    {
        Task InsertAsync(MachineData machineData);

        Task<ICollection<MachineData>> GetAllAsync(FilterDefinition<MachineData> filter);
    }
}
