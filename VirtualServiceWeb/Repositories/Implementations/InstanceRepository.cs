using VirtualServiceWeb.Data;
using VirtualServiceWeb.Data.Models;
using VirtualServiceWeb.Repositories.Interfaces;

namespace VirtualServiceWeb.Repositories.Implementations;

public class InstanceRepository : BaseRepository<InstanceModel>, IInstanceRepository
{
    public InstanceRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}