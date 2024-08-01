using MachinStreamer.DAL.Models;
using MachinStreamer.DAL.Repositories;
using MongoDB.Driver;

namespace MachineStreamer.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineDataRepository machineDataRepository;

        public MachineService(IMachineDataRepository machineDataRepository)
        {
            this.machineDataRepository = machineDataRepository;
        }
        public Task<ICollection<MachineData>> GetAllAsync(FilterDefinition<MachineData> filter)
        {
            return machineDataRepository.GetAllAsync(filter);
        }

        public Task InsertAsync(MachineData data)
        {
            return machineDataRepository.InsertAsync(data);
        }
    }
}
