using MachinStreamer.DAL.Models;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MachineStreamer.Services
{
    public interface IMachineService
    {
        ICollection<MachineData> GetAll(Expression<Func<MachineData, bool>> filter);

        Task InsertAsync(MachineData data);
    }
}
