using MachinStreamer.DAL.Models;
using MachinStreamer.DAL.Repositories;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MachineStreamer.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineDataRepository machineDataRepository;

        public MachineService(IMachineDataRepository machineDataRepository)
        {
            this.machineDataRepository = machineDataRepository;
        }
        public ICollection<MachineData> GetAll(Expression<Func<MachineData, bool>> filter)
        {
            return machineDataRepository.GetAll(filter);
        }

        public Task InsertAsync(MachineData data)
        {
            return machineDataRepository.InsertAsync(data);
        }
    }
}
