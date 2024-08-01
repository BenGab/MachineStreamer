using MachinStreamer.DAL.Models;
using MongoDB.Driver;

namespace MachineStreamer.Services
{
    public interface IMachineService
    {
        Task<ICollection<MachineData>> GetAllAsync(FilterDefinition<MachineData> filter);

        Task InsertAsync(MachineData data);
    }
}
