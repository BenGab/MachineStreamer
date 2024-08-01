using MachinStreamer.DAL.Models;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MachinStreamer.DAL.Repositories
{
    public interface IMachineDataRepository
    {
        Task InsertAsync(MachineData machineData);

        ICollection<MachineData> GetAll(Expression<Func<MachineData, bool>> filter);
    }
}
